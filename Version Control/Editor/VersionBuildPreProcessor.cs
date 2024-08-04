using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UnityTools.VersionControl.Editor {
    [InitializeOnLoad]
    public class VersionBuildPreProcessor : IPreprocessBuildWithReport {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report) {
            var versionSO = CurrentVersionSO.Instance;
            var version = versionSO.version.ToBasicVersion();
            PlayerSettings.bundleVersion = version;

            var bundleVersionCode = (versionSO.version.major * 100000) + (versionSO.version.minor * 1000) + versionSO.version.build;
            PlayerSettings.Android.bundleVersionCode = bundleVersionCode;
            PlayerSettings.macOS.buildNumber = $"{bundleVersionCode.ToString()}00";

            UpdateCurrentVersion(versionSO);
            EditorUtility.SetDirty(versionSO);
            AssetDatabase.SaveAssets();
        }

        public void UpdateCurrentVersion(CurrentVersionSO currentVersion) {
            if (currentVersion == null)
                return;

            if (VersionControl.GitDirectory != null) {
                currentVersion.version.gitBranch = VersionControl.GetGitBranch();
                currentVersion.version.gitCommitSHA = VersionControl.GetGitSHA();
            }

            currentVersion.version.buildTarget = EditorUserBuildSettings.activeBuildTarget.ToString();
            currentVersion.version.isDevelopment = Debug.isDebugBuild;
            currentVersion.version.buildDateTime = System.DateTime.Now.ToString("u");
        }
    }
}

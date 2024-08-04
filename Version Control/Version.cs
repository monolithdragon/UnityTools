using System;

namespace UnityTools.VersionControl {
    [Serializable]
    public struct Version {
        public int major;
        public int minor;
        public int build;

        public string buildType;
        public string platform;
        public string buildTarget;

        public bool isDevelopment;

        public string gitBranch;
        public string gitCommitSHA;
        public string buildDateTime;
        public string inkCompileDateTime;

        public string ToBasicVersion() => string.Format("{0}.{1}.{2}", major, minor, build);
        public override string ToString() => string.Format("Version {0}.{1}.{2}{3} {4} {5}", major, minor, build, string.IsNullOrWhiteSpace(buildType) ? "" : $" ({buildType})", gitBranch, gitCommitSHA);
    }
}

using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityTools.ImportAssetUtility {
    public class ImportAssetEditor : Editor {
        [MenuItem("UnityTools/Import Essentials Asset")]
        public static void Execute() {
            ImportEssentials(new Asset("DOTween HOTween v2.unitypackage", "Demigiant/Editor ExtensionsAnimation"));
        }

        private static void ImportEssentials(Asset asset) {
            Debug.Log("Importing: <b>" + asset.Name + "</b>");
            AssetDatabase.ImportPackage(Path.Combine(asset.StorePath, asset.SubFolder, asset.Name), false);
        }
    }
}

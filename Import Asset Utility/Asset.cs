using System;

namespace UnityTools.ImportAssetUtility {
    public class Asset {
        /// <summary>
        /// Name of asset;
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Asset folder.
        /// </summary>
        public string SubFolder { get; }

        /// <summary>
        /// Asset store folder.
        /// </summary>
        public string StorePath { get; }

        /// <summary>
        /// Initialize a new <see cref="Asset"/> instance.
        /// </summary>
        /// <param name="name">Name of asset</param>
        /// <param name="subFolder">The asset folder</param>
        public Asset(string assetName, string subFolder) {
            Name = assetName;
            SubFolder = subFolder;
            StorePath =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/Unity/Asset Store-5.x";
        }
    }
}

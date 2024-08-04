using System.Collections.Generic;
using System.IO;

namespace UnityTools.FolderUtility {
    public class Folder {
        /// <summary>
        /// List all folders.
        /// </summary>
        public readonly List<Folder> Folders;

        /// <summary>
        /// Name of folder;
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Current folder name with parent path.
        /// </summary>
        public string CurrentFolder { get; }

        /// <summary>
        /// Parent folder with path.
        /// </summary>
        public string ParentFolder { get; }

        /// <summary>
        /// Initialize a new <see cref="Folder"/> instance.
        /// </summary>
        /// <param name="name">Name of folder</param>
        /// <param name="parentFolder">The parent folder</param>
        public Folder(string name, string parentFolder) {
            Name = name;
            ParentFolder = parentFolder;
            CurrentFolder = parentFolder != string.Empty ? ParentFolder + Path.DirectorySeparatorChar + Name : Name;
            Folders = new List<Folder>();
        }

        /// <summary>
        /// Add new folder.
        /// </summary>
        /// <param name="name">Name of folder</param>
        /// <returns>The new folder.</returns>
        public Folder Add(string name) {
            var folder = ParentFolder.Length > 0 ? new Folder(name, ParentFolder + Path.DirectorySeparatorChar + Name)
                : new Folder(name, Name);
            Folders.Add(folder);
            return folder;
        }
    }
}

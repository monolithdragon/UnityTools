using UnityEngine;

namespace UnityTools.VersionControl {
    public class CurrentVersionSO : ScriptableObject {
        public Version version;

        private static CurrentVersionSO instance;

        public static CurrentVersionSO Instance {
            get {
                if (instance == null)
                    instance = Resources.Load<CurrentVersionSO>(typeof(CurrentVersionSO).Name);
                if (instance == null) {
                    Debug.LogWarning($"No instance of {typeof(CurrentVersionSO).Name} found, using default values");
                    instance = CreateInstance<CurrentVersionSO>();
                }

                return instance;
            }
        }

        protected virtual void OnEnable() {
            if (instance == null) {
                instance = this;
            }
        }

        protected virtual void OnDisable() {
            if (instance == this) {
                instance = null;
            }
        }
    }
}

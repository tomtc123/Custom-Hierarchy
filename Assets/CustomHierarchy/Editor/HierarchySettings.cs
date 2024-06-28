using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CustomHierarchy.Editor
{
    public class HierarchySettings : ScriptableObject
    {
        private static string FilePath => $"Assets/CustomHierarchy/{nameof(HierarchySettings)}.asset";
        public bool showChildCount;
        public List<HierarchyStyle> styles = new();

        private static HierarchySettings _instance;

        public static HierarchySettings Load()
        {
            if (_instance != null)
                return _instance;
            _instance = AssetDatabase.LoadAssetAtPath<HierarchySettings>(FilePath);
            if (_instance == null)
            {
                _instance = CreateInstance<HierarchySettings>();
                AssetDatabase.CreateAsset(_instance, FilePath);
                EditorUtility.SetDirty(_instance);
                AssetDatabase.SaveAssets();
            }
            return _instance;
        }
    }
}
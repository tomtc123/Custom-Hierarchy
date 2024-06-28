using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CustomHierarchy.Editor
{
    [CreateAssetMenu(fileName = "HierarchySettings", menuName = "HierarchySettings")]
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
            _instance ??= CreateInstance<HierarchySettings>();
            return _instance;
        }
    }
}
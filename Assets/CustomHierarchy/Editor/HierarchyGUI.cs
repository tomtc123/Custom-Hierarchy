using UnityEditor;
using UnityEngine;

namespace CustomHierarchy.Editor
{
    [InitializeOnLoad]
    public abstract class HierarchyGUI
    {
        private static HierarchySettings _settings;

        static HierarchyGUI()
        {
            _settings = HierarchySettings.Load();
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            _settings = HierarchySettings.Load();
        }

        private static HierarchyStyle GetStyle(GameObject go)
        {
            if (go == null || _settings == null)
                return null;
            foreach (var style in _settings.styles)
            {
                if (!string.IsNullOrEmpty(style.nameContain) && go.name.Contains(style.nameContain))
                    return style;
            }

            return null;
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance == null)
                return;
            var go = instance as GameObject;
            if (go == null)
                return;

            DrawColorText(go, selectionRect);
            DrawChildCount(go, selectionRect);
        }

        private static void DrawColorText(GameObject go, Rect selectionRect)
        {
            var style = GetStyle(go);
            if (style != null)
            {
                var rect = new Rect(selectionRect.position.x + 18f, selectionRect.position.y,
                    selectionRect.size.x - 18f, selectionRect.size.y);
                EditorGUI.LabelField(rect, go.name, style.TextStyle);
            }
        }

        private static void DrawChildCount(GameObject go, Rect selectionRect)
        {
            if (_settings == null || !_settings.showChildCount || go.transform.childCount == 0)
                return;
            Rect rect = new Rect(selectionRect);
            rect.x += selectionRect.width;
            rect.x -= 20;
            rect.width = 60;
            GUI.Label(rect, $"{go.transform.childCount}");
        }
    }
}
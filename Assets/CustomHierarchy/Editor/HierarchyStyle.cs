using System;
using UnityEngine;

namespace CustomHierarchy.Editor
{
    [Serializable]
    public class HierarchyStyle
    {
        public string nameContain;
        public Color color = Color.white;

        private GUIStyle _textStyle;

        public GUIStyle TextStyle
        {
            get
            {
                if (_textStyle == null || _textStyle.normal.textColor != color)
                {
                    _textStyle = new GUIStyle
                    {
                        normal = new GUIStyleState { textColor = color },
                    };
                }

                return _textStyle;
            }
        }
    }
}
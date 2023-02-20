using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WebGLSupport
{
    public class WrappedEmptyInputField : IInputField
    {
        public ContentType contentType => throw new System.NotImplementedException();

        public LineType lineType => throw new System.NotImplementedException();

        public int fontSize => throw new System.NotImplementedException();

        public string text { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string placeholder => throw new System.NotImplementedException();

        public int characterLimit => throw new System.NotImplementedException();

        public int caretPosition => throw new System.NotImplementedException();

        public bool isFocused => throw new System.NotImplementedException();

        public int selectionFocusPosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int selectionAnchorPosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool ReadOnly => throw new System.NotImplementedException();

        public bool OnFocusSelectAll => throw new System.NotImplementedException();

        public void ActivateInputField()
        {
            throw new System.NotImplementedException();
        }

        public void DeactivateInputField()
        {
            throw new System.NotImplementedException();
        }

        public Rect GetScreenCoordinates()
        {
            throw new System.NotImplementedException();
        }

        public void Rebuild()
        {
            throw new System.NotImplementedException();
        }

        public RectTransform RectTransform()
        {
            throw new System.NotImplementedException();
        }
    }
}

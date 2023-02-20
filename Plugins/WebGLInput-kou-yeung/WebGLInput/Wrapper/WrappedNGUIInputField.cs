using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebGLSupport.Detail;

namespace WebGLSupport
{


    public class WrappedNGUIInputField : IInputField
    {
        private UIInput input;
        private RebuildChecker checker;

        public WrappedNGUIInputField(UIInput _input)
        {
            Debug.Log("NGUI webgl input");
            input = _input;
            checker = new RebuildChecker(this);

            if (input != null && input.GetComponent<RectTransform>() == null)
            {
                input.gameObject.AddComponent<RectTransform>();
            }
        }

        public ContentType contentType
        {
            get
            {
                int v = 0;
                if (input.inputType == UIInput.InputType.Standard) v = 0;
                else if (input.inputType == UIInput.InputType.AutoCorrect) v = 1;
                else if (input.inputType == UIInput.InputType.Password) v = 7;
                return (ContentType)v;
            }
        }

        public LineType lineType
        {
            get { return LineType.SingleLine; }
        }

        public int fontSize
        {
            get { return input.label.fontSize; }
        }

        public string text
        {
            get { return input.value; }
            set { input.value = value; }
        }

        public string placeholder
        {
            get
            {
                return "";
            }
        }

        public int characterLimit
        {
            get { return input.characterLimit; }
        }

        public int caretPosition
        {
            get { return 0; }
        }

        public bool isFocused
        {
            get { return input.isSelected; }
        }

        public int selectionFocusPosition
        {
            get { return 0; }
            set { }
        }
        public int selectionAnchorPosition
        {
            get { return 0; }
            set { }
        }

        public bool ReadOnly { get { return false; } }

        public bool OnFocusSelectAll
        {
            get { return true; }
        }

        public void ActivateInputField()
        {
            input.isSelected = true;
        }

        public void DeactivateInputField()
        {
            input.isSelected = false;
        }

        public void Rebuild()
        {
            if (checker.NeedRebuild())
            {
                input.UpdateLabel();
            }
        }

        public RectTransform RectTransform()
        {
            return input.GetComponent<RectTransform>();
        }

        public Rect GetScreenCoordinates()
        {
            var rect = new Rect();
            try
            {
                var pt = UICamera.currentCamera.WorldToScreenPoint(input.label.transform.position);
                var wd = input.label.GetComponent<UIWidget>();
                float width = wd.width;
                float height = wd.height;

                rect = new Rect(pt.x - width / 2f, pt.y - height / 2f, width, height);
            }
            catch (System.Exception)
            {

            }

            return rect;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using WebGLSupport.Detail;

namespace WebGLSupport
{
    /// <summary>
    /// Wrapper for UnityEngine.UI.InputField
    /// </summary>
    class WrappedInputField : IInputField
    {
        InputField input;
        RebuildChecker checker;

        public bool ReadOnly { get { return input.readOnly; } }

        public string text
        {
            get { return input.text; }
            set { input.text = value; }
        }

        public string placeholder
        {
            get
            {
                if (!input.placeholder) return "";
                var text = input.placeholder.GetComponent<Text>();
                return text ? text.text : "";
            }
        }

        public int fontSize
        {
            get { return input.textComponent.fontSize; }
        }

        public ContentType contentType
        {
            get { return (ContentType)input.contentType; }
        }

        public LineType lineType
        {
            get { return (LineType)input.lineType; }
        }

        public int characterLimit
        {
            get { return input.characterLimit; }
        }

        public int caretPosition
        {
            get { return input.caretPosition; }
        }

        public bool isFocused
        {
            get { return input.isFocused; }
        }

        public int selectionFocusPosition
        {
            get { return input.selectionFocusPosition; }
            set { input.selectionFocusPosition = value; }
        }

        public int selectionAnchorPosition
        {
            get { return input.selectionAnchorPosition; }
            set { input.selectionAnchorPosition = value; }
        }

        public bool OnFocusSelectAll
        {
            get { return true; }
        }

        public WrappedInputField(InputField input)
        {
            this.input = input;
            checker = new RebuildChecker(this);
        }

        public RectTransform RectTransform()
        {
            return input.GetComponent<RectTransform>();
        }

        public void ActivateInputField()
        {
            input.ActivateInputField();
        }

        public void DeactivateInputField()
        {
            input.DeactivateInputField();
        }

        public void Rebuild()
        {
            if (checker.NeedRebuild())
            {
                input.textComponent.SetAllDirty();
                input.Rebuild(CanvasUpdate.LatePreRender);
            }
        }

        public Rect GetScreenCoordinates()
        {
            var uiElement = RectTransform();
            var worldCorners = new Vector3[4];
            uiElement.GetWorldCorners(worldCorners);

            // try to support RenderMode:WorldSpace
            var canvas = uiElement.GetComponentInParent<Canvas>();
            var useCamera = (canvas.renderMode != RenderMode.ScreenSpaceOverlay);
            if (canvas && useCamera)
            {
                var camera = canvas.worldCamera;
                if (!camera) camera = Camera.main;

                for (var i = 0; i < worldCorners.Length; i++)
                {
                    worldCorners[i] = camera.WorldToScreenPoint(worldCorners[i]);
                }
            }

            var min = new Vector3(float.MaxValue, float.MaxValue);
            var max = new Vector3(float.MinValue, float.MinValue);
            for (var i = 0; i < worldCorners.Length; i++)
            {
                min.x = Mathf.Min(min.x, worldCorners[i].x);
                min.y = Mathf.Min(min.y, worldCorners[i].y);
                max.x = Mathf.Max(max.x, worldCorners[i].x);
                max.y = Mathf.Max(max.y, worldCorners[i].y);
            }

            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
    }
}
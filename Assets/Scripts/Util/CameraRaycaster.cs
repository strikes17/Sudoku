namespace SudokuGame.Camera
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class CameraRaycaster : MonoBehaviour
    {
        [SerializeField]
        protected Camera mainCamera = default;

        [SerializeField]
        protected EventSystem eventSystem = default;

        [SerializeField]
        protected GraphicRaycaster graphicRaycaster = default;

        protected PointerEventData pointerEventData = default;

        public virtual RaycastHit2D Raycast(Vector2 inputPosition, int layerMask)
        {
            pointerEventData = new PointerEventData(eventSystem);
            List<RaycastResult> uiResults = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, uiResults);
            if (uiResults.Count == 0)
            {
                Ray ray = mainCamera.ScreenPointToRay(inputPosition);
                return Physics2D.Raycast(ray.origin, ray.direction, 100f, layerMask, -100f, 100f);
            }
            return default;
        }
    }
}

namespace SudokuGame.Input
{
    using System;
    using UnityEngine;

    public class InputHandler : MonoBehaviour
    {
        public event Action onMouseDown = delegate { };

        public Vector2 InputPosition => Input.mousePosition;

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
            }
        }

        protected virtual void OnMouseDown() => onMouseDown();
    }

}

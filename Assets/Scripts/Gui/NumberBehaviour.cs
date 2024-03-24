namespace SudokuGame.Gameplay.Gui
{
    using System;
    using SudokuGame.DI;
    using SudokuGame.Util;
    using UnityEngine;

    public class NumberBehaviour : MonoBehaviour, IPoolable
    {
        [SerializeField]
        protected IntContainer intContainer = default;

        public IntContainer NumberContainer
        {
            get => intContainer;
            set
            {
                if (intContainer != value)
                {
                    intContainer = value;
                    OnNumberChanged(intContainer);
                }
            }
        }

        public bool IsActiveState => gameObject.activeSelf;

        public event Action onStateChanged = delegate { };

        public IPoolable NewInstance => Instantiate(this);

        public void SetActiveState() => gameObject.SetActive(true);

        public void SetDisableState() => gameObject.SetActive(false);

        public void Dispose() => SetDisableState();

        public event Action<IntContainer> onNumberChanged = delegate { };

        protected virtual void OnNumberChanged(IntContainer intContainer) => onNumberChanged(intContainer);
    }


}

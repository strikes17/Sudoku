namespace SudokuGame.Gameplay.Gui
{
    using SudokuGame.DI;
    using TMPro;
    using UnityEngine;

    public class NumberTextView : MonoBehaviour
    {
        [SerializeField]
        protected NumberBehaviour numberBehaviour = default;

        [SerializeField]
        protected TMP_Text numberText = default;

        protected virtual void OnEnable()
        {
            numberBehaviour.onNumberChanged += OnNumberChanged;
            OnNumberChanged(numberBehaviour.NumberContainer);
        }

        protected virtual void OnDisable()
        {
            numberBehaviour.onNumberChanged -= OnNumberChanged;
        }

        private void OnNumberChanged(IntContainer container) => numberText.text = container.Data.ToString();
    }
}

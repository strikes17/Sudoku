namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;

    public class ButtonCloseWindow : AbstractButton
    {
        [SerializeField]
        protected GameObject window = default;

        protected override void OnButtonClicked() => window.gameObject.SetActive(false);
    }
}

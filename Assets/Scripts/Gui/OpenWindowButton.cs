namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;

    public class OpenWindowButton : AbstractButton
    {
        [SerializeField]
        protected GameObject window = default;

        protected override void OnButtonClicked() => window.gameObject.SetActive(true);
    }
}

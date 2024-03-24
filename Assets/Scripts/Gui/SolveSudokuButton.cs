namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;

    public class SolveSudokuButton : AbstractButton
    {
        [SerializeField]
        protected FieldSolution fieldSolution = default;

        protected override void OnButtonClicked()
        {
            fieldSolution.Solve();
        }
    }

}

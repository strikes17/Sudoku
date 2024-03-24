namespace SudokuGame.Gameplay.Gui
{
    using System.Collections;
    using SudokuGame.DI;
    using SudokuGame.Systems;
    using UnityEngine;

    public class RestartButton : AbstractButton
    {
        [SerializeField]
        protected GameStarterContainer gameStarterContainer = default;

        [SerializeField]
        protected FieldSolutionValidator fieldSolutionValidator = default;

        [SerializeField]
        protected bool skipValidation = false;

        protected override void OnButtonClicked()
        {
            if (skipValidation)
            {
                fieldSolutionValidator.IsOn = false;
            }
            gameStarterContainer.Data.StartGame();
            fieldSolutionValidator.IsOn = true;
        }

    }
}

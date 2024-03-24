namespace SudokuGame.Gameplay.Gui
{
    using SudokuGame.DI;
    using SudokuGame.Systems;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Game Starter Container", menuName = "Sudoku Game/DI/Game Starter Container")]
    public class GameStarterContainer : BaseContainer<BaseGameStarter>
    {

    }
}

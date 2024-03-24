namespace SudokuGame.Gameplay
{
    using System.Linq;
    using SudokuGame.DI;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Solution Container", menuName = "Sudoku Game/DI/Solution Container")]
    public class SudokuSolutionContainer : BaseDicionaryContainer<string, SudokuSolution>
    {
        public readonly string MAIN_SOLUTION = "main";
        public SudokuSolution Main
        {
            get
            {
                if (dataCollection.TryGetValue(MAIN_SOLUTION, out SudokuSolution solution))
                {
                    return solution;
                }
                else
                {
                    Debug.LogError("Failed to get main solution");
                    return null;
                }
            }
        }
    }
}

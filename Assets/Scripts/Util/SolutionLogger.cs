namespace SudokuGame.Debug
{
    using System.Collections.Generic;
    using SudokuGame.Gameplay;
    using UnityEngine;

    public class SolutionLogger : MonoBehaviour
    {
        [SerializeField]
        protected FieldSolutionValidator sudokuSolutionValidator = default;

        protected virtual void OnEnable()
        {
            sudokuSolutionValidator.onSolutionFailed += LogFail;
            sudokuSolutionValidator.onSolutionSucceded += LogSuccess;
        }

        protected virtual void OnDisable()
        {
            sudokuSolutionValidator.onSolutionFailed -= LogFail;
            sudokuSolutionValidator.onSolutionSucceded -= LogSuccess;
        }

        protected virtual void LogSuccess() => Debug.Log("Solution succeded");

        protected virtual void LogFail(SudokuCell failedCell, List<SudokuCell> failedCells) => failedCells.ForEach(x => Debug.LogError($"Failed cell at {x.Data.FieldPosition}"));
    }
}

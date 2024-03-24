namespace SudokuGame.Gameplay
{
    using System;
    using UnityEngine;

    [Serializable]
    public class SudokuSolitionSaveFile
    {
        [SerializeField]
        protected SerializableSudokuSolution activeSolution = default;

        [SerializeField]
        protected SerializableSudokuSolution solvedSolution = default;
        
        public SerializableSudokuSolution ActiveSolution => activeSolution;
        
        public SerializableSudokuSolution SolvedSolution => solvedSolution;

        protected string fileName = string.Empty;

        public SudokuSolitionSaveFile(string saveFileName, SerializableSudokuSolution active, SerializableSudokuSolution solved)
        {
            fileName = saveFileName;
            activeSolution = active;
            solvedSolution = solved;
        }
    }
}

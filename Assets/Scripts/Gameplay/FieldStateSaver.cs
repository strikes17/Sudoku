namespace SudokuGame.Gameplay
{
    using System.IO;
    using SudokuGame.DI;
    using UnityEngine;

    public class FieldStateSaver : MonoBehaviour
    {
        [SerializeField]
        protected SudokuSolutionContainer sudokuSolutionContainer = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        protected int SavesCount
        {
            get => PlayerPrefs.GetInt("saves_count", 0);
            set => PlayerPrefs.SetInt("saves_count", value);
        }

        public virtual void Save()
        {
            string saveFileName = $"sudoku_solution_{++SavesCount}";

            SudokuSolution trueSolution = sudokuSolutionContainer.Main;
            SudokuSolution currentSolution = new SudokuSolution().Set(sudokuCells);

            SerializableSudokuSolution serializedTrueSolution = trueSolution.GetSerializableSudoku();
            SerializableSudokuSolution serializedCurrentSolution = currentSolution.GetSerializableSudoku();

            SudokuSolitionSaveFile saveFile = new SudokuSolitionSaveFile
                (saveFileName, serializedCurrentSolution, serializedTrueSolution);

            string jsonSolution = JsonUtility.ToJson(saveFile);
            string directoryPath = $"{Application.persistentDataPath}/saves";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllText($"{directoryPath}/{saveFileName}.json", jsonSolution);
        }
    }
}

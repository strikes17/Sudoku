
namespace SudokuGame.Data
{
    using SudokuGame.Systems;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Difficulty Data", menuName = "Sudoku Game/Data/Difficulty Data")]
    public class DifficultyLevelData : ScriptableObject
    {
        [SerializeField, Range(0f, 1f)]
        protected float hiddenCellsRatio = 0f;

        [SerializeField, Range(1f, 3)]
        protected int dimensions = 0;

        [SerializeField]
        protected string title;

        public string Title => title;
        
        public int Dimensions => dimensions;

        public int TotalSudukoCellsCount => (int)Mathf.Pow(Dimensions, 2) * 9;
        
        public float HiddenCellsRatio => hiddenCellsRatio;
    }
}

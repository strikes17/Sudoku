namespace SudokuGame.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "New StringId", menuName = "Sudoku Game/Id/New StringId")]
    public class StringId : ScriptableObject
    {
        [SerializeField]
        protected string id = default;

        public string Id => Id;
    }

}

namespace SudokuGame.Gameplay
{
    using SudokuGame.Camera;
    using SudokuGame.DI;
    using SudokuGame.Input;
    using UnityEngine;

    public class SudokuInteractionHandler : MonoBehaviour
    {
        protected const string SUDOKU_CELL_LAYER = "Sudoku Cell";

        [SerializeField]
        protected InputHandlerContainer inputHandlerContainer = default;

        [SerializeField]
        protected CameraRaycaster cameraRaycaster = default;

        [SerializeField]
        protected SudokuCellContainer previousSudokuCell = default;

        [SerializeField]
        protected SudokuCellContainer selectedSudokuCell = default;

        protected int layerMask = default;

        protected InputHandler inputHandler = default;

        protected virtual void Awake()
        {
            layerMask = 1 << LayerMask.NameToLayer(SUDOKU_CELL_LAYER);
        }

        protected virtual void OnEnable()
        {
            inputHandler = inputHandlerContainer.Data;
            if (inputHandler != null)
            {
                inputHandler.onMouseDown += TryInteractWithSudoku;
            }
        }

        protected virtual void OnDisable()
        {
            if (inputHandler != null)
            {
                inputHandler.onMouseDown -= TryInteractWithSudoku;
            }
        }

        protected virtual void TryInteractWithSudoku()
        {
            RaycastHit2D sudokuCellHit = cameraRaycaster.Raycast(inputHandler.InputPosition, layerMask);
            Collider2D collider = sudokuCellHit.collider;
            if (collider != null)
            {
                SudokuCell sudokuCell = collider.GetComponent<SudokuCell>();
                if (sudokuCell != null)
                {
                    previousSudokuCell.Data = selectedSudokuCell.Data;
                    selectedSudokuCell.Data = sudokuCell;

                    if (previousSudokuCell.Data != null)
                    {
                        previousSudokuCell.Data.Deselect();
                    }
                    
                    selectedSudokuCell.Data.Select();
                }
            }

        }

    }
}

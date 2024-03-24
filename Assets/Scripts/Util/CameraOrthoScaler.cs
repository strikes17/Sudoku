namespace SudokuGame.Camera
{
    using SudokuGame.Data;
    using SudokuGame.Difficulty;
    using UnityEngine;

    public class CameraOrthoScaler : MonoBehaviour
    {
        [SerializeField]
        protected DifficultyLevelContainer difficultyLevelContainer = default;

        [SerializeField, Min(1f)]
        protected float scaleFactor = 1.6f;

        [SerializeField]
        protected Camera mainCamera = default;

        protected virtual void OnEnable()
        {
            mainCamera.orthographicSize = difficultyLevelContainer.Data.Dimensions * scaleFactor;
            difficultyLevelContainer.onDataChanged += UpdateSize;
        }

        protected virtual void OnDisable() => difficultyLevelContainer.onDataChanged -= UpdateSize;

        protected virtual void UpdateSize(DifficultyLevelData data) => mainCamera.orthographicSize = data.Dimensions * scaleFactor;
    }
}

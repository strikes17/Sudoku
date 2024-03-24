namespace SudokuGame.Gameplay.Gui
{
    using System.Collections.Generic;
    using System.IO;
    using SudokuGame.Util;
    using UnityEngine;
    public class LoadGameMenu : MonoBehaviour
    {
        [SerializeField]
        protected SelectSaveBehaviour selectSaveBehaviourPrefab = default;

        [SerializeField]
        protected Transform contentRootTransform = default;

        protected ObjectPool<SelectSaveBehaviour> selectSaveBehaviourPool = default;

        protected virtual void Awake() => selectSaveBehaviourPool = new ObjectPool<SelectSaveBehaviour>(selectSaveBehaviourPrefab);

        protected virtual void OnEnable()
        {
            string directoryPath = $"{Application.persistentDataPath}/saves";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string[] savedFiles = Directory.GetFiles($"{Application.persistentDataPath}/saves", "*.json");
            foreach (string fileName in savedFiles)
            {
                SelectSaveBehaviour selectSaveBehaviour = selectSaveBehaviourPool.Get();

                selectSaveBehaviour.SaveFileName = fileName;

                selectSaveBehaviour.transform.SetParent(contentRootTransform);

                selectSaveBehaviour.SetActiveState();
            }
        }

        protected virtual void OnDisable()
        {
            foreach (SelectSaveBehaviour selectSaveBehaviour in selectSaveBehaviourPool.Objects)
            {
                selectSaveBehaviour.SetDisableState();
            }
        }
    }
}

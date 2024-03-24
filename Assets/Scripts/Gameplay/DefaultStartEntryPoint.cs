
namespace SudokuGame.Systems
{
    using System;
    using System.Collections;
    using SudokuGame.DI;
    using UnityEngine;

    public sealed class DefaultStartEntryPoint : BaseGameStarter
    {
        [SerializeField]
        private SceneLoaderContainer sceneLoaderContainer = default;

        private SceneLoader sceneLoader = default;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            sceneLoader = sceneLoaderContainer.Data;
            if (sceneLoader != null)
            {
                OnInitSceneLoader(sceneLoader);
            }
            else
            {
                sceneLoaderContainer.onDataChanged += OnInitSceneLoader;
            }

        }

        private void OnInitSceneLoader(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
            sceneLoader.onSceneLoaded += StartGameOnLoad;
            sceneLoader.LoadScene(sceneLoader.GAME);
        }

        private void OnDestroy()
        {
            sceneLoaderContainer.onDataChanged -= OnInitSceneLoader;
            sceneLoader.onSceneLoaded -= StartGameOnLoad;
        }

        private void StartGameOnLoad(string sceneName) => StartCoroutine(OnGameStartedCoroutine());

        private IEnumerator OnGameStartedCoroutine()
        {
            yield return new WaitForEndOfFrame();
            StartGame();
            Destroy(gameObject);
        }
    }
}

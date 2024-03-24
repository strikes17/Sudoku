namespace SudokuGame.DI
{
    using SudokuGame.Systems;
    using UnityEngine;

    public class SceneLoaderContainerInit : BaseContainerInit<SceneLoader>
    {
        protected override void InitializeContainer()
        {
            DontDestroyOnLoad(data);
            base.InitializeContainer();
        }
    }

}

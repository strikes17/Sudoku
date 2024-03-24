namespace SudokuGame.Gameplay.Gui
{
    using System.Collections.Generic;
    using SudokuGame.Data;
    using SudokuGame.Difficulty;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class DifficultyDropdown : AbstractDropdown
    {
        [SerializeField]
        protected DifficultyCollectionLevelContainer difficultyCollection = default;

        [SerializeField]
        protected DifficultyLevelContainer difficultyLevel = default;

        protected Dictionary<int, DifficultyLevelData> levelBindings = new Dictionary<int, DifficultyLevelData>();

        protected override void OnDropdownChanged(int option)
        {
            if (levelBindings.TryGetValue(option, out DifficultyLevelData data))
            {
                difficultyLevel.Data = data;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            base.OnEnable();
            int index = 0;
            int currentLevelIndex = 0;
            List<TMP_Dropdown.OptionData> optionDatas = new List<TMP_Dropdown.OptionData>();
            foreach (DifficultyLevelData data in difficultyCollection.DataCollection)
            {
                levelBindings.TryAdd(index++, data);
                optionDatas.Add(new TMP_Dropdown.OptionData() { text = data.Title });
                if (data == difficultyLevel.Data)
                {
                    currentLevelIndex = index;
                }
            }

            dropdown.AddOptions(optionDatas);

            dropdown.SetValueWithoutNotify(currentLevelIndex);
        }

    }
}

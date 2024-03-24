namespace SudokuGame.Gameplay.Gui
{
    using System;
    using System.Collections.Generic;
    using SudokuGame.DI;
    using SudokuGame.Util;
    using UnityEngine;

    public class NumberPanelHandler : MonoBehaviour
    {
        [SerializeField]
        protected NumberBehaviour numberBehaviourPrefab = default;

        [SerializeField]
        protected Transform contentRootTransform = default;

        [SerializeField]
        protected List<IntContainer> allNumbersContainers = default;

        [SerializeField]
        protected UserModeContainer userModeContainer = default;

        [SerializeField]
        protected UserMode userMode = default;

        protected ObjectPool<NumberBehaviour> numbers = default;

        protected virtual void Awake() => numbers = new ObjectPool<NumberBehaviour>(numberBehaviourPrefab);

        protected virtual void OnEnable()
        {
            userModeContainer.onDataChanged += OnUserModeChanged;
            for (int i = 0; i < allNumbersContainers.Count; i++)
            {
                NumberBehaviour numberBehaviour = numbers.Get();

                numberBehaviour.transform.SetParent(contentRootTransform, false);

                numberBehaviour.NumberContainer = allNumbersContainers[i];
            }
            OnUserModeChanged(userModeContainer.Data);
        }

        protected virtual void OnUserModeChanged(UserMode mode)
        {
            if (userMode == mode)
            {
                foreach (NumberBehaviour numberBehaviour in numbers.Objects)
                {
                    numberBehaviour.SetActiveState();
                }
            }
            else
            {
                foreach (NumberBehaviour numberBehaviour in numbers.Objects)
                {
                    numberBehaviour.SetDisableState();
                }
            }
        }

        protected virtual void OnDisable()
        {
            userModeContainer.onDataChanged -= OnUserModeChanged;
            foreach (NumberBehaviour numberBehaviour in numbers.Objects)
            {
                numberBehaviour.Dispose();
            }
        }
    }
}

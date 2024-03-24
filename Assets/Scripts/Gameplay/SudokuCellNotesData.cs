namespace SudokuGame.Gameplay.View
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SudokuCellNotesData : MonoBehaviour
    {
        public event Action<int> onNoteRemoved = delegate { };

        public event Action<int> onNoteAdded = delegate { };

        public event Action onNoteHidden = delegate { };

        public event Action onNoteShown = delegate { };

        [SerializeField]
        protected SudokuCellData sudokuCellData = default;

        public IEnumerable Notes => notes;

        protected List<int> notes = new List<int>();

        protected void SetNoteAtIndex(int index, int number)
        {
            if(index >= notes.Count && index < 0)
            {
                Debug.LogError($"Failed to set note at {index}");
                return;
            }
            notes[index] = number;
        }

        protected virtual void Awake()
        {
            for (int i = 0; i < 9; i++)
            {
                notes.Add(0);
            }
        }

        protected virtual void OnEnable()
        {
            sudokuCellData.onNoteSet += OnNoteSet;
            sudokuCellData.onNumberSet += OnNumberSet;
        }

        protected virtual void OnNumberSet(SudokuCell cell, int number)
        {
            if (number == 0)
            {
                onNoteShown();
            }
            else
            {
                onNoteHidden();
            }
        }

        protected virtual void OnDisable()
        {
            sudokuCellData.onNoteSet -= OnNoteSet;
            sudokuCellData.onNumberSet -= OnNumberSet;
        }

        protected virtual void OnNoteSet(SudokuCell sudokuCell, int number)
        {
            if (notes.Contains(number))
            {
                SetNoteAtIndex(number - 1, 0);
                onNoteRemoved(number);
            }
            else
            {
                SetNoteAtIndex(number - 1, number);
                onNoteAdded(number);
            }
        }

    }
}

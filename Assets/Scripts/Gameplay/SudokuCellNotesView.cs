namespace SudokuGame.Gameplay.View
{
    using System.Text;
    using TMPro;
    using UnityEngine;

    public class SudokuCellNotesView : MonoBehaviour
    {
        protected const string SPACE_LITERAL = " ";

        [SerializeField]
        protected SudokuCellNotesData notesData = default;

        [SerializeField]
        protected TMP_Text notesText = default;

        protected virtual void Awake() => notesText.text = string.Empty;

        protected virtual void OnEnable()
        {
            notesData.onNoteAdded += AddNote;
            notesData.onNoteRemoved += AddNote;
            notesData.onNoteHidden += HideNote;
            notesData.onNoteShown += ShowNote;
        }

        protected virtual void OnDisable()
        {
            notesData.onNoteAdded -= AddNote;
            notesData.onNoteRemoved -= AddNote;
            notesData.onNoteHidden -= HideNote;
            notesData.onNoteShown -= ShowNote;
        }

        protected virtual void HideNote() => notesText.gameObject.SetActive(false);

        protected virtual void ShowNote() => notesText.gameObject.SetActive(true);

        protected virtual void AddNote(int number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int indexer = 0;
            foreach (int noteNumber in notesData.Notes)
            {
                indexer++;
                string stringNum = noteNumber == 0 ? SPACE_LITERAL : noteNumber.ToString();
                stringBuilder.Append(stringNum);
                if (indexer < 9)
                {
                    stringBuilder.Append(SPACE_LITERAL);
                }
                if (indexer % 3 == 0)
                {
                    stringBuilder.Append("\n");
                }
            }
            notesText.text = stringBuilder.ToString();
        }
    }
}

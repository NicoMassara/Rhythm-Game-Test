using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts
{
    public class TrackUI : MonoBehaviour
    {
        [SerializeField] private TrackController trackController;
        [SerializeField] private Image timeBar;
        [SerializeField] private NoteUI[] notesUI;

        private void Start()
        {
            trackController.OnNoteFailed += OnNoteFailedHandler;
            trackController.OnNotePress += OnNotePressHandler;
            trackController.OnStart += OnStartHandler;


            CleanNotes();
        }

        private void Update()
        {
            timeBar.fillAmount = trackController.GetTimeRatio();
        }

        private void CleanNotes()
        {
            foreach (var note in notesUI)
            {
                note.gameObject.SetActive(false);
            }
            
            timeBar.fillAmount = 0;
        }

        private void SetNotesInUI()
        {
            var notes = trackController.GetNotes();

            for (int i = 0; i < notes.Length; i++)
            {
                notesUI[i].gameObject.SetActive(true);
                notesUI[i].SetState(UiNoteState.Default);
                notesUI[i].SetSprite(notes[i]);
            }
        }

        private void OnNoteFailedHandler(int index)
        {
            notesUI[index].SetState(UiNoteState.Failed);
        }

        private void OnNotePressHandler(int index)
        {
            notesUI[index].SetState(UiNoteState.Success);
        }
        
        private void OnStartHandler()
        {
            CleanNotes();
            SetNotesInUI();
        }
    }
}
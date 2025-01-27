using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main.Scripts.Rhythm
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Fretboard fretboard; 
        [SerializeField] private NoteChecker noteChecker;
        [SerializeField] private MuscleManBehavior muscleMan;
        
        private void Update()
        {
            CreateNotes();
            CheckNotes();
            LightOffNotes();
        }

        private void HandleNoteCheck(NotesColorEnum coloNote)
        {
            if (noteChecker.CheckNote(coloNote))
            {
                muscleMan.SetPoseByColor(coloNote);
            }
            else
            {
                fretboard.LightNote(coloNote);
            }
        }

        private void CheckNotes()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                HandleNoteCheck(NotesColorEnum.Red);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                HandleNoteCheck(NotesColorEnum.Yellow);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                HandleNoteCheck(NotesColorEnum.Blue);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                HandleNoteCheck(NotesColorEnum.Green);
            }
        }

        private void LightOffNotes()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                fretboard.LightNote(NotesColorEnum.Red, false);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                fretboard.LightNote(NotesColorEnum.Yellow, false);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                fretboard.LightNote(NotesColorEnum.Blue, false);
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                fretboard.LightNote(NotesColorEnum.Green, false);
            }
        }

        private void CreateNotes()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                fretboard.CreateNote(NotesColorEnum.Red);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                fretboard.CreateNote(NotesColorEnum.Yellow);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                fretboard.CreateNote(NotesColorEnum.Blue);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                fretboard.CreateNote(NotesColorEnum.Green);
            }
        }
    }
}
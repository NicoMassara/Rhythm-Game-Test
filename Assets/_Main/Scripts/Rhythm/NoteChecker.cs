using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    public class NoteChecker : MonoBehaviour
    {
        private List<Cube> _notes;
        private int _score = 0;
        
        public int GetScore()
        {
            return _score;
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void Start()
        {
            _notes = new List<Cube>();
        }

        public bool CheckNote(NotesColorEnum colorNote)
        {
            bool didHit = false;
            var noteToCheck = FindNote(colorNote);
            if (noteToCheck != null)
            {
                noteToCheck.Strum();
                didHit = true;
                _score += 10;
                Debug.Log($"Check Note {colorNote}");
            }
            else
            {
                //Debug.Log($"No note found for {colorNote}");
            }

            return didHit;
        }

        private Cube FindNote(NotesColorEnum colorNote)
        {
            Cube returnNote = null;
            if (_notes.Count > 0)
            {
                foreach (Cube note in _notes)
                {
                    if (note.Color == colorNote)
                    {
                        returnNote = note;
                        _notes.Remove(note);
                        break;
                    }
                }
            }
            
            return returnNote;
        }

        #region Collision

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Cube>(out var note))
            {
                if (!_notes.Contains(note))
                {
                    _notes.Add(note);
                    //Debug.Log($"Add note {note.Color}");
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Cube>(out var note))
            {
                if (_notes.Contains(note))
                {
                    _notes.Remove(note);
                    //Debug.Log($"Remove note {note.Color}");
                }
            }
        }

        #endregion


    }
}
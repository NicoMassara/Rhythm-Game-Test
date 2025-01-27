using System;
using _Main.Scripts.Rhythm.SO;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    public class NotesController : MonoBehaviour
    {
        [SerializeField] private Fretboard fretboard;
        [SerializeField] private TrackDataSo trackData;

        private bool _bDoesStart = false;
        private float _currentTime;
        private int _currentNoteIndex;
        private int _maxIndex;
        private float _trackLenght;
        private float _currentTrackProgress;

        public float GetTrackProgressRatio()
        {
            return _currentTrackProgress / _trackLenght;
        }

        private void Start()
        {
            HandleRestart();
            SetTrackLenght();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && GetTrackProgressRatio() == 0 && !_bDoesStart)
            {
                _bDoesStart = true;
            }

            if (_bDoesStart)
            {
                HandleNotes();

                if (_maxIndex == _currentNoteIndex)
                {
                    _bDoesStart = false;
                    Debug.Log("Track End");
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && GetTrackProgressRatio() >= 1)
            {
                Debug.Log("Track Restart");
                HandleRestart();
                _bDoesStart = true;
            }
        }


        private void HandleRestart()
        {
            _currentNoteIndex = 0;
            _currentTrackProgress = 0;
            _currentTime = 0;
            _maxIndex = trackData.Notes.Length;
        }

        private void SetTrackLenght()
        {
            for (int i = 0; i < _maxIndex; i++)
            {
                _trackLenght += trackData.Notes[i].delay;
            }
        }

        private void HandleNotes()
        {
            var noteData = trackData.Notes[_currentNoteIndex];
            if (_currentTime >= noteData.delay)
            {
                _currentTime = 0;
                fretboard.CreateNote(noteData.color);
                
                _currentNoteIndex++;
            }
            
            _currentTime += Time.deltaTime;
            _currentTrackProgress += Time.deltaTime;
        }
    }
}
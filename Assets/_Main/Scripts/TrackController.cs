using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace _Main.Scripts
{
    public class TrackController : MonoBehaviour
    {
        [SerializeField] private TrackDataSo[] trackData;
        
        private TrackDataSo _currentTrack;

        private bool _canRestart;
        private float _currentTime;
        private bool _canStart;
        private bool _canAddNote;
        private int _notesIndex;
        private int _correctNotesAmount;
        
        public float CurrentTime => _currentTime;
        
        public UnityAction OnStart;
        public UnityAction<int> OnNoteFailed;
        public UnityAction<int> OnNotePress;
        public UnityAction<float> OnScore;

        private void Start()
        {
            SetTrack(DifficultyEnum.Easy);
        }

        private void Update()
        {
            if (_canStart && _canAddNote)
            {
                _currentTime -= Time.deltaTime;
                
                if (_currentTime <= 0)
                {
                    _canAddNote = false;
                    CheckNotesScore();
                }
            }
        }
        

        public void AddNote(NoteType noteType)
        {
            if(!_canAddNote) return;
            
            bool isEqual = _currentTrack.Notes[_notesIndex] == noteType;

            if (isEqual)
            {
                _correctNotesAmount++;
                OnNotePress.Invoke(_notesIndex);
            }
            else
            {
                OnNoteFailed?.Invoke(_notesIndex);
            }
            
            _notesIndex++;

            if (_notesIndex >= _currentTrack.NoteCount)
            {
                _canAddNote = false;
                
                CheckNotesScore();
            }
        }

        private void CheckNotesScore()
        {
            var scoreRatio = _correctNotesAmount / (float) _currentTrack.NoteCount;
            
            OnScore?.Invoke(scoreRatio);
            _canRestart = true;
            _canStart = false;
        }

        public NoteType[] GetNotes()
        {
            return _currentTrack.Notes;
        }

        public void StartTrack()
        {
            if (_canStart == false)
            {
                _currentTime = _currentTrack.MaxTime;
                _canAddNote = true;
                _canStart = true;
                _canRestart = false;
                SetInitValues();
                OnStart?.Invoke();
            }
        }

        private void SetInitValues()
        {
            _correctNotesAmount = 0;
            _notesIndex = 0;
        }


        public float GetTimeRatio()
        {
            return  1f - (_currentTime / _currentTrack.MaxTime) ;
        }

        public void SetTrack(DifficultyEnum difficulty)
        {
            if (_canStart == false)
            {
                _currentTrack = trackData[(int)difficulty];
            }

        }
    }
    
    public enum DifficultyEnum
    {
        Easy,
        Medium,
        Hard,
        Deadly
    }
}
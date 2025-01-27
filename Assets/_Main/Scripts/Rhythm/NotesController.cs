using System;
using _Main.Scripts.Rhythm.SO;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    [RequireComponent(typeof(AudioSource))]
    public class NotesController : MonoBehaviour
    {
        [SerializeField] private Fretboard fretboard;
        [SerializeField] private TrackDataSo trackData;
        [SerializeField] private NoteChecker noteChecker;

        private AudioSource _audioSource;
        private bool _bDoesStart = false;
        private float _currentTime;
        private int _currentNoteIndex;
        private int _maxIndex;
        private float _trackLenght;
        private float _currentTrackProgress;
        private float _trackTempo;


        public float GetTrackProgressRatio()
        {
            return _currentTrackProgress / _trackLenght;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            HandleStart();
            SetTrackLenght();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && GetTrackProgressRatio() == 0 && !_bDoesStart)
            {
                _bDoesStart = true;
                PlaySong();
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
                HandleStart();
                noteChecker.ResetScore();
                PlaySong();
                _bDoesStart = true;
            }
        }

        private void HandleStart()
        {
            _currentNoteIndex = 0;
            _currentTrackProgress = 0;
            _currentTime = 0;
            _maxIndex = trackData.Notes.Length;

        }

        private void PlaySong()
        {
            _audioSource.clip = trackData.AudioClip;
            _audioSource.Play();
        }

        private void SetTrackLenght()
        {
            _trackTempo = trackData.Tempo;
            
            for (int i = 0; i < _maxIndex; i++)
            {
                _trackLenght += trackData.Notes[i].GetTime(_trackTempo);
            }
        }

        private void HandleNotes()
        {
            var noteData = trackData.Notes[_currentNoteIndex];
            if (_currentTime >= noteData.GetTime(_trackTempo))
            {
                _currentTime = 0;
                //None is used just to wait
                if (noteData.color != NotesColorEnum.None)
                {
                    fretboard.CreateNote(noteData.color);
                }
                
                _currentNoteIndex++;
            }
            
            _currentTime += Time.deltaTime;
            _currentTrackProgress += Time.deltaTime;
        }
    }
}
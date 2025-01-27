using System;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    public class Fretboard : MonoBehaviour
    {
        [Header("Objects References")]
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private GameObject[] lightNotes;
        [Space]
        [Header("Notes Parameters")] 
        [SerializeField] private float noteSpeed = 5;
        [Range(0f, 2f)][Tooltip("Max Distance that a note can be played")] 
        [SerializeField] private float noteGracePeriod;
        [SerializeField] private Sprite strumSprite;
        
        private NotesFactory _notesFactory;

        private void Awake()
        {
            _notesFactory = GetComponent<NotesFactory>();
        }

        public void CreateNote(NotesColorEnum noteColor)
        {
            var index = (int)noteColor - 1;
            _notesFactory.CreateNotes(noteColor, spawnPoints[index], noteSpeed);
        }

        public void LightNote(NotesColorEnum noteColor, bool doesLight = true)
        {
            var index = (int)noteColor - 1;
            lightNotes[index].SetActive(doesLight);
        }
    }
}
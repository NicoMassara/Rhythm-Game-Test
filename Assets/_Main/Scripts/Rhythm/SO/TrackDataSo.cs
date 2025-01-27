using System;
using UnityEngine;

namespace _Main.Scripts.Rhythm.SO
{
    [CreateAssetMenu(fileName = "TrackData", menuName = "ScriptableObject/TrackData", order = 0)]
    public class TrackDataSo : ScriptableObject
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private float tempo;
        [SerializeField] private NoteData[] notes;

        public AudioClip AudioClip => audioClip;
        public float Tempo => tempo;
        public NoteData[] Notes => notes;

    }

    [Serializable]
    public class NoteData
    {
        [SerializeField]
        private NotesTimeEnum time;
        public NotesColorEnum color;

        public float GetTime(float tempo)
        {
            float temp = 60 / tempo;
            return time switch
            {
                NotesTimeEnum.Whole => 4*temp,
                NotesTimeEnum.Quarter => 2*temp,
                NotesTimeEnum.Eighth => 1*temp,
                NotesTimeEnum.Sixteenth => 0.5f*temp,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

}
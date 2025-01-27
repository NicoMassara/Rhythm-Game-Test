using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main.Scripts.Rhythm.SO
{
    [CreateAssetMenu(fileName = "TrackData", menuName = "ScriptableObject/TrackData", order = 0)]
    public class TrackDataSo : ScriptableObject
    {
        [SerializeField] private NoteData[] notes;

        public NoteData[] Notes => notes;
    }

    [Serializable]
    public class NoteData
    {
        [FormerlySerializedAs("time")] public float delay;
        public NotesColorEnum color;
    }

}
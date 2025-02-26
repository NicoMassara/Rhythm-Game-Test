using UnityEngine;

namespace _Main.Scripts
{
    [CreateAssetMenu(fileName = "TrackData", menuName = "ScriptableObjects/Track Data")]
    public class TrackDataSo : ScriptableObject
    {
        [Tooltip("Min 1, Max 8")]
        [SerializeField] private NoteType[] notes;

        [Range(1,15)]
        [SerializeField] private float maxTime;


        public NoteType[] Notes => notes;
        public float MaxTime => maxTime;
        public int NoteCount => notes.Length;
    }

    public enum NoteType
    {
        None,
        Up,
        Down,
        Right,
        Left
    }
}
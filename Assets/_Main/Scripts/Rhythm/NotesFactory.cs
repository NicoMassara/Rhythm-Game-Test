using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    public class NotesFactory : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite redNote;
        [SerializeField] private Sprite yellowNote;
        [SerializeField] private Sprite blueNote;
        [SerializeField] private Sprite greenNote;
        [Header("Prefabs")]
        [SerializeField] private GameObject notePrefab;

        private Sprite GetSprite(NotesColorEnum color)
        {
            return color switch
            {
                NotesColorEnum.Red => redNote,
                NotesColorEnum.Yellow => yellowNote,
                NotesColorEnum.Blue => blueNote,
                NotesColorEnum.Green => greenNote,
                _ => null
            };
        }

        public Cube CreateNotes(NotesColorEnum color, Transform spawnTransform, float noteSpeed)
        {
            var returnNote = Instantiate(
                notePrefab, 
                spawnTransform.position, Quaternion.identity, 
                spawnTransform).GetComponent<Cube>();
            
            returnNote.SetColor(color);
            returnNote.SetSprite(GetSprite(color));
            returnNote.SetSpeed(noteSpeed);
            
            return returnNote;
        }
    }
}
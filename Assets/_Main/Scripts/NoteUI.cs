using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts
{
    public class NoteUI : MonoBehaviour
    {
        [SerializeField] private Sprite[] noteSprites;
        
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }


        public void SetSprite(NoteType type)
        {
            var index = (int)type-1;
            var sprite = noteSprites[index];
            
            _image.sprite = sprite;
        }

        public void SetState(UiNoteState state)
        {
            switch (state)
            {
                case UiNoteState.Default:
                    _image.color = Color.white;
                    break;
                case UiNoteState.Success:
                    _image.color = Color.green;
                    break;
                case UiNoteState.Failed:
                    _image.color = Color.red;
                    break;
            }
        }
    }

    public enum UiNoteState
    {
        Default,
        Success,
        Failed
    }
}
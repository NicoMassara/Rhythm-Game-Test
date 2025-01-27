using System;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    /// <summary>
    /// It's a Note. Fck Rider
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class Cube : MonoBehaviour
    {
        [SerializeField] private Sprite strumSprite;
        private SpriteRenderer _spriteRenderer;
        private float _speed;
        public NotesColorEnum Color { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_speed > 0)
            {
                transform.position += Vector3.down * (_speed * Time.deltaTime);
            }
        }

        public void SetColor(NotesColorEnum color)
        {
            Color = color;
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void Strum()
        {
            SetSprite(strumSprite);
            _speed = 0;
            Destroy(gameObject, 0.15f);
        }
    }
}
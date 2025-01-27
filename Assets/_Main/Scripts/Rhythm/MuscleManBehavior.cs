using System;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MuscleManBehavior : MonoBehaviour
    {
        [SerializeField] private Sprite idleSprite;
        [SerializeField] private Sprite[] poseSprites;
        
        private SpriteRenderer _spriteRenderer;
        private float _poseTime = 0.5f;
        private float _currentPoseTime = 0;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_currentPoseTime > 0)
            {
                _currentPoseTime -= Time.deltaTime;
                if (_currentPoseTime <= 0)
                {
                    SetSprite(idleSprite);
                    _currentPoseTime = 0;
                }
            }
        }

        public void SetPoseByColor(NotesColorEnum notesColor)
        {
            var index = (int)notesColor - 1;
            SetSprite(poseSprites[index]);
            ResetTimer();
        }

        private void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        private void ResetTimer()
        {
            _currentPoseTime = _poseTime;
        }
    }
}
using System;
using TMPro;
using UnityEngine;

namespace _Main.Scripts
{
    public class Dancer : MonoBehaviour
    {
        [SerializeField] private TrackController trackController;
        [SerializeField] private Sprite[] dancerSprites;
        [SerializeField] private TMP_Text scoreText;

        private Sprite _startSprite;

        private string[] scoreTexts = new string[]
        {
            "Perfect Argument",
            "Good Argument",
            "Poor Argument",
            "That's a Fallacy",
            "Well..."
            
        };
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _startSprite = _spriteRenderer.sprite;
            scoreText.text = "";
            
            trackController.OnStart += OnStartHandler;
            trackController.OnScore += OnScoreHandler;
        }

        private void OnStartHandler()
        {
            _spriteRenderer.sprite = _startSprite;
            scoreText.text = "";
        }

        private void SetVisualData(int index)
        {
            scoreText.text = scoreTexts[index];
            _spriteRenderer.sprite = dancerSprites[index];
        }

        private void OnScoreHandler(float score)
        {
            score *= 100;
            if (score <= 0)
            {
                SetVisualData(4);
            }
            else if (score > 0 && score < 25)
            {
                SetVisualData(3);
            }
            else if (score >= 25 && score < 75)
            {
                SetVisualData(2);
            }
            else if (score >= 75 && score < 100)
            {
                SetVisualData(1);
            }
            else if (score >= 100)
            {
                SetVisualData(0);
            }
        }
    }
}
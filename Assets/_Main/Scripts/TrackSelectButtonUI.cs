using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Main.Scripts
{
    public class TrackSelectButtonUI : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text buttonText;
        private DifficultyEnum _difficulty;
        
        public UnityAction<DifficultyEnum> OnSelect;

        private void Start()
        {
            button.onClick.AddListener(() => OnSelect?.Invoke(_difficulty));
        }

        public void SetData(DifficultyEnum difficulty)
        {
            buttonText.text = difficulty.ToString();
            _difficulty = difficulty;
        }
    }
}
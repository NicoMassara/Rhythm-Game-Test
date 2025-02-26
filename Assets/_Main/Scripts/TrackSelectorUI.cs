using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts
{
    public class TrackSelectorUI : MonoBehaviour
    {
        [SerializeField] private TrackController trackController;
        [SerializeField] private TrackSelectButtonUI[] _selectButtons;
        [SerializeField] private Button _startButton;

        private void Start()
        {
            var index = 0;
            foreach (var button in _selectButtons)
            {
                button.SetData((DifficultyEnum)index);
                button.OnSelect += OnSelectHandler;
                index++;
            }
            
            _startButton.onClick.AddListener(OnStartClickHandler);
        }

        private void OnStartClickHandler()
        {
            trackController.StartTrack();
        }

        private void OnSelectHandler(DifficultyEnum difficulty)
        {
            trackController.SetTrack(difficulty);
        }
    }
}
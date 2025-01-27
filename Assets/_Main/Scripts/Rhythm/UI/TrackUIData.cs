using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Rhythm.UI
{
    public class TrackUIData : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private NotesController notesController;

        private void Awake()
        {
            progressBar.fillAmount = 0;
        }

        private void Update()
        {
            progressBar.fillAmount = notesController.GetTrackProgressRatio();
        }
    }
}
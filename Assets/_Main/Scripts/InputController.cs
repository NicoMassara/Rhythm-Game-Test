using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private TrackController trackController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                trackController.AddNote(NoteType.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                trackController.AddNote(NoteType.Down);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                trackController.AddNote(NoteType.Right);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                trackController.AddNote(NoteType.Left);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                trackController.StartTrack();
            }
        }
    }
}
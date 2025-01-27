using System;
using UnityEngine;

namespace _Main.Scripts.Rhythm
{
    
    public class NoteCleaner : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           Destroy(other.gameObject);
        }
    }
}
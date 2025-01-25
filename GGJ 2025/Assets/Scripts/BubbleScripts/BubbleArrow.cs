using System;
using MovingObjectScripts;
using UnityEngine;

namespace BubbleScripts
{
    public class BubbleObject : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Boba"))
            {
                var movingObjectStateManager = other.gameObject.GetComponent<MovingObjectStateManager>();
                movingObjectStateManager.SwitchState(MovingObjectStates.BubbledState);
            }
        }
    }
}

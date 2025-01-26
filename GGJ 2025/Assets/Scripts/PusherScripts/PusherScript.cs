using System;
using System.Collections;
using DefaultNamespace;
using MovingObjectScripts;
using UnityEngine;

namespace PusherScripts
{
    public class PusherScript : MonoBehaviour
    {
        public float blowForce = 5f;

        public float blowDuration = 2f;

        public bool isBlower = true;
        
        public float adjustDistance = 0.2f;
        
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Constants.Tags.Boba))
            {
                return;
            }

            var bobaOjectStateManager = other.gameObject.GetComponent<MovingObjectStateManager>();
            Debug.Log("Here");
            if (isBlowerAndBubbledBoba(bobaOjectStateManager))
            {
                PushBoba(other);
                Debug.Log("Bubbld boba hit");
            } else if (isJumpPadAndDefaultBoba(bobaOjectStateManager))
            {
                PushBoba(other);
            }

        }

        private void PushBoba(Collider2D other)
        {
            var bobaRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
            float zRotation = transform.eulerAngles.z;
            
            Vector2 direction;
            if (Mathf.Approximately(zRotation, 0f) || Mathf.Approximately(zRotation, 180f))
            {
                direction = transform.up;
            }
            else
            {
                direction = -transform.up;
            }
            
            var newVelocity = direction * blowForce;
            
            StartCoroutine(ChangeVelocityTemporarily(bobaRigidBody, newVelocity, blowDuration));
        }

        private bool isBlowerAndBubbledBoba(MovingObjectStateManager movingObjectStateManager)
        {
            return movingObjectStateManager != null && isBlower &&
                   movingObjectStateManager.getCurrentState() is MovingObjectBubbledState;
        }

        private bool isJumpPadAndDefaultBoba(MovingObjectStateManager movingObjectStateManager)
        {
            return movingObjectStateManager != null && !isBlower &&
                   movingObjectStateManager.getCurrentState() is MovingObjectDefaultState;
        }
        
        

        IEnumerator ChangeVelocityTemporarily(Rigidbody2D rb, Vector2 newVelocity, float duration)
        {

            var originalVelocity = rb.linearVelocity;
            rb.linearVelocity = newVelocity;


            yield return new WaitForSeconds(duration);

            rb.linearVelocity = originalVelocity;
        }
    }
}

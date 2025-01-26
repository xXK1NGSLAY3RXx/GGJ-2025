using System;
using DefaultNamespace;
using PusherScripts;
using UnityEngine;

namespace BlockEditor
{
    public class EditableBlock : MonoBehaviour
    {

        private GameObject _childObject;
        private SpriteRenderer spriteRenderer;
        private SpriteRenderer _childSpriteRenderer;
        
        private enum Side { Top, Bottom, Left, Right }

        private bool _is0 = false;
        private bool _is90 = false;
        private bool _is180 = false;
        private bool _is270 = false;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // _blockWithJumpPad = GameObject.FindGameObjectWithTag(Constants.Tags.BlockWithJumpPad);
            _childSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.Rotate(0,0, 90);
            }
        }

        private void OnMouseDown()
        {
            InstantiateChild(GameObject.FindGameObjectWithTag(Constants.Tags.JumpPad), Side.Right);
        }
        
        private void InstantiateChild(GameObject child, Side side)
        {

            var newChild = Instantiate(child, transform.position, Quaternion.identity);
            newChild.transform.localScale = child.transform.localScale;
            newChild.transform.rotation = child.transform.rotation;


            var squareRenderer = GetComponent<SpriteRenderer>();
            if (squareRenderer == null)
            {
                Debug.LogError("This GameObject must have a SpriteRenderer.");
                return;
            }
            
            
            var halfSizeLen = squareRenderer.bounds.size.x / 2f;
            
            switch (side)
            {
                case Side.Top:
                    newChild.transform.position +=
                        new Vector3(0, halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0);
                    break;
                case Side.Right:
                    newChild.transform.Rotate(0,0,90);
                    newChild.transform.position +=
                        new Vector3(halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0, 0);
                    break;
                case Side.Bottom:
                    newChild.transform.Rotate(0,0,180);
                    newChild.transform.position -=
                        new Vector3(0, halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0);
                    break;
                case Side.Left:
                    newChild.transform.Rotate(0,0,270);
                    newChild.transform.position -=
                        new Vector3(halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0, 0);
                    break;
            }
            
            

            Debug.Log("Child object instantiated and attached to " + side + " of the square.");
        }
        
        
        
    }
}

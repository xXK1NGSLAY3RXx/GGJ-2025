using System.Collections.Generic;
using PusherScripts;
using UnityEngine;

namespace BlockEditor
{
    public class EditableBlock : MonoBehaviour
    {

        public bool is0 = false;
        public bool is90 = false;
        public bool is180 = false;
        public bool is270 = false;
        public BlockChildEnum _blockChild;
        
        
        private GameObject _childObject;
        private SpriteRenderer squareRenderer;
        private bool _editMode = false;

        public enum Side { Top, Bottom, Left, Right }

        private List<Side> _possibleSides = new List<Side>();
        private int _possibleSideIndex;

        public void SetBlockChild(BlockChildEnum blockChild)
        {
            _blockChild = blockChild;
            _childObject = GameObject.FindGameObjectWithTag(BlockChildEnum.JumpPad.GetTag());
        }
        
        void Start()
        {
            if (is0) _possibleSides.Add(Side.Top);
            if (is90) _possibleSides.Add(Side.Right);
            if (is180) _possibleSides.Add(Side.Bottom);
            if (is270) _possibleSides.Add(Side.Left);
            squareRenderer = GetComponent<SpriteRenderer>();
            _childObject = GameObject.FindGameObjectWithTag(_blockChild.GetTag());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _possibleSideIndex += 1;
                if (_possibleSideIndex >= _possibleSides.Count)
                {
                    _possibleSideIndex %= _possibleSides.Count;
                }
                
                if (_childObject == null) return;
                
                RotateChild(gameObject.transform.GetChild(0).gameObject, _possibleSides[_possibleSideIndex]);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _editMode = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                //TODO: Delete child
            }
        }

        private void OnMouseDown()
        {
            if (_blockChild == null) return;
            if (_editMode) return;
            _editMode = true;
            InstantiateChild(_childObject, _possibleSides[_possibleSideIndex]);
        }
        
        private void InstantiateChild(GameObject child, Side side)
        {
            var newChild = Instantiate(child, transform.position, Quaternion.identity);
            newChild.transform.localScale = child.transform.localScale;
            newChild.transform.parent = transform;

            RotateChild(newChild, side);
        }

        public void RotateChild(GameObject child, Side side)
        {
            child.transform.position = transform.position;
            child.transform.rotation = _childObject.transform.rotation;
            var halfSizeLen = squareRenderer.bounds.size.x / 2f;
            
            Debug.Log(side);
            
            switch (side)
            {
                case Side.Top:
                    child.transform.position +=
                        new Vector3(0, halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0);
                    break;
                case Side.Right:
                    child.transform.Rotate(0,0,90);
                    child.transform.position +=
                        new Vector3(halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0, 0);
                    break;
                case Side.Bottom:
                    child.transform.Rotate(0,0,180);
                    child.transform.position -=
                        new Vector3(0, halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0);
                    break;
                case Side.Left:
                    child.transform.Rotate(0,0,270);
                    child.transform.position -=
                        new Vector3(halfSizeLen + child.GetComponent<PusherScript>().adjustDistance, 0, 0);
                    break;
            }
        }
        
        
        
    }
}

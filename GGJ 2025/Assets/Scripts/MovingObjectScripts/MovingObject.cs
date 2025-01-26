using System;
using MovingObjectScripts;
using UnityEngine;
public class MovingObject : MonoBehaviour
{
    public float walkingSpeed = 5.0f;
    public float bubbledSpeed = 5.0f;
    public float characterColliderSize ;
    public float bubbleColliderSize ;
    private float _currentSpeed = 0.0f;
  
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public void SetCurrentSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }
}
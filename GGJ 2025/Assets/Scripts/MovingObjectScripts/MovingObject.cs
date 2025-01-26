using System;
using MovingObjectScripts;
using Unity.VisualScripting;
using UnityEngine;
public class MovingObject : MonoBehaviour
{
    public float walkingSpeed = 5.0f;
    public float bubbledSpeed = 5.0f;
    public float bubbleTime;
    public float characterColliderSize ;
    public float bubbleColliderSize ;
    private float _currentSpeed = 0.0f;
    public int startingDirection = 1;
    private int direction;
    private Transform Art;
  
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = startingDirection;
        Art =  transform.Find("Art");
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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
          
            if (direction == 1)
            {
                Art.transform.eulerAngles = new Vector3(0, 0, 0); 
            }
            else if (direction == -1)
            {
                Art.transform.eulerAngles = new Vector3(0, 180, 0); 
            }
        }
        
       
    }

    public int getDirection()
    {
        return direction;
    }
}
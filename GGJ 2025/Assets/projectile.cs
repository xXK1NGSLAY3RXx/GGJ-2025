using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public bool destroy_on_collision = false;
    public float speed;
    public float damage_amount;
    public float range;
    public bool ricochet;
    
  


    private Rigidbody2D rb;
    public Transform barrel_direction;
    private Vector2 direction;
    



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = barrel_direction.right;
        rb.linearVelocity = direction * speed;
      


    }

    private void Update()
    {
        if (range > 0)
        {
            range -= Time.deltaTime;
            if (range <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(destroy_on_collision);
        Debug.Log(ricochet);
        //var health_script = other.gameObject.GetComponent<Health>();
        // if (health_script != null && damage_amount > 0)
        // {
        //
        //     health_script.ApplyDamage(damage_event);
        //     Destroy(gameObject);
        // }

        if (destroy_on_collision  && !ricochet)
        {
            Debug.Log("in destory");
            Destroy(gameObject);

        }

    }
}
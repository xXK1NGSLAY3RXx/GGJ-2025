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


    void OnCollisionEnter2D(Collision2D other)
    {

       
        //var health_script = other.gameObject.GetComponent<Health>();
        if (ricochet)
        {

            Vector2 object_normal = other.contacts[0].normal;
            direction = Vector2.Reflect(direction, object_normal).normalized;
            rb.linearVelocity = direction * speed;
        }
        // if (health_script != null && damage_amount > 0)
        // {
        //
        //     health_script.ApplyDamage(damage_event);
        //     Destroy(gameObject);
        // }

        else if (destroy_on_collision == true && !ricochet)
        {
            Destroy(gameObject);

        }




    }
}
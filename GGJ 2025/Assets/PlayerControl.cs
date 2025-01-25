using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Vector2 speed = Vector2.one;
    private Rigidbody2D _rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerControl();
    }
    
    private void updatePlayerControl()
    {
        UpdatePosition();
        UpdateRotation();
    }
    private void UpdatePosition()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2D.linearVelocity = speed * input;

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.linearVelocity = new Vector2(input.x, 1) * speed;
        }
        
    }

    private void UpdateRotation()
    {

        if (Camera.main == null)
            return;
        var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        var mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        /*transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, angle)),
            Time.deltaTime * 5);*/
    }

    private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

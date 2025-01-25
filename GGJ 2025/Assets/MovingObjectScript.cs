using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: Any initialization code can go here
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacterAlongYAxis();
    }

    void MoveCharacterAlongYAxis() {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
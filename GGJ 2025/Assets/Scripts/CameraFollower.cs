using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;

    private void Update()
    {
        if (!followTarget)
            return;

        transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, Time.deltaTime * 5);
    }
}
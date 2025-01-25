using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float smoothness;

    private void Update()
    {
        offset.z += Input.mouseScrollDelta.y;
        if (!followTarget)
            return;

        transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, Time.deltaTime * smoothness);
    }
}
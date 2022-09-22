using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .1f;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position-target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
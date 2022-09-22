using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed =0;
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
    }
}
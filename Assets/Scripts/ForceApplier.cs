using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerMovement moveScript;
    private float baseMoveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (tag == "Player")
        {
            moveScript = GetComponent<PlayerMovement>();
            baseMoveSpeed = moveScript.moveSpeed;
        }
    }

    public void AddForce(Vector3 vector3, float power, float forceTime)
    {
        if (tag == "Player")
        {
            moveScript.moveSpeed = power;
            Invoke("StopForce", forceTime);
        }
        else if (tag == "Opponent")
        {
            rb.AddForce(vector3 * power);            
            Invoke("StopForceRb", forceTime);
        }
    }

    private void StopForceRb()
    {
       rb.velocity = Vector3.zero;
    }

    private void StopForce()
    {
        moveScript.moveSpeed = baseMoveSpeed;
    }
}
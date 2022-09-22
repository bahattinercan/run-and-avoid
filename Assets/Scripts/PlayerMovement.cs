using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed;
    public VariableJoystick variableJoystick;
    private Vector3 direction;
    private bool canMove = false;
    public float moveSpeed;
    private void Start()
    {
        canMove = false;
        GameManager.Instance.OnRaceStarted += OnRaceStarted;
    }

    private void OnRaceStarted()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove == true)
        {
            direction = Vector3.right * variableJoystick.Horizontal;
            if (Mathf.Abs(variableJoystick.Vertical) > .1f || Mathf.Abs(variableJoystick.Horizontal) > .1f)
            {
                transform.Translate(direction * horizontalSpeed * Time.deltaTime);
            }
            transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
        }
        
    }
}
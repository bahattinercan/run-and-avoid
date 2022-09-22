using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Vector3 endDistance;
    private Vector3 endPos;
    private Vector3 startPosition;
    [SerializeField]private float desiredDuration = 1f;
    private float elapsedTime;
    [SerializeField] private bool isRandom = true;

    [SerializeField]
    private AnimationCurve curve;

    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPos = startPosition + endDistance;
        if(isRandom)
            Invoke("StartMove", Random.Range(.3f, 1f));
        else
            Invoke("StartMove", .3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(startPosition, endPos, curve.Evaluate(percentageComplete));

            if (endPos == transform.position)
            {
                Vector3 tempVector3 = startPosition;
                startPosition = endPos;
                endPos = tempVector3;
                elapsedTime = 0;
            }
        }        
    }

    private void StartMove()
    {
        canMove = true;
    }
}

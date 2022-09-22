using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private Transform paintT;
    [SerializeField] private Transform[] endPoints;
    public int posIndex;
    [SerializeField] private Transform[] confettiTransforms;

    private void Start()
    {
        posIndex = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnRaceFinished_Invoke();
            GameManager.Instance.firstCamera.gameObject.SetActive(false);
            GameManager.Instance.paintSystem.gameObject.SetActive(true);

            other.transform.Find("Mesh").GetComponent<Animator>().Play("happyIdle");
            other.GetComponent<PlayerMovement>().horizontalSpeed = 0;
            other.GetComponent<PlayerMovement>().moveSpeed = 0;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = paintT.position;
            PlayConfetti();
        }
        else if (other.CompareTag("Opponent"))
        {
            if (posIndex < endPoints.Length)
            {
                other.transform.Find("Mesh").GetComponent<Animator>().Play("happyIdle");
                other.GetComponent<OpponentAI>().Agent.isStopped = true;
                other.GetComponent<OpponentAI>().Agent.velocity = Vector3.zero;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.transform.position = endPoints[posIndex].position;                
                posIndex++;
            }
        }
    }

    private void PlayConfetti()
    {
        foreach (Transform item in confettiTransforms)
        {
            //Instantiate(GameAssets.Instance.confettiP, item);
        }
    }
}
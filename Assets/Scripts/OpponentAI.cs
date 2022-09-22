using UnityEngine;
using UnityEngine.AI;

public class OpponentAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; set => agent = value; }

    // Start is called before the first frame update
    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        GameManager.Instance.OnRaceStarted += OnRaceStarted;
    }

    private void OnRaceStarted()
    {
        Invoke("RunToTheEnd", Random.Range(.1f, .5f));
    }

    private void RunToTheEnd()
    {
        transform.Find("Mesh").GetComponent<Animator>().Play("running");
        Agent.SetDestination(GameManager.Instance.endPoint.position);
    }
}
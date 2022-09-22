using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("happyIdle");
        GameManager.Instance.OnRaceStarted += OnRaceStarted;
    }

    private void OnRaceStarted()
    {
        animator.Play("run");
    }
}
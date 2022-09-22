using UnityEngine;

public class TutorialSlider : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnRaceStarted += OnRaceStart;
    }

    private void OnRaceStart()
    {
        Destroy(gameObject);
    }
}
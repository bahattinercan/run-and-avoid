using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveWhenRaceFinished : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnRaceFinished += GameManager_onRaceFinished;
    }

    private void GameManager_onRaceFinished()
    {
        gameObject.SetActive(false);
    }
}

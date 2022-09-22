using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Transform endPoint;
    public Transform startPoint;
    public Transform paintSystem;
    public Camera firstCamera;
    public GameObject playerGO;
    private int playerRank;
    private int percentageOfPaint=100;
    public GameObject[] opponents;
    private float[] runnerZLocations;
    public float paintTime = 10f;

    public event Action OnRaceStarted;
    public event Action OnRaceFinished;
    public event Action OnPaintFinished;
    public event Action<float> ChangePaintPercentage;
    public bool isRaceFinished = false;
    public bool isPaintFinished = false;

    public static GameManager Instance { get => instance; }
    public int PlayerRank { get => playerRank; private set => playerRank = value; }
    public int PercentageOfPaint { get => percentageOfPaint; set => percentageOfPaint = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        opponents = GameObject.FindGameObjectsWithTag("Opponent");
        runnerZLocations = new float[9];
        percentageOfPaint = 100;
    }

    private void Update()
    {
        PlayerRankDetection();
    }

    public void OnRaceFinished_Invoke()
    {
        OnRaceFinished?.Invoke();
        isRaceFinished = true;
    }

    public void OnPaintFinished_Invoke()
    {
        OnPaintFinished?.Invoke();
        paintSystem.gameObject.SetActive(false);
        firstCamera.gameObject.SetActive(true);
        isPaintFinished = true;
    }

    public void OnRaceStarted_Invoke()
    {
        OnRaceStarted?.Invoke();
    }

    private void PlayerRankDetection()
    {
        for (int i = 0; i < runnerZLocations.Length - 1; i++)
        {
            runnerZLocations[i] = opponents[i].transform.position.z;
        }
        runnerZLocations[runnerZLocations.Length - 1] = playerGO.transform.position.z;
        ShellSort.Float_ShellSort(runnerZLocations, runnerZLocations.Length);
        Array.Reverse(runnerZLocations);
        for (int i = 0; i < runnerZLocations.Length; i++)
        {
            if (playerGO.transform.position.z == runnerZLocations[i] && isRaceFinished == false)
                PlayerRank = (i + 1);
        }
    }

    public int GetRank(Vector3 loc)
    {
        for (int i = 0; i < runnerZLocations.Length; i++)
        {
            if (playerGO.transform.position.z == runnerZLocations[i])
                return (i + 1);
        }
        return 0;
    }
}
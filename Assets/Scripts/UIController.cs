using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameObject rankImage;
    private GameObject rankText;
    private GameObject endGameScreen;

    // Start is called before the first frame update
    private void Start()
    {
        rankImage = GameObject.Find("rankImage");
        rankText = GameObject.Find("rankText");
        endGameScreen = GameObject.Find("EndGameScreen");
        endGameScreen.SetActive(false);
        GameManager.Instance.OnPaintFinished += GameManager_OnPaintFinished;
    }

    private void GameManager_OnPaintFinished()
    {
        endGameScreen.SetActive(true);
        rankImage.SetActive(false);
        rankText.SetActive(false);
        endGameScreen.transform.Find("EndGamePanel").GetComponent<EndGamePanel>().Setup();
    }
}
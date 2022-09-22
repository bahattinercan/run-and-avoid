using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        MySceneManager.LoadScene("Gameplay");
    }
}
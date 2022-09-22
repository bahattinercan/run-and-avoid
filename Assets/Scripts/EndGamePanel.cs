using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public Image[] starImages;
    public Image raceMedalImage;
    public Image paintMedalImage;

    public void Setup()
    {
        int playerRank = GameManager.Instance.PlayerRank;
        int raceStar= 0;
        int paintStar= 0;
        switch (playerRank)
        {
            case 1:
                raceMedalImage.sprite = GameAssets.Instance.goldMedal;
                raceStar = 3;
                break;
            case 2:
                raceMedalImage.sprite = GameAssets.Instance.silverMedal;
                raceStar = 2;
                break;
            default:
                raceMedalImage.sprite = GameAssets.Instance.bronzeMedal;
                raceStar = 1;
                break;
        }
        int percentageOfPaint = GameManager.Instance.PercentageOfPaint;
        if (percentageOfPaint > 95)
        {
            paintMedalImage.sprite = GameAssets.Instance.goldMedal;
            paintStar = 3;
        }else if (percentageOfPaint > 80)
        {
            paintMedalImage.sprite = GameAssets.Instance.silverMedal;
            paintStar = 2;
        }
        else
        {
            paintMedalImage.sprite = GameAssets.Instance.bronzeMedal;
            paintStar = 1;
        }

        if (paintStar + raceStar == 6) // 3 star
        {
            for (int i = 0; i < 3; i++)
            {
                starImages[i].sprite = GameAssets.Instance.star;
                starImages[i].gameObject.GetComponent<Animator>().Play("starFilled");
            }
        }else if (paintStar + raceStar >= 4) // 2 star
        {
            for (int i = 0; i < 2; i++)
            {
                starImages[i].sprite = GameAssets.Instance.star;
                starImages[i].gameObject.GetComponent<Animator>().Play("starFilled");
            }
        }
        else // 1 star
        {
            for (int i = 0; i < 1; i++)
            {
                starImages[i].sprite = GameAssets.Instance.star;
                starImages[i].gameObject.GetComponent<Animator>().Play("starFilled");
            }
        }
    }

    public void NextLevelButton()
    {
        MySceneManager.LoadSameScene();
    }

    public void RestartButton()
    {
        MySceneManager.LoadSameScene();
    }

    public void MenuButton()
    {
        MySceneManager.LoadScene("MainMenu");
    }
}
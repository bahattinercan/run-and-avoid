using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;

    public static GameAssets Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameAssets>("GameAssets");
            }
            return instance;
        }
    }

    public Transform confettiP;
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;
    public Sprite star;
    public AudioClip clapAudio;
}
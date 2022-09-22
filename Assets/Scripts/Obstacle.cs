using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MySceneManager.LoadSameScene();
        }else if (other.CompareTag("Opponent"))
        {
            other.transform.position = GameManager.Instance.startPoint.position;
        }
    }
}
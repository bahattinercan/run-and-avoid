using UnityEngine;
using TMPro;
public class TimerText : MonoBehaviour
{
    private bool canStart=false;
    private TextMeshProUGUI text;
    private float startTime;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        startTime= GameManager.Instance.paintTime;
        GameManager.Instance.OnRaceFinished += OnRaceFinished;
    }

    private void OnRaceFinished()
    {
        canStart = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canStart==true)
        {
            startTime -= Time.deltaTime;
            text.text = startTime.ToString("F0")+"!";
            if(startTime<=0)
            {
                GameManager.Instance.OnPaintFinished_Invoke();
                Destroy(gameObject);
            }            
        }
    }
}
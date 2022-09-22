using UnityEngine;
using TMPro;
public class StartTimerText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float startTime;
    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        startTime = 3;
    }

    // Update is called once per frame
    private void Update()
    {
        startTime -= Time.deltaTime;
        text.text = startTime.ToString("F0") + "!";
        if (startTime <= 0)
        {
            GameManager.Instance.OnRaceStarted_Invoke();
            Destroy(gameObject);
        }
    }
}
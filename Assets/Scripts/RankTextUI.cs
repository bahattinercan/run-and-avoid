using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RankTextUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = GameManager.Instance.PlayerRank.ToString();
    }
}

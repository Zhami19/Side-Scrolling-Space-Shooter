using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text counter;
    private int killCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter.text = "Kills: " + killCount;
    }

    public void UpdateKillCount()
    {
        killCount++;
        counter.text = "Kills: " + killCount.ToString();
    }
}

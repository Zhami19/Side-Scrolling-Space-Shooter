using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject youWin;
    [SerializeField] GameObject youLose;
    [SerializeField] TMP_Text counter;

    private int killCount = 0;

    public UnityEvent OnWin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        youWin.SetActive(false);
        youLose.SetActive(false);
        counter.text = "Kills: " + killCount;
    }

    private void Update()
    {
        if (killCount == 20)
        {
            YouWin();
        }
    }

    public void UpdateKillCount()
    {
        killCount++;
        counter.text = "Kills: " + killCount.ToString();
    }

    public void YouWin()
    {
        Time.timeScale = 0f;
        youWin.SetActive(true);
        OnWin.Invoke();
    }

    public void YouLose()
    {
        Time.timeScale = 0f;
        youLose?.SetActive(true);
    }
}

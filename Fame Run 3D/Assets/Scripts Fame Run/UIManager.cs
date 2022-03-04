using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    [Header("Canvas System")]
    [SerializeField] private GameObject taptoStart;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelWin;

    [SerializeField] private GameObject ActiveScore;
    private int totalScore;

    private void OnStart()
    {
        taptoStart.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void OnWin()
    {
        mainPanel.SetActive(false);

        if (panelLose.activeSelf == false)
        {
            panelWin.SetActive(true);
        }
    }

    private void OnLose()
    {

        mainPanel.SetActive(false);

        if (panelWin.activeSelf == false)
        {
            panelLose.SetActive(true);
        }
    }

    public void UpdateScore(int addingScore)
    {
        totalScore += addingScore;
        ActiveScore.GetComponent<Text>().text = "" + totalScore.ToString();
    }

    private void OnEnable()
    {
        GameManager.OnGameStart += OnStart;
        GameManager.OnGameWin += OnWin;
        GameManager.OnGameLose += OnLose;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= OnStart;
        GameManager.OnGameWin -= OnWin;
        GameManager.OnGameLose -= OnLose;
    }
}

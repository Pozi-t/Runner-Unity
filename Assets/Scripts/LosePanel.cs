using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] Text recordText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text pauseScoreText;

    private void Start()
    {
        SetRecord();
    }

    public void SetRecord()
    {
        int lastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int recordScore = PlayerPrefs.GetInt("recordScore");
        if (recordScore < lastRunScore)
        {
            Debug.Log("recordScore " + recordScore);
            Debug.Log("lastRunScore " + lastRunScore);

            recordScore = lastRunScore;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = recordScore.ToString();
        }
        else
            recordText.text = "Best Record : " + recordScore.ToString();
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        pauseScoreText.text = "Now score " + scoreText.text;
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }
}

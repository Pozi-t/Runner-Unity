using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Button musicButton;
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        if (PlayerPrefs.GetString("Music") == "No")
        {
            musicButton.GetComponent<Image>().sprite = musicOff;
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOn;
            GetComponent<AudioSource>().Play();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadURL()
    {
        Application.OpenURL("https://dec.nure.ua/b3k-full-time-spring-2022/");
    }
    public void MusicWork()
    {
        if (PlayerPrefs.GetString("Music") == "No")
        {
            PlayerPrefs.SetString("Music", "Yes");
            musicButton.GetComponent<Image>().sprite = musicOn;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            PlayerPrefs.SetString("Music", "No");
            musicButton.GetComponent<Image>().sprite = musicOff;
            GetComponent<AudioSource>().Stop();
        }
    }
}

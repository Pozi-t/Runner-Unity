using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopController : MonoBehaviour
{
    private bool[] StockCheck;
    [SerializeField] private Skin[] skins;

    [SerializeField] private Text coinsText;
    [SerializeField] private Text costText;
    [SerializeField] private GameObject player;
    [SerializeField] private Button buyButton;

    public int index;
    public int coins;
    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenSkin");
        coinsText.text = coins.ToString();

        StockCheck = new bool[skins.Length];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");
        else StockCheck[0] = true;

        skins[index].isChoisen = true;

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].inStok = StockCheck[i];
            if (i == index)
                player.GetComponent<SkinnedMeshRenderer>().material = skins[i].material;
        }
        costText.text = "CHOSEN";
        buyButton.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray",StockCheck);
    }

    private void Start()
    {

        if (PlayerPrefs.GetString("Music") == "Yes")
            GetComponent<AudioSource>().Play();
        else GetComponent<AudioSource>().Stop();
    }
    public void LeftSwap()
    {
        if (index > 0)
        {
            index--;
            if (skins[index].isChoisen && skins[index].inStok)
            {
                costText.text = "CHOSEN";
                buyButton.interactable = false;
            }
            else if (!skins[index].isChoisen && skins[index].inStok)
            {
                costText.text = "CHOOSE";
                buyButton.interactable = true;
            }
            else
            {
                costText.text = skins[index].cost.ToString();
                buyButton.interactable = true;
            }
            player.GetComponent<SkinnedMeshRenderer>().material = skins[index].material;
        }
    }
    public void RightSwap()
    {
        if (index < skins.Length - 1)
        {
            index++;
            if (skins[index].isChoisen && skins[index].inStok)
            {
                costText.text = "CHOSEN";
                buyButton.interactable = false;
            }
            else if (!skins[index].isChoisen && skins[index].inStok)
            {
                costText.text = "CHOOSE";
                buyButton.interactable = true;
            }
            else
            {
                costText.text = skins[index].cost.ToString();
                buyButton.interactable = true;
            }
            player.GetComponent<SkinnedMeshRenderer>().material = skins[index].material;
        }
    }
    public void BuyButtonAction()
    {
        if (buyButton.interactable && !skins[index].inStok)
        {
            if(coins > skins[index].cost)
            {
                coins -= skins[index].cost;
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                skins[index].inStok = true;
                costText.text = "CHOOSE";
                Save();
            }
        }
        if (buyButton.interactable && !skins[index].isChoisen && skins[index].inStok)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyButton.interactable = false;
            costText.text = "CHOSEN";
            for (int i = 0; i < skins.Length; i++)
            {
                if(i == index) skins[i].isChoisen = true;
                else skins[i].isChoisen = false;
                
            }
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

[System.Serializable]
public class Skin
{
    public int cost;
    public bool inStok;
    public bool isChoisen;
    public Material material;
}

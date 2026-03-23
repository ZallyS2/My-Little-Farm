using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    public List<Image> toolsUI = new List<Image>();
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image pickaxetUI;
    //[SerializeField] private Image swordUI;
    //[SerializeField] private Image rodUI;
    //[SerializeField] private Image waterUI;
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private Itens playerItens;
    private Player player;


    private void Awake()
    {
        playerItens = FindObjectOfType<Itens>();
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0;
        woodUIBar.fillAmount = 0;
        carrotUIBar.fillAmount = 0;
    }


    void Update()
    {
        UpdateObjs();
        CurrentObjs();
    }

    void UpdateObjs()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.TotalWaterMax;
        woodUIBar.fillAmount = playerItens.currentWoods / playerItens.TotalHoodsMax;
        carrotUIBar.fillAmount = playerItens.carrots / playerItens.CarrotsMax;
    }


    void CurrentObjs()
    {
        for(int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.HandlingObj - 1)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtCost;


    /// <summary>
    /// カレンシーの表示更新
    /// </summary>
    public void UpdateDisplayCurrency()
    {

        txtCost.text = GameData.instance.currency.ToString();
    }
}
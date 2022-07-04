using UnityEngine;
using System;

/// <summary>
/// キャラの詳細データ
/// </summary>
[System.Serializable]
public class CharaData
{
    public int charaNo;
    public int cost;
    public Sprite charaSprite;
    public string charaName;

    public int attackPower;
    public AttackRangeType attackRange;
    public float intervalAttackTime;
    public int maxAttackCount;

    [Multiline]
    public string discription;

    // TODO 他にもあれば追加


    public CharaData(string[] datas)
    {
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }
        charaNo = int.Parse(datas[0]);
        cost = int.Parse(datas[1]);
        charaName = datas[2];
        attackPower=int.Parse(datas[3]);
        attackRange=(AttackRangeType)Enum.Parse(typeof(AttackRangeType), datas[4]);
        intervalAttackTime=float.Parse(datas[5]);
        maxAttackCount= int.Parse(datas[6]);
        discription=datas[7];
    }
}
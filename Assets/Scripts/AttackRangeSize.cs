using UnityEngine;
using System;

[System.Serializable]
public class AttackRangeSize
{
    public AttackRangeType attackRangeType;
    public Vector2 size;


    public AttackRangeSize(string[] datas)
    {
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }
        attackRangeType = (AttackRangeType)Enum.Parse(typeof(AttackRangeType), datas[0]);
        size =new Vector2(float.Parse(datas[1]),float.Parse(datas[2]));
    }
}

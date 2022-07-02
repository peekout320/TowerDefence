using UnityEngine;

/// <summary>
/// キャラの詳細データ
/// </summary>
[System.Serializable]
public class CharaDate
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

}

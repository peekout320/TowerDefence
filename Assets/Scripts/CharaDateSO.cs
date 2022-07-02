using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaDateSO", menuName = "Create CharaDateSO")]
public class CharaDateSO : ScriptableObject
{
    public List<CharaDate> charaDatasList = new List<CharaDate>();
}
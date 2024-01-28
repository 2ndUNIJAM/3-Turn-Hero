using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ArmorDataSO", menuName = "Scriptable Object/ArmorDataSO")]
public class ArmorDataSO : ScriptableObject
{
    [SerializeField] private string engName;
    public string EngName => engName;

    [SerializeField] private string korName;
    public string KorName => korName;

    [SerializeField] private string descript;
    public string Descript => descript;
    [SerializeField] private Image icon;
    public Image Icon => icon;

    [SerializeField] private string armorType;
    public string ArmorType => armorType;

    [SerializeField] private string elementType;
    public string ElementType => elementType;

    [SerializeField] private int def;
    public int DEF => def;

    [SerializeField] private int moveSpeed;
    public int MoveSpeed => moveSpeed;

    [SerializeField] private int attackSpeed;
    public int AttackSpeed => attackSpeed;

    [SerializeField] private string rarity;
    public string Rarity => rarity;

    [SerializeField] private float possibility;
    public float Possibility => possibility;
}

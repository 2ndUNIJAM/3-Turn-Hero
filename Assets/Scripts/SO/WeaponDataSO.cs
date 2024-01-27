using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Object/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private string engName;
    public string EngName => engName;

    [SerializeField] private string korName;
    public string KorName => korName;

    [SerializeField] private string descript;
    public string Descript => descript;

    [SerializeField] private string weaponType;
    public string WeaponType => weaponType;

    [SerializeField] private string elementType;
    public string ElementType => elementType;

    [SerializeField] private int atk;
    public int ATK => atk;

    [SerializeField] private int atkSpeed;
    public int ATKSpeed => atkSpeed;

    [SerializeField] private string rarity;
    public string Rarity => rarity;

    [SerializeField] private float possibility;
    public float Possibility => possibility;

}
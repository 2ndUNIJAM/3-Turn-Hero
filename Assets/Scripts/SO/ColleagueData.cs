using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColleagueDataSO", menuName = "Scriptable Object/ColleagueDataSO")]
public class ColleagueDataSO : ScriptableObject
{
    [SerializeField] private string engName;
    public string EngName => engName;

    [SerializeField] private string korName;
    public string KorName => korName;

    [SerializeField] private string descript;
    public string Descript => descript;
    [SerializeField] private Image icon;
    public Image Icon => icon;

    [SerializeField] private int count;
    public int Count => count;

    [SerializeField] private string gender;
    public string Gender => gender;

    [SerializeField] private float possibility;
    public float Possibility => possibility;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    #region GoogleSheet URL

    private readonly string jemSO_GoogleSheetURL
        = "https://docs.google.com/spreadsheets/d/1Fh8iJE6lMugm5JWjn0CIw6rMHPVDZZ563tqRBai_o_4/export?format=tsv&range=A3:D";

    #endregion

    public void Init()
    {
        DownloadAllSO();
    }

    public void DownloadAllSO()
    {
        StartCoroutine(DownloadItemSO());
    }

    IEnumerator DownloadItemSO()
    {
        UnityWebRequest www = UnityWebRequest.Get(jemSO_GoogleSheetURL);
        yield return www.SendWebRequest();

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log($"Network Error! ItemSOList are not Downloaded. [Error: {www.error}]");
            yield break;
        }

        LoadJemSO(www.downloadHandler.text);
    }

    private void LoadJemSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] columns = row[i].Split("\t");
            ParseJemSO(GameManager.Data.JemSOList[i], columns);
        }
    }

    private void ParseJemSO(JemSO jemSO, string[] columns)
    {
        JemStat stat = new JemStat();
        string name = columns[0];
        string info = columns[1];
        long price = long.Parse(columns[2]);
        stat.Init(columns[3].Trim()); // 마지막 \n 제거

        jemSO.Init(name, info, price, stat);
    }
}

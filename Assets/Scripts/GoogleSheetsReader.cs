using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsReader : MonoBehaviour
{
    string _googleSheetsURL = "https://script.google.com/macros/s/AKfycbwsg8aJZA7QNEYR6EGjY3y0mJg_LTwDDo2A-mRzlHTJCuGpcFapNQM7TonKAaIzM3U/exec";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadGoogleSheetsData());
    }
    private IEnumerator DownloadGoogleSheetsData()
    {
        using(UnityWebRequest www = UnityWebRequest.Get(_googleSheetsURL))
        {
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string json = www.downloadHandler.text;

                GoogleSheetsData sheetsData = JsonUtility.FromJson<GoogleSheetsData>(json);
            }
        }
    }
}
[System.Serializable]
public class GoogleSheetsData
{
    public GoogleSheetItem[] data;
}
[System.Serializable]
public class GoogleSheetItem
{
    public string No;
    public string Name;
    public string ’e‚Ì–¼‘O;
    public string ”­ŽË‘¬“x;
}

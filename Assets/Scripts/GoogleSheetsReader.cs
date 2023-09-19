using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsReader : MonoBehaviour
{
    string _googleSheetsURL = "https://script.google.com/macros/s/AKfycbxOL_iis2_ciy4qWwBAaQ4sFJveidaeZg1U4VymfOBjpXc_cEkoYx7Vjb-J7I6LlOx9/exec";
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

                json = "{\"data\": " + json + "}";
                Debug.Log(json);

                GoogleSheetsData sheetsData = JsonUtility.FromJson<GoogleSheetsData>(json);

                // GoogleSheetsManagerにデータをセット
                GoogleSheetsManager manager = GoogleSheetsManager.GetInstance();
                manager._sheetsData = sheetsData;
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
    public int No;
    public string Name;
    public string 弾の名前;
    public int 発射速度;
}

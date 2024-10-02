using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsReader : MonoBehaviour
{
    string _googleSheetsURL = "https://script.google.com/macros/s/AKfycbyeqFOG51pbmi3YRhN2EE8CpJNkZ1_5aTswC8ytlcLrpgtijTc5u8hyNTbbcRRVXgBh/exec";

    bool _isLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadGoogleSheetsData());
    }
    private IEnumerator DownloadGoogleSheetsData()
    {
        _isLoaded = false;
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

                // GoogleSheetsManager�Ƀf�[�^���Z�b�g
                GoogleSheetsManager manager = GoogleSheetsManager.GetInstance();
                manager._sheetsData = sheetsData;
                _isLoaded = true;
            }
        }
    }

    public bool IsDataLoading()
    {
        return _isLoaded;
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
    public string �e�̖��O;
    public int ���ˑ��x;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;
using System;

//{"type":"general","setup":"Why are pirates called pirates?","punchline":"Because they arrr!","id":304}
[Serializable]
public class Joke
{
    public int id;
    public string type;
    public string setup;
    public string punchline;

}

public class RequestDb : MonoBehaviour
{
    private string url = "https://official-joke-api.appspot.com";
    private string jsonData;

    void Start()
    {

        StartCoroutine(GetRequest(url + "/random_joke"));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                ReadData(uwr);
            }
        }

    }


    private void ReadData(UnityWebRequest uwr)
    {
        string json = uwr.downloadHandler.text;

        Debug.Log(JsonUtility.FromJson<Joke>(json).setup);
        Debug.Log(JsonUtility.FromJson<Joke>(json).punchline);
    }


}

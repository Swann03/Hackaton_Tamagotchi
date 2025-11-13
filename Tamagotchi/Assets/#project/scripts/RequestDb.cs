using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

//{"type":"general","setup":"Why are pirates called pirates?","punchline":"Because they arrr!","id":304}
[Serializable]
public struct Depenses
{
    public Depense[] member;
    public int totalItems;
}

[Serializable]
public struct Depense
{

    public string typeDepense;
    public string id;

}

public class RequestDb : MonoBehaviour
{
    private string url = "https://pitifully-ticketless-fabiola.ngrok-free.dev/api";
    private string jsonData;

    void Start()
    {

        StartCoroutine(GetRequest(url + "/depenses"));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url))  //--> pourquoi un usign ici ?
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
        jsonData = uwr.downloadHandler.text;
        Depenses data = JsonUtility.FromJson<Depenses>(jsonData);
        Debug.Log(data.totalItems);  //--> ligne à décortiquer
        Debug.Log(data.member[0].@id);
    }

 
}

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;


[Serializable]
public struct Depenses
{
    public Member[] member;
    public int totalItems;
}

[Serializable]
public struct Member
{

    public string id;
    public string typeDepense;
    public int montant;
    public string dateDepense;
    public string personnage;

}

public class RequestDb : MonoBehaviour
{
    private string url = "https://pitifully-ticketless-fabiola.ngrok-free.dev/api";
    private string jsonData;
    private List<string> differentAccess = new List<string> { "/depenses", "/evenements", "personnages"};

    void Start()
    {

        StartCoroutine(GetRequest(url + differentAccess[0]));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url)) //necessary to open and close access
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

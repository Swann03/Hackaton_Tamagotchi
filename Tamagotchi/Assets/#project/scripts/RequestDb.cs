using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;


//                      --DEPENSES
[Serializable]
public struct Depenses
{
    public MemberDepense[] member;
    public int totalItems;
}

[Serializable]
public struct MemberDepense
{
    public int id;
    public int montant;
    public string typeDepense;
    public string dateDepense;
    public string personnage;

}

[Serializable]
public struct MemberEvenement
{
    public int id;
    public string nomEvenement;
    public string description;
    public string personnage;
}


//                      --EVENEMENTS

[Serializable]
public struct Evenements
{
    public int totalItems;
    public MemberEvenement[] member;
}




//                      --PERSONNAGES
[Serializable]
public struct MemberPersonnage
{
    public int id;
    public string nom;
    public int enfant;
    public int revenuHebdo;
}

[Serializable]
public struct Personnages
{
    public int totalItems;
    public MemberPersonnage[] memberPersonnages;

}





public class RequestDb : MonoBehaviour
{
    private string url = "https://pitifully-ticketless-fabiola.ngrok-free.dev/api";
    private string jsonDataDepenses;
    private string jsonDataEvent;
    private string jsonDataPersonnages;

    public Depenses depenseData;
    public Evenements eventData;
    public Personnages personnageData;

    private bool depenseIsReady;
    private bool eventIsReady;
    private bool personnageIsReady;

    public bool isReady => depenseIsReady && eventIsReady && personnageIsReady; 

    //private List<string> differentAccess = new List<string> { "/depenses", "/evenements", "personnages" };

    void Awake()
    {
        StartCoroutine(GetRequestDepenses(url));
        StartCoroutine(GetRequestEvent(url));
        StartCoroutine(GetRequestPersonnage(url));
    }

    IEnumerator GetRequestDepenses(string url)
    {
        depenseIsReady = false;
        string urlDepenses = url + "/depenses";
        using (UnityWebRequest uwr = UnityWebRequest.Get(urlDepenses)) //necessary to open and close access
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                depenseData = ReadData<Depenses>(uwr);
                depenseIsReady = true;
            }
        }

    }

    IEnumerator GetRequestEvent(string url)
    {
        eventIsReady = false;
        string urlDepenses = url + "/evenements";
        using (UnityWebRequest uwr = UnityWebRequest.Get(urlDepenses)) //necessary to open and close access
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                eventData = ReadData<Evenements>(uwr);
                eventIsReady = true;
            }
        }

    }

    IEnumerator GetRequestPersonnage(string url)
    {
        personnageIsReady = false;
        string urlDepenses = url + "/personnages";
        using (UnityWebRequest uwr = UnityWebRequest.Get(urlDepenses)) //necessary to open and close access
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                personnageData = ReadData<Personnages>(uwr);
                personnageIsReady = true;
            }
        }

    }


    private T ReadData<T>(UnityWebRequest uwr)
    {
        jsonDataDepenses = uwr.downloadHandler.text;
        T data = JsonUtility.FromJson<T>(jsonDataDepenses);
        return data;
    
    }



}

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;


//                      --DEPENSES
[Serializable]
public struct Depenses
{
    public Member[] member;
    public int totalItems;
}

[Serializable]
public struct Member
{
    public int id;
    public int montant;
    public string typeDepense;
    public string dateDepense;
    public string personnage;
    public string nomEvenement;
    public string description;
    public string nom;
    public int enfant;
    public int revenuHebdo;


}


//                      --EVENEMENTS

[Serializable]
public struct Evenements
{
    public int totalItems;
    public Member[] memberEvenements;
}


// [Serializable]
// public struct MemberEvenements
// {
//     public int id;
//     public string nomEvenement;
//     public string description;
//     public string personnage;
// }




//                      --PERSONNAGES
[Serializable]
public struct Personnages
{
    public int totalItems;
    public Member[] memberPersonnages;

}

// [Serializable]
// public struct MemberPersonnages
// {
//     public int id;
//     public string nom;
//     public int enfant;
//     public int revenuHebdo;
// }




public class RequestDb : MonoBehaviour
{
    private string url = "https://pitifully-ticketless-fabiola.ngrok-free.dev/api";
    private string jsonDataDepenses;
    private string jsonDataEvent;
    private string jsonDataPersonnages;
    private List<string> differentAccess = new List<string> { "/depenses", "/evenements", "personnages" };

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
        jsonDataDepenses = uwr.downloadHandler.text;
        Depenses dataDepenses = JsonUtility.FromJson<Depenses>(jsonDataDepenses);
        Debug.Log(dataDepenses.member[1].montant);
        Debug.Log(dataDepenses.member[1].typeDepense);
        

        // jsonDataEvent = uwr.downloadHandler.text;

        // Evenements dataEvent = JsonUtility.FromJson<Evenements>(jsonDataEvent);
        // Debug.Log(dataEvent.memberEvenements.nomEvenement);
    }



}

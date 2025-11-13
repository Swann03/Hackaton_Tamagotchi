using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

//{"type":"general","setup":"Why are pirates called pirates?","punchline":"Because they arrr!","id":304}
[Serializable]
public struct Joke
{
    //public int id;
   // public string type;
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
        Joke reallyGoodJoke = JsonUtility.FromJson<Joke>(jsonData);
        Debug.Log(reallyGoodJoke.setup);  //--> ligne à décortiquer
        Debug.Log(reallyGoodJoke.punchline);
    }

 
}

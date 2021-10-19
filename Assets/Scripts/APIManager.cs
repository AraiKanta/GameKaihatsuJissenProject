using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
    private static APIManager m_apiManagerInstance;

    public static APIManager Instance
    {
        get
        {
            if (m_apiManagerInstance == null)
            {
                GameObject singleton = new GameObject();
                m_apiManagerInstance = singleton.AddComponent<APIManager>();
                singleton.name = "(SingletonMonoBehaviour) APIManager";

                DontDestroyOnLoad(singleton);
            }
            return m_apiManagerInstance;
        }
    }

    private APIManager()
    {

    }

    /// <summary>
    /// API　ゲット通信
    /// </summary>
    /// <param name="getPath"></param>
    /// <param name="callBack"></param>
    public void Get(string getPath, Action callBack)
    {
        StartCoroutine(MonsterGetApi(getPath, callBack));

        StartCoroutine(FiledGetApi(getPath, callBack));
    }

    public void Post(WWWForm wWWForm, string postPath, Action callBack)
    {
        StartCoroutine(PostApi(wWWForm, postPath, callBack));
    }

    /// <summary>
    /// API　ゲット通信
    /// </summary>
    /// <param name="getPath"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    IEnumerator MonsterGetApi(string getPath, Action callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(getPath);
        Debug.Log("ゲット通信\n" + getPath);

        yield return webRequest.SendWebRequest();

        callBack?.Invoke();

        var json = webRequest.downloadHandler.text;

        Debug.Log("json" + json);

        var model = JsonUtility.FromJson<MonsterModel>(json);

        Debug.Log("model" + model.MonsterName);
    }

    /// <summary>
    /// API　ゲット通信
    /// </summary>
    /// <param name="getPath"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    IEnumerator FiledGetApi(string getPath, Action callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(getPath);
        Debug.Log("ゲット通信\n" + getPath);

        yield return webRequest.SendWebRequest();

        callBack?.Invoke();

        var json = webRequest.downloadHandler.text;

        Debug.Log("json" + json);

        var model = JsonUtility.FromJson<FiledModel>(json);

        Debug.Log("model");
    }

    /// <summary>
    /// API　Post通信
    /// </summary>
    /// <param name="getPath"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    IEnumerator PostApi(WWWForm wWWForm, string postPath, Action callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post(postPath, wWWForm);
        Debug.Log("ポスト通信\n" + postPath + wWWForm);

        yield return webRequest.SendWebRequest();

        callBack?.Invoke();

        var json = webRequest.downloadHandler.text;
        Debug.Log(json);
    }
}

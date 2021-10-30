using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetDataFromServer : MonoBehaviour
{

    private string _serverDataSourceUri = VariablesData.GetDataSourceUri();


    private void Start()
    {
        StartCoroutine(LoadTextFromServer(_serverDataSourceUri));
        StartCoroutine(LoadServerData());
    }

    IEnumerator LoadTextFromServer(string url)
    {
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            VariablesData.SetTruckInFieldData(request.downloadHandler.text);

            Debug.Log(request.downloadHandler.text);

        }

        request.Dispose();
    }



    private IEnumerator LoadServerData()
    {
        while (true)
        {
            StartCoroutine(LoadTextFromServer(_serverDataSourceUri));
            yield return new WaitForSecondsRealtime(30f);
        }

    }






}

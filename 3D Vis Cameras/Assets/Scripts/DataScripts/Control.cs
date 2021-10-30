using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{

    [SerializeField] GameObject _textPanel;

    private Text _textOnPanel;


    private float _interval = VariablesData.GetUpdateInterval();


    private void Start()
    {

        //_textOnPanel = _textPanel.GetComponent<Text>();
        // _textOnPanel = _textPanel.GetComponent<Text>();

        StartCoroutine(ShowServerData1());
        StartCoroutine(ShowServerData());
        // SetTruck();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }


    private IEnumerator ShowServerData()
    {
        while (true)
        {
            var textFromServer = VariablesData.GetTruckInFieldData();
            
            if (textFromServer != null)
            {
                _textOnPanel = _textPanel.GetComponent<Text>();
                _textOnPanel.text = textFromServer;
            }
            yield return new WaitForSecondsRealtime(3f);
        }

    }


    private IEnumerator ShowServerData1()
    {

            var textFromServer = VariablesData.GetTruckInFieldData();

            if (textFromServer != null)
            {
                _textOnPanel = _textPanel.GetComponent<Text>();
                _textOnPanel.text = textFromServer;
            }
            yield return new WaitForSecondsRealtime(1f);


    }










}

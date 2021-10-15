using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{

    [SerializeField] GameObject _truck;
    [SerializeField] GameObject _truckText;

    [SerializeField] float _stepPositionAppearTruck = 10f;




    private float _interval = VariablesData.GetUpdateInterval();
    private string _infoFromServer;
    private float _stepXtruckGeneration = VariablesData.GetStepXtruckGeneration();
    private float _stepYtruckGeneration = VariablesData.GetStepYtruckGeneration();


    private void Start()
    {
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
            _stepXtruckGeneration = VariablesData.GetStepXtruckGeneration();

            if (VariablesData.GetTruckInFieldData() != null)
            {

                string[] trucks_in_queue = VariablesData.GetTruckInFieldData().Split(',');

                foreach (var one_truck in trucks_in_queue)
                {
                    string[] trucks_in_queue_item = one_truck.Split(':');

                    SetTruck(trucks_in_queue_item[1], trucks_in_queue_item[0]);
                }
            }



            

            yield return new WaitForSecondsRealtime(_interval);
        }

    }



    void SetTruck(string gosNomer, string docPrefix)
    {
        // позиция куда пихаем машины
        Vector3 _respaunPosition = GameObject.Find("Respaun1").transform.position;
        Quaternion _respaunRotation = GameObject.Find("Respaun1").transform.rotation;

        // текст на машину
        GameObject truckText = Instantiate(_truckText, _respaunPosition, _respaunRotation) as GameObject;
        truckText.GetComponent<TextMesh>().text = gosNomer + ' ' + docPrefix;
        truckText.transform.Rotate(0, 180, 0);

        // машина
        GameObject truck = Instantiate(_truck, _respaunPosition, _respaunRotation) as GameObject;

        // прилепили текст
        //Sets "newParent" as the new parent of the player GameObject.
        truckText.transform.SetParent(truck.transform);
        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        // player.transform.SetParent(newParent, false);


        Rigidbody truckRigitBody = truck.GetComponent<Rigidbody>();
        // truck.transform.Rotate(0, 180, 0);
        // truckRigitBody.transform.Rotate(0, 180, 0);

        // truck.transform.Translate(Vector3.right * Random.Range(0, 0));



        // Y coord
        var startYcoord = _stepYtruckGeneration;

        if (docPrefix.Equals("TAN"))
        {
            startYcoord = _stepYtruckGeneration - 12f;
            truck.transform.Translate(Vector3.left * startYcoord);
        } 
        else if (docPrefix.Equals("SYN"))
        {
            startYcoord = _stepYtruckGeneration -6f;
            truck.transform.Translate(Vector3.left * startYcoord);
        } 
        else if (docPrefix.Equals("NLU"))
        {
            startYcoord = _stepYtruckGeneration + 0f;
            truck.transform.Translate(Vector3.left * startYcoord);
        } 
        else if (docPrefix.Equals("PDB"))
        {
            startYcoord = _stepYtruckGeneration + 6f;
            truck.transform.Translate(Vector3.left * startYcoord);
        } 
        else if (docPrefix.Equals("ZAS"))
        {
            startYcoord = _stepYtruckGeneration + 12f;
            truck.transform.Translate(Vector3.left * startYcoord);
        }
        // _stepYtruckGeneration = _stepYtruckGeneration + 1f;


        // X coord
        truck.transform.Translate(Vector3.forward * _stepXtruckGeneration);
        _stepXtruckGeneration = _stepXtruckGeneration - _stepPositionAppearTruck;


        // add force to 
        // var _ImpulseForce = 50;
        // пока без импульяса
        // truckRigitBody.AddForce(truck.transform.forward * _ImpulseForce, ForceMode.Impulse);

        Destroy(truck, VariablesData.GetTruckLifetime());

    }












}

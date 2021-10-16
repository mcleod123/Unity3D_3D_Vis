using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{


    public GameObject go;
    public float sensitivity = 1F;
    private Camera goCamera;
    private Vector3 MousePos;
    private float MyAngle = 0F;

    private float _speed = 9f;

    void Start()
    {
        // Инициализируем кординаты мышки и ищем главную камеру
        goCamera = GetComponent<Camera>();
        //go = goCamera.transform.parent.gameObject;
    }

    void Update()
    {
        MousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;

            MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, MyAngle);

            // MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
            // goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -MyAngle);

            // --------
            //MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
            //goCamera.transform.Rotate(go.transform.position.x, goCamera.transform.right.y, -MyAngle);


        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Motion(Vector3.right, _speed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Motion(Vector3.left, _speed);
        }



        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Motion(Vector3.forward, _speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Motion(Vector3.back, _speed);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            Motion(Vector3.up, _speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Motion(Vector3.down, _speed);
        }



    }




    private void Motion(Vector3 direction, float localSpeed)
    {


        if (direction.Equals(Vector3.right))
        {
            transform.Translate(Vector3.right * localSpeed * Time.deltaTime);
        }

        if (direction.Equals(Vector3.left))
        {
            transform.Translate(Vector3.left * localSpeed * Time.deltaTime);
        }


        if (direction.Equals(Vector3.back))
        {
            transform.Translate(Vector3.back * localSpeed * Time.deltaTime);
        }

        if (direction.Equals(Vector3.forward))
        {
            transform.Translate(Vector3.forward * localSpeed * Time.deltaTime);
        }


        if (direction.Equals(Vector3.up))
        {
            transform.Translate(Vector3.up * localSpeed * Time.deltaTime);
        }

        if (direction.Equals(Vector3.down))
        {
            transform.Translate(Vector3.down * localSpeed * Time.deltaTime);
        }


    }





}

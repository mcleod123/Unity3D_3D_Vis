using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    [SerializeField] private FixedJoint _jointToDestroy;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            StartCollisions();
            /*
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Event");
            }
            */

        }

    }


    private void StartCollisions()
    {
        GameObject sphere = GameObject.Find("Sphere");
        _jointToDestroy = sphere.GetComponent<FixedJoint>();
        Destroy(_jointToDestroy);
    }


}

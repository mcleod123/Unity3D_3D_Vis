using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    bool isCanBuild = true;
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (isCanBuild) 
        {
            isCanBuild = false;
            Instantiate(tower, transform.position, transform.rotation);
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }


    public void OnMouseUp()
    {

    }

    public void OnMouseEnter()
    {
        if(isCanBuild)
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }
    }

    public void OnMouseExit()
    {
        if(isCanBuild)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }

    }
}

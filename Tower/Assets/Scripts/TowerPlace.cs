using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    bool isCanBuild = true;
    public GameObject tower;

    private Color _emptyColor = new Color(0f, 0.7f, 0f, 0.1f);
    private Color _selectionColor = new Color(0.1f, 0.8f, 0.1f, 0.5f);

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
            // GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            GetComponent<Renderer>().material.color = _emptyColor;
        }
    }


    public void OnMouseUp()
    {

    }

    public void OnMouseEnter()
    {
        if(isCanBuild)
        {
            // GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            GetComponent<Renderer>().material.color = _selectionColor;
        }
    }

    public void OnMouseExit()
    {
        if(isCanBuild)
        {
            // GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            GetComponent<Renderer>().material.color = _emptyColor;
        }

    }
}

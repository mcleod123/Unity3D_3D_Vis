using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    private Camera camera;
    private TowerPlace currentTowerPlace;


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "TowerPlace" )
        {

            bool isMouseDown = Input.GetMouseButtonDown(0);
            bool isMouseUp = Input.GetMouseButtonUp(0);


            TowerPlace towerPlace = hit.collider.gameObject.GetComponent<TowerPlace>();

            if (isMouseDown || isMouseUp)
            {
 
                if(isMouseDown)
                {
                    towerPlace.OnMouseDown();
                } 
                else if (isMouseUp)
                {
                    towerPlace.OnMouseUp();
                }
            } 
            else
            {
                if (currentTowerPlace != towerPlace)
                {
                    if (currentTowerPlace!=null)
                    {
                        currentTowerPlace.OnMouseExit();
                    }

                    towerPlace.OnMouseEnter();
                    currentTowerPlace = towerPlace;
                }

            }

        }
        else
        {
            if (currentTowerPlace != null)
            {
                currentTowerPlace.OnMouseExit();
            }

            currentTowerPlace = null;
        }



    }
}

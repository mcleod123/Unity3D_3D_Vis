using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{

    private void OnMouseDown()
    {
        StartAll();
    }

    private void StartAll()
    {
        FixedJoint jointToDestroy = this.GetComponent<FixedJoint>();
        Destroy(jointToDestroy);

        

    }


}

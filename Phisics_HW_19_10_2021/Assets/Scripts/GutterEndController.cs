using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterEndController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        HitManager.Instance.IsHit = 1;
    }
}
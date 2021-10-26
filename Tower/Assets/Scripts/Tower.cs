using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float FindRadius = 2f;

    Enemy enemy;

    Transform towerHead;


    // Start is called before the first frame update
    void Start()
    {
        towerHead = transform.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy ==null)
        {
            // find enemies
            FindEnemy();
        }
        else
        {
            // rotate dule
            towerHead.LookAt(enemy.transform);
        }
    }

    private void FindEnemy()
    {
        var enemies = GameObject.FindObjectsOfType<Enemy>();
        float min = FindRadius;
        Enemy minEnemy = null;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);

            if( dist <= min)
            {
                min = dist;
                minEnemy = e;
            }
        }

        enemy = minEnemy;
    }
}

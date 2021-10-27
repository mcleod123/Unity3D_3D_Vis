using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float FindRadius = 2f;
    public float TimeShoot = 0.1f;
    public GameObject bullet;

    Enemy enemy;
    Transform towerHead;
    private float timerShoot = 1f;

    // Start is called before the first frame update
    void Start()
    {
        towerHead = transform.Find("Head");
    }


    private void Shoot() 
    {
        timerShoot -= Time.deltaTime;

        if(timerShoot <= 0)
        {
            timerShoot = TimeShoot;
            GameObject obj = Instantiate(bullet, towerHead.transform.position, towerHead.transform.rotation);
            Bullet b = obj.GetComponent<Bullet>();
            b.Enemy = enemy;
        }
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

            // shoot
            Shoot();

            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if(dist>FindRadius)
            {
                enemy = null;
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 15f;
    public float TimeLife = 1f;
    public Enemy Enemy;
    public float Damage = 25f;

    float timerLife = 0f;


    void Start()
    {
        timerLife = TimeLife;
    }

    void Update()
    {
        if(Enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        timerLife -= Time.deltaTime;

        Vector3 dir = Enemy.transform.position - transform.position;
        float _speed = Speed * Time.deltaTime;

        if (timerLife <= 0)
        {

            // время жизни пули закончилось
            timerLife = TimeLife;
            Destroy(gameObject);
        }
        else if (Mathf.Round(dir.magnitude) <= _speed)
        // else if (Enemy != null && (Vector3.Distance(transform.position, Enemy.transform.position) <= _speed))
        {
            if (Enemy != null)
            {
                // пул попала в ццель
                Enemy.SetDamage(Damage);
                Destroy(gameObject);
                return;
            }

        }

        transform.Translate(new Vector3(0, 0, Speed));
    }
}

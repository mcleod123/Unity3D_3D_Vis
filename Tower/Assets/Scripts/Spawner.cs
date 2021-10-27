using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // кого мы спауним
    public GameObject spawnObject;

    // че это длять такое?
    public float spawnTime = 0.3f;

    // задержка перед началом волны
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            timer = spawnTime;
        }
    }
}

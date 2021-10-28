using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // кого мы спауним
    public GameObject enemyPrefabItem;

    // задержка перед рождением объекта
    private float spawnTime = 2f;

    // задержка перед началом волны
    private float _spawnEnemyItemsInterval = 0;

    private string _spawnObjectName = "Spawner";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _spawnEnemyItemsInterval -= Time.deltaTime;

        if (_spawnEnemyItemsInterval <= 0)
        {
            Instantiate(enemyPrefabItem, transform.position, transform.rotation, GameObject.Find(_spawnObjectName).transform);
            _spawnEnemyItemsInterval = spawnTime;
        }
    }


    // отловить событие начала игры и тыкнуть картуину
    // StartCoroutine(TestCoroutine());

    /*
     
     IEnumerator TestCoroutine()
        {
	        while(true)
	        {
		        yield return null;
		        Debug.Log(Time.deltaTime);
	        }
        }
     */

}

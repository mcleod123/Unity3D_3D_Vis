using System.Collections;
using UnityEngine;



public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _enemyCatDiedEffect;

    private int EnemyDeathCost = SettingsController.EnemyDeathCost;
    private GameObject _forTrashContainer;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex = -1;
    private float life;
    private float speed = SettingsController.EnemyMovingSpeed;
    private float MaxLife = SettingsController.EnemyMaxLife;

    private float nullLife = 0;
    private int freezeCoordY = 0;
    private string _wayPointsGroup = SettingsController.EnemyWayPointsGroup;
    private float _enemyDieEffectIntervalDissaopear = SettingsController.EnemyDieEffectIntervalDissapear;

    void Start()
    {
        // waypoints = GameObject.Find("WayPoints").transform;
        waypoints = GameObject.Find(_wayPointsGroup).transform;
        _forTrashContainer = GameObject.Find(SettingsController.TrashContainerObjectName);
        NextWaypoint();
        life = MaxLife;
    }

    void Update()
    {
        Vector3 enemyMoveDirection = waypoint.transform.position - transform.position;
        enemyMoveDirection.y = freezeCoordY;

        float _speed = Time.deltaTime * speed;
        transform.Translate(enemyMoveDirection.normalized * _speed);


        if (enemyMoveDirection.magnitude <= _speed)
        {
            NextWaypoint();
        }




    }




    void NextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.childCount)
        {

            // событие при котором враг доходит до финиша и забирает жизнь игрока
            var eventData = new EnemyWasMovedToFinish() { Enemy = EnemyType.EnemyCat };
            EventAggregator.Post(this, eventData);


            Destroy(gameObject);
            return;
        }



        waypoint = waypoints.GetChild(waypointIndex);
    }

    public void SetDamage(float value)
    {
        life -= value;
        if(life <= nullLife)
        {

            // событие смерти врага, которое принесет нам денежек на счет
            var eventData = new EnemyDeathEventData() { Enemy = EnemyType.EnemyCat, EnemyDeathCost = EnemyDeathCost };
            EventAggregator.Post(this, eventData);

            // звук - убили врага котика
            AudioManager.PlaySFX(SFXType.EnemyCatDied);

            // _enemyCatDiedEffect
            //GameObject effectGameObjectToDestroy = Instantiate(_enemyCatDiedEffect, transform.position, transform.rotation);
            GameObject effectGameObjectToDestroy = Instantiate(_enemyCatDiedEffect, transform.position, transform.rotation, _forTrashContainer.transform);
            //StartCoroutine(DestroyEffectObject(effectGameObjectToDestroy));

            // убили обьект
            Destroy(gameObject);

            // удаляем эффект уничтожения котика
            Destroy(effectGameObjectToDestroy, _enemyDieEffectIntervalDissaopear);


        }
    }





}
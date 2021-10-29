using UnityEngine;



public class Enemy : MonoBehaviour
{

    private int EnemyDeathCost = SettingsController.EnemyDeathCost;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex = -1;
    private float life;
    private float speed = SettingsController.EnemyMovingSpeed;
    private float MaxLife = SettingsController.EnemyMaxLife;

    private float nullLife = 0;
    private int freezeCoordY = 0;
    private string _wayPointsGroup = SettingsController.EnemyWayPointsGroup;

    void Start()
    {
        // waypoints = GameObject.Find("WayPoints").transform;
        waypoints = GameObject.Find(_wayPointsGroup).transform;
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

            Debug.Log("КОтик вынес вам жизнь!");

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

            // убили обьект
            Destroy(gameObject);
        }
    }




}
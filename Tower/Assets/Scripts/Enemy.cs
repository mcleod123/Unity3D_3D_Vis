using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float MaxLife = 100f;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex = -1;
    private float life;
    private float nullLife = 0;
    private int freezeCoordY = 0;

    private string _wayPointsGroup = "WayPoints";

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
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    // Gamer
    public static int StartCoinsVale = 100;
    public static int CountGamersLifes = 3;



    // TowerPlace
    public static Color EmptyTowerPlaceColor = new Color(0f, 0.7f, 0f, 0.1f);
    public static Color SelectionTowerPlaceColor = new Color(0.1f, 0.8f, 0.1f, 0.5f);
    public static Color DeleteTowerPlaceColor = new Color(0.9f, 0f, 0f, 0.5f);


    // 1) Tower
    public static int TowerBuildingCost = 50;


    // 2). Tower Bullet
    public static float TowerBulletSpeed = 0.4f;
    public static float TowerBulletTimeLife = 1f;
    public static float TowerBulletDamage = 25f;





    // 3). Enemy
    public static int EnemyDeathCost = 20;
    public static int EnemyMaxLife = 100;
    public static float EnemyMovingSpeed = 1f;
    public static string EnemyWayPointsGroup = "WayPoints";
    public static float EnemyDieEffectIntervalDissapear = 0.5f;

}


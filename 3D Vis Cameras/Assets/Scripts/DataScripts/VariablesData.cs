using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariablesData
{

    // game constant
    private const string _serverDataSourceUri = "https://topsites.cc/api/api_unity.php?mom_duck_said=yes";
    private const float _updateInterval = 30f;
    private const float _truckLifetime = 9.9f;
    private const float _stepXtruckGeneration = 3f;
    private const float _stepYtruckGeneration = 3f;

    private static string _trucksInField;


    public static float GetStepYtruckGeneration()
    {
        return _stepYtruckGeneration;
    }

    public static float GetStepXtruckGeneration()
    {
        return _stepXtruckGeneration;
    }

    public static float GetTruckLifetime()
    {
        return _truckLifetime;
    }

    public static float GetUpdateInterval()
    {
        return _updateInterval;
    }

    public static void SetTruckInFieldData(string newString)
    {
        _trucksInField = newString;
    }

    public static string GetTruckInFieldData()
    {
        return _trucksInField;
    }

    public static string GetDataSourceUri()
    {
        return _serverDataSourceUri;
    }

}

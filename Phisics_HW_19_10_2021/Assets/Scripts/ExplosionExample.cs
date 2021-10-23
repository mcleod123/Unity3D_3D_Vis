using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionExample : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 150f;
    [SerializeField] private float _radius = 40f;

    [SerializeField] private Transform _explosionPoint;

    [SerializeField] private float _minSpeedToExplosion = 10f;

    [SerializeField] private GameObject _explosionPrefab;


    private void Explosion()
    {

        Vector3 explosionPosition = _explosionPoint.position;

        //Instantiate(_explosionPrefab, new Vector3(21F, 0, -15), Quaternion.identity);
        Instantiate(_explosionPrefab, explosionPosition, Quaternion.identity);

        var hits = Physics.SphereCastAll(_explosionPoint.position, _radius, _explosionPoint.up);
        foreach (var hit in hits)
        {
            var rigidbody = hit.collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, _explosionPoint.position, _radius);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isSphereMoved())
        {
            Explosion();
        }

    }


    private bool isSphereMoved()
    {

        Rigidbody sphereRigitBody = this.GetComponent<Rigidbody>();
        var speed = sphereRigitBody.velocity.magnitude;

        if(speed > _minSpeedToExplosion)
        {
            return true;
        } 
        else 
        {
            return false;
        } 

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBullshit : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private LayerMask _layerMask;

    private BoxCollider _collider;

    private Rigidbody _rigidbody;


    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("HitSmthg");
        if(collision.collider.TryGetComponent(out Rigidbody rigidbody))
        {
            PushObjects(collision.collider);
        }
    }

    private void PushObjects(Collider collider)
    {
        if (collider.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 direction = (collider.transform.position - transform.position).normalized;
            rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{

    [SerializeField] private float impulsWeight = 3.0f;
    [SerializeField] private string targetObjectTag;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == targetObjectTag)
        {
            var rigid = other.gameObject.GetComponent<Rigidbody>();
            var impulse = (rigid.position - transform.position).normalized * impulsWeight;
            rigid.AddForce(impulse,ForceMode.Impulse);
            Debug.Log("Hit!!!");
        }
    }
}

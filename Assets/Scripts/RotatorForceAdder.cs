using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorForceAdder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ForceApplier>().AddForce(Vector3.up,12.5f,.3f);
        }else if (other.CompareTag("Opponent"))
        {
            other.GetComponent<ForceApplier>().AddForce(Vector3.up, 1000f, .2f);
        }
    }


}

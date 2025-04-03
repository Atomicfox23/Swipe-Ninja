using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genTrigger : MonoBehaviour
{
    public GameObject obstacleSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("genTrigger"))
        {
            Instantiate(obstacleSection, new Vector3(0, 0, 100), Quaternion.identity);
        }
    }
}

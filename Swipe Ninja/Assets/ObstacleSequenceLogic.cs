using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSequenceLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -8) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destroyTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChack : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pin")
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Pin")
        {
            Destroy(other.gameObject, 2.0f);
            count--;
        }
    }
}

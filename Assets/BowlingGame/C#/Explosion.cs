using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float power = 10.0f;
    public float radius = 10.0f;
    public float upwards = 0.0f;
    Vector3 position;

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
        if(other.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
            Explosionmode();
        }
    }

    public void Explosionmode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(power, position, radius);
            }
        }
    }
}

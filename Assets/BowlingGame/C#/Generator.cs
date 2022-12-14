using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject PinPrefab;
    GameObject Pin;
    private HitChack hk;

    // Start is called before the first frame update
    void Start()
    {
        hk = GameObject.Find("HitChack").GetComponent<HitChack>();
        Pin = (GameObject)Instantiate(PinPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PinReset()
    {
        hk.count = 0;
        Destroy(Pin);
        Pin = (GameObject)Instantiate(PinPrefab, transform.position, Quaternion.identity);
    }
}

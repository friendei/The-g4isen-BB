using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallThrow : MonoBehaviour
{
    public GameObject ballPrefab;
    public float shotspeed;
    public int shotCount;

    private Vector3 throwpos;
    private Manager manage;

    private GameObject ThrowCamera;
    private GameObject PinCamera;

    public Slider slider;
    public bool mflag, sflag;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        throwpos = transform.position;
        manage = GameObject.Find("Manager").GetComponent<Manager>();

        ThrowCamera = GameObject.Find("ThrowCamera");
        PinCamera = GameObject.Find("PinCamera");

        PinCamera.SetActive(false);

        slider.value = 0.5f;
        mflag = true;
        sflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(throwpos.x, throwpos.y, Mathf.Sin(Time.time) * 7.0f + throwpos.z);

        if (Input.GetKey(KeyCode.Space))
        {
            manage.CTextChange();

            if (shotCount > 0)
            {
                shotCount -= 1;

                ball = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();
                ballRb.AddForce(transform.forward * (slider.value * shotspeed));
                sflag = false;

                manage.BallflagChange(ball);

                PinCamera.SetActive(true);
                ThrowCamera.SetActive(false);

            }
        }

        if(mflag == true && sflag == true)
        {
            slider.value += Time.deltaTime;
            if(slider.value == 1)
            {
                mflag = false;
            }
        }

        if(mflag == false && sflag == true)
        {
            slider.value -= Time.deltaTime;
            if(slider.value == 0)
            {
                mflag = true;
            }
        }
        
    }
}

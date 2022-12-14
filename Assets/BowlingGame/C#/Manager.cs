using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text ctext;

    public Text resultText;
    public int setcount;
    GameObject HitChack;
    GameObject ball;
    HitChack hitchack;
    private bool ballflag;
    private BallThrow throwpos;
    private Generator gene;
    int pins;

    private SpawnBomb SpB;

    private GameObject ThrowCamera;
    private GameObject PinCamera;

    public Text exitText;

    // Start is called before the first frame update
    void Start()
    {
        ctext.gameObject.SetActive(true);

        setcount = 2;
        HitChack = GameObject.Find("HitChack");
        hitchack = HitChack.GetComponent<HitChack>();
        ballflag = false;
        throwpos = GameObject.Find("ThrowPosition").GetComponent<BallThrow>();
        gene = GameObject.Find("SetPinPosition").GetComponent<Generator>();

        SpB = GameObject.Find("SpawnBomb").GetComponent<SpawnBomb>();

        ThrowCamera = GameObject.Find("ThrowCamera");
        PinCamera = GameObject.Find("PinCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if(ballflag == true)
        {
            if(ball.transform.position.y < -50 || ball.GetComponent<Rigidbody>().IsSleeping())
            {
                Destroy(ball);
                ballflag = false;
                StartCoroutine("Result");

            }
        }
    }

    public void BallflagChange(GameObject Ball)
    {
        ball = Ball;
        ballflag = true;

    }

    public void CTextChange()
    {
        ctext.gameObject.SetActive(false);
    }

    IEnumerator Result()
    {
        if(setcount == 2 && hitchack.count == 0)
        {
            resultText.text = "ストライク！";
            exitText.text = "Escapeで提出";
            yield return new WaitForSeconds(3);
            throwpos.shotCount = 1;
            throwpos.sflag = true;
            resultText.text = "";
            exitText.text = "";
            gene.PinReset();
            SpB.BombReset();
            ThrowCamera.SetActive(true);
            yield break;
        }

        if(setcount == 1 && hitchack.count == 0)
        {
            resultText.text = "スペア！";
            exitText.text = "Escapeで提出";
            yield return new WaitForSeconds(3);
            resultText.text = "";
            exitText.text = "";
            throwpos.shotCount = 1;
            setcount = 2;
            throwpos.sflag = true;
            gene.PinReset();
            SpB.BombReset();
            ThrowCamera.SetActive(true);
            yield break;
        }

        if(setcount == 1 && hitchack.count != 0)
        {
            resultText.text = 100 - hitchack.count + "ピン！";
            exitText.text = "Escapeで提出";
            yield return new WaitForSeconds(3);
            resultText.text = "";
            exitText.text = "";
            throwpos.shotCount = 1;
            setcount = 2;
            throwpos.sflag = true;
            gene.PinReset();
            SpB.BombReset();
            ThrowCamera.SetActive(true);
            yield break;
        }
        else
        {
            resultText.text = "２投目！";
            yield return new WaitForSeconds(3);
            resultText.text = "";
            pins = hitchack.count;
            setcount = 1;
            throwpos.shotCount = 1;
            throwpos.sflag = true;
            SpB.BombReset();
            ThrowCamera.SetActive(true);
        }

       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoop : MonoBehaviour
{
    public float SceneWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneWaitTime = SceneWaitTime + Time.deltaTime;

        if(SceneWaitTime > 5)
        {
            SceneManager.LoadScene("StartScene");
            SceneWaitTime = 0;
        }
    }
}

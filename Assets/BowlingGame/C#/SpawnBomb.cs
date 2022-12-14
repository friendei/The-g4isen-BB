using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject BombPrefab;
    GameObject Bomb;

    public float spawn_X;
    public float spawn_Y;
    public float spawn_Z;
    private float posX_E;
    private float posZ_E;

    // Start is called before the first frame update
    void Start()
    {
        posX_E = Random.Range(spawn_X * -1 + 28.5f, spawn_X + 28.5f);
        posZ_E = Random.Range(spawn_Z * -1, spawn_Z);
        Bomb = (GameObject)Instantiate(BombPrefab, new Vector3(posX_E, spawn_Y, posZ_E), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
            posX_E = Random.Range(spawn_X * -1 + 28.5f,  spawn_X + 28.5f);
            posZ_E = Random.Range(spawn_Z * -1, spawn_Z);
    }

    public void BombReset()
    {
        Destroy(Bomb);
        Bomb = (GameObject)Instantiate(BombPrefab, new Vector3(posX_E, spawn_Y, posZ_E), Quaternion.identity);
    }
}

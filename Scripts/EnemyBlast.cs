using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlast : MonoBehaviour
{
    public Transform enemyLaserSpawn;
    public float nextLaser = 1.5f;
    public float currTime = 0.0f;
    public GameObject enemyLaser;

    // Start is called before the first frame update
    void Start()
    {
        enemyLaserSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemyBlast();
    }
    public void enemyBlast()
    {
        currTime += Time.deltaTime;
        if(currTime > nextLaser)
        {
            nextLaser += currTime;
            Instantiate(enemyLaser, enemyLaserSpawn.position, Quaternion.identity);
            nextLaser -= currTime;
            currTime = 0.0f;
        }

    }

}

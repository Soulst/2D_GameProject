using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public Transform laserSpawn;
    public float nextLaser = 0.7f;
    public float currTime = 0.0f;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        laserSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        blast();
    }
    public void blast()
    {
        currTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && currTime > nextLaser)
        {
            nextLaser += currTime;
            Instantiate (projectile,laserSpawn.position, Quaternion.identity);
            nextLaser -= currTime;
            currTime = 0.0f;
        }
    }
}

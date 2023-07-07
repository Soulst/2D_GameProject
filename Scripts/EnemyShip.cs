using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D enemyShip;
    public float moveSpeed = 3.5f;
    public bool changeDirection = false;
    public int enemyLives;
    public Text showDialog;

    // Start is called before the first frame update
    void Start()
    {
        enemyLives = 10;
        enemyShip = this.gameObject.GetComponent<Rigidbody2D>();
        showDialog = GameObject.Find("DialogText").GetComponent<Text>();
        showDialog.text = "Well, looks like this is our first enemy. Time to crush them.";
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemyShip();
    }
    public void moveEnemyShip()
    {
        if(changeDirection == true)
        {
            enemyShip.velocity = new UnityEngine.Vector2(0, 1) * -1 * moveSpeed;
        }
        else if(changeDirection == false)
        {
            enemyShip.velocity = new UnityEngine.Vector2(0, 1) * moveSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BarrierU")
        {
            changeDirection = true;
        }
        if (collision.gameObject.name == "BarrierD")
        {
            changeDirection = false;
        }

        if(collision.gameObject.tag == "PlayerLaser")
        {
            if(enemyLives <= 0)
            {
                Object.Destroy(this.gameObject);
                SceneManager.LoadScene(2);
            }
            enemyLives--;

            if(enemyLives == 8)
            {
                showDialog.text = "That's it ! Keep damaging the space monster..";
            }
            if (enemyLives == 2)
            {
                showDialog.text = "You are almost there.. Just a few more !";
            }
        }
    }



    
}

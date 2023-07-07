using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterThree : MonoBehaviour
{
    public Rigidbody2D enemyShip;
    public float moveSpeed = 6.0f;
    public bool changeDirection = false;
    public int enemyLives;
    public int randy;
    public Text showDialog;

    // Start is called before the first frame update
    void Start()
    {
        enemyLives = 20;
        enemyShip = this.gameObject.GetComponent<Rigidbody2D>();
        showDialog = GameObject.Find("DialogText").GetComponent<Text>();
        showDialog.text = "Now this looks like the last one..";
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemyShip();
    }
    public void moveEnemyShip()
    {
        if (changeDirection == true)
        {
            randy = Random.Range(0, 2);
            if (randy == 1)
            {
                enemyShip.velocity = new UnityEngine.Vector2(0, 1) * -1 * moveSpeed;
            }
            else if (randy == 0)
            {
                enemyShip.velocity = new UnityEngine.Vector2(0, 1) * -1 * (moveSpeed * 1.8f);
            }

        }
        else if (changeDirection == false)
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

        if (collision.gameObject.tag == "PlayerLaser")
        {
            if (enemyLives <= 0)
            {
                Object.Destroy(this.gameObject);
                SceneManager.LoadScene(6);
            }
            enemyLives--;
            if (enemyLives == 12)
            {
                showDialog.text = "This purple alien will not stop! Better keep dodging.";
            }
            if (enemyLives == 8)
            {
                showDialog.text = "So fast!";
            }
            if (enemyLives == 8)
            {
                showDialog.text = "Cmon, I must get home!!";
            }

        }



    }
}

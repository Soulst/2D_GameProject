using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterTwo : MonoBehaviour
{
    public Rigidbody2D enemyShip;
    public float moveSpeed = 3.5f;
    public bool changeDirection = false;
    public int enemyLives;
    public int randy;
    public Text showDialog;

    // Start is called before the first frame update
    void Start()
    {
        enemyLives = 14;
        enemyShip = this.gameObject.GetComponent<Rigidbody2D>();
        showDialog = GameObject.Find("DialogText").GetComponent<Text>();
        showDialog.text = "Hmm, this fellow seems a bit tougher.. better be careful.";
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
            if(randy == 1)
            {
               enemyShip.velocity = new UnityEngine.Vector2(0, 1) * -1 * moveSpeed;
            }
            else if(randy == 0)
            {
               enemyShip.velocity = new UnityEngine.Vector2(0, 1) * -1 * (moveSpeed*1.8f);
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
                SceneManager.LoadScene(3);
            }
            enemyLives--;
            if (enemyLives == 8)
            {
                showDialog.text = "Whew, this one is tough.. Am I halfway there yet?";
            }
            if (enemyLives == 1)
            {
                showDialog.text = "Arrgh! Get out of my way, slime monster!";
            }
        }



    }
}

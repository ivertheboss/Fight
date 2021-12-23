using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyPartical;
    private GameObject healthBar;
    private GameObject healthBarPar;

    public int health = 10;
    private int health2;
    private float xscale;
    //healthBarViewTime
    public float HBVT = 5;
    private bool hide = false;

    void Start()
    {
        health2 = health;
        enemyPartical = GameObject.Find("EnemyDeath");  
        healthBar = this.gameObject.transform.GetChild(1).gameObject;  
        healthBarPar = this.gameObject.transform.GetChild(1).gameObject;  
        healthBar = healthBar.transform.GetChild(0).gameObject;
        xscale = healthBar.transform.localScale.x;
    }

    void Update(){
        if(health <= 0){
            Instantiate(enemyPartical, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);
        }

        if(hide == true){
            float target = 1.0f;
 
            float delta = target - HBVT;
            delta *= Time.deltaTime;
 
            HBVT += delta;
        }

        if(HBVT <= 1.4f){
            hide = false;
            healthBarPar.SetActive(false);
        }
        print(hide);
    }

    //healthBarViewTimeFunction
    public void HBVTF(){
        HBVT = 5;
        hide = true;
    }

    public void Hit(){
        healthBarPar.SetActive(true);
        HBVTF();
        healthBar.transform.localScale -= new Vector3(xscale / health2, 0, 0);
    }
}

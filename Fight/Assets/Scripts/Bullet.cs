using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public Rigidbody2D rb;
    public GameObject enemyPartical;
    public GameObject BulletPartical;

    void Start()
    {
        enemyPartical = GameObject.Find("EnemyDeath");
        rb.velocity = transform.right * Speed;        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Enemy>() != null){
            other.gameObject.GetComponent<Enemy>().health -= 1;
            other.gameObject.GetComponent<Enemy>().Hit();
        }
        Destroy(gameObject);
    }
}

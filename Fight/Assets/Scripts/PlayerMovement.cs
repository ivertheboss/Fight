using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public float MovementSpeed = 3f;
    public Rigidbody2D rb;
    public float JumpForce = 1;
    public Transform Gun;
    public GameObject GunObject;
    public GameObject GunB;
    public GameObject GunM;
    public GameObject GunF;
    public bool yes = false;
    public bool no = false;

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        Player.transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f){
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < Player.transform.position.x){
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            if(!yes){
                no = false;
                yes = true;
                GunObject.transform.localScale = new Vector3(1.3096f, -0.2768f, 1f);
                GunObject.transform.localPosition = new Vector3(0.297f, 0.477f, -1f);
                GunB.transform.localPosition = new Vector3(0.297f, GunB.transform.localPosition.y, 0f);
                GunM.transform.localPosition = new Vector3(0.297f, GunM.transform.localPosition.y, 0f);
                GunF.transform.localPosition = new Vector3(0.297f, GunF.transform.localPosition.y, 0f);
            }
        }
        else{
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            if(!no){
                no = true;
                yes = false;
                GunObject.transform.localScale = new Vector3(1.3096f, 0.2768f, 1f);
                GunObject.transform.localPosition = new Vector3(-0.297f, 0.477f, -1f);
                GunB.transform.localPosition = new Vector3(-0.297f, GunB.transform.localPosition.y, 0f);
                GunM.transform.localPosition = new Vector3(-0.297f, GunM.transform.localPosition.y, 0f);
                GunF.transform.localPosition = new Vector3(-0.297f, GunF.transform.localPosition.y, 0f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{   
    public Transform FirePoint;
    public GameObject bullet;
    public Transform Gun;
    public Transform GunObj;
    public GameObject gunshotPartical;
    public GameObject Player;
    public GameObject RecoilB;
    public GameObject RecoilM;    
    public GameObject RecoilF;    

    void Update()
    {
        gunshotPartical = GameObject.Find("Gunshot");
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot(){
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
        Instantiate(gunshotPartical, FirePoint.position, FirePoint.rotation);
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < Player.transform.position.x){
            GunObj.transform.localPosition = RecoilM.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilB.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilM.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilF.transform.localPosition;
        }
        else{
            GunObj.transform.localPosition = RecoilM.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilB.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilM.transform.localPosition;
            yield return new WaitForSeconds(.03f);
            GunObj.transform.localPosition = RecoilF.transform.localPosition;
        }
    }
}

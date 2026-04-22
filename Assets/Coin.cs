using UnityEngine;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    public GameObject[] enemies;
    public Rigidbody projectile;
    private bool flying = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        projectile.AddForce(GameObject.Find("Main Camera").GetComponent<Camera>().transform.forward * 15f,ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(flying){
            transform.Rotate (720*Time.deltaTime,0,0);
        }
    }
    
    public void HitClosestEnemy(){
        flying = false;
        GameObject closest = enemies[0];
        foreach(GameObject e in enemies){
            if(Vector3.Distance(closest.transform.position,transform.position) > Vector3.Distance(e.transform.position,transform.position)){
                closest = e;
                Debug.Log(closest);
            }
        }
        closest.GetComponent<Enemy>().Shot();
        projectile.constraints = RigidbodyConstraints.FreezePosition;
        projectile.constraints = RigidbodyConstraints.FreezeRotation;
        Destroy(this.gameObject,0.25f);
    }
}

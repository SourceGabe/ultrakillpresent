using UnityEngine;

public class Gun : MonoBehaviour
{
    private Ray gun;
    LayerMask enemylayerMask;
    LayerMask coinLayerMask;
    public GameObject projectile;
    public GameObject launchPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           enemylayerMask = LayerMask.GetMask("enemy"); 
           coinLayerMask = LayerMask.GetMask("coin");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if(Input.GetKeyUp(KeyCode.Q)){
            Debug.Log("throw Coin");
            Throw();
        }
    }
    private void Shoot(){
        Enemy target;
        Coin projectile;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, Mathf.Infinity, enemylayerMask)){
            Debug.Log("Hit enemy");
            target = hit.transform.gameObject.GetComponent<Enemy>();
            target.Shot();
            
        }
             if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, Mathf.Infinity, coinLayerMask)){
            Debug.Log("Hit coin");
            projectile = hit.transform.gameObject.GetComponent<Coin>();
            projectile.HitClosestEnemy(); 
        }

        
    }
    private void Throw(){
        Instantiate(projectile,launchPos.transform.position,transform.rotation);
    }
}

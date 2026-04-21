using UnityEngine;

public class Enemy : MonoBehaviour
{
     Material m_Material;
    private bool isLiving = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLiving){
           m_Material.color = Color.green; 
        }else{
            m_Material.color = Color.red;
        }  
    }
    public void Shot(){
        isLiving = false;
    }
}

using UnityEngine;
using System.Collections;

public class MainCharAtack : MonoBehaviour {

    public GameObject attacked;
    public GameObject empty;
	// Use this for initialization
	void Start () {
        
       
	}
	
	// Update is called once per frame
	void Update () {
       
        
    }
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Enemy"))
        {
            attacked = Col.gameObject;
           
        }
    }
   
   
      
   
}

using UnityEngine;
using System.Collections;

public class EnemyClass : MonoBehaviour {
    public float Life;
    public float damage;
    public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
    }
   
   public void sufferingDMG(float dmg)
    {        
        Life = Life - dmg;
        Debug.Log("tomou o dano M ");
        anim.SetBool("beingHit", true);

    }
    void onDeath()
    {
        if (Life < 0)
        {
            anim.SetBool("Death", true);
        }
    }
}

using UnityEngine;
using System.Collections;

public class CharacterClass : MonoBehaviour {

    public float Life , atack,defense;
    public Animator anim;
    public Vector3 SpawnCords;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void sufferingDMG(float dmg)
    {
        Life = Life - dmg;
        if (Life < 0)
            onDeath();
    }
    void onDeath()
    {       
            anim.SetBool("Dead", true);        
    }
}

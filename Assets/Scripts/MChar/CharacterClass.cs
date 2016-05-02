using UnityEngine;
using System.Collections;

public class CharacterClass : MonoBehaviour {

    public float Life=100 , atack,defense;
    bool dealDamage;
    bool substractOnce;
    bool dead;
    public float damageTimer = 1f;
    WaitForSeconds damageT;
    Animator anim;

    public Vector3 SpawnCords;
    // Use this for initialization

    void Start () {
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dealDamage)
        {
            if (!substractOnce)
            {

                Life -= 10;
                anim.SetTrigger("TakingDmg");
                Debug.Log("takingDamage");
            }
            StartCoroutine("CloseDamage");
        }
	if (Life < 0)
        {
            if (!dead)
            {
                anim.SetBool("Dead", true);                
                dealDamage = true;
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                if (GetComponent<EnemeyAI>())
                {
                    GetComponent<EnemeyAI>().enabled = false;
                    GetComponent<NavMeshAgent>().enabled = false;
                }
                else
                {
                    GetComponent<CharacterControl>().enabled = false;
                }
                dead = true;
            }
        }
	}

    public void GetHit(int damage)
    {       
        Life -= damage;

    }
    public void checkToApplyDamage()
    {
        if (!dealDamage)
        {
            dealDamage = true;
        }
    }
   IEnumerator CloseDamage()
    {
        Debug.Log("Closing dmg");
        dealDamage = false;
        substractOnce = false;
        yield return damageT;
    }
}

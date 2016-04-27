using UnityEngine;
using System.Collections;

public class PlayerAtack : MonoBehaviour {

    PlayerInputs plInput;
    CharacterControl plMove;
    Animator anim;
    public float comboRate = .5f;
    WaitForSeconds comboR;
    public GameObject damageCollider;
	// Use this for initialization
	void Start () {
        plInput = GetComponent<PlayerInputs>();
        anim = GetComponent<Animator>();
        plMove = GetComponent<CharacterControl>();
        comboR = new WaitForSeconds(comboRate);
        damageCollider.SetActive(false);
	}
	
	
	void FixedUpdate ()
    {
        if (plInput.atk1)
        {
            anim.SetBool("MediumAtack", true);
            plMove.canMove = false;
            StartCoroutine("CloseAttack");
        }
        if (plInput.atk2)
        {
            anim.SetBool("PowerAtack", true);
            plMove.canMove = false;
            StartCoroutine("CloseAttack");
        }

    }
    IEnumerator CloseAttack()
    {
        yield return comboR;
        anim.SetBool("MediumAtack", false);
        anim.SetBool("PowerAtack", false);
    }
    public void OpenDamageCollider()
    {
        damageCollider.SetActive(true);
    }
    public void CloseDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}

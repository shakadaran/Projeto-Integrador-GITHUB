using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
    
    public float speed = 1f, rotSpeed = 1f, StrafeSpeed = 1f,smoothness=.5f;    
    private int contagemdeClick;
    private bool running;
    private float doubleClickInterval;
    private float tempoClickDuplo;
    public bool canMove = true;
    public Animator animcontrol;    // animator
    CharacterController controller;
    public float spdc,strspdc,rspdc;
    PlayerInputs plInput;
	// Use this for initialization
	void Start () {
        animcontrol = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        plInput = GetComponent<PlayerInputs>();
	}
    
    void FixedUpdate()
    {
        if (canMove)
        {
            if(plInput.v!=0 || plInput.h!=0) animcontrol.SetBool("Moving", true);
            else animcontrol.SetBool("Moving", false);
            if (plInput.run)
            {
                speed = Mathf.SmoothDamp(speed, 2f,ref smoothness,2f,.3f );
                
            }
            else speed = 1;
            Vector3 VerticalForce = Vector3.forward * plInput.v;
            Vector3 HorizontalForce = Vector3.right * plInput.h;
            transform.Rotate(transform.up* plInput.r*rotSpeed);
            //controller.Move((HorizontalForce + VerticalForce).normalized);
            Debug.Log("Moveu");
            UpdateAnimator();
        }
    }
    void UpdateAnimator()
    {
        animcontrol.SetFloat("LinearSpd", plInput.v *speed);
        animcontrol.SetFloat("StrafeSpeed", plInput.h *StrafeSpeed);
        Debug.Log("atualizou");
    }
   

}
   


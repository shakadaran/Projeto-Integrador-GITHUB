using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
    public float h, v, r; //inputs
    public float Speed,RotSpeed,StrafeSpeed;// character control variables;
    public Animator animcontrol;    // animator
    public float attack;        //    atack     
    public Vector3  combo ;     //          and power
    public MainCharAtack shortcut;// atalho pro script de dano
    public GameObject child;
    public bool takingdmg; // variavel de tomar porrada
    public Vector3 moveDir = Vector3.zero;
    public float spdc,strspdc,rspdc;
    CharacterController controller;
	// Use this for initialization
	void Start () {
        shortcut = GetComponentInChildren<MainCharAtack>();
        combo.Set(1, 2, 3);
        controller = GetComponent<CharacterController>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
      
            if (spdc != 0 || strspdc != 0 || rspdc!=0)
            {
                animcontrol.SetBool("Moving", true);
            }
            else animcontrol.SetBool("Moving", false);

        if (Input.GetAxis("Fire1") > 0)
        {
            animcontrol.SetBool("PowerAtack", true);
            child.GetComponent<BoxCollider>().enabled = true;
            shortcut.attacked.gameObject.GetComponentInParent<EnemyClass>().sufferingDMG(1);
        }
        else
            {
                animcontrol.SetBool("PowerAtack", false);            
            }

        if (Input.GetAxis("Fire2") > 0)
        {
            animcontrol.SetBool("MediumAtack", true);
            child.GetComponent<BoxCollider>().enabled = true;
            shortcut.attacked.gameObject.GetComponentInParent<EnemyClass>().sufferingDMG(1);
        }
        else
        {
            animcontrol.SetBool("MediumAtack", false);            
        }
           
        h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            animcontrol.SetBool("strafing", true);
        }
        else animcontrol.SetBool("strafing", false);

        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        spdc = animcontrol.GetFloat("LinearSpd");
        strspdc = animcontrol.GetFloat("StrafeSpeed");
        rspdc = animcontrol.GetFloat("AngularSpd");
        animcontrol.SetFloat("LinearSpd", v * Speed);
        animcontrol.SetFloat("AngularSpd",r * RotSpeed);
        animcontrol.SetFloat("StrafeSpeed", h * StrafeSpeed);
        transform.Rotate(transform.up * r*RotSpeed);
        moveDir = transform.forward * v*Speed + transform.right * h*StrafeSpeed;
        controller.Move(moveDir * Time.deltaTime);
    }
    void OnTriggerEnter(Collider col)
    {      
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            if (col.GetComponentInParent<Animator>().GetBool("Atack"))
            {
                Debug.Log("HIT");
                animcontrol.SetBool("TakingDmg", true);
                transform.gameObject.GetComponent<CharacterClass>().sufferingDMG(1);
                
            }
        }
        
     }

    }
   


using UnityEngine;
using System.Collections;

public class EnemeyAI : MonoBehaviour {
    public GameObject Jogador;
    public Vector3 distancia;
    private float dist ,velocity,rotation;
    public Animator anim;

    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
       

        
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = Jogador.transform.position;
        distancia = transform.position - Jogador.transform.position;
        dist = distancia.magnitude;
        velocity = agent.desiredVelocity.magnitude;
        rotation = agent.angularSpeed;
        //anim.SetFloat("LinearSpd", dist);
        anim.SetFloat("AngularSpd", 0);
        if (dist < 2.5)
        {
            anim.SetBool("Atack", true);
        }
        else anim.SetBool("Atack", false);

    }


  
   
}


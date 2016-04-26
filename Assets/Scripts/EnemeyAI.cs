using UnityEngine;
using System.Collections;

public class EnemeyAI : MonoBehaviour {
    public GameObject Jogador;
    public Vector3 distancia;
    public float dist ,velocity,rotation,prevRot=0;
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
        velocity = agent.velocity.magnitude;
        rotation = prevRot- transform.rotation.y;
        anim.SetFloat("LinearSpd", velocity);
        anim.SetFloat("AngularSpd", rotation);
        if (dist < 2.5)
        {
            anim.SetBool("Atack", true);
        }
        else anim.SetBool("Atack", false);
        
    }
    void LateUpdate()
    {
        prevRot = transform.rotation.y;
    }
}


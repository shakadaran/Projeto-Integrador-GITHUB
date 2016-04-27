using UnityEngine;
using System.Collections;

public class EnemeyAI : MonoBehaviour
{
    public float attackRate = .2f;
    float attackR;
    bool attacking;
    public float attackRange = 3;
    public GameObject damageCollider;
    Animator anim;
    NavMeshAgent agent;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange;
        //agent.updateRotation = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < attackRange + 4f)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
        if (!attacking)
        {
            agent.Resume();
            agent.SetDestination(target.position);

            Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

            float hor = relativePosition.magnitude;// relativePosition.z;
            float vert = relativePosition.x;
            anim.SetFloat("LinearSpd", hor,0.6f,Time.deltaTime);
            //anim.SetFloat("AngularSpd", hor,0.6f, Time.deltaTime);
        }
        else
        {
            agent.Stop();
            Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);
            float hor = relativePosition.magnitude;//relativePosition.z;
            float vert = relativePosition.x;
            anim.SetFloat("LinearSpd", hor,0.6f,Time.deltaTime);
            //anim.SetFloat("AngularSpd", hor,0.6f,Time.deltaTime);
            attackR += Time.deltaTime;
            if (attackR > attackRate)
            {
                anim.SetBool("Atack", true);
                StartCoroutine("CloseAttack");
                attackR = 0;
            }
        }
    }
    IEnumerator CloseAttack()
    {
        yield return new WaitForSeconds(.4f);
        anim.SetBool("Atack", false);
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
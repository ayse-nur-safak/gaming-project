using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;
using static Zombie_1;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Zombie_1 : MonoBehaviour
{
    [Header("Zombie Health and Damage")]
    public float giveDamage = 5f; 

    [Header("Zombie Things")]
    public NavMeshAgent zombieAgent;
    public Transform LookPoint;
    public Camera AttackingRaycastArea;
    public LayerMask PlayerLayer;
    public Transform playerBody;

    [Header("Zombie Guarding var")]
    public GameObject[] walkPoints;
    int currentZombiePosition = 0;
    public float zombieSpeed;
    float walkingpointRadius = 2;

    [Header("Zombie Attacking Var")]
    public float timeBtwAttack;
    bool previouslyAttack;

    [Header("Zombie Animation")]
    public Animator anim;

    [Header("Zombie mood / states")]
    public float visionRadius;
    public float attackingRadius;
    public bool playerInvisionRadius;
    public bool playerInattackingRadius;

    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()

    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInattackingRadius = Physics.CheckSphere(transform.position, attackingRadius, PlayerLayer);

        if (!playerInvisionRadius && !playerInattackingRadius) Guard();
        if (playerInvisionRadius && !playerInattackingRadius) PursuePlayer();
        if (playerInvisionRadius && playerInattackingRadius) AttackPlayer();
    }
    
    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentZombiePosition].transform.position, transform.position) < walkingpointRadius)
        {
            currentZombiePosition = Random.Range(0, walkPoints.Length);
            if (currentZombiePosition >= walkPoints.Length)
            {
                currentZombiePosition = 0;
            };
        }
        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentZombiePosition].transform.position, Time.deltaTime * zombieSpeed);
        //change zombie facing
        transform.LookAt(walkPoints[currentZombiePosition].transform.position);
    } 
    public void PursuePlayer()
    {
        if(zombieAgent.SetDestination(playerBody.position))
        {
            anim.SetBool("dance", false);
            anim.SetBool("Attacking", true);
            anim.SetBool("Running", true);
            anim.SetBool("Die", false);
        }
        else
        {
            anim.SetBool("dance", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Running", false);
            anim.SetBool("Die", true);
        }
    }
    private void AttackPlayer()
    {
        zombieAgent.SetDestination(transform.position);
        transform.LookAt(LookPoint);
        if (!previouslyAttack)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(AttackingRaycastArea.transform.position, AttackingRaycastArea.transform.forward, out hitInfo, attackingRadius))
            {
                Debug.Log("Attacking" + hitInfo.transform.name);
                mousemovement playerBody = hitInfo.transform.GetComponent<mousemovement>();

                if (playerBody != null)
                {
                    playerBody.playerHitDamage(giveDamage);
                }

                anim.SetBool("dance", true);
                anim.SetBool("Attacking", false);
                anim.SetBool("Running", false);
                anim.SetBool("Die", false);
            }

            previouslyAttack = true;
            Invoke(nameof(ActiveAttacking), timeBtwAttack);
        }
    }
    private void ActiveAttacking()
    {
        previouslyAttack = false;
    }

}

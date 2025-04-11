using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BotMove : MonoBehaviour
{

    NavMeshAgent navAgent;
    Transform player;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(FindPlayer());
    }

    void Update()
    {
        //sqrMagnitude - the speed towards that direction squared
        //anim.SetFloat("Speed", navAgent.velocity.sqrMagnitude);
    }
    IEnumerator FindPlayer(){
        while (true){
            yield return new WaitForSeconds(1);
            navAgent.SetDestination(player.position);
        }
    }
    
}

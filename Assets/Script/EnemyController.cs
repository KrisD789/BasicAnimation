using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using System.Collections.Generic;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float Speed = 2f;
    //Rigidbody rb;
    NavMeshAgent agent;

    Animator anim;

    [SerializeField ]
    List<Transform> wayPoint = new List<Transform>();
    [SerializeField]
    float waitTime = 2f;
    [SerializeField]
    bool patroInLoop = true;

    int currentWaypointIndex = 0;
    bool isWaiting = false;
    bool movingForward = true;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (wayPoint == null || wayPoint.Count == 0) return;

        GoToCurrentWaypoint();
    }

    private void Update()
    {
        if (wayPoint.Count == 0 || isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance  <= agent.stoppingDistance )
        {
            anim.SetTrigger("idle");
            agent.speed = 0;
            StartCoroutine(WaitAtWaypoint());
        }
    }

    void GoToCurrentWaypoint()
    {
        if (wayPoint.Count == 0) return;

        agent.SetDestination(wayPoint[currentWaypointIndex].position);
    }

    void SelectNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % wayPoint.Count;
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        SelectNextWaypoint();
        anim.SetTrigger("walk");
        agent.speed = Speed;
        GoToCurrentWaypoint();
        isWaiting = false;

    }

    private void FixedUpdate()
    {
        //Vector3 forWard = transform.forward * Speed;
        //rb.linearVelocity = new Vector3(forWard.x, rb.linearVelocity.y, forWard.z);
    }

}
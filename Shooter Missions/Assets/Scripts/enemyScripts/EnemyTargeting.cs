using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargeting : MonoBehaviour
{

    public bool IsAtStart = true;
    public bool Follow = false;
    public NavMeshAgent agent;
    public GameObject Player;
    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Follow)
        {
            agent.SetDestination(Player.transform.position);
        }
        else if (!Follow && !IsAtStart)
        {
            agent.SetDestination(startPoint.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Follow = true;
            IsAtStart = false;
        }
        if (other.gameObject.tag == "ReturnPoint" && !Follow)
        {
            IsAtStart = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Follow = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeNavigation : MonoBehaviour
{
    Transform player;
    NavMeshAgent head;

    public bool isBodyPart = false;
    public Transform bodyPartDestination;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        head = GameObject.FindGameObjectWithTag("Snake").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBodyPart) {
            GetComponent<NavMeshAgent>().destination = bodyPartDestination.position;
        } else {
            head.destination = player.position;
        }
    }
}

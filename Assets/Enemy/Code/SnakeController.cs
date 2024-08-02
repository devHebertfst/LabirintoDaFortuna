using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeController : MonoBehaviour
{
    // Settings
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // NavMesh
    private NavMeshAgent navAgent;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        // Move head towards the player
        navAgent.destination = player.position;

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snake's path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += BodySpeed * Time.deltaTime * moveDirection;

            // Rotate body towards the point along the snake's path
            body.transform.LookAt(point);

            index++;
        }

        // Limit the size of position history
        if (PositionsHistory.Count > (BodyParts.Count + 1) * Gap)
        {
            PositionsHistory.RemoveAt(PositionsHistory.Count - 1);
        }
    }

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    public float GetSnakeSpeed() {
        return navAgent.speed;
    }

    public void SetSnakeSpeed(float speed) {
        navAgent.speed = speed;
    }
}

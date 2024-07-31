using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    public Transform Player; // Referência ao jogador
    private Rigidbody rb;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update() {
        // Move towards the player
        Vector3 directionToPlayer = (Player.position - transform.position).normalized;
        Vector3 newPosition = transform.position + directionToPlayer * MoveSpeed * Time.deltaTime;

        // Move using Rigidbody to respect collisions
        rb.MovePosition(newPosition);

        // Rotate towards the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snake's path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snake's path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake() {
        // Instantiate body instance and add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        body.AddComponent<Rigidbody>().isKinematic = true;
        body.AddComponent<Collider>();
    }
}

using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    public Vector3[] possibleSpawns;
    public GameObject snake;

    void Start() {
        int random = Random.Range(0, possibleSpawns.Length);

        snake.transform.position = possibleSpawns[random];
    }
}
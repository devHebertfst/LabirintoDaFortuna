using System.Collections;
using UnityEngine;

public abstract class Collectible : MonoBehaviour {
    public GameObject pickupEffect;
    public float pickupEffectDuration;

    public float duration;

    public float speedRotation = 10f;
    private float amp = 0.15f;
    private float freq = 0.56f;
    protected Vector3 initPos;

    public Transform groundCheck;
    public GameObject playerEffect;
    public GameManager gameManager;

    protected abstract void StartEffect();
    protected abstract void EndEffect();

    IEnumerator EffectCoroutine(Transform playerTransform)
    {        
        try {
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            GameObject instantiatedPlayerEffect = Instantiate(playerEffect, groundCheck.position, Quaternion.identity, playerTransform);

            Destroy(effect, pickupEffectDuration);
        } catch {
            // Handle exceptions if necessary
        }

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        StartEffect();
        yield return new WaitForSeconds(duration);
        EndEffect();

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EffectCoroutine(other.transform));
        }
    }

    protected void Start(){
        initPos = transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    protected void Update(){
        transform.Rotate(0f, speedRotation * Time.deltaTime, 0f, Space.World);
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }
}
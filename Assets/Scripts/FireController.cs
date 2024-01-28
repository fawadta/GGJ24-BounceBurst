using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private SpawnManager spawnManagerScript;

    [SerializeField] float fireSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * fireSpeed, ForceMode.Impulse);
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 50)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawnManagerScript.SpawnSmallerEnemies(collision.gameObject.transform.position + new Vector3(0, 1, 0));
            Destroy(collision.gameObject);
        }
        else
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;

    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(moveSpeed * Time.deltaTime * (player.transform.position - transform.position), ForceMode.Impulse);
        if (transform.position.magnitude > 50 || transform.position.y < -0.4f)
        {
            Debug.Log("destroying....");
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating(nameof(EnemyJump), 1f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(moveSpeed * Time.deltaTime * (player.transform.position - transform.position), ForceMode.Impulse);
        if (transform.position.magnitude > 50 || transform.position.y < 0.4f)
            Destroy(gameObject);
    }

    private void EnemyJump()
    {
        //Debug.Log("Jump");
        enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

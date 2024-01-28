using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horiInput;
    [SerializeField] float verInput;
    [SerializeField] float moveSpeed;

    [SerializeField] FireController firePrefab;

    private Rigidbody rb;

    [SerializeField] Vector3 bulletOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletOffset = new Vector3(0, -0.425f, 0.79f);
    }

    // Update is called once per frame
    void Update()
    {
        horiInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        if (horiInput > 0)
            rb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        if (horiInput < 0)
            rb.AddForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        if (verInput > 0)
            rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        if (verInput < 0)
            rb.AddForce(Vector3.back * moveSpeed * Time.deltaTime, ForceMode.Impulse);

        /*        
        if (horiInput > 0)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (horiInput < 0)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (verInput > 0)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (verInput < 0)
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        */

        if (Input.GetKey(KeyCode.Space))
            Fire();
        if (transform.position.magnitude > 50)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Fire()
    {
        Instantiate(firePrefab, transform.position + bulletOffset, firePrefab.transform.rotation);
    }
}
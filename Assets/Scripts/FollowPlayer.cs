using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = new Vector3(0, 1.17f, -4.4f) + new Vector3(0, 4.84f, -8.33f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}

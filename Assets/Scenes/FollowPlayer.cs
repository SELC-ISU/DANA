using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector2 offset = new Vector2(0, 0);

    private Vector3 relativePosition;

    // Start is called before the first frame update
    void Start()
    {
        relativePosition = new Vector3(offset.x, offset.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + relativePosition;
    }
}

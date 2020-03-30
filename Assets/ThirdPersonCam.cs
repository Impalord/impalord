using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    // Variable Distance of Camera from Player
    private float distanceAway = 5;
    private float distanceUp = 2;
    [SerializeField]
    private float smooth;
    private Transform follow;
    private Vector3 targetposition;

    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<Transform>();
        follow = GameObject.FindWithTag("Player").transform;

    }

    void LateUpdate()
    {
        // Make a offset for camera 
        Vector3 Charoffset = follow.position + new Vector3(0f, distanceUp, 0f);

        // Calculate the postion for camera position 
        targetposition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetposition, Color.green);

        // making Smooth cam

        transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * smooth);

        // Lookat Right WAY
        transform.LookAt(follow);
        cameraCollision(Charoffset,  ref targetposition);
    }
    private void cameraCollision(Vector3 from, ref Vector3 to)
    {
        Debug.DrawLine(from, to, Color.cyan);

        RaycastHit wallHit = new RaycastHit();
        if( Physics.Linecast(from, to, out wallHit))
        {
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            to = new Vector3(wallHit.point.x, to.y, wallHit.point.z);
        }
    }
}

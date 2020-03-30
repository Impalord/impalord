using System.Collections;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    private Animator ani; // animator object


    // Value setting
    private float directionalDampTime = 0.25f;
    private float speed;
    private float horizontal;
    private float vertical;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        if(ani.layerCount >= 2)
        {
            ani.SetLayerWeight(1, 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ani)
        {
            horizontal = Input.GetAxis("Horizontal");  // Get Horizontal from Input
            vertical = Input.GetAxis("Vertical");    // Get Vertical from Input
            speed = new Vector2(horizontal, vertical).sqrMagnitude; // Set speed

            // Setting up variable connected to Animator in Unity
            ani.SetFloat("Speed", speed);
            ani.SetFloat("Direction", horizontal, directionalDampTime, Time.deltaTime);


        }



        
    }
}

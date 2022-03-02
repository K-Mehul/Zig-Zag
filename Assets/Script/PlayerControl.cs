using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject particle;
    float movementSpeed = 8.0f; 
    bool started;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }    

    // Update is called once per frame
    void Update()
    {
        if(!started) {
            if(Input.GetMouseButton(0)) {
                rb.velocity = new Vector3(0,0,movementSpeed);
                started = true;

                GameManager.instance.GameStart();
            }
        }

        Debug.DrawRay(transform.position,Vector3.down,Color.white);

        if(! Physics.Raycast(transform.position,Vector3.down,1f)) {
            gameOver = true;
            rb.velocity = new Vector3(0,-25.0f,0);
            Camera.main.GetComponent<FollowCamera>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if(Input.GetMouseButton(0) && !gameOver) {
            SwitchDirection();   
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0) {
            rb.velocity = new Vector3(movementSpeed,0,0);
        }
        else if(rb.velocity.x > 0) {
            rb.velocity = new Vector3(0,0,movementSpeed);
        }
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Diamond") {
            GameObject part = Instantiate(particle,collider.gameObject.transform.position,Quaternion.identity);
            Destroy(collider.gameObject);
            Destroy(part,1.0f);
        }
    }
}

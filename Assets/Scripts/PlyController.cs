using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyController : MonoBehaviour
{
 


    public Animator anim;
    public Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;

    // Start is called before the first frame update
    void Start(){
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        Grounded();
        Jump();
        Move();
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && this.grounded){
            this.rb.AddForce(Vector3.up *4, ForceMode.Impulse);
        }
    }

    private void Grounded(){
        if(Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask)){
            this.grounded = true;
        }
        else{
            this.grounded = false;
        }
        this.anim.SetTrigger("jump");
    }

    private void Move(){
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 mouvement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        mouvement.Normalize();

        this.transform.position += mouvement *0.04f;
        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
         this.anim.SetTrigger("walk");
  
    }

}

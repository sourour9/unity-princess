using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarEnterExitSystem : MonoBehaviour
{

    
    Animator animator;
    bool InCar;



    void Start()
    {
        animator = GetComponent<Animator>();
        InCar = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InCar)
            {
                animator.SetBool("Open", true);
                animator.SetBool("InCar", false);
                //System.Threading.Thread.Sleep(1000);
                animator.SetBool("Open", false);
                InCar = false;
                
            }
            else
            {
                animator.SetBool("Open", true);
                animator.SetBool("InCar", true);
                //System.Threading.Thread.Sleep(1000);
               animator.SetBool("Open", false);
                InCar = true;
            }
        }
    }

    IEnumerator DelayedClose(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
    }
}
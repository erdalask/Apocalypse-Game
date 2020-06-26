using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isrunning", true);
         
        }

        else
        {
            anim.SetBool("isrunning", false);


        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isjumping", true);
        }

        else
        {
            anim.SetBool("isjumping", false);

        }


        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isreverse", true);
        }

        else
        {
            anim.SetBool("isreverse", false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isleft", true);
        }

        else
        {
            anim.SetBool("isleft", false);

        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isright", true);
        }

        else
        {
            anim.SetBool("isright", false);

        }

       if(Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("isshooting", true);
        }

       else
        {
            anim.SetBool("isshooting", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("isaiming", true);
        }

        else
        {
            anim.SetBool("isaiming", false);
        }

    }
    
}

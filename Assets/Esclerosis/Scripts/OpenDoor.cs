using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator animation;
    public bool pickedPaper = false;

    private void Start()
    {
        animation = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightHandAnchor" || other.name == "LeftHandAnchor" && pickedPaper)
        {
            animation.enabled = true;
            animation.SetBool("isOpen_Obj_1", true);
            GlobalManager.instance.fadeOut("Park");
            
        }
    }
}

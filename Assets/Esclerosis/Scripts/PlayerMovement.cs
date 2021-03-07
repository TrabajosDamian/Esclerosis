using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    int interval;

    [SerializeField]
    GameObject player;

    public Animator anim;

    [SerializeField]
    float dragMax, drag, rotation;

    bool slow;

    void Start()
    {
        player.GetComponent<OVRPlayerController>().Acceleration = drag;
        slow = false;
        StartCoroutine(WalkModifier());
    }

    IEnumerator WalkModifier()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            player.GetComponent<OVRPlayerController>().Acceleration = slow ? drag : dragMax;
            slow = !slow;
            if (slow)
            {
                anim.SetBool("blurr", true);
                StartCoroutine(WaitForRotation(0.9f));
            }
            else
            {
                anim.SetBool("blurr", false);
                StartCoroutine(WaitForUndoRotation(1.21f));
            }

        }
    }

    IEnumerator WaitForRotation(float interval)
    {
        yield return new WaitForSeconds(interval);
        transform.Rotate(0, 0, rotation);
    }

    IEnumerator WaitForUndoRotation(float interval)
    {
        yield return new WaitForSeconds(interval);
        transform.Rotate(0, 0, -rotation);
    }
}

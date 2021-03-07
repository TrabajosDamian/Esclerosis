using UnityEngine;

public class TicketGrab : MonoBehaviour
{
	public Animator animatorScreen, animatorTicket;


	private void OnTriggerEnter(Collider other)
	{
        animatorTicket.enabled = true;
        animatorScreen.enabled = true;
        animatorTicket.SetBool("grab", true);
        animatorScreen.SetBool("grab", true);
	}
}

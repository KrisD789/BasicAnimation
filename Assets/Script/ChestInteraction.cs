using UnityEngine;


public class ChestInteraction : MonoBehaviour, IInteractable
{
    Animator Anim;
    
    static bool opened;

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    public void Interaction()
    {
        Debug.Log(" Interact!!!!!!!!!!!!!!! ");

        if (!opened) Anim.SetTrigger("open");
        else Anim.SetTrigger("close");

        opened = !opened;
    }

}

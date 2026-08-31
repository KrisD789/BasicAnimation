using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    Animator Anim;
    bool opened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GameObject.Find("Door").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction()
    {
        Debug.Log(" Interact!!!!!!!!!!!!!!! ");

        if (!opened) Anim.SetTrigger("open");
        else Anim.SetTrigger("close");

        opened = !opened;
    }
}

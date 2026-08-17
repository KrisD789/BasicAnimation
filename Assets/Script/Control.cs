using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Control : MonoBehaviour
{
    public float Speed = 2f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    private void FixedUpdate()
    {
        Vector3 forWard = transform.forward * Speed;
        rb.linearVelocity = new Vector3(forWard.x, rb.linearVelocity.y, forWard.z);
    }

}
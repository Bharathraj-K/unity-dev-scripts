using UnityEngine;
using UnityEngine.Rendering;

public class PickUpAndThrow : MonoBehaviour
{
    public float throwSpeed = 100f;
    public Transform pickUpPosition;
    public Camera cam;
    public float castDistance = 5f;

    private bool pickedUp = false;
    private GameObject pickup;
    private Rigidbody rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !pickedUp)
        {
            TryPickUp();
        }
        if(pickedUp && pickup != null)
        {
            pickup.transform.position = pickUpPosition.position;
            if (Input.GetMouseButtonDown(0) && pickedUp)
            {
                Throw();
            }
        }
    }

    void TryPickUp()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, castDistance))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                pickup = hit.collider.gameObject;
                rb = pickup.GetComponent<Rigidbody>();

                rb.isKinematic = true;
                rb.useGravity = false;

                pickedUp = true;
            }
        }
    }

    void Throw()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(cam.transform.forward * throwSpeed);

        pickedUp = false;
        pickup = null;
        rb = null;
    }
}

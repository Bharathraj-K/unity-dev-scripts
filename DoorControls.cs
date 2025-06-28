using UnityEngine;

public class DoorControls : MonoBehaviour
{
    public GameObject doorPivot;
    public float speed = 2f;

    private Quaternion openRotation;
    private Quaternion closedRotation;
    private bool playerNear = false;
    private bool isOpen = false;

    void Start()
    {
        closedRotation = doorPivot.transform.rotation;
        openRotation = Quaternion.Euler(doorPivot.transform.eulerAngles + new Vector3(0, 80, 0));
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.F))
        {
            isOpen = !isOpen;
        }

        if (isOpen)
        {
            doorPivot.transform.rotation = Quaternion.Lerp(doorPivot.transform.rotation, openRotation, Time.deltaTime * speed);
        }
        else
        {
            doorPivot.transform.rotation = Quaternion.Lerp(doorPivot.transform.rotation, closedRotation, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}

using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    
    public GameObject noteCanvas;
    public GameObject interactCanvas;
    public float castDistance;
    [TextArea(3, 10)]
    public string noteText;

    private Outline ot;
    private Camera playerCam;
    private TextMeshProUGUI note;
    private bool isReading = false;


    void Start()
    {
        playerCam = Camera.main;
        note = noteCanvas.GetComponentInChildren<TextMeshProUGUI>();
        note.text = noteText;
        ot = GetComponent<Outline>();
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, castDistance))
        {
            if (hit.collider.CompareTag("Note"))
            {
                interactCanvas.SetActive(!isReading);
                ot.enabled = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    isReading = true;
                    noteCanvas.SetActive(true);
                }
            }
        }
        else
        {
            isReading = false;
            noteCanvas.SetActive(false);
            interactCanvas.SetActive(false);
            ot.enabled = false;
        }
        

    }
}

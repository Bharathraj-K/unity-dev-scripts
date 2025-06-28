using UnityEngine;

public class FlashControls : MonoBehaviour
{
    public GameObject Flashlight;
    private bool isOn = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flashlight.SetActive(isOn);
            isOn = !isOn;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lever : MonoBehaviour
{
    [SerializeField] TMP_Text dialogs;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animator Lever_1; 
    [SerializeField] Animator Up_2;

    bool Lever1;
    bool Up2;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            dialogs.text = "- Presione 'K' -";
        }

        if (Input.GetKey(KeyCode.K))
        {
            Lever_1.SetBool("Lever", true);
            Lever1 = true;
            Up_2.SetBool("CanUp", true);
            Up2 = true;

        }
        if (Lever1)
        {
            dialogs.text = "- Mecanismo Activado - ";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
        }
    }
}

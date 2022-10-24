using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] TMP_Text dialogs;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animator doorAnim;

    bool doorOpen;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            dialogs.text = "-Inserte tajeta- 'K'";

            if (Input.GetKey(KeyCode.K))
            {
                doorAnim.SetBool("UseKey", true);
                doorOpen = true;
            }

            if (doorOpen)
            {
                dialogs.text = "- Salida de emergencia activada - ";
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
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
            if (gameManager.IsKey == false && !doorOpen)
            {
                dialogs.text = "-PUERTA BLOQUEADA - Necesitas una tajeta de acceso-";
            }
            else
            {
                dialogs.text = "-Inserte tajeta- 'K'";
            }

            if (Input.GetKey(KeyCode.K))
            {
                doorAnim.SetBool("UseKey", true);
                doorOpen = true;
            }
            if (doorOpen)
            { 
            dialogs.text = "-Entrando Floor 2- ";
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
 
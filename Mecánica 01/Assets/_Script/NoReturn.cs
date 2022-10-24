using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoReturn : MonoBehaviour
{
    [SerializeField] TMP_Text dialogs;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] GameManager gameManager;

    bool doorOpen;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        dialogPanel.SetActive(true);  
        dialogs.text = "- ERROR - No se puede usar esta puerta";
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


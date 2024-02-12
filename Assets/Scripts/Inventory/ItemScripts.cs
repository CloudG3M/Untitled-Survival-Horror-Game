using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScripts : MonoBehaviour
{
    public ItemData _name;
    public TextMeshPro pickup;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GetComponent<GameManager>()._selectedItem = _name;
        CharacterTankController.instance.GetComponent<CharacterTankController>()._iteminRange = true;
        CharacterTankController.instance.GetComponent<CharacterTankController>()._pickupObject = this.gameObject;
        if (other.tag == "Player")
        {
            pickup.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.GetComponent<GameManager>()._selectedItem = null;
        CharacterTankController.instance.GetComponent<CharacterTankController>()._iteminRange = false;
        CharacterTankController.instance.GetComponent<CharacterTankController>()._pickupObject = null;
        if (other.tag == "Player")
        {
            pickup.gameObject.SetActive(false);
        }
    }
}
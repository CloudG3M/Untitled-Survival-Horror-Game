using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScripts : MonoBehaviour
{
    public ItemData _name;
    public TextMeshPro pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.GetComponent<GameManager>()._selectedItem = _name;
        PlayerController.instance.GetComponent<PlayerController>()._iteminRange = true;
        PlayerController.instance.GetComponent<PlayerController>()._pickupObject = this.gameObject;
        if (other.tag == "Player")
        {
            pickup.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameManager.instance.GetComponent<GameManager>()._selectedItem = null;
        PlayerController.instance.GetComponent<PlayerController>()._iteminRange = false;
        PlayerController.instance.GetComponent<PlayerController>()._pickupObject = null;
        if (other.tag == "Player")
        {
            pickup.gameObject.SetActive(false);
        }
    }
}
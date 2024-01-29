using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControl : MonoBehaviour
{
    public GameObject map;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MapView()
    {
        //Debug.Log("open map");
        map.SetActive(true);
        GameManager.instance.GetComponent<GameManager>().canvas.SetActive(false);
    }
    
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;

    public void OnSlotSelected(ItemSlot selectedSlot)
    {
        if (selectedSlot._itemData == null)
        {
            _itemNameText.ClearMesh();
            _itemDescriptionText.ClearMesh();
            return;
        }

        _itemNameText.SetText(selectedSlot._itemData.Name);
        _itemDescriptionText.SetText(selectedSlot._itemData.Description[0]);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject map;
    private void ExitGame()
    {
        Application.Quit();
    }

    public void MapView()
    {
        //Debug.Log("open map");
        map.SetActive(true);
        GameManager.instance.GetComponent<GameManager>().canvas.SetActive(false);
    }

    private void Awake()
    {
        menuButtons = new Button[] { equip, use, inspect, combine, drop };
    }

    public Button equip;
    public Button use;
    public Button inspect;
    public Button combine;
    public Button drop;
    public Button[] menuButtons;
    public bool[] menuBool;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;

    public void OnSlotSelected(ItemSlot selectedSlot)
    {
        if (selectedSlot._itemData == null)
        {
            _itemNameText.ClearMesh();
            _itemDescriptionText.ClearMesh();
            foreach(Button b in menuButtons)
            {
                b.gameObject.SetActive(false);
            }
            return;
        }

        _itemNameText.SetText(selectedSlot._itemData.Name);
        _itemDescriptionText.SetText(selectedSlot._itemData.Description[0]);
        menuBool = new bool[] { selectedSlot._itemData.equip, selectedSlot._itemData.use, selectedSlot._itemData.inspect, selectedSlot._itemData.combine, selectedSlot._itemData.drop };
        for (int i = 0; i < menuButtons.Length; i++)
        {
            if (menuBool[i] == true)
            {
                menuButtons[i].gameObject.SetActive(true);
            }
            else if (menuBool[i] == false)
            {
                menuButtons[i].gameObject.SetActive(false);
            }
        }
    }


}

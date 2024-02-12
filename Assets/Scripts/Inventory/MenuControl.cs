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

    public Button equip;
    public Button use;
    public Button inspect;
    public Button combine;
    public Button drop;
    public Button[] menuButtons;
    public List<bool> menuBool;

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
        menuBool.Add(selectedSlot._itemData.equip);
        menuBool.Add(selectedSlot._itemData.use);
        menuBool.Add(selectedSlot._itemData.inspect);
        menuBool.Add(selectedSlot._itemData.combine);
        menuBool.Add(selectedSlot._itemData.drop);
    }


}

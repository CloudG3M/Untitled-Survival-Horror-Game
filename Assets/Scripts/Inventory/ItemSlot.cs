using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, ISelectHandler
{
    public ItemData _itemData;

    public MenuControl _menuControl;
    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log("Selected");
        _menuControl.OnSlotSelected(this.GetComponent<ItemSlot>());
    }

    private void Awake()
    {
        _menuControl = FindObjectOfType<MenuControl>();
        invUpdate();
    }
    public void invUpdate()
    {
        if (_itemData == null) return;
        var spawnedSprite = Instantiate<Image>(_itemData.Sprite, transform.position, Quaternion.identity, transform);
    }
}


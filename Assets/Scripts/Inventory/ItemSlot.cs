using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, ISelectHandler
{
    public ItemData _itemData;

    private MenuControl _menuControl;
    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log("Selected");
        _menuControl.OnSlotSelected(this);
    }

    private void Awake()
    {
        invUpdate();
    }
    public void invUpdate()
    {
        _menuControl = FindObjectOfType<MenuControl>();
        if (_itemData == null) return;
        var spawnedSprite = Instantiate<Image>(_itemData.Sprite, transform.position, Quaternion.identity, transform);
    }
}


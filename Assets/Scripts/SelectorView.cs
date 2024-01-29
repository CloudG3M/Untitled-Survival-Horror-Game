using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectorView : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        var selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null) return;

        transform.position = Vector3.Lerp(transform.position, selected.transform.position, _speed * Time.deltaTime);

        var otherRect = selected.GetComponent<RectTransform>();

        var horizonallerp = Mathf.Lerp(_rectTransform.rect.size.x, otherRect.rect.size.x, _speed * Time.deltaTime);
        var verticallerp = Mathf.Lerp(_rectTransform.rect.size.y, otherRect.rect.size.y, _speed * Time.deltaTime);

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horizonallerp);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, verticallerp);

    }
}

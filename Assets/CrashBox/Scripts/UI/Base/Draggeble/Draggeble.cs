using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggeble : MonoBehaviour, IDraggable, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string Key => _key;
    public object DataContext { get; set; }

    [SerializeField] private string _key;
    [SerializeField] private GameObject _view; 
    [SerializeField] private GameObject _dragTemplate;
    [SerializeField] private string _dragContainerTag = "DragContainer";
    [SerializeField] private bool _hideViewOnDrag;
    [SerializeField] private bool _destroyEndDrag;

    private GameObject _dragItem;

    public void OnDrag(PointerEventData eventData)
    {
        _dragItem.transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var dragContainer = GameObject.FindGameObjectWithTag(_dragContainerTag);
        if (dragContainer)
        {
            _dragItem = Instantiate(_dragTemplate, dragContainer.transform);
            _dragItem.SetActive(true);
        }

        if (_hideViewOnDrag)
        {
            _view?.SetActive(false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_destroyEndDrag)
        {
            Destroy(gameObject);
        }
        else if (_hideViewOnDrag)
        {
            _view?.SetActive(true);
        }

        if (_dragItem)
        {
            Destroy(_dragItem);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldDrop : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private RectTransform _dropConteiner;

    [SerializeField]
    private KeyTemplate[] _templates;

    public void OnDrop(PointerEventData eventData)
    {
        var draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable != null)
        {
            var keyTemplate = _templates.FirstOrDefault(x => x.Key == draggable.Key);
            if (keyTemplate.Template != null)
            {
                var canvas = _dropConteiner.GetComponentInParent<Canvas>();
                var mousePosition = canvas.worldCamera.ScreenToWorldPoint(eventData.position);

                var dropItem = Instantiate(keyTemplate.Template, _dropConteiner);
                mousePosition.z = dropItem.transform.position.z;
                dropItem.transform.position = mousePosition;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsControl : MonoBehaviour
{
    [SerializeField]
    private Transform _itemsContainer;

    [SerializeField]
    private BaseViewContext[] _itemTemplates;

    [SerializeField]
    private bool HideTemplate = true;

    private List<BaseViewContext> _items;
    public List<BaseViewContext> Items =>
       _items ??= new List<BaseViewContext>();

    private GameObject _templatePool;

    private void Awake()
    {
        if (HideTemplate)
        {
            _templatePool = new GameObject();
            _templatePool.name = "_templates";
            _templatePool.transform.SetParent(transform);
            _templatePool.SetActive(false);

            foreach(var itemTemplate in _itemTemplates)
            {
                itemTemplate.transform.SetParent(_templatePool.transform);
            }
        }
    }

    public void Rebuild(IEnumerable<object> source)
    {
        Clear();

        foreach (var itemContext in source)
        {
            var template = FindTemplate(itemContext);
            if (template)
            {
                var itemView = Instantiate(template, _itemsContainer);
                itemView.SetDataContext(itemContext);

                Items.Add(itemView);
            }
        }
    }

    public void Clear()
    {
        foreach (var itemView in Items)
        {
            Destroy(itemView);
        }

        Items.Clear();
    }

    private BaseViewContext FindTemplate(object itemContext)
    {
        foreach (var itemTemplate in _itemTemplates)
        {
            if (itemContext.GetType() == itemTemplate.DataContextType)
            {
                return itemTemplate;
            }
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCardView : ViewContext<LevelCard>
{
    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private Image _previewImage;

    private void Update()
    {
        if (DataContext != null)
        {
            _nameText.text = DataContext.Name;
            _previewImage.sprite = null;
        }
    }
}

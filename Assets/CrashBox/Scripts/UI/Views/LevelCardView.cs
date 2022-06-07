using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCardView : View<LevelCard>
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
            _previewImage.sprite = DataContext.Preview;
        }
    }

    public void OnClickCard()
    {
        var startupInfo = new GameObject { name = nameof(StartupInfo) };
        DontDestroyOnLoad(startupInfo);

        var si = startupInfo.AddComponent<StartupInfo>();
        si.LevelTemplate = DataContext.Template;

        SceneManager.LoadScene("Game");
    }
}

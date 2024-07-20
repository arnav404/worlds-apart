using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public MenuInfo info;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        Color normalColor = new Color(0f/255.0f, 177.0f/255.0f, 79.0f/255.0f, 0.9f);
        Color highlightedColor = new Color(0f/255.0f, 177.0f/255.0f, 79.0f/255.0f, 1f);
        int name = int.Parse(this.gameObject.name);
        if(info.completed[name-1]) {
            ColorBlock cb = button.colors;
            cb.normalColor = normalColor;
            cb.highlightedColor = highlightedColor;
            button.colors = cb;
        }
    }

}

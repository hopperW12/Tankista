using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] 
public class UIInfo
{
    public string Name;
    public GameObject ui;
}
public class UIManager : MonoBehaviour
{
    [SerializeField] 
    public UIInfo[] uis;

    private GameObject _ui;

    public void Show(string name)
    {
        if (_ui != null) 
            Hide();
        
        UIInfo uiInfo = uis
            .Where(info => info.Name == name)
            .FirstOrDefault();
        if (uiInfo == null)
            return;
        
        _ui = Instantiate(uiInfo.ui, GameObject.Find("Canvas").transform);
    }

    public void Hide()
    {
        if (_ui != null)
            DestroyImmediate(_ui);
    }
}

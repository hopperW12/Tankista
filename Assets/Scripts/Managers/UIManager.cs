using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] 
public class UIInfo //Trida ktera slouzi pro dynamicke pridavani UI v editoru
{
    public string Name;
    public GameObject ui;
}
public class UIManager : MonoBehaviour
{
    [SerializeField] 
    public UIInfo[] uis; //Seznam UI

    private GameObject _ui;

    //Zobrazit UI
    public void Show(string name)
    {
        //Pokud je nastaveno nejake UI tak ho schovej
        if (_ui != null) 
            Hide();
        
        //Projede seznam UI a najde to ktere potrebuji - jedna se o for(;;;) ale zjednoduseny 
        UIInfo uiInfo = uis
            .Where(info => info.Name == name)
            .FirstOrDefault();
        //Podminka aby se nevytvarel prazdna instance
        if (uiInfo == null)
            return;
        
        //Vytvoreni kopie ui na canvas(hlavni komponent na UI)
        _ui = Instantiate(uiInfo.ui, GameObject.Find("Canvas").transform);
    }

    //Schovani UI pokud existuje
    public void Hide()
    {
        if (_ui != null)
            Destroy(_ui);
    }
}

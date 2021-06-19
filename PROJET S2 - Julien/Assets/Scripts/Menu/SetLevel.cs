using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject village;
    [SerializeField] GameObject foret;
    [SerializeField] GameObject site;
    [SerializeField] GameObject grotte;
    [SerializeField] GameObject laby;
    [SerializeField] GameObject arene;

    public void SetForet()
    {
        menu.SetActive(false);
        village.SetActive(false);
        foret.SetActive(true);
        Cursor.visible = false;
    }
    public void SetSite()
    {
        menu.SetActive(false);
        village.SetActive(false);
        site.SetActive(true);
        Cursor.visible = false;
    }
    public void SetGrotte()
    {
        menu.SetActive(false);
        village.SetActive(false);
        grotte.SetActive(true);
        Cursor.visible = false;
    }
    public void SetLaby()
    {
        menu.SetActive(false);
        village.SetActive(false);
        laby.SetActive(true);
        Cursor.visible = false;
    }
    public void SetArene()
    {
        menu.SetActive(false);
        village.SetActive(false);
        arene.SetActive(true);
        Cursor.visible = false;
    }
}

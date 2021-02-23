using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] Menu[] menus; //Array (ou liste) des menus

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName) //Ouvre un menu en fonction de son nom
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName) //Ouvre le menu menus[i]
            {
                menus[i].Open();
            }
            else if (menus[i].open)             //Ferme les autres
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)             //Ouvre un menu en fonction de son "ID"
    {
        for (int i = 0; i < menus.Length; i++)  //Ferme tous les menus
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();                            //Ouvre le menu
    }

    public void CloseMenu(Menu menu)            //Ferme le menu
    {
        menu.Close();
    }
}

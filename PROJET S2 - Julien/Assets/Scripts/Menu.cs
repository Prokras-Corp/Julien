using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;

    public void Open()  //Ouvre un menu
    {
        open = true;
        gameObject.SetActive(true);
    }

    public void Close() //Ferme un menu
    {
        open = false;
        gameObject.SetActive(false);
    }
}

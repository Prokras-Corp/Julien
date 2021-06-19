using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    #region Singleton

    public static Armor instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning Armor Inventory already exists");
            return;
        }
        instance = this;
    }
    
    #endregion
    
    public List<Equipment> armor = new List<Equipment>();

    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;

    public int space = 5;

    public bool Add(Equipment item)
    {
        if (!item.isDefault)
        {
            if (armor.Count - space != 0)
            {
                armor.Add(item);
                if (OnItemChangedCallback != null)
                {
                    OnItemChangedCallback.Invoke();
                }
            }
            else
            {
                Debug.Log("Not enough Inventory space.");
                return false;
            }
        }

        return true;

    }

    public void Remove(Equipment item)
    {
        armor.Remove(item);
    }
}

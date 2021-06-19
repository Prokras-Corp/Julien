using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning more than one inventory found.");
            return;
        }
        instance = this;
    }
    
    #endregion

    void Start()
    {
        inventory.SetActive(true);
    }
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;

    public int space = 16;

    public bool Add(Item item)
    {
        if (!item.isDefault)
        {
            if (items.Count - space != 0)
            {
                items.Add(item);
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

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}

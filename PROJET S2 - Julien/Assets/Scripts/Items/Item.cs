using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;


    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public void AddtoArmor()
    {
        if (this is Equipment)
        {
            Armor.instance.Add((Equipment) this);
        }
    }

    public void ArmorToInventory()
    {
        if (this is Equipment)
        {
            Armor.instance.Remove((Equipment) this);
        }
        Inventory.instance.Add(this);
    }
    
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlots equipSlot;
    public int armorModifier;
    public int damageModifier;


    public override void Use()
    {
        base.Use();

        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}


public enum EquipmentSlots
{
    Helmet,
    Breastplate,
    Leggings,
    Boots,
    Ring
}
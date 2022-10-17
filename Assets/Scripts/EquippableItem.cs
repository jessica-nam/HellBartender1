using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType{
    FirstDrink,
    SecondDrink,
    ThirdDrink,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int Drink;
    [Space]
    public float DrinkPercent;
    [Space]
    public EquipmentType EquipmentType;

}

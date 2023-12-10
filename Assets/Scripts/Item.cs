using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int quantity;

    public ItemType itemType;
    public string itemDescription;
}

public enum ItemType
{
    Nan, //предмета нет
    DoubleJamp, 
    Dash,
    SlowLanding, 

    Water,
    BaseForOintment,
    Pot,
    VioletWebcap,
    GlossyGloss,
    FlyAgaric,
    Chanterelle,

    OintmentFromFlyAgaric,
    NutritionalMedicine,
    MedicineForMemory,
    Powder,
    StomachMedicine,
    Dummy
}

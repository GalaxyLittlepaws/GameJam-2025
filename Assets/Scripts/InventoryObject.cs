using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory Item")]
public class InventoryObject : ScriptableObject {
    public string objectName;
    public Texture2D icon;
}

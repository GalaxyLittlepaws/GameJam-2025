using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory Item")]
public class InventoryObject : ScriptableObject {
    public string objectName;
    public Sprite icon;
    public Texture2D cursor;
    public List<InventoryObject> canCombineWith;
    public List<InventoryObject> objectWhenCombined;
    public List<bool> toggleBlue;
}

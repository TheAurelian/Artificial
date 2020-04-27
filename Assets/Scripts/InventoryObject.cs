using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object as it appears in the inventory menu UI")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("Description of the inventory object that will be displayed in the invetory menu when selected")]
    [TextArea(3, 6)]
    [SerializeField]
    private string description;

    [Tooltip("Icon of the inventory object that will be displayed in the invetory menu")]
    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;
    public string ObjectName => objectName;
    public string Description => description;

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    /// <summary>
    /// When the player interacts with an invetory object; 
    /// Add inventory object to playerinventory list and remove from the object from the game world without destroying it (disable collider and renderer)
    /// </summary>
    public override void InteractiveWith()
    {
        base.InteractiveWith();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        collider.enabled = false;
        Debug.Log($"Inventory menu game obect name {InventoryMenu.Instance.name}");
    }
}

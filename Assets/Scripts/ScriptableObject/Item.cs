using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Item", menuName="Inventory/Item")]
public class Item : ScriptableObject {

	public string name = "New Name";
	public Sprite sprite = null;
	public bool bDefault = false;
}

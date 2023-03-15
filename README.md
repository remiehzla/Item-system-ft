# Item-system-ft

**User guide**
**Base**
- Create a ScriptableObject 
o Add a name, ID and sprite (more features can be added in the Item 
script)
o Rigidbody
o Collider
- Press “I” (capital i) to access the inventory UI.
Inherit the IDataManger script and add its LoadData() and SaveData() methods to 
any scripts that you wish to save data from. In addition to this, the data has to be 
initialized in the GameData constructor as well.

**Dictionary**
- Create an object, generate an unique ID and save it in the dictionary.
o Add a GUID using the generator.
▪ Or use a custom name instead of an ID
- Use the ItemPickup script, which can be customized to your liking.

**List**
- Create an object
- Assign the ItemController script
- Assign the PickupItem script
- Add the corresponding ScriptableObject (for the Inventory UI) for both scripts
Both work together with my saving system, but only the objects in the list will be 
added to the inventory UI.

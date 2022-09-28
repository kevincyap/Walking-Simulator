using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ToggleInventory() {
        SetInventory(!canvas.activeSelf);
    }
    public void SetInventory(bool val) {
        canvas.SetActive(val);
        SceneController.instance.SetPause(val);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            ToggleInventory();
        }
    }
}

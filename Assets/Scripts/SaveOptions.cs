using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveOptions : MonoBehaviour
{
    private Dropdown dropdownMenu;
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        dropdownMenu = GetComponent<Dropdown>();
        Debug.Log("Dropdown Value la inceput:" + dropdownMenu.value);
    }

    // Update is called once per frame
    void Update()
    {
        value = dropdownMenu.value;
        
    }

}

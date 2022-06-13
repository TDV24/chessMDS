using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTable : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1, sprite2, sprite3;

    void Start()
    {   
        
        int valoareSalvata = PlayerPrefs.GetInt("tema");
        if (valoareSalvata > 0)
        {
            switch (valoareSalvata)
            {
                case 1:
                    spriteRenderer.sprite = sprite1;
                    break;
                case 2:
                    spriteRenderer.sprite = sprite2;
                    break;
                case 3:
                    spriteRenderer.sprite = sprite3;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

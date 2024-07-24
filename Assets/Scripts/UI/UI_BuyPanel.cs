using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BuyPanel : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        StoreManger.instance.CreateItem(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

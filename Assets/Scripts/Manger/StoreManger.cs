using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManger : MonoBehaviour
{
    public static StoreManger instance;

    public GameObject prefabItem;

    private GameObject storePanel;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    //TODO 后边完善
    void BuyItem(int id)
    {
    }

    public void CreateItem(GameObject panel)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject prefab = Instantiate(prefabItem);
            prefab.transform.parent = panel.transform;
        }
    }
}
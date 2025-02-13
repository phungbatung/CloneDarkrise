using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TestCode : MonoBehaviour
{
    public Button btn;
    public TMP_InputField inp;
    public GameObject prefab;
    private List<GameObject> enemies;

    private void Awake()
    {
        btn.onClick.AddListener(Spawn);
        enemies = new List<GameObject>();
    }
    private void Spawn()
    {
        int quantity = int.Parse(inp.text);
        int quantityDiff = Mathf.Abs(quantity-enemies.Count);
        if(quantity - enemies.Count>0)
        {
            for(int i =0; i <quantityDiff; i++)
            {
                GameObject go = Instantiate(prefab);
                enemies.Add(go);
            }    
        }
        else
        {
            for (int i = 0; i < quantityDiff; i++)
            {
                Destroy(enemies[0]);
                enemies.RemoveAt(0);
            }
        }    
    }    


}

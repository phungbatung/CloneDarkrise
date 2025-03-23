using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollector : MonoBehaviour
{
    [SerializeField] private GameObject interactButtonPrefab;
    private Dictionary<InteractableObject, InteractButton> interactButtons;
    private void Awake()
    {
        interactButtons = new();
    }
    public void Add(InteractableObject _obj)
    {
        InteractButton button = Instantiate(interactButtonPrefab, transform).GetComponent<InteractButton>();
        button.SetInteractableObject( _obj );
        interactButtons[_obj] = button;
    }

    //private void Update()
    //{
    //    foreach (var kvp in interactButtons)
    //    {
    //        if (kvp.Key == null)
    //            Remove(kvp.Key);
    //    }
    //}

    public void Remove(InteractableObject _obj)
    {
        try
        {
            if (!interactButtons.ContainsKey(_obj))
                return;
            Destroy(interactButtons[_obj].gameObject);
            interactButtons.Remove(_obj);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}

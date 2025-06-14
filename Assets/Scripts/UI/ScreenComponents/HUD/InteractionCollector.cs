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


    public void Remove(InteractableObject _obj)
    {
        if (_obj == null || !interactButtons.ContainsKey(_obj))
            return;
        Destroy(interactButtons[_obj].gameObject);
        interactButtons.Remove(_obj);
    }

}

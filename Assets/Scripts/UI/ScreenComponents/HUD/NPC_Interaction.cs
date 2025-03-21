using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    private Dictionary<InteractableObject, InteractButton> interactButtons;
    private void Awake()
    {
        interactButtons = new();
    }
    public void Add(InteractableObject _obj)
    {
        InteractButton button = Instantiate(interactButton, transform).GetComponent<InteractButton>();
        button.SetInteractableObject( _obj );
        interactButtons[_obj] = button;
    }

    public void Remove(InteractableObject _obj)
    {
        Destroy(interactButtons[_obj].gameObject);
        interactButtons.Remove(_obj);
    }
}

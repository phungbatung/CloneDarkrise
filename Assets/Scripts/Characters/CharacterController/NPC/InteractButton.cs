using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerClickHandler
{
    private InteractableObject npc;
    public void OnPointerClick(PointerEventData eventData)
    {
        npc.InteractAction(); 
    }
    public void SetInteractableObject(InteractableObject _npc)
    {
        npc = _npc;
    }
}

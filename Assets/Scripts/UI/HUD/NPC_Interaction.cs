using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject interact_NPC_Button;
    private Dictionary<NPC, NPC_InteractButton> interactButtons;
    private void Awake()
    {
        interactButtons = new();
    }
    public void Add(NPC _npc)
    {
        NPC_InteractButton button = Instantiate(interact_NPC_Button, transform).GetComponent<NPC_InteractButton>();
        button.SetNPC( _npc );
        interactButtons[_npc] = button;
    }

    public void Remove(NPC _npc)
    {
        Destroy(interactButtons[_npc].gameObject);
        interactButtons.Remove(_npc);
    }
}

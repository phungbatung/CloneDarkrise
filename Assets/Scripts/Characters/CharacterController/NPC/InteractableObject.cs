using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void InteractAction();

    //private void OnDisable()
    //{
    //    PlayerManager.Instance?.player?.detector?.outZoneNPC(this);
    //}

}

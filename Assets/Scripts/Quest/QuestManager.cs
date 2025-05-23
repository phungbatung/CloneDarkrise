using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance.gameObject);
    }
}

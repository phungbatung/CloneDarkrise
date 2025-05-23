using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStepState : MonoBehaviour
{
    public string state;
    public string status;

    public QuestStepState(string state, string status)
    {
        this.state = state;
        this.status = status;
    }

    public QuestStepState()
    {
        this.state = "";
        this.status = "";
    }
}

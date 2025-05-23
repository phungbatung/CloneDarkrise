using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public QuestInfo QuestInfo { get; private set; }

    public QuestState QuestState { get; private set; }

    public int QuestStep { get; private set; }

    public QuestStepState[] QuestStepStates { get; private set; }

    public Quest(QuestInfo questInfo)
    {
        QuestInfo = questInfo;
        QuestState = QuestState.REQUIREMENTS_NOT_MET;
        QuestStep = 0;
        QuestStepStates = new QuestStepState[QuestInfo.QuestSteps.Length];
        for(int i = 0; i < QuestInfo.QuestSteps.Length; i++)
        {
            QuestStepStates[i] = new QuestStepState();
        }
    }
    public Quest(QuestInfo questInfo, QuestState questState, int questStep, QuestStepState[] questStepStates)
    {
        QuestInfo = questInfo;
        QuestState = questState;
        QuestStep = questStep;
        QuestStepStates = questStepStates;
    }
}

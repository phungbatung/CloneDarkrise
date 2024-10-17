using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BuffModel
{
    private BuffManager buffManager;
    public int itemId;
    public float timeLeft { get; private set; }
    public Action<float> CountdownEvent;
    public Action EndBuffEvent;
    
    public BuffModel(BuffManager _buffManager, int _itemId,  float _timeLeft)
    {
        buffManager = _buffManager;
        itemId = _itemId;
        timeLeft = _timeLeft;
    }

    public void Countdown(float _deltaTime)
    {
        timeLeft -= _deltaTime;
        CountdownEvent?.Invoke(timeLeft);
        CheckForEndBuff();
    }

    public void CheckForEndBuff()
    {
        if (timeLeft <= 0)
        {
            buffManager.EndBuff(itemId);
            EndBuffEvent?.Invoke();
        }
    }
}

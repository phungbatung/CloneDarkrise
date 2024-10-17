using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPresenter
{
    public BuffModel buffModel { get; private set; }
    private BuffView buffView;

    public BuffPresenter(BuffManager _buffManager, BuffView _buffView, int _itemId, float _buffDuration)
    {
        buffModel = new BuffModel(_buffManager, _itemId, _buffDuration);
        buffView = _buffView;

        buffView.SetIcon(ItemManager.Instance.itemDict[_itemId].icon);
        buffModel.CountdownEvent += UpdateView;
        buffModel.EndBuffEvent += EndBuff;
    }
    public void ExecuteCountDown(float _deltaTime)
    {
        buffModel.Countdown(_deltaTime);
    }
    public void UpdateView(float _timeLeft)
    {
        buffView.SetTimeLeft(_timeLeft);
    }

    public void EndBuff()
    {
        buffView?.EndBuff();
    }

}

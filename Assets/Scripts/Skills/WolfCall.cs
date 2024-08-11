using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCall : Skill
{
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private int quantity;
    [SerializeField] private float wolfLifeTime;
    [SerializeField] private Vector3 spawnPosition;
    public override void Called()
    {
        player.stateMachine.ChangeState(player.wolfCall);
    }

    public void WolfsCall()
    {
        for (int i=0; i<quantity; i++)
        {
            GameObject wolf = Instantiate(wolfPrefab);
            Vector3 offset;
            if (i == 0)
                offset = new Vector3(player.facingDir * spawnPosition.x, spawnPosition.y, spawnPosition.z);
            else if (i == 1)
                offset = new Vector3(-player.facingDir * spawnPosition.x, spawnPosition.y, spawnPosition.z);
            else
                offset = new Vector3(0, spawnPosition.y, spawnPosition.z);
            wolf.GetComponent<Wolf>().SetUpWolf(player, player.transform.position + offset, wolfLifeTime);
        }
    }
}

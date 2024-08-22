using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightCut : Skill
{
    [SerializeField] private GameObject lightPrefabs;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Vector2 slashSize;
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.lightCut);
    }

    public void Cut()
    {
        float distanceToMove=maxDistance;
        RaycastHit2D hit=Physics2D.Raycast(player.transform.position, new Vector2(player.facingDir, 0), maxDistance, wallLayer);
        if (hit == true)
            distanceToMove = hit.distance;
        player.transform.position = player.transform.position + new Vector3(player.facingDir*(distanceToMove-1f), 0, 0);
        CreateLightSlash();  
    }    

    private void CreateLightSlash()
    {
        GameObject lightSlash = Instantiate(lightPrefabs);
        lightSlash?.GetComponent<LightSlashController>()?.SetUpLightSlash(player, slashSize);
    }
}

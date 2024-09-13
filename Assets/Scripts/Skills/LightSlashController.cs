using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSlashController : MonoBehaviour
{
    private Player player;
    private LightCut lightCut;
    private float cutDir;
    private Vector2 size;

    public void SetUpLightSlash(Player _player, Vector2 _size, LightCut _lightCut)
    {
        player = _player;
        lightCut = _lightCut;
        transform.position = _player.transform.position;
        size = _size;
        cutDir = _player.facingDir;
        if (cutDir == -1)
            Flip();
    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    public void Attack()
    {
        LightCutLevelData lightCutLevelData = lightCut.skillData.levelsData[lightCut.currentLevel] as LightCutLevelData;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(player.facingDir * size.x/2, 0, 0), size, 0);
        foreach (Collider2D collider in colliders)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                player.stats.DoDamage(target, lightCutLevelData.damagePercentage);
            }
        }
    }
    public void DestroyGO()
    {
        Destroy(gameObject);
    }

}

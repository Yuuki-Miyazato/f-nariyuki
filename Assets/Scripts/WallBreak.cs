using UnityEngine;

public class WallBreak : MonoBehaviour
{
 private int hp = 1; //内壁のhp

    private SpriteRenderer spriteRenderer;
    
    public void DamageWall(int loss)
    {
        hp -= loss;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
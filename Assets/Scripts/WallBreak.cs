using UnityEngine;

public class WallBreak : MonoBehaviour
{

    public Sprite dmgSprite; //破壊されているときの画像
    public int hp = 1; //内壁のhp

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
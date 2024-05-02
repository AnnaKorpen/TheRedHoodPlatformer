using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite realWorldSprite;
    [SerializeField] private Sprite fantasyWorldSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToRealWorldSprite()
    {
        spriteRenderer.sprite = realWorldSprite;
    }

    public void ChangeToFantasyWorldSprite()
    {
        spriteRenderer.sprite = fantasyWorldSprite;
    }
}

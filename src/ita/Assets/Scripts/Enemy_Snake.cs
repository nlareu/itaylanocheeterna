using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy_Snake : ScriptExecuterBehaviour {

    public TimeInterval HitInterval = new TimeInterval(1f);
    private Sprite Sprite_0;
    public Sprite Sprite_1;
    public Sprite Sprite_2;

    private BoxCollider2D boxCollider;
    private Vector2 boxColliderOriginalOffset;
    private Vector2 boxColliderOriginalSize;
    private SpriteRenderer spriteRenderer;
    //private Vector2 starterPosition;
    //private Vector2 starterScale;

    // Use this for initialization
    void Awake() {
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.tag = "Snake";

        this.boxColliderOriginalOffset = new Vector2(this.boxCollider.offset.x, this.boxCollider.offset.y);
        this.boxColliderOriginalSize = new Vector2(this.boxCollider.size.x, this.boxCollider.size.y);
        this.Sprite_0 = this.spriteRenderer.sprite;
        //this.starterScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y);
        //this.starterPosition = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void FixedUpdate () {
        if (this.Executing == true)
        {
            this.HitInterval.Accumulate();

            if ((this.HitInterval.Value >= 0f) && (this.HitInterval.Value < 0.25f))
            {
                this.boxCollider.offset = new Vector2(1.115984f, this.boxColliderOriginalOffset.y);
                this.boxCollider.size = new Vector2(2.237789f, this.boxColliderOriginalSize.y);
                this.spriteRenderer.sprite = this.Sprite_1;
                //this.transform.localScale = new Vector2(4f, this.starterScale.y);
                //this.transform.position = new Vector2(68f, this.starterPosition.y);
            }
            else if ((this.HitInterval.Value >= 0.25f) && (this.HitInterval.Value < 0.5f))
            {
                this.boxCollider.offset = new Vector2(0.008533478f, this.boxColliderOriginalOffset.y);
                this.boxCollider.size = new Vector2(4.45269f, this.boxColliderOriginalSize.y);
                this.spriteRenderer.sprite = this.Sprite_2;
                //this.transform.localScale = new Vector2(8f, this.starterScale.y);
                //this.transform.position = new Vector2(65f, this.starterPosition.y);
            }
            else if ((this.HitInterval.Value >= 0.5f) && (this.HitInterval.Value < 0.75f))
            {
                this.boxCollider.offset = new Vector2(1.115984f, this.boxColliderOriginalOffset.y);
                this.boxCollider.size = new Vector2(2.237789f, this.boxColliderOriginalSize.y);
                this.spriteRenderer.sprite = this.Sprite_1;
                //this.transform.localScale = new Vector2(4f, this.starterScale.y);
                //this.transform.position = new Vector2(68f, this.starterPosition.y);
            }
            else
            {
                //Set collider size to its original value.
                this.boxCollider.offset = new Vector2(this.boxColliderOriginalOffset.x, this.boxColliderOriginalOffset.y);
                this.boxCollider.size = new Vector2(this.boxColliderOriginalSize.x, this.boxColliderOriginalSize.y);
                this.spriteRenderer.sprite = this.Sprite_0;
                //this.transform.position = new Vector2(this.starterPosition.x, this.starterPosition.y);
                //this.transform.localScale = new Vector2(this.starterScale.x, this.starterScale.y);

                this.HitInterval.Reset();

                //Stop executing.
                this.Executing = false;
            }
        }
	}
}

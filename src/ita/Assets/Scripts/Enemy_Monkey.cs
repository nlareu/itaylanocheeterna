using UnityEngine;

public class Enemy_Monkey : ScriptStarterBehaviour
{
    public Bullet Bullet;
    public float BulletInterval = 1f;

    private TimeInterval bulletTimerInterval;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        this.bulletTimerInterval = new TimeInterval(this.BulletInterval);
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.tag = "Monkey";
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        this.bulletTimerInterval.Accumulate();

        if (this.bulletTimerInterval.IntervalExceeded == true)
        {
            Bullet bullet = Instantiate(
                this.Bullet, 
                new Vector2(
                    this.gameObject.transform.position.x,
                    this.spriteRenderer.bounds.max.y
                ),
                Quaternion.identity
            );

            this.bulletTimerInterval.Reset();
        }
	}
}

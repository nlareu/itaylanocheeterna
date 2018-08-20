using UnityEngine;

public class Enemy_AguaraguazuFemale : ScriptStarterBehaviour
{
    public float FlipColliderInterval = 1f;
    public LayerMask PlayerLayerMask;
    public GameObject VisionZonePointA;
    public GameObject VisionZonePointB;

    private Animator animator;
    private TimeInterval flipColliderTimerInterval;
    private bool visionZoneActived = false;


    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        this.flipColliderTimerInterval = new TimeInterval(this.FlipColliderInterval);
        this.tag = "AguaraguazuFemale";

        this.animator.SetBool("Looking", false);
    }

    void FixedUpdate() {
        this.flipColliderTimerInterval.Accumulate();

        //Check if must active/deactive vision zone.
        if (this.flipColliderTimerInterval.IntervalExceeded == true)
        {
            this.visionZoneActived = !this.visionZoneActived;

            this.flipColliderTimerInterval.Reset();
        }


        //Update animation
        this.animator.SetBool("Looking", this.visionZoneActived);


        //If vision zone is actived, check if player is in the vision zone.
        if (this.visionZoneActived)
        {
            Collider2D playerCollider = Physics2D.OverlapArea(this.VisionZonePointA.transform.position, this.VisionZonePointB.transform.position, this.PlayerLayerMask);

            if (playerCollider)
            {
                Debug.Log("Player in vision zone!");

                AppController.ResetGame();
            }
        }
	}
}

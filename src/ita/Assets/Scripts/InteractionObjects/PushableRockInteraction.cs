using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableRockInteraction : BaseInteraction {

	public override void StartInteraction(AvatarController avatar){
        var objRb = this.gameObject.GetComponent<Rigidbody2D>();
        var avRb = avatar.GetComponent<Rigidbody2D>();

        if (avRb.position.x < objRb.position.x)
            objRb.AddForce(Vector2.right * avatar.PushForce);
        else
            objRb.AddForce(Vector2.left * avatar.PushForce);

        //this.gameObject.SetActive(false);
    }
}

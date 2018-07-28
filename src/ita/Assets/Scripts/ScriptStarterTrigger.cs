using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStarterTrigger : MonoBehaviour {

    public ScriptStarter Target;

	// Use this for initialization
	void Start () {
        if (this.Target == null)
            throw new System.Exception("Target msut be set.");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        this.Target.StartScript();
    }
}

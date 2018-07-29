using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStarterTrigger : MonoBehaviour {

    public ScriptStarterBehaviour Target;
    public string TriggerTag;

    // Use this for initialization
    void Start () {
        if (this.Target == null)
            throw new System.Exception("Target must be set.");
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == this.TriggerTag)
            this.Target.StartScript();
    }
}

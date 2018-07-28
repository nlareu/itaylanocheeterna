using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptStarter : MonoBehaviour, IScriptStarter
{
    public bool Started { get; private set;}

    public ScriptStarter()
    {
        this.Started = false;

        if (this.gameObject.activeSelf == true)
            this.gameObject.SetActive(false);
    }

    //protected abstract void Execute();
    public void StartScript()
    {
        if (this.Started == false)
        {
            this.gameObject.SetActive(true);

            this.Started = true;

            //this.Execute();
        }
    }    
}
using System;
using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GlobalEvent globalEvent = ScriptableObject.CreateInstance<GlobalEvent>();
        globalEvent.Publish();
    }
}

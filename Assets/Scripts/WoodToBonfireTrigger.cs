using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodToBonfireTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddBurnedWood(collision.gameObject);
        }
    }
}

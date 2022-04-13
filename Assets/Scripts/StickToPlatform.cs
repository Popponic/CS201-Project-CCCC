using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    //void oncontrollercollisionenter(controllercolliderhit hit)
    //{
    //    if (hit.gameobject.name == "player")
    //    {
    //        hit.gameobject.transform.setparent(transform);
    //    }
    //}

    //void oncontrollercollisionexit(controllercolliderhit hit)
    //{
    //    if (hit.gameobject.name == "player")
    //    {
    //        hit.gameobject.transform.setparent(null);
    //    }
    //}

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        if (other.tag == "Player")
    //        {
    //            other.transform.SetParent(transform);
    //        }
    //    }

    //    private void OnTriggerExit(Collider other)
    //    {
    //        if (other.tag == "Player")
    //        {
    //            other.transform.SetParent(transform);
    //        }
    //    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}

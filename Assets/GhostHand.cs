using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GhostHand : MonoBehaviour
{
    public Transform trackingOriginTransform;
    public Hand hand;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = trackingOriginTransform.position + hand.transform.localPosition;
    }
}

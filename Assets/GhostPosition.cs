using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GhostPosition : MonoBehaviour
{
    public Transform trackingOriginTransform;
    private Player player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;

        if (player == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.");
            Destroy(this.gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = trackingOriginTransform.position + (player.feetPositionGuess - player.trackingOriginTransform.position);
        //print(transform.position.ToString());
    }
}

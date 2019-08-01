using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GhostModel : MonoBehaviour
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
        transform.position = new Vector3(transform.position.x, player.hmdTransform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.eyeHeight - 0.2f, transform.position.z);
    }
}

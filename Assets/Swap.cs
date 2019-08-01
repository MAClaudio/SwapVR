using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using System;

public class Swap : MonoBehaviour
{
    public Hand hand;
    public SteamVR_Action_Boolean swapAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Swap");
    private Player player = null;
    private Vector3 ghostPosition;
    public GameObject placeholder;
    public AudioClip teleportSound;

    [Header("Audio Sources")]
    public AudioSource headAudioSource;

    //-------------------------------------------------
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
    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (swapAction == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> No swap action assigned");
            return;
        }

        swapAction.AddOnChangeListener(OnSwapActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (swapAction != null)
            swapAction.RemoveOnChangeListener(OnSwapActionChange, hand.handType);
    }

    private void OnSwapActionChange(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (newState)
        {
            //print("Start");
            //print("Player position: " + player.trackingOriginTransform.position.ToString());
            //print("Ghost position: " + placeholder.transform.position.ToString());
            Vector3 tempVector = player.trackingOriginTransform.position;
            player.trackingOriginTransform.position = new Vector3(placeholder.transform.position.x, player.trackingOriginTransform.position.y, placeholder.transform.position.z);
            placeholder.transform.position = new Vector3(tempVector.x, placeholder.transform.position.y, tempVector.z);

            headAudioSource.transform.SetParent(player.hmdTransform);
            headAudioSource.transform.localPosition = Vector3.zero;
            headAudioSource.clip = teleportSound;
            headAudioSource.Play();
        }
    }
}

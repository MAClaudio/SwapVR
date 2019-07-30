using UnityEngine;
using Valve.VR;

public class Swap : MonoBehaviour
{
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    public SteamVR_Action_Boolean swapAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Swap");


    // Update is called once per frame
    void Update()
    {
        if(GetGrab())
        {
            print("Grab " + handType);
        }

        if(GetSwap())
        {
            print("Swap " + handType);
        }
    }

    public bool GetGrab() // 2
    {
        return grabGripAction.GetStateDown(handType);
    }

    public bool GetSwap()
    {
        return swapAction.GetStateDown(handType);
    }
}

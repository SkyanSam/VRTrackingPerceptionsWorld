
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.Networking;
using VRC.Core;
using VRC.Udon.Wrapper.Modules;
using System;

public class PlayerDebug : UdonSharpBehaviour
{
    VRCPlayerApi player;
    public TMPro.TextMeshPro textMeshPro;
    void Start()
    {
        var players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
        players = VRCPlayerApi.GetPlayers(players);
        player = players[0];
        Debug.Log($"VRTP|Start");
    }

    // Update is called once per frame
    void Update()
    {
        
        var trackingData = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
        Debug.Log($"VTRP|Update|{Print("position", trackingData.position)}|{Print("rotation", trackingData.rotation)}|ticks:{DateTime.Now.Ticks}");
        
        
        //var l = player.GetTrackingData(VRCPlayerApi.TrackingDataType.)
        /*
        
        var playerPosition = player.GetPosition();
        var Leyeposition = player.GetBonePosition(HumanBodyBones.LeftEye);
        var Leyerotation = player.GetBoneRotation(HumanBodyBones.LeftEye);
        var Reyeposition = player.GetBonePosition(HumanBodyBones.RightEye);
        var Reyerotation = player.GetBoneRotation(HumanBodyBones.RightEye);

        textMeshPro.text = player.displayName + "\n" + Print("Left", Leyerotation) + "\n" + Print("Right", Reyerotation);
        var str = Print(nameof(playerPosition), playerPosition) +
            Print(nameof(Leyeposition), Leyeposition) +
            Print(nameof(Leyerotation), Leyerotation) +
            Print(nameof(Reyeposition), Reyeposition) +
            Print(nameof(Reyerotation), Reyerotation);
        Debug.Log(str);*/
    }
    public string Print(string name, Vector3 vec)
    {
        return $"{name}:{vec.x},{vec.y},{vec.z}";
    }
    public string Print(string name, Quaternion vec)
    {
        return $"|{name}:{(int)vec.eulerAngles.x},{(int)vec.eulerAngles.y},{(int)vec.eulerAngles.z}|";
    }
}

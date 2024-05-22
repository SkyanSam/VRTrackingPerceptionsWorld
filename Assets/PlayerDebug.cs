
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.Networking;
using VRC.Core;
using VRC.Udon.Wrapper.Modules;
using System;
using System.CodeDom;

public class PlayerDebug : UdonSharpBehaviour
{
    public string participantDisplayName;
    public string researcherDisplayName;
    VRCPlayerApi player;
    VRCPlayerApi researcher = null;
    public TMPro.TextMeshPro textMeshPro;
    void UpdateVRCPlayerApis()
    {
        var players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
        players = VRCPlayerApi.GetPlayers(players);
        foreach (var p in players) {
            if (p.displayName == participantDisplayName)
                player = p;
            else if (p.displayName == researcherDisplayName)
                researcher = p;
        }
    }
    void Start()
    {
        UpdateVRCPlayerApis();
        Debug.Log($"VRTP|Start");
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateVRCPlayerApis();

        var trackingData = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
        var outputLine = $"VTRP|Update|{Print("position", trackingData.position)}|{Print("rotation", trackingData.rotation)}|ticks:{DateTime.UtcNow.Ticks}";
        if (researcher != null)
        {
            var researcherTrackingData = researcher.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
            outputLine += $"|{Print("rPosition", researcherTrackingData.position)}";
        }
        Debug.Log(outputLine);
    }
    public string Print(string name, Vector3 vec)
    {
        return $"{name}:{vec.x},{vec.y},{vec.z}";
    }
    public string Print(string name, Quaternion vec)
    {
        return $"|{name},{(int)vec.eulerAngles.x},{(int)vec.eulerAngles.y},{(int)vec.eulerAngles.z}|";
    }
}

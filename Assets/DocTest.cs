using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonSharp;
using VRC.SDK3.ClientSim;
using System.Runtime.CompilerServices;
using VRC.SDKBase;
public class DocTest : UdonSharpBehaviour
{
    // Start is called before the first frame update
    VRCPlayerApi player;
    void Start()
    {
        var players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
        players = VRCPlayerApi.GetPlayers(players);
        player = players[0];
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = player.GetPosition();
        var Leyeposition = player.GetBonePosition(HumanBodyBones.LeftEye);
        var Leyerotation = player.GetBoneRotation(HumanBodyBones.LeftEye);
        var Reyeposition = player.GetBonePosition(HumanBodyBones.RightEye);
        var Reyerotation = player.GetBoneRotation(HumanBodyBones.RightEye);
        var str = Print(nameof(playerPosition), playerPosition) +
            Print(nameof(Leyeposition), Leyeposition) +
            Print(nameof(Leyerotation), Leyerotation) +
            Print(nameof(Reyeposition), Reyeposition) +
            Print(nameof(Reyerotation), Reyerotation);
        Debug.Log(str);
    }
    public string Print(string name, Vector3 vec)
    {
        return $"|{name}:{vec.x},{vec.y},{vec.z}|";
    }
    public string Print(string name, Quaternion vec)
    {
        return $"|{name}:{vec.eulerAngles.x},{vec.eulerAngles.y},{vec.eulerAngles.z}|";
    }
}

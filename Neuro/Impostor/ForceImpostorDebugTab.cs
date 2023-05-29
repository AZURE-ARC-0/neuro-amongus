﻿using System.Collections.Generic;
using System.Linq;
using Neuro.Debugging;
using Neuro.Utilities;
using UnityEngine;

namespace Neuro.Impostor;

[DebugTab]
public class ForceImpostorDebugTab : DebugTab
{
    public override string Name => "Force impostor";

    public static bool Enabled { get; set; }
    public static List<string> CurrentlySelected { get; } = new();

    public override bool IsEnabled => AmongUsClient.Instance.AmHost;

    public override void BuildUI()
    {
        Enabled = GUILayout.Toggle(Enabled, $"Force Impostor: {(Enabled ? "Enabled" : "Disabled")}", GUI.skin.button);
        if (!Enabled) return;
        NeuroUtilities.GUILayoutDivider();

        IEnumerable<string> allPlayerNames = GameData.Instance.AllPlayers.ToArray().Where(d => d != null).Select(d => d.PlayerName);
        foreach (string playerName in allPlayerNames)
        {
            bool currentlyForced = CurrentlySelected.Contains(playerName);
            bool toggled = GUILayout.Toggle(currentlyForced, $"{playerName}{(currentlyForced ? " Forced" : "")}", GUI.skin.button);
            if (toggled && !currentlyForced) CurrentlySelected.Add(playerName);
            if (!toggled && currentlyForced) CurrentlySelected.Remove(playerName);
        }
    }
}

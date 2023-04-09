﻿using System.Collections;
using Neuro.Cursor;
using PowerTools;

namespace Neuro.Minigames.Solvers;

[MinigameSolver(typeof(DrillMinigame))]
public sealed class RepairDrillSolver : TaskMinigameSolver<DrillMinigame>
{
    protected override IEnumerator CompleteMinigame(DrillMinigame minigame, NormalPlayerTask task)
    {
        int buttonIndex = 0;
        while (buttonIndex < minigame.Buttons.Length)
        {
            SpriteAnim button = minigame.Buttons[buttonIndex];

            yield return InGameCursor.Instance.CoMoveTo(button);
            minigame.FixButton(button);

            if (minigame.states[buttonIndex] == minigame.MaxState) buttonIndex++;
        }
    }
}

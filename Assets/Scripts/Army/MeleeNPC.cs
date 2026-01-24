using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeNPC : Base
{
    protected override void PerformAttackAction()
    {
        base.PerformAttackAction();

        // Add melee-specific attack effects here
        // e.g., sword swing VFX, slash effect, melee sound
        // PlayMeleeSwingEffect();
    }
}
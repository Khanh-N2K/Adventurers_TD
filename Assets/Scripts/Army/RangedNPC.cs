using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedNPC : Base
{
    [Header("Archer Settings")]
    public GameObject arrowPrefab;
    public Transform shootPoint;

    protected override void PerformAttackAction()
    {
        base.PerformAttackAction();

        // Shoot arrow projectile
        if (target != null && arrowPrefab != null && shootPoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
            // Setup arrow to fly toward target
        }
    }
}

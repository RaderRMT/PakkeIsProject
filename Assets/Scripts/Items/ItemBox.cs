﻿using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class ItemBox : MonoBehaviour {

    public AttackItem[] AttackItems;

    public AttackItem GetRandomItem() {
        return AttackItems[Random.Range(0, AttackItems.Length)];
    }

    private void OnTriggerEnter(Collider other) {
        AttackController controller = other.gameObject.GetComponentInParent<AttackController>();
        if (controller == null) {
            return;
        }
        
        if (controller.HasItem()) {
            return;
        }

        DisableBox();
        controller.SetAttackItem(GetRandomItem());
    }

    private void DisableBox() {
        Destroy(gameObject);
    }
}


using System.Linq;
using UnityEngine;

public class AttackController : MonoBehaviour {
    
    private AttackItem _heldAttackItem;

    public void SetAttackItem(AttackItem attackItem) {
        if (_heldAttackItem != null) {
            return;
        }
        
        _heldAttackItem = attackItem;
    }
    
    public void UseHeldItem() {
        if (_heldAttackItem == null) {
            return;
        }
        
        _heldAttackItem.Use(FindClosestPlayer());
        _heldAttackItem = null;
    }

    private PlayerController FindClosestPlayer() {
        return FindObjectsByType<PlayerController>(FindObjectsSortMode.None)
                .Where(p => p.transform.position != transform.position)
                .OrderBy(p => Vector3.Distance(p.transform.position, transform.position))
                .FirstOrDefault();
    }
}

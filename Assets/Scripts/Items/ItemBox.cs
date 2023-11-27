using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class ItemBox : MonoBehaviour {

    public AttackItem[] AttackItems;

    private float _currentDisableTime;

    public AttackItem GetRandomItem() {
        return AttackItems[Random.Range(0, AttackItems.Length)];
    }

    private void OnTriggerEnter(Collider other) {
        AttackController controller = other.gameObject.GetComponentInParent<AttackController>();
        if (controller == null) {
            return;
        }
        
        controller.SetAttackItem(GetRandomItem());
        DisableBox();
    }

    private void DisableBox() {
        gameObject.SetActive(_currentDisableTime < 0);
    }
}


using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class ItemBox : MonoBehaviour {

    public float DisableTime;
    public AttackItem[] AttackItems;

    private float _currentDisableTime;

    private void Update() {
        if (_currentDisableTime < 0) {
            return;
        }

        _currentDisableTime -= Time.deltaTime;
        gameObject.SetActive(_currentDisableTime < 0);
    }

    public AttackItem GetRandomItem() {
        return AttackItems[Random.Range(0, AttackItems.Length)];
    }

    private void OnTriggerEnter(Collider other) {
        AttackController controller = other.gameObject.GetComponent<AttackController>();
        if (controller == null) {
            return;
        }
        
        controller.SetAttackItem(GetRandomItem());
        DisableBox();
    }

    private void DisableBox() {
        _currentDisableTime = DisableTime;
    }
}


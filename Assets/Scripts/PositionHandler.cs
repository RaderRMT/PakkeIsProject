using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PositionHandler : MonoBehaviour {

    public List<PlayerController> PlayerPositions;
    public List<Texture> PositionSprites;

    private List<PlayerController> _finishPlayers = new List<PlayerController>();

    private void Update() {
        List<PlayerController> orderedPositions = PlayerPositions.Where(p => !_finishPlayers.Contains(p))
                .OrderBy(p => gameObject.transform.position.z - p.KayakRigidbody.transform.position.z)
                .ToList();

        for (int i = 0; i < orderedPositions.Count; i++) {
            PlayerController controller = orderedPositions[i];
            controller.PlayerPositionRawImage.texture = PositionSprites[i + _finishPlayers.Count];

            if (controller.KayakRigidbody.transform.position.z > gameObject.transform.position.z) {
                _finishPlayers.Add(controller);
                
                controller.ShowFinishScreen();
                controller.DisableMovements();
            }
        }
    }
}
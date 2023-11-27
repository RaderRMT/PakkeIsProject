using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionHandler : MonoBehaviour {

    public List<PlayerController> PlayerPositions;
    public List<Texture> PositionSprites;

    private void Update() {
        List<PlayerController> orderedPositions = PlayerPositions.OrderBy(p => Vector3.Distance(p.KayakRigidbody.transform.position, gameObject.transform.position)).ToList();

        for (int i = 0; i < orderedPositions.Count; i++) {
            orderedPositions[i].PlayerPositionRawImage.texture = PositionSprites[i];
        }
    }
}
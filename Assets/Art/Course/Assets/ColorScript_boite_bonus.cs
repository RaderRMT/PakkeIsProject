using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript_boite_bonus : MonoBehaviour
{
    public Light lightObject; //Set your light Object
    public bool useRainbowColors;
    public Gradient colorGradient;
    public float duration = 20.0F;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (useRainbowColors && lightObject)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            lightObject.color = colorGradient.Evaluate(lerp);
        }
    }
}

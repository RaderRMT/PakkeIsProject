using Character;
using Character.Camera.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForDebug : MonoBehaviour
{

    [SerializeField] CanvasGroup _fadeDead;

    private float _timerDebug;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ResetTimerDebug()
    {
        _timerDebug = 0;
    }

}

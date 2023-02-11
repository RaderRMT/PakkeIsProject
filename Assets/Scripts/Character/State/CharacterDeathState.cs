﻿using Character.Camera;
using Kayak;
using UnityEngine;

namespace Character.State
{
    public class CharacterDeathState : CharacterStateBase
    {
        private KayakController _kayakController;
        private InputManagement _inputs;

        private bool _transitionIn = false;
        private bool _respawned = false;

        private float _timerToRespawnCheckpoint = 0;
        private float _timerFadeOutStart = 0;
        private float _timerFadeInEnded = 0;

        public CharacterDeathState(CharacterManager characterManagerRef, KayakController kayakController, InputManagement inputs, MonoBehaviour monoBehaviour) :
            base(characterManagerRef, monoBehaviour)
        {
            _kayakController = kayakController;
            _inputs = inputs;
        }

        public override void EnterState(CharacterManager character)
        {
            Debug.Log("death");
            CameraController.Instance.StatePlayer = CameraController.PlayerState.DeadState;
        }

        public override void UpdateState(CharacterManager character)
        {
            Transform checkpoint = CheckpointManager.Instance.CurrentCheckpoint.TargetRespawnTransform;

            //Rotate kayak at 180 in z with balance
            if (CharacterManagerRef.Balance > 0 && CharacterManagerRef.Balance < 60)
                CharacterManagerRef.Balance += 0.5f;
            else if (CharacterManagerRef.Balance < 0 && CharacterManagerRef.Balance > -60)
                CharacterManagerRef.Balance -= 0.5f;

            //Timer Start Fade
            if (CameraController.Instance.StartTimerDeath == true)
            {
                _timerFadeInEnded += Time.deltaTime;
            }

            //Transition In
            if (_timerFadeInEnded > CharacterManagerRef.TimeFadeInAfterDeath && _transitionIn == false)
            {
                _transitionIn = true;
                CharacterManagerRef.TransitionManager.LaunchTransitionIn(SceneTransition.TransitionType.Fade);
            }

            //Timer transition In
            if (_transitionIn == true && _respawned == false)
            {
                _timerToRespawnCheckpoint += Time.deltaTime;
            }


            if (_timerToRespawnCheckpoint >= CharacterManagerRef.TimeToRespawnCheckPoint)
            {
                if (_respawned == true)
                {
                    _timerFadeOutStart += Time.deltaTime;
                }

                if (_respawned == false)
                {
                    //put kayak in checkpoint position & rotation
                    _kayakController.transform.position = checkpoint.position;
                    _kayakController.transform.rotation = checkpoint.rotation;

                    //Reset value
                    _kayakController.CanReduceDrag = true;
                    CharacterManagerRef.CamController.CanMoveCameraMaunally = true;
                    CharacterManagerRef.Balance = 0;
                    _respawned = true;
                }

            }
            if (_timerFadeOutStart > CharacterManagerRef.TimeToPlayFadeOutAfterRespawn && _respawned == true)
                this.SwitchState(character);
            MakeBoatRotationWithBalance(_kayakController.transform, 1);
        }

        public override void FixedUpdate(CharacterManager character)
        {
        }

        public override void SwitchState(CharacterManager character)
        {
            //Transition out
            CharacterManagerRef.TransitionManager.LaunchTransitionOut(SceneTransition.TransitionType.Fade);

            //Reset variable
            CameraController.Instance.ResetValueDead();

            //Switch state
            CharacterNavigationState characterNavigationState = new CharacterNavigationState(_kayakController, _inputs, CharacterManagerRef, MonoBehaviourRef);
            CharacterManagerRef.SwitchState(characterNavigationState);
        }
    }
}
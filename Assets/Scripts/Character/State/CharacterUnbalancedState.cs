using Character.Camera;
using Character.Camera.State;
using Kayak;
using Kayak.Data;
using Sound;
using UnityEngine;

namespace Character.State
{
    public class CharacterUnbalancedState : CharacterStateBase
    {
        #region Variables
        private const float DIVIDE_TIMER_PERCENT = 4;
        private const float VALUE_BALANCE_TO_NORMAL_STATE = 2;

        private KayakController _kayakController;
        private InputManagement _inputs;

        private float _timerUnbalanced = 0;
        private float _timerReturnNavigationState;

        private float _timerDebug = 0;

        private int _signeBalance;
        private bool _triggerLeft = false;

        #endregion

        #region Constructor

        public CharacterUnbalancedState() : base()
        {
            _kayakController = CharacterManagerRef.KayakControllerProperty;
            _inputs = CharacterManagerRef.InputManagementProperty;
            CanBeMoved = false;
            CanCharacterOpenWeapons = false;
        }

        #endregion

        #region Override Functions

        public override void EnterState(CharacterManager character)
        {
        }

        public override void UpdateState(CharacterManager character)
        {
        }
        public override void FixedUpdate(CharacterManager character)
        {

        }

        public override void SwitchState(CharacterManager character)
        {

        }

        public override void ExitState(CharacterManager character)
        {
        }

        #endregion
    }
}
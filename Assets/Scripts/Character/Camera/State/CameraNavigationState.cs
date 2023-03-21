using UnityEngine;

namespace Character.Camera.State
{
    public class CameraNavigationState : CameraStateBase
    {
        private float _timerCameraReturnBehindBoat = 0;

        public CameraNavigationState(CameraManager cameraManagerRef, MonoBehaviour monoBehaviour) :
            base(cameraManagerRef, monoBehaviour)
        {
        }

        public override void EnterState(CameraManager camera)
        {
            CameraManagerRef.ShakeCamera(0);
            CameraManagerRef.AnimatorRef.Play("VCam FreeLook");
            CameraManagerRef.Brain.m_BlendUpdateMethod = Cinemachine.CinemachineBrain.BrainUpdateMethod.LateUpdate;
        
            CameraManagerRef.ResetNavigationValue();
        
            //look-at
            CameraManagerRef.VirtualCamera.LookAt = null;
        }
        public override void UpdateState(CameraManager camera)
        {
            if (Mathf.Abs(CameraManagerRef.RotationZ) > 0)
            {
                CameraManagerRef.SmoothResetRotateZ();
            }

            MoveCamera();

            ClampRotationCameraValue();

            CameraManagerRef.ApplyRotationCamera();

            if (Input.GetKeyDown(KeyCode.K))
            {
                CameraTrackState cameraTrackState = new CameraTrackState(CameraManagerRef, MonoBehaviourRef, "VCam TrackDolly");
                CameraManagerRef.SwitchState(cameraTrackState);
            }

            if (CameraManagerRef.Waves.CircularWavesDurationList.Count > 0)
            {
                CameraManagerRef.ShakeCamera(CameraManagerRef.AmplitudShakeWhenWaterWave);
            }
            else if (CameraManagerRef.WaterFlow)
            {
                CameraManagerRef.ShakeCamera(CameraManagerRef.AmplitudShakeWhenWaterFlow);
            }
            else
            {
                CameraManagerRef.ShakeCamera(0);
            }
        }
        public override void FixedUpdate(CameraManager camera)
        {

        }
        public override void SwitchState(CameraManager camera)
        {

        }

        private void MoveCamera()
        {
            //rotate freely with inputs
            bool rotateInput = Mathf.Abs(CameraManagerRef.Input.Inputs.RotateCamera.x) + Mathf.Abs(CameraManagerRef.Input.Inputs.RotateCamera.y) >= CameraManagerRef.Input.Inputs.DEADZONE; //0.5f;
            const float minimumVelocityToReplaceCamera = 0.2f;
            _timerCameraReturnBehindBoat += Time.deltaTime;
            if (rotateInput && CameraManagerRef.CanMoveCameraManually)
            {
                ManageFreeCameraMove(ref _timerCameraReturnBehindBoat, CameraMode.Navigation);
            }
            //manage rotate to stay behind boat
            else if (Mathf.Abs(CameraManagerRef.RigidbodyKayak.velocity.x + CameraManagerRef.RigidbodyKayak.velocity.z) > minimumVelocityToReplaceCamera && _timerCameraReturnBehindBoat > CameraManagerRef.TimerCameraReturnBehindBoat ||
                     (Mathf.Abs(CameraManagerRef.CharacterManager.CurrentStateBase.RotationStaticForceY) > minimumVelocityToReplaceCamera / 20) && _timerCameraReturnBehindBoat > CameraManagerRef.TimerCameraReturnBehindBoat)
            {
                #region clavier souris
                //avoid last input to be 0
                if (CameraManagerRef.LastInputX != 0 || CameraManagerRef.LastInputY != 0)
                {
                    CameraManagerRef.LastInputX = 0;
                    CameraManagerRef.LastInputY = 0;
                }
                #endregion

                #region variable
                //get target rotation
                Quaternion localRotation = CameraManagerRef.CinemachineCameraTarget.transform.localRotation;
                Quaternion targetQuaternion = Quaternion.Euler(new Vector3(0,
                    -(CameraManagerRef.CharacterManager.CurrentStateBase.RotationStaticForceY + CameraManagerRef.CharacterManager.CurrentStateBase.RotationPaddleForceY) * CameraManagerRef.MultiplierValueRotation,
                    localRotation.z));
                //get camera local position
                Vector3 cameraTargetLocalPosition = CameraManagerRef.CinemachineCameraTarget.transform.localPosition;

                const float rotationThreshold = 0.15f;
                float rotationStaticY = CameraManagerRef.CharacterManager.CurrentStateBase.RotationStaticForceY;
                float rotationPaddleY = CameraManagerRef.CharacterManager.CurrentStateBase.RotationPaddleForceY;
                #endregion

                //calculate camera rotation & position
                if (Mathf.Abs(rotationStaticY) > rotationThreshold || // if kayak is rotating
                    Mathf.Abs(rotationPaddleY) > rotationThreshold) //if kayak moving
                {
                    //rotation
                    CameraManagerRef.CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, targetQuaternion, CameraManagerRef.LerpLocalRotationMove);

                    //position
                    if (Mathf.Abs(rotationStaticY) > rotationThreshold / 2)// if kayak is rotating
                    {
                        cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, CameraManagerRef.LerpLocalPositionNotMoving);
                    }
                    else if (Mathf.Abs(rotationPaddleY) > rotationThreshold / 2)// if kayak is moving
                    {
                        cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x,
                            (rotationStaticY + rotationPaddleY) * CameraManagerRef.MultiplierValuePosition, //value
                            CameraManagerRef.LerpLocalPositionMove); //time lerp
                        cameraTargetLocalPosition.z = 0;
                    }
                }
                else //if kayak not moving or rotating
                {
                    CameraManagerRef.CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, Quaternion.Euler(new Vector3(0, 0, localRotation.z)), CameraManagerRef.LerpLocalRotationNotMoving);
                    cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, CameraManagerRef.LerpLocalPositionNotMoving);
                }


                //apply camera rotation & position
                CameraManagerRef.CinemachineTargetEulerAnglesToRotation(cameraTargetLocalPosition);

                //camera target to kayak rotation and position
                CameraManagerRef.MakeTargetFollowRotationWithKayak();
            }
            else
            {
                CameraManagerRef.LastInputValue();
            }
        }
        private void ResetCameraBehindBoat()
        {
            //Start
            CameraManagerRef.MakeTargetFollowRotationWithKayak();

            //Middle
            Quaternion localRotation = CameraManagerRef.CinemachineCameraTarget.transform.localRotation;
            Vector3 cameraTargetLocalPosition = CameraManagerRef.CinemachineCameraTarget.transform.localPosition;

            CameraManagerRef.CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, Quaternion.Euler(new Vector3(0, 0, localRotation.z)), 1f);
            cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, 1f);
            CameraManagerRef.CinemachineTargetEulerAnglesToRotation(cameraTargetLocalPosition);

            //End
            CameraManagerRef.ApplyRotationCamera();
        }
    }
}

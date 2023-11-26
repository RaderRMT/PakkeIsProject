﻿using System;
using System.Collections.Generic;
using Character;
using Collectible;
using Json;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Menu
{
    public class SubMenuCollectibleController : MenuController
    {
        [Header("Sub Menu"), SerializeField] private List<MenuUIObject> _objectsList = new List<MenuUIObject>();
        [SerializeField] private TMP_Text _nameText, _descriptionText;
        [SerializeField] private GameObject _defaultCollectibleMesh;

        private int _index;
        private GameObject _currentDisplayedMesh;

        protected override void Start()
        {
            base.Start();
            JsonFilesManagerSingleton.Instance.CollectibleJsonFileManagerProperty.OnNewCollectibleGet.AddListener(SetTilesData);
            if (_defaultCollectibleMesh != null)
            {
                _defaultCollectibleMesh.SetActive(false);
            }
        }

        private void Update()
        {
            if (IsUsable == false || _currentDisplayedMesh == null)
            {
                return;
            }
            
            RotateGameObjectFromSticks(_currentDisplayedMesh.transform);
        }

        public override void SetMenu(bool isActive, bool isUsable)
        {
            base.SetMenu(isActive, isUsable);
            
            if (isUsable == false)
            {
                return;
            }

            if (IsUsable)
            {
                SetTile();
            }
        }

        protected override void Left(InputAction.CallbackContext context)
        {
            if (IsUsable == false ||
                HorizontalIndex <= 0)
            {
                return;
            }

            base.Left(context);
            _index--;
            SetTile();
        }

        protected override void Right(InputAction.CallbackContext context)
        {
            if (IsUsable == false ||
                HorizontalIndex >= Length-1 ||
                _index >= _objectsList.Count-1)
            {
                return;
            }
            
            base.Right(context);
            _index++;
            SetTile();
        }

        protected override void Up(InputAction.CallbackContext context)
        {
            if (IsUsable == false ||
                VerticalIndex <= 0)
            {
                return;
            }
            
            base.Up(context);
            _index -= Length;
            SetTile();
        }

        protected override void Down(InputAction.CallbackContext context)
        {
            if (IsUsable == false ||
                VerticalIndex >= Height ||
                _index+Length >= _objectsList.Count)
            {
                return;
            }
            
            base.Down(context);
            _index += Length;
            SetTile();
        }

        private void SetTile()
        {
            if (_objectsList.Count <= 0)
            {
                return;
            }
            
            for (int i = 0; i < _objectsList.Count; i++)
            {
                _objectsList[i].Set(i == _index);
            }
            
            _objectsList[_index].Set(true);

            if (_nameText == null || _descriptionText == null)
            {
                return;
            }

            CollectibleUIObject collectibleUIObject = _objectsList[_index].GetComponent<CollectibleUIObject>();
            _nameText.text = collectibleUIObject == null ? _objectsList[_index].GetName() : collectibleUIObject.GetName();
            _descriptionText.text = collectibleUIObject == null ? _objectsList[_index].GetDescription() : collectibleUIObject.GetDescription();
            
            //mesh
            if (_currentDisplayedMesh != null)
            {
                _currentDisplayedMesh.SetActive(false);
            }
            GameObject mesh = _defaultCollectibleMesh;
            if (collectibleUIObject != null && collectibleUIObject.CollectibleMesh != null && collectibleUIObject.Data != null)
            {
                mesh = collectibleUIObject.CollectibleMesh;
            }
            mesh.SetActive(true);
            _currentDisplayedMesh = mesh;
        }

        private void SetTilesData()
        {
            for (int i = 0; i < _objectsList.Count; i++)
            {
                CollectibleUIObject collectibleUIObject = _objectsList[i].GetComponent<CollectibleUIObject>();
                
                if (collectibleUIObject == null ||
                    i >= JsonFilesManagerSingleton.Instance.CollectibleJsonFileManagerProperty.CollectedItems.Count || 
                    JsonFilesManagerSingleton.Instance.CollectibleJsonFileManagerProperty.CollectedItems[i] == null)
                {
                    continue;
                }

                if (JsonFilesManagerSingleton.Instance.CollectibleJsonFileManagerProperty.CollectedItems[i].IsCollected)
                {
                    collectibleUIObject.Data = JsonFilesManagerSingleton.Instance.CollectibleJsonFileManagerProperty.CollectedItems[i].CollectibleGameObject.Data;
                }
            }
        }

        private void RotateGameObjectFromSticks(Transform transform)
        {
            Vector3 sticksInputs = CharacterManager.Instance.InputManagementProperty.Inputs.RotateCamera;

            float rotationAmountX = -sticksInputs.x * 2f;
            float rotationAmountY = -sticksInputs.y * 2f;
            if (rotationAmountX == 0)
            {
                const float rotationSpeed = 0.1f;
                rotationAmountX = rotationSpeed;
            }
            
            transform.Rotate(Vector3.up, rotationAmountX, Space.World);
            transform.Rotate(Vector3.right, rotationAmountY, Space.World);
        }
    }
}
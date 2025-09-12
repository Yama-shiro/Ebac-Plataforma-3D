using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Cloth;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer;
        public Texture2D texture2D;
        private string _shadeIdName = "_EmissionMap";
        private Texture2D _defaultTexture;

        private void Awake()
        {
            _defaultTexture = (Texture2D)skinnedMeshRenderer.sharedMaterials[0].GetTexture(_shadeIdName);
        }

        [Button]
        private void ChangeTexture()
        {
            skinnedMeshRenderer.sharedMaterials[0].SetTexture(_shadeIdName, texture2D);
        }

        public void ChangeTexture(ClothSetup clothSetup)
        {
            skinnedMeshRenderer.sharedMaterials[0].SetTexture(_shadeIdName, clothSetup.texture2D);
        }

        public void ResetTexture()
        {
            skinnedMeshRenderer.sharedMaterials[0].SetTexture(_shadeIdName, _defaultTexture);
        }
    }
}

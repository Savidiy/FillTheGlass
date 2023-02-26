using System;
using System.Collections.Generic;
using LevelWindowModule.Contracts;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SettingsModule
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 0)]
    public class GameSettings : SerializedScriptableObject
    {
        public Dictionary<EGlassFormType, Sprite> GlassSprites = new();
        public Dictionary<EGlassFormType, AccessoriesPositionData> AccessoriesPositions = new();
        public List<LevelData> Levels;

        public int GetLevelTargetMoney(int levelNumber)
        {
            return levelNumber >= Levels.Count
                ? 0
                : Levels[levelNumber].TargetMoneyCount;
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            AssetDatabase.SaveAssetIfDirty(this);
#endif
        }
    }

    [Serializable]
    public class LevelData
    {
        public int TargetMoneyCount;
        public int DurationInSeconds;

        public List<EGlassFormType> StartEmptyGlasses;
    }

    [Serializable]
    public sealed class AccessoriesPositionData
    {
        public Vector3 IcePosition;
        public Vector3 CitrusPosition;
        public Vector3 StrawPosition;
    }
}
using System;
using LevelWindowModule.Contracts;
using SettingsModule;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class GlassStaticDataProvider
    {
        private readonly GameSettings _gameSettings;

        public GlassStaticDataProvider(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public Sprite GetSpriteByType(EGlassFormType glassFormType)
        {
            if (_gameSettings.GlassSprites.TryGetValue(glassFormType, out Sprite sprite))
            {
                return sprite;
            }

            throw new Exception($"Can't find sprite for type '{glassFormType}'");
        }

        public AccessoriesPositionData GetAccessoriesPositionByType(EGlassFormType glassFormType)
        {
            if (_gameSettings.AccessoriesPositions.TryGetValue(glassFormType, out AccessoriesPositionData accessoriesPositionData))
            {
                return accessoriesPositionData;
            }

            throw new Exception($"Can't find AccessoriesPositionData for type '{glassFormType}'");
        }
    }
    
    
}
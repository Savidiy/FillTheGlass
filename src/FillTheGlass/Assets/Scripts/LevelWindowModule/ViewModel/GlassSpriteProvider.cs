using System;
using LevelWindowModule.Contracts;
using SettingsModule;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class GlassSpriteProvider
    {
        private readonly GameSettings _gameSettings;

        public GlassSpriteProvider(GameSettings gameSettings)
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
    }
}
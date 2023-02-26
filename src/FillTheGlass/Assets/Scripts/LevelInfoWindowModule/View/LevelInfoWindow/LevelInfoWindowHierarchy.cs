using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelInfoWindowModule.View
{
    public sealed class LevelInfoWindowHierarchy : MonoBehaviour
    {
        public TMP_Text LevelLabel;
        public TMP_Text TargetMoneyLabel;
        public TMP_Text TotalMoneyLabel;
        public CalendarHierarchy CalendarHierarchy;
        public Button BackButton;
        public Button StartButton;
        public Button SettingsButton;
    }
}
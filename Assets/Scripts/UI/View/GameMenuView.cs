using System.Collections.Generic;
using TMPro;
using UI.Abstractions;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace UI.View
{
    public class GameMenuView : MonoBehaviour, IAnyInventoryListener, IAnyActualTimerListener, IUpdateListeners
    {
        [SerializeField] private TMP_Text _timeBurningFire;
        [SerializeField] private TMP_Text _countApple;
        [SerializeField] private TMP_Text _countWood;

        private GameEntity _uiListenerEntity;

        public void UpdateListeners()
        {
            _uiListenerEntity = Contexts.sharedInstance.game.CreateEntity();
            _uiListenerEntity.AddAnyInventoryListener(this);
            _uiListenerEntity.AddAnyActualTimerListener(this);
        }


        public void OnAnyActualTimer(GameEntity entity, float seconds)
        {
            _timeBurningFire.text = Mathf.FloorToInt(seconds).ToString();
        }

        public void OnAnyInventory(GameEntity entity, int woodCount, int appleCount)
        {
            _countApple.text = appleCount.ToString();
            _countWood.text = woodCount.ToString();
        }
    }
}
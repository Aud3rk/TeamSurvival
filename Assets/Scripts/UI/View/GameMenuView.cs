using TMPro;
using UnityEngine;

namespace UI.View
{
    public class GameMenuView : MonoBehaviour, IInventoryListener, IActualTimerListener
    {
        [SerializeField] private TMP_Text _timeBurningFire;
        [SerializeField] private TMP_Text _countApple;
        [SerializeField] private TMP_Text _countWood;

        private void Start()
        {
            Contexts.sharedInstance.game.playerEntity.AddInventoryListener(this);
            Contexts.sharedInstance.game.bonfireEntity.AddActualTimerListener(this);
        }

        public void OnInventory(GameEntity entity, int woodCount, int appleCount)
        {
            _countApple.text = appleCount.ToString();
            _countWood.text = woodCount.ToString();
        }


        public void OnActualTimer(GameEntity entity, float seconds)
        {
            _timeBurningFire.text = Mathf.FloorToInt(seconds).ToString();
        }
    }
}
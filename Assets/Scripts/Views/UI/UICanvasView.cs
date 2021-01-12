using Entitas;
using TMPro;
using UnityEngine;
using Views.Interfaces;

namespace Views.UI
{
    public class UiCanvasView : MonoBehaviour, IEventListener, IScoreListener
    {
        private GameEntity _entity;

        [SerializeField] private TextMeshProUGUI _scoreText;

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddScoreListener(this);
        }

        public void RemoveListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.RemoveScoreListener();
        }

        public void OnScore(GameEntity entity, int value)
        {
            _scoreText.text = $"{value}";
        }
    }
}
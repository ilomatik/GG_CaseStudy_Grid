using Controllers;
using GameVariable;
using UnityEngine;
using View;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject    _gameView;
        [SerializeField] private GameVariables _variables;
        
        private GameController _gameController;
        
        private void Start()
        {
            GameObject view     = Instantiate(_gameView, Vector3.zero, Quaternion.identity);
            GameView   gameView = view.GetComponent<GameView>();
            
            _gameController = new GameController(gameView, _variables);
            _gameController.LoadLevel();
            _gameController.SubscribeEvents();
        }
        
        private void OnDestroy()
        {
            _gameController.UnsubscribeEvents();
        }
    }
}
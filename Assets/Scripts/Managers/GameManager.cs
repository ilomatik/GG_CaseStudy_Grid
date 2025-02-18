using Controllers;
using UnityEngine;
using View;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameView;
        [SerializeField] private int        _colCount;
        [SerializeField] private int        _rowCount;
        
        private GameController _gameController;
        
        private void Start()
        {
            GameObject view     = Instantiate(_gameView, Vector3.zero, Quaternion.identity);
            GameView   gameView = view.GetComponent<GameView>();
            
            _gameController = new GameController(gameView, _colCount, _rowCount);
            _gameController.LoadLevel();
            _gameController.SubscribeEvents();
        }
        
        private void OnDestroy()
        {
            _gameController.UnsubscribeEvents();
        }
    }
}
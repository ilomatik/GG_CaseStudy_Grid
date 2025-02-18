using Data;
using Events;
using View;

namespace Controllers
{
    public class GameController
    {
        private GameData _data;
        private GameView _view;

        private int _colCount;
        private int _rowCount;

        public GameController(GameView gameView, int colCount, int rowCount)
        {
            _data = new GameData();
            _view = gameView;

            _colCount = colCount;
            _rowCount = rowCount;
        }

        public void SubscribeEvents()
        {
            ViewEvents.OnTileClicked += OnTileClicked;
        }

        public void UnsubscribeEvents()
        {
            ViewEvents.OnTileClicked -= OnTileClicked;
        }

        public void LoadLevel()
        {
            _data.Initialize(_colCount, _rowCount);
            _view.Initialize(_colCount, _rowCount);

            for (int c = 0; c < _colCount; c++)
            {
                for (int r = 0; r < _rowCount; r++)
                {
                    _data.CreateTile(c, r);
                    _view.CreateTile(c, r);
                }
            }
        }

        private void OnTileClicked(int col, int row)
        {
            if (_data.IsTileMarked(col, row)) return;
            
            _data.MarkTile(col, row);
            _view.MarkTile(col, row);
        }
    }
}
using System.Collections.Generic;
using Data;
using Events;
using GameVariable;
using Holders;
using UnityEngine;
using View;

namespace Controllers
{
    public class GameController
    {
        private GameData      _data;
        private GameView      _view;
        private GameVariables _variables;

        private int _colCount;
        private int _rowCount;

        public GameController(GameView gameView, GameVariables variables)
        {
            _data      = new GameData();
            _view      = gameView;
            _variables = variables;

            _colCount = _variables.ColCount;
            _rowCount = _variables.RowCount;
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
            _view.SetTileDurations(_variables.MarkedScaleUpDuration, _variables.MarkedScaleDownDuration);
            _view.SetTileEases(_variables.MarkedScaleUpEase, _variables.MarkedScaleDownEase);

            int tileId = 0;
            
            for (int c = 0; c < _colCount; c++)
            {
                for (int r = 0; r < _rowCount; r++)
                {
                    _data.CreateTile(c, r, tileId);
                    _view.CreateTile(c, r, tileId);
                    
                    tileId++;
                }
            }
            
            _view.ResizeTiles();
        }

        private void OnTileClicked(int col, int row)
        {
            if (_data.IsTileMarked(col, row)) return;
            
            _data.MarkTile(col, row);
            _view.MarkTile(col, row);
            
            CheckWinCondition(col, row);
        }
        
        private void CheckWinCondition(int col, int row)
        {
            MarkedTilesHolder markedTiles      = _data.GetMarkedTiles(col, row);
            int               markedTilesCount = markedTiles.MarkedTilesCount;

            if (markedTilesCount < _variables.UnmarkLimit) return;
            
            for (int m = 0; m < markedTilesCount; m++)
            {
                MarkedTile markedTile = markedTiles.GetMarkedTileByIndex(m);
                
                _data.UnmarkTile(markedTile.Col, markedTile.Row);
                _view.UnmarkTile(markedTile.Col, markedTile.Row);
            }
        }
    }
}
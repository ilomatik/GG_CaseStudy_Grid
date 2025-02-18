using System.Collections.Generic;
using Holders;

namespace Data
{
    public class GameData
    {
        private int _colCount;
        private int _rowCount;

        private TileData[,] _tileData;

        #region Level Start
        
        public void Initialize(int colCount, int rowCount)
        {
            _colCount    = colCount;
            _rowCount    = rowCount;

            _tileData = new TileData[_colCount, _rowCount];
        }

        public void CreateTile(int col, int row, int id)
        {
            TileData tileData = new TileData(id, col, row);
            tileData.Unmark();
            
            if (col - 1 >= 0)
            {
                TileData neighbourTile = _tileData[col - 1, row];
                tileData.AddNeighbourTile(neighbourTile);
                neighbourTile.AddNeighbourTile(tileData);
            }

            if (row - 1 >= 0)
            {
                TileData neighbourTile = _tileData[col, row - 1];
                tileData.AddNeighbourTile(neighbourTile);
                neighbourTile.AddNeighbourTile(tileData);
            }

            _tileData[col, row] = tileData;
        }

        #endregion

        #region Tile
        
        public void MarkTile(int col, int row)
        {
            _tileData[col, row].Mark();
        }
        
        public void UnmarkTile(int col, int row)
        {
            _tileData[col, row].Unmark();
        }

        public bool IsTileMarked(int col, int row)
        {
            return _tileData[col, row].HasMarked;
        }
        
        #endregion
        
        public MarkedTilesHolder GetMarkedTiles(int col, int row)
        {
            MarkedTilesHolder markedTilesHolder = new MarkedTilesHolder();
            
            List<TileData> connectedTiles = GetTileZone(_tileData[col, row]);

            for (int c = 0; c < connectedTiles.Count; c++)
            {
                TileData tile = connectedTiles[c];
                markedTilesHolder.AddMarkedTile(new MarkedTile(tile.Col, tile.Row));
            }

            return markedTilesHolder;
        }
        
        private List<TileData> GetTileZone(TileData tile)
        {
            List<TileData> markedTiles = new List<TileData>();

            if (!tile.HasMarked) return markedTiles;

            //tile.Check();
            List<TileData> tempTiles = GetTileNeighbours(tile);

            for (int i = 0; i < tempTiles.Count; i++)
            {
                TileData tempTile = tempTiles[i];

                if (!tempTile.HasMarked) continue;
                if (tempTile.IsChecked) continue;

                markedTiles.Add(tempTile);
                tempTile.Check();
                List<TileData> data = GetTileNeighbours(tempTile);

                for (int j = 0; j < data.Count; j++)
                {
                    tempTiles.Add(data[j]);
                }
            }
            
            UncheckAllTiles();

            return markedTiles;
        }
        
        private List<TileData> GetTileNeighbours(TileData tile)
        {
            List<TileData> neighbours = new List<TileData>();

            int col = tile.Col;
            int row = tile.Row;

            if (col + 1 < _colCount)
            {
                neighbours.Add(_tileData[col + 1, row]);
            }

            if (col - 1 >= 0)
            {
                neighbours.Add(_tileData[col - 1, row]);
            }

            if (row + 1 < _rowCount)
            {
                neighbours.Add(_tileData[col, row + 1]);
            }

            if (row - 1 >= 0)
            {
                neighbours.Add(_tileData[col, row - 1]);
            }

            return neighbours;
        }
        
        private void UncheckAllTiles()
        {
            for (int c = 0; c < _colCount; c++)
            {
                for (int r = 0; r < _rowCount; r++)
                {
                    _tileData[c, r].Uncheck();
                }
            }
        }
    }
}
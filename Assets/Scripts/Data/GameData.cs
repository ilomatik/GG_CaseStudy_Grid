namespace Data
{
    public class GameData
    {
        private int _colCount;
        private int _rowCount;

        private TileData[,] _tileData;

        public void Initialize(int colCount, int rowCount)
        {
            _colCount = colCount;
            _rowCount = rowCount;

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

        public void MarkTile(int col, int row)
        {
            _tileData[col, row].Mark();
        }

        public bool IsTileMarked(int col, int row)
        {
            return _tileData[col, row].HasMarked;
        }
    }
}
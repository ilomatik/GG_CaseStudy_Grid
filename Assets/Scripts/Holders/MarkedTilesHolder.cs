using System.Collections.Generic;

namespace Holders
{
    public class MarkedTilesHolder
    {
        public int MarkedTilesCount => _markedTiles.Count;
        
        private List<MarkedTile> _markedTiles;
        
        public MarkedTilesHolder()
        {
            _markedTiles = new List<MarkedTile>();
        }
        
        public void AddMarkedTile(MarkedTile markedTile)
        {
            _markedTiles.Add(markedTile);
        }
        
        public MarkedTile GetMarkedTileByIndex(int index)
        {
            return _markedTiles[index];
        }
    }
    
    public class MarkedTile
    {
        public int Col { get; }
        public int Row { get; }
        
        public MarkedTile(int col, int row)
        {
            Col = col;
            Row = row;
        }
    }
}
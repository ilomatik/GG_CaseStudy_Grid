using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class TileData
    {
        public int  Id        { get; private set; }
        public int  Col       { get; private set; }
        public int  Row       { get; private set; }
        public bool HasMarked { get; private set; }
        public bool IsChecked { get; private set; }
        
        private List<TileData> _neighbourTiles;
        
        public TileData(int id, int col, int row)
        {
            Id  = id;
            Col = col;
            Row = row;
            
            _neighbourTiles = new List<TileData>();
        }
        
        public void Mark()
        {
            HasMarked = true;
        }
        
        public void Unmark()
        {
            HasMarked = false;
        }
        
        public void Check()
        {
            IsChecked = true;
        }
        
        public void Uncheck()
        {
            IsChecked = false;
        }

        public void AddNeighbourTile(TileData tileData)
        {
            if (!_neighbourTiles.Exists(x => x.Id.Equals(tileData.Id)))
            {
                _neighbourTiles.Add(tileData);
            }
        }

        public bool HasNeighbourWithId(int tileId)
        {
            return _neighbourTiles.Any(tile => tile.Id.Equals(tileId));
        }
    }
}
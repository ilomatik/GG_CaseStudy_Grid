using Events;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TileView  _tilePrefab;
        [SerializeField] private Transform _tilesParent;

        private TileView[,] _tileViews;

        public void Initialize(int colCount, int rowCount)
        {
            _tileViews = new TileView[colCount, rowCount];
        }
        
        public void CreateTile(int col, int row, int id)
        {
            Vector3 position = new Vector3(col, 0, row);
            
            TileView tileView = Instantiate(_tilePrefab, position, Quaternion.identity, _tilesParent);
            tileView.Initialize(id, col, row, OnTileClicked);
            
            _tileViews[col, row] = tileView;
        }
        
        public void MarkTile(int col, int row)
        {
            _tileViews[col, row].Mark();
        }
        
        public void UnmarkTile(int col, int row)
        {
            _tileViews[col, row].Unmark();
        }
        
        private void OnTileClicked(int col, int row)
        {
            ViewEvents.TileClicked(col, row);
        }
    }
}

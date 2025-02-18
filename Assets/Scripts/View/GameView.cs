using DG.Tweening;
using Events;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TileView  _tilePrefab;
        [SerializeField] private Transform _tilesParent;

        private TileView[,] _tileViews;
        private float       _tileScaleUpDuration;
        private float       _tileScaleDownDuration;

        public void Initialize(int colCount, int rowCount)
        {
            _tileViews = new TileView[colCount, rowCount];
            
            float offsetX = colCount / 2f;
            float offsetZ = rowCount / 2f;
            
            _tilesParent.position = new Vector3(-offsetX, 0, -offsetZ);
        }
        
        public void SetTileDurations(float tileScaleUpDuration, float tileScaleDownDuration)
        {
            _tileScaleUpDuration   = tileScaleUpDuration;
            _tileScaleDownDuration = tileScaleDownDuration;
        }
        
        public void CreateTile(int col, int row, int id)
        {
            Vector3 position = new Vector3(col, 0, row);
            
            TileView tileView = Instantiate(_tilePrefab, _tilesParent);
            tileView.transform.localPosition = position;
            tileView.Initialize(id, col, row, OnTileClicked);
            tileView.SetDurations(_tileScaleUpDuration, _tileScaleDownDuration);
            
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

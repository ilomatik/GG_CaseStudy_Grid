using System.Threading.Tasks;
using DG.Tweening;
using Events;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TileView  _tilePrefab;
        [SerializeField] private Transform _tilesParent;
        [SerializeField] private Color     _startColor;
        [SerializeField] private Color     _endColor;

        private TileView[,] _tileViews;
        private int         _colCount;
        private int         _rowCount;
        private Vector3     _tileScale;
        private float       _tileScaleUpDuration;
        private float       _tileScaleDownDuration;
        private Ease        _scaleUpEase;
        private Ease        _scaleDownEase;

        public void Initialize(int colCount, int rowCount)
        {
            _colCount = colCount;
            _rowCount = rowCount;
            
            _tileViews = new TileView[_colCount, _rowCount];
            _tileScale = _tilePrefab.transform.localScale;
            
            SetTileParentPosition(_colCount, _rowCount);
            SetCameraPosition(_colCount, _rowCount);
        }
        
        public void SetTileDurations(float tileScaleUpDuration, float tileScaleDownDuration)
        {
            _tileScaleUpDuration   = tileScaleUpDuration;
            _tileScaleDownDuration = tileScaleDownDuration;
        }
        
        public void SetTileEases(Ease scaleUpEase, Ease scaleDownEase)
        {
            _scaleUpEase   = scaleUpEase;
            _scaleDownEase = scaleDownEase;
        }
        
        public void CreateTile(int col, int row, int id)
        {
            Vector3 position = new Vector3(col, 0, row);
            
            TileView tileView = Instantiate(_tilePrefab, _tilesParent);
            tileView.transform.localPosition = position;
            tileView.Initialize(id, col, row, OnTileClicked);
            tileView.SetDurations(_tileScaleUpDuration, _tileScaleDownDuration);
            tileView.SetEases(_scaleUpEase, _scaleDownEase);

            // Calculate the color based on the position
            float tile = (float)(col * _rowCount + row) / (_colCount * _rowCount - 1);
            Color tileColor = Color.Lerp(_startColor, _endColor, tile);
            tileView.SetColor(tileColor);
            
            tileView.transform.localScale = Vector3.zero;
            _tileViews[col, row] = tileView;
        }

        public async void ResizeTiles()
        {
            for (int c = 0; c < _colCount; c++)
            {
                for (int r = _rowCount - 1; r >= 0; r--)
                {
                    _tileViews[c, r].transform.DOScale(_tileScale, _tileScaleUpDuration).SetEase(_scaleUpEase);

                    await Task.Delay(10);
                }
            }
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
        
        private void SetTileParentPosition(int colCount, int rowCount)
        {
            float offsetX = colCount / 2f;
            float offsetZ = rowCount / 2f;
            
            _tilesParent.position = new Vector3(-offsetX, 0, -offsetZ);
        }
        
        private void SetCameraPosition(int colCount, int rowCount)
        {
            float cameraHeight = rowCount > (colCount * 2) ? rowCount : colCount * 2;
            Camera.main.transform.position = new Vector3(-0.5f, cameraHeight, -0.5f);
        }
    }
}

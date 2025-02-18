using UnityEngine;

namespace GameVariable
{
    [CreateAssetMenu(fileName = "GameVariables", menuName = "Game Variables")]
    public class GameVariables : ScriptableObject
    {
        [SerializeField] private int _colCount;
        [SerializeField] private int _rowCount;
        [SerializeField] private int _unmarkLimit;

        [SerializeField] private float _markedScaleUpDuration;
        [SerializeField] private float _markedScaleDownDuration;

        public int ColCount    => _colCount;
        public int RowCount    => _rowCount;
        public int UnmarkLimit => _unmarkLimit;
        
        public float MarkedScaleUpDuration   => _markedScaleUpDuration;
        public float MarkedScaleDownDuration => _markedScaleDownDuration;
    }
}
using Assets.Scripts.Components.StageComponents.StageAreas;
using Assets.Scripts.Staff.Core;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents
{
    public class CrowdGenerator : BindingMonoBehaviour
    {
        [SerializeField] private SimpleStageArea _stageArea;
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private GameObject[] _fans;
        [SerializeField] private Transform _parent;
        [SerializeField] private float _topMargin;
        [SerializeField] private float _leftMargin;
        [SerializeField] private float _rightMargin;
        [SerializeField] private float _botMargin;

        private int FanCount { get { return _fans.Length; } }
        
        private Vector2 ActualSize { get { return new Vector2(_stageArea.Size.x - _rightMargin - _leftMargin, _stageArea.Size.y - _topMargin - _botMargin);} }

        private Vector2 ActualPosition { get { return new Vector2(_stageArea.Position.x + _leftMargin, _stageArea.Position.y + _botMargin);} }

        private Vector2 CellSize { get { return new Vector2(ActualSize.x / _columns, ActualSize.y / _rows);} }

        public void Generate()
        {
            Clear();

            for (var row=0;row < _rows; row++)
                for (var column=0; column < _columns; column++)
                {
                    var position = GetCellPosition(row, column);
                    var go = GetFan();
                    go.transform.position = position;
                    go.transform.parent = _parent;
                }
        }

        private Vector2 GetCellPosition(int row, int column)
        {
            var position = new Vector2(ActualPosition.x + CellSize.x * column, ActualPosition.y + CellSize.y * row);
            position += CellSize/2;
            position += new Vector2(Random.Range(-CellSize.x/2, CellSize.x/2), Random.Range(-CellSize.y/2, CellSize.y/2));
            return position;
        }

        private void Clear()
        {
            foreach (Transform child in _parent)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        private Vector2 GetPosition()
        {
            var x = Random.Range(_stageArea.Position.x, _stageArea.Position.x + _stageArea.Size.x);
            x = Mathf.Clamp(x, _stageArea.Position.x + _leftMargin, _stageArea.Position.x + _stageArea.Size.x-_rightMargin);
            var y = Random.Range(_stageArea.Position.y, _stageArea.Position.y + _stageArea.Size.y);
            y = Mathf.Clamp(y, _stageArea.Position.y + _botMargin, _stageArea.Position.y + _stageArea.Size.y - _topMargin);
            return new Vector2(x, y);
        }

        private GameObject GetFan()
        {
            return Instantiate(_fans[Random.Range(0, FanCount)]);
        }
    }
}

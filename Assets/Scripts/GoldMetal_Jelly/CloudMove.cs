using UnityEngine;
namespace GoldMetal_Jelly
{
    public class CloudMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.1f;
        [SerializeField] private bool _isRightMove = true;
        [SerializeField] private float _repositionEndX = 10;
        [SerializeField] private float _repositionStartX = -10;

        private Transform _tr;

        void Start()
        {
            _tr = GetComponent<Transform>();
        }

        void Update()
        {
            if (_tr == null) return;

            if(_tr.position.x >= _repositionEndX)
            {
                Vector3 reposition = _tr.position;
                reposition.x = _repositionStartX;
                _tr.position = reposition;
            }

            if (_isRightMove)
                _tr.Translate(Time.deltaTime * _speed * Vector3.right);
            else
                _tr.Translate(Time.deltaTime * _speed * Vector3.left);
        }
    }
}

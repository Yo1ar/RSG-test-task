using System;
using UnityEngine;
using Utils;

namespace Components
{
    public class FollowComponent : MonoBehaviour
    {
        public bool Follow;
        [SerializeField] public Transform _target;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 _position;
        private Vector3 _direction;


        private void Start()
        {
            _target = GameObject.Find("Player").transform;
            _position = transform.position;
        }

        private void Update()
        {
            if (Follow)
            {
                _position = transform.position;
                _direction = (_target.transform.position - _position).normalized;
                _rigidbody.MovePosition(_position + _direction * (_speed * Time.fixedDeltaTime));
            }
            else
            {
                _rigidbody.MovePosition(transform.position + _direction * (_speed * Time.fixedDeltaTime));
            }
        }

        public void SetFollowSpeed(float speed)
        {
            _speed = speed;
        }
    }
}
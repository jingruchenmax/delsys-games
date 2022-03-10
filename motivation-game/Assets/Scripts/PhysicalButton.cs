using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimonSaysGame
{
    [RequireComponent(typeof(InteractionBehavior))]
    public class PhysicalButton : MonoBehaviour
    {
        [SerializeField] private float threshold = 0.1f;
        [SerializeField] private float deadZone = 0.025f;


        private InteractionBehavior interactionBehavior;
        private bool _isPressed;
        private Vector3 _startPos;
        private ConfigurableJoint _joint;
        // Start is called before the first frame update

        private void Awake()
        {
            interactionBehavior = GetComponent<InteractionBehavior>();
        }
        void Start()
        {
            _startPos = transform.localPosition;
            _joint = GetComponent<ConfigurableJoint>();

        }

        // Update is called once per frame
        void Update()
        {
            if (!_isPressed && GetValue() + threshold >= 1)
            {
                _isPressed = true;
                interactionBehavior.onPressed.Invoke();
            }

            if (_isPressed && GetValue() - threshold <= 0)
            {
                _isPressed = false;
                interactionBehavior.onReleased.Invoke();
            }

        }

        float GetValue()
        {
            var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
            if (Mathf.Abs(value) < deadZone) value = 0;
            return Mathf.Clamp(value, -1, 1);
        }

    }
}


using System;
using UnityEngine;
using Utils;
using UnityEngine.UI;

namespace InteractionSystem
{
    public class InteractComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask interactLayer;
        [SerializeField] private float triggerZoneRadius;
        [SerializeField] private GameObject _panel;
        [SerializeField] private CircleCollider2D collider;

        private void Awake()
        {
            collider.radius = triggerZoneRadius;
        }

        private void OnTriggerEnter2D()
        {
            Collider2D otherCollider = Physics2D.OverlapCircle(transform.position, triggerZoneRadius, interactLayer);
            if (otherCollider != null)
            {
                _panel.SetActive(true);
            }
        }

        private void OnTriggerExit2D()
        {
            _panel.SetActive(false);
        }

        public void OnInterectTable()
        {
            Collider2D otherCollider = Physics2D.OverlapCircle(transform.position, triggerZoneRadius, interactLayer);
            if (otherCollider != null)
            {
                if (otherCollider.TryGetComponent(out IInteractable interactable))
                {
                    _panel.SetActive(false);
                    interactable.Interact();
                }
            }
        }
    }
}
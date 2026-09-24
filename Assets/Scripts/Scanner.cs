using System;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private float _laserDistance = 3f;
    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _lineRenderer.enabled = false;
        _lineRenderer.startWidth = 0.01f;
        _lineRenderer.endWidth = 0.01f;
    }

    private void Update()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, _laserDistance, _layerMask))
            {
                _lineRenderer.SetPosition(1, hit.point);
                _lineRenderer.startColor = Color.green;
                _lineRenderer.endColor = Color.green;
            }
            else
            {
                _lineRenderer.SetPosition(1, transform.position + transform.forward * _laserDistance);
                _lineRenderer.startColor = Color.red;
                _lineRenderer.endColor = Color.red;
            }
        }
    }

    public void Scan()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _laserDistance, _layerMask))
        {
            BuyableObject obj = hit.transform.gameObject.GetComponent<BuyableObject>();
            if (obj == null)
            {
                obj = hit.transform.gameObject.GetComponentInParent<BuyableObject>();
            }
            if (obj != null)
            {
                //Debug.Log("name : " + obj.DisplayName + ", price : " + obj.Price.ToString());

                UiManager.Instance.AddItemToList(obj.DisplayName, obj.Price);
            }
        }
    }

    public void GrabScanner()
    {
        _lineRenderer.enabled = true;
    }

    public void ExitScanner()
    {
        _lineRenderer.enabled = false;
    }
}

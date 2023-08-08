using UnityEngine;

public class GunSightController : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel; // Точка ствола пистолета
    [SerializeField] private float _rayDistance = 10f; // Расстояние луча
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateGunSight();
    }

    private void UpdateGunSight()
    {
        Ray ray = new Ray(_gunBarrel.position, _gunBarrel.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, _rayDistance))
        {
            _lineRenderer.SetPosition(0, _gunBarrel.position);
            _lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            _lineRenderer.SetPosition(0, _gunBarrel.position);
            _lineRenderer.SetPosition(1, _gunBarrel.position + _gunBarrel.forward * _rayDistance);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Transform _back;
    [SerializeField] private Transform _thumble;
    [SerializeField] private float _radius = 256f;

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private RectTransform _thumbleRectTransform;

    private Vector3 _axis;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _back.position = eventData.position;
        _thumbleRectTransform.anchoredPosition = Vector3.zero;
        _startPosition = _thumble.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var direction = (new Vector3(eventData.position.x, eventData.position.y) - _startPosition).normalized;
        Debug.Log($"direction: {direction}");

        var distance = Vector3.Distance(_startPosition, eventData.position);
        distance = Mathf.Clamp(distance, 0, _radius);

        _thumble.position = direction * distance + _startPosition;
        _axis = direction;

        MoveTarget();
    }

    public void OnDrop(PointerEventData eventData)
    {
        _thumbleRectTransform.anchoredPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        _thumbleRectTransform = _thumble.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveTarget()
    {
        _target.position += _axis * _speed * Time.deltaTime;

        // _target.transform.position(_axis * _speed * Time.deltaTime)
    }
}

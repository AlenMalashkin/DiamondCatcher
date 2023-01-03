using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum TouchFields
    {
        LeftTouchField,
        RightTouchField
    }

    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private TouchFields currentTouchField;

    public void Init(Player player)
    {
        _player = player;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (currentTouchField == TouchFields.LeftTouchField)
        {
            _player.SetMoveLeftBehaviour();
        }    

        if (currentTouchField == TouchFields.RightTouchField)
        {
            _player.SetMoveRightBehaviour();
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _player.SetStayBehaviour();
    }
}

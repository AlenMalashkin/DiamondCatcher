using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Currency;

public class Player : MonoBehaviour
{
    public event Action<FallingItems.Item> OnCollectItemEvent;

    [SerializeField] private float _speed;

    private Dictionary<Type, IPlayerBehaviour> playerBehaviours;
    private IPlayerBehaviour currnetPlayerBehaviour;

    private Bank _bank;

    private void OnEnable()
    {
        OnCollectItemEvent += CollectItem;

        InitBehavoiurs();
        SetBehaviourByDefault();
    }

    private void OnDisable()
    {
        OnCollectItemEvent -= CollectItem;
    }

    private void Update()
    {
        if (currnetPlayerBehaviour != null)
            currnetPlayerBehaviour.Update();

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();
        
        if (Input.GetKey(KeyCode.RightArrow))
            MoveRight();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out FallingItems.Item item))
        {
            OnCollectItemEvent.Invoke(item);
        }
    }

    public void Init(Bank bank)
    {
        _bank = bank;
    }

    private void CollectItem(FallingItems.Item item)
    {
        item.gameObject.SetActive(false);
        _bank.AddResource(item.GetItemPlayerPrefsName);
    }

    private void InitBehavoiurs()
    {
        playerBehaviours = new Dictionary<Type, IPlayerBehaviour>();

        playerBehaviours[typeof(PlayerMoveLeftBehaviour)] = new PlayerMoveLeftBehaviour(this);
        playerBehaviours[typeof(PlayerMoveRightBehaviour)] = new PlayerMoveRightBehaviour(this);
        playerBehaviours[typeof(PlayerStayBehaviour)] = new PlayerStayBehaviour(this);
    }

    private void SetBehaviour(IPlayerBehaviour newPlayerBehavoiur)
    {
        if (currnetPlayerBehaviour != null)
            currnetPlayerBehaviour.Exit();

        currnetPlayerBehaviour = newPlayerBehavoiur;
        currnetPlayerBehaviour.Enter();
    }

    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        return playerBehaviours[type];
    }

    private void SetBehaviourByDefault()
    {
        SetStayBehaviour();
    }

    public void SetStayBehaviour()
    {
        var behavoiur = GetBehaviour<PlayerStayBehaviour>();
        SetBehaviour(behavoiur);
    }

    public void SetMoveRightBehaviour()
    {
        var behavoiur = GetBehaviour<PlayerMoveRightBehaviour>();
        SetBehaviour(behavoiur);
    }

    public void SetMoveLeftBehaviour()
    {
        var behavoiur = GetBehaviour<PlayerMoveLeftBehaviour>();
        SetBehaviour(behavoiur);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void Stop()
    {
        return;
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using Boss;
using UnityEngine;
using Currency;
using FallingItems;

public class Player : MonoBehaviour
{
    public event Action<FallingItems.DefaultItem> OnCollectItemEvent;
    public event Action<FallingItems.BoostItem> OnCollectBoostItemEvent;

    private PlayerBoosts _playerBoosts;
    private float _speed;

    private Dictionary<Type, IPlayerBehaviour> playerBehaviours;
    private IPlayerBehaviour currnetPlayerBehaviour;

    private Bank _bank;

    private void OnEnable()
    {
        _playerBoosts = GetComponent<PlayerBoosts>();

        OnCollectItemEvent += CollectItem;
        OnCollectItemEvent += CountTotalItemAmount;
        OnCollectBoostItemEvent += OnCollectBoostItem;
        
        InitBehavoiurs();
        SetBehaviourByDefault();
    }

    private void OnDisable()
    {
        OnCollectItemEvent -= CollectItem;
        OnCollectItemEvent -= CountTotalItemAmount;
        OnCollectBoostItemEvent -= OnCollectBoostItem;
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
        if (col.collider.TryGetComponent(out FallingItems.DefaultItem item))
        {
            OnCollectItemEvent?.Invoke(item);
        }

        if (col.collider.TryGetComponent(out FallingItems.BoostItem boostItem))
        {
            OnCollectBoostItemEvent?.Invoke(boostItem);
        }
    }

    public void Init(Bank bank)
    {
        _bank = bank;
        _speed = PlayerPrefs.GetInt("playerSpeed", 10);
        
    }

    private void CollectItem(FallingItems.DefaultItem item)
    {
        item.gameObject.SetActive(false);
        _bank.AddResource(item.GetItemPlayerPrefsName, 1);
    }

    private void CountTotalItemAmount(DefaultItem item)
    {
        var amount = PlayerPrefs.GetInt(item.GetItemPlayerPrefsName + "Total", 0);
        amount += 1;
        PlayerPrefs.SetInt(item.GetItemPlayerPrefsName + "Total", amount);
    }

    private void OnCollectBoostItem(FallingItems.BoostItem boostItem)
    {
        boostItem.gameObject.SetActive(false);
        var boost = _playerBoosts.SetBoost(boostItem.boostName);
        boost.Invoke();
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

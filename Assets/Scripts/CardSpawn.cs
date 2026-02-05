using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSpawn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 startScale = Vector2.one;
    public Vector2 endScale = new Vector2(0.9f, 0.9f);
    private bool isPointerDown = false;
    public bool isClick;
    public float countdown;
    public Button btn;
    public Image fill;
    public int coin;
    public Text text;
    public Text countTxt;
    public Action onClick;
    private bool isCoin;
    public void Start()
    {
        isClick = true;
        fill.fillAmount = 0;
        countTxt.text = "0";
        countTxt.gameObject.SetActive(false);
        text.text = coin.ToString();
        btn.onClick.AddListener(OnClick);
        isCoin = coin <= UIInGame.Instance.Coin;
    }
    public void OnClick()
    {
        if (!UIInGame.Instance.IsStart) return;
        if (!isClick || !isCoin) return;
        isClick = false;
        btn.enabled = false;
        onClick?.Invoke();
        fill.fillAmount = 1;
        StartCountdown(countdown);
        UIInGame.Instance.RemoveCoin(coin);
    }
    public void StartCountdown(float duration)
    {
        countTxt.text = duration.ToString();
        float valChange = duration;
        countTxt.gameObject.SetActive(true);
        DOTween.To(() => valChange, x => valChange = x, 0, duration).SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                countTxt.text = ((int)valChange).ToString();
                fill.fillAmount = valChange / duration;
            })
            .OnComplete(() =>
            {
                isClick = true;
                btn.enabled = true;
                fill.fillAmount = 0;
                countTxt.text = "0";
                countTxt.gameObject.SetActive(false);
                Debug.Log("⏰ Countdown finished");
            }).SetId(this);
    }
    public void CheckClickButton()
    {
        isCoin = coin <= UIInGame.Instance.Coin;
        btn.interactable = isCoin;
    }
    public void AddListener(Action action)
    {
        onClick = action;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!UIInGame.Instance.IsStart) return;
        if (!isClick || !isCoin) return;
        isPointerDown = true;
        transform.DOScale(endScale, 0.1f).SetEase(Ease.Linear).SetUpdate(true).SetId(this);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!UIInGame.Instance.IsStart) return;
        if (!isClick || !isCoin) return;
        if (!isPointerDown) return;
        isPointerDown = false;
        transform.DOScale(startScale, 0.1f).SetEase(Ease.Linear).SetUpdate(true).SetId(this);
    }
}
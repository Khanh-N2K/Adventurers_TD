using UnityEngine;
using UnityEngine.UI;

public class UIInGame : Singleton<UIInGame>
{
    public int Coin = 50;
    public Button[] listBtns;
    public void Start()
    {
        for (int i = 0; i < listBtns.Length; i++)
        {
            listBtns[i].onClick.AddListener(() => SpawnCharacter(i));
        }
    }
    public void SpawnCharacter(int idx)
    {
        MapCtr.Instance.SpawnCharacter(idx);
    }
}
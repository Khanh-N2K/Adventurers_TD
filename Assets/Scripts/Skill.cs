using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Button btn;
    private void Awake()
    {
        btn.onClick.AddListener(OnSkill);
    }
    private void OnSkill()
    {

    }
}
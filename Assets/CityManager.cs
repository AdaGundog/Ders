using UnityEngine;
using TMPro;
public class CityManager : MonoBehaviour
{
    public static CityManager Instance { get; private set; }

    public int money = 1000;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateMoneyUI();
    }

    private void Update()
    {
        UpdateMoneyUI();
    }
    void UpdateMoneyUI()
    {
        moneyText.text = "Money: " + money;
    }

}

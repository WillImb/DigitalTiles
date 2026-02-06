using JetBrains.Annotations;
using UnityEngine;

public class ReportScene : MonoBehaviour
{
    public float debt;
    public float money;
    public float tax = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        debt = PlayerPrefs.GetFloat("debt",100000);

        CalcGrossIncome();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalcGrossIncome()
    {
        float taxedMoney = money * (tax/ 100);

        debt -= taxedMoney;
        money -= taxedMoney;

        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("debt",debt);
    }
}

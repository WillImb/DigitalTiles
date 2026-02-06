using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager instance;

    public float brainCoins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        brainCoins = PlayerPrefs.GetFloat("kudos", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

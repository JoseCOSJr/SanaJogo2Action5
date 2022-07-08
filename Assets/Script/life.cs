using UnityEngine;

public class life : MonoBehaviour
{
    [SerializeField]
    private int lifeMax = 2;
    private int lifeCount;

    private void OnEnable()
    {
        lifeCount = lifeMax;
    }

    public void AddLife(int addValue)
    {
        lifeCount += addValue;

        if(lifeCount > lifeMax)
        {
            lifeCount = lifeMax;
        }

        if (lifeCount <= 0)
        {
            lifeCount = 0;
            gameObject.SetActive(false);
        }
    }
}

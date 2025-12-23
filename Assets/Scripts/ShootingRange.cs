using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    [SerializeField] Transform _dummiesParent;
    [SerializeField] private GameObject[] _dummies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {

        int count = _dummiesParent.childCount;
        _dummies = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            _dummies[i] = _dummiesParent.GetChild(i).gameObject;
        }
    }


    public void ResetDummy()
    {
        foreach (var dummy in _dummies)
        {
            dummy.gameObject.SetActive(true);
        }
    }

    public void ClearDummy()
    {
        foreach (var dummy in _dummies)
        {
            dummy.gameObject.SetActive(false);
        }
    }
}

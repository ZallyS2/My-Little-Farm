using UnityEngine;

public class Itens : MonoBehaviour
{
    [SerializeField] private int _currentWoods;
    [SerializeField] private int _totalHoodsMax;

    [SerializeField] private float _currentWater;
    [SerializeField] private float _totalWaterMax;

    [SerializeField] private float _carrots;
    [SerializeField] private float _carrotsMax;


    public int currentWoods { get => _currentWoods; set => _currentWoods = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }
    public float TotalWaterMax { get => _totalWaterMax; set => _totalWaterMax = value; }
    public int TotalHoodsMax { get => _totalHoodsMax; set => _totalHoodsMax = value; }
    public float carrots { get => _carrots; set => _carrots = value; }
    public float CarrotsMax { get => _carrotsMax; set => _carrotsMax = value; }

    void Start()
    {
        _totalHoodsMax = 40;
        _totalWaterMax = 500;
        _carrotsMax = 25;
    }

    void Update()
    {
        
    }


    public void WaterLimit(int water)
    {
        if(_currentWater <= _totalWaterMax)
        {
            _currentWater += water;
        }
        else
        {
            Debug.Log("Limite de água atingido");
        }
    }

    public void WoodLimit(int wood)
    {
        if(_currentWoods <= _totalHoodsMax)
        {
            _currentWoods += wood;
        }
        else
        {
            Debug.Log("Limite de madeira atingido");
        }
    }
}

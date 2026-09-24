using UnityEngine;

public class BuyableObject : MonoBehaviour
{
    public string DisplayName { get { return _name; } }
    public float Price { get { return _price; } }

    [SerializeField] private string _name;
    [SerializeField] private float _price;


}

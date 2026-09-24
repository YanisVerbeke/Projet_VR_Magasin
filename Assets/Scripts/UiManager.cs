using System.Security.AccessControl;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    private GameObject _productListObject;
    private TextMeshProUGUI _totalPriceText;

    [SerializeField] private GameObject _listItemPrefab;
    [SerializeField] private GameObject _listContentObject;

    // ça aurait été mieux de gérer la liste dans un autre script et que celui là ne serve qu'à l'affichage mais il est tard
    private float _totalPrice = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _productListObject = transform.Find("HUD/ProductList").gameObject;
        _totalPriceText = transform.Find("HUD/ProductList/totalPrice").GetComponent<TextMeshProUGUI>();

        DisplayList(false);
        ClearProductList();
    }



    public void AddItemToList(string name, float price)
    {
        GameObject item = Instantiate(_listItemPrefab, _listContentObject.transform);
        item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        item.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = price.ToString() + " G";

        _totalPrice += price;
        _totalPriceText.text = "Total : " + _totalPrice.ToString() + " G";
        DisplayList(true);
    }

    public void DisplayList(bool active)
    {
        _productListObject.SetActive(active);
    }

    public void ToggleListButton()
    {
        DisplayList(!_productListObject.activeInHierarchy);
    }

    public void ClearProductList()
    {
        for (int i = 0; i < _listContentObject.transform.childCount; i++)
        {
            Destroy(_listContentObject.transform.GetChild(i).gameObject);
        }
        _totalPrice = 0;
        _totalPriceText.text = "Total : 0 G";
    }
}

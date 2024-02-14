using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Car playerCar;
    [SerializeField] private GameObject _instantiateCarFields;
    [SerializeField] private Text _yearField;
    [SerializeField] private Text _makeField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCar()
    {
        int year;

        if (!int.TryParse(_yearField.text, out year))
        {
            Debug.Log("invalid year. Please insert numbers only.");
            return;
        }

        if (year >= 1886 && _makeField.text != "")
        {
            playerCar = new Car();
            playerCar.Year = year;
            playerCar.Make = _makeField.text;
            playerCar.PrintAllInfo();
        }
        else
        {
            Debug.Log("Invalid year inserted or make field is empty. Year must be higher than 1885.");
        }
    }
}

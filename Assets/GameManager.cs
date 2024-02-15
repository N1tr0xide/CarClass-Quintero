using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Car _playerCar;

    [SerializeField] private GameObject _instantiateCarInputFields;
    [SerializeField] private GameObject _carInformationPanel;
    [SerializeField] private GameObject _carSpeedPanel;
    [SerializeField] private Text _yearInputField, _makeInputField;
    [SerializeField] private Text _carYearText, _carMakeText;
    [SerializeField] private Text _errorsText;
    private Text _carSpeedText;

    // Start is called before the first frame update
    void Start()
    {
        _carSpeedText = _carSpeedPanel.GetComponentInChildren<Text>();
        _carInformationPanel.SetActive(false);
        _carSpeedPanel.SetActive(false);
        _errorsText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpdateSpeedUI(_playerCar.Accelerate(Random.Range(1,5)));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdateSpeedUI(_playerCar.Deaccelerate(Random.Range(1, 5)));
        }
    }

    private void LoadCarInfoUI(Car car)
    {
        _carYearText.text = $"Year: {car.Year}";
        _carMakeText.text = $"Make: {car.Make}";
    }

    private void UpdateSpeedUI(int speed)
    {
        _carSpeedText.text = $"Current Speed: {speed} mph";
    }

    public void InstantiateCar()
    {
        int year;

        if (!int.TryParse(_yearInputField.text, out year))
        {
            _errorsText.text = "invalid year. Please insert numbers only.";
            return;
        }

        if (year >= 1886 && _makeInputField.text != "")
        {
            _playerCar = new Car();
            _playerCar.Year = year;
            _playerCar.Make = _makeInputField.text;
            _playerCar.PrintAllInfo();

            _instantiateCarInputFields.SetActive(false);
            _carInformationPanel.SetActive(true);
            _carSpeedPanel.SetActive(true);

            LoadCarInfoUI(_playerCar);
            UpdateSpeedUI(_playerCar.Accelerate(0));
        }
        else
        {
            _errorsText.text = "Invalid year inserted or make field is empty. Year must be higher than 1885.";
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
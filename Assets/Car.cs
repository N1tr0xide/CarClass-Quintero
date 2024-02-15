using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    private int year;
    private string make;
    private readonly int maxSpeed = 100;
    private int currentSpeed;

    public int Year 
    { 
        get { return year; }
        set 
        {
            if (value < 1886)
            {
                Debug.LogWarning($"{value} is an invalid year, year must be at least 1886");
                return;
            }
            year = value; 
        }
    }

    public string Make
    {
        get { return make; }
        set 
        {
            if(value == null || value == "")
            {
                Debug.LogWarning($"Invalid assingment. String is null or empty");
                return;
            }
            make = value; 
        }
    }

    public int Accelerate(int bySpeed)
    {
        int newSpeed = currentSpeed + bySpeed;
        currentSpeed = newSpeed >= maxSpeed ? maxSpeed : newSpeed; 
        return currentSpeed;
    }

    public int Deaccelerate(int bySpeed)
    {
        int newSpeed = currentSpeed - bySpeed;
        currentSpeed = newSpeed <= 0 ? 0 : newSpeed;
        return currentSpeed;
    }

    public void PrintAllInfo()
    {
        Debug.Log($"Year: {year}, Make: {make}, current speed: {currentSpeed}");
    }
}

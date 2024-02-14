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
        set { year = value; }
    }

    public string Make
    {
        get { return make; }
        set { make = value; }
    }

    public void Accelerate(int bySpeed)
    {
        int newSpeed = currentSpeed + bySpeed;
        currentSpeed = newSpeed >= maxSpeed ? maxSpeed : newSpeed; 
    }

    public void Deaccelerate(int bySpeed)
    {
        int newSpeed = currentSpeed - bySpeed;
        currentSpeed = newSpeed <= 0 ? 0 : newSpeed;
    }

    public void PrintAllInfo()
    {
        Debug.Log($"Year: {year}, Make: {make}, current speed: {currentSpeed}");
    }
}

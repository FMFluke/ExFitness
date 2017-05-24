using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

class Profile
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public char Gender { get; set; }

    public Profile(int id,string name,int weight,int height,char gender)
    {
        this.ID = id;
        this.Name = name;
        this.Weight = weight;
        this.Height = height;
        this.Gender = gender;
    }
}
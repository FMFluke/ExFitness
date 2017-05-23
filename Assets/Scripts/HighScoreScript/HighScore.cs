using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

class HighScore:IComparable<HighScore> {
    public int Score { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int ID { get; set; }
    public HighScore (int id,string name,int score)
    {
        this.Score = score;
        this.ID = id;
        this.Name = name;
    }

    public int CompareTo(HighScore other)
    {
        if (other.Score < this.Score)
            return -1;
        else if (other.Score > this.Score)
            return 1;
        else
            return 0;
        //throw new NotImplementedException();
    }
}

using UnityEngine;
using System.Collections.Generic;


public class ResultData
{
    public int correctCount;
    public int wrongCount;
    public int missingCount;

    public float totalPrice;
    public int score;

    public List<string> correctItems = new();
    public List<string> wrongItems = new();
    public List<string> missingItems = new();
}

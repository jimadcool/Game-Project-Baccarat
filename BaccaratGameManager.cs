using System.Collections.Generic;
using UnityEngine;

public class BaccaratGameManager : MonoBehaviour
{
    public int balance = 1000;

    public Player player = new Player();
    public Banker banker = new Banker();

    public void PlayRound(string selectedBet, int betAmount)
    {
        // Your game logic here
    }
}

// Supporting classes
public class Player { public List<Card> Cards = new List<Card>(); public int Value() => 0; }
public class Banker { public List<Card> Cards = new List<Card>(); public int Value() => 0; }
public class Card
{
    public string name;
    public Card(string n) { name = n; }
    public override string ToString() { return name; }
}

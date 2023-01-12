using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());
        Player[] players = new Player[n];
        
        for(int i=0; i<n; i++)
        {
            string[] values = Console.ReadLine().Split(' ');
            players[i].Name = values[0];
            players[i].Score = int.Parse(values[1]);
        }
               
        Array.Sort(players, new Checker());
        foreach(var player in players)
        {
            Console.WriteLine(player.Name + " " + player.Score);
        }
    }
}

public class Player {
    public string? Name { get; set; } = string.Empty;
    public int? Score { get; set; }
}

public class Checker : IComparer<Player> {

    int IComparer<Player>.Compare(Player? a1, Player? a2) {
        if (a1.Score < a2.Score) {
            return 1;
        } else if (a1.Score > a2.Score) {
            return -1;
        } else {
            return string.Compare(a1.Name, a2.Name);
        }
  }     
  
}

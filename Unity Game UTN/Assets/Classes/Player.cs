using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string path = @"C:\Users\zapli\Documents\Unity Projects\Unity_Game\Unity Game UTN\Assets\Files\players.bin";

    public string playerName;
    public int playerScore;

    public Player (string name, int score)
    {
        playerName = name;
        playerScore = score;
    }

    public void savePlayer ()
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }

        // Abro el archivo en modo append
        FileStream fs = File.Open(path, FileMode.Append);

        if (fs.CanWrite)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(this.playerName + "-" + this.playerScore + "|");
            fs.Write(buffer, 0, buffer.Length);
        }

        fs.Close();
    }

    public Player[] getAllPlayers ()
    {
        string data;
        Player[] players = null;
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

        if (fs.CanRead)
        {
            // Guardo los datos en un array de bytes igual de grande que el archivo
            byte[] buffer = new byte[fs.Length];
            int bytesRead = fs.Read(buffer, 0, buffer.Length);

            data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            players = formatPlayers(data);
        }

        fs.Close();

        
        

        return players;
    }

    public Player[] formatPlayers (string data)
    {
        data = data.Substring(0, data.Length -1);
        string[] playersData = data.Split('|');
        Player[] players = new Player[playersData.Length];

        for (int i = 0;i < playersData.Length;i++)
        {
            string[] formattedData = playersData[i].Split('-');
            players[i] = new Player(formattedData[0], int.Parse(formattedData[1]));
        }

        return players;
    }
}

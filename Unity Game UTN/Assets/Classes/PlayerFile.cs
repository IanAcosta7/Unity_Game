using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFile
{
    public static string path = Application.persistentDataPath + @"\players.bin";

    // Esta funcion escribe un nuevo "Player" en el archivo "path"
    public void savePlayer(Player player)
    {
        if (File.Exists(path))
        {
            FileStream fs = File.Open(path, FileMode.Append); // Abro el archivo en modo append

            if (fs.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(player.playerName + "-" + player.playerScore + "|");
                fs.Write(buffer, 0, buffer.Length);
            }

            fs.Close();
        }
        else
        {
            FileStream fs = File.Open(path, FileMode.Create); // Abro el archivo en modo write

            if (fs.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(player.playerName + "-" + player.playerScore + "|");
                fs.Write(buffer, 0, buffer.Length);
            }

            fs.Close();
        }
    }

    // Esta funcion devuelve un arreglo de todos los "Player" en el archivo "path"
    public Player[] getAllPlayers()
    {
        string data;
        Player[] players = null;

        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); // Abro el archivo en modo lectura 

            if (fs.CanRead)
            {
                // Guardo los datos en un array de bytes igual de grande que el archivo
                byte[] buffer = new byte[fs.Length];
                int bytesRead = fs.Read(buffer, 0, buffer.Length);

                data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                players = formatPlayers(data);
            }

            fs.Close();
        }

        return players;
    }

    // Esta función transforma el string largo en datos del tipo Player
    public Player[] formatPlayers(string data)
    {
        data = data.Substring(0, data.Length - 1);
        string[] playersData = data.Split('|');
        Player[] players = new Player[playersData.Length];

        for (int i = 0; i < playersData.Length; i++)
        {
            string[] formattedData = playersData[i].Split('-');
            players[i] = new Player(formattedData[0], int.Parse(formattedData[1]));
        }

        return players;
    }
}

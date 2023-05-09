using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    private string dbName = "URI = file:Inventory.db";

    void Start()
    {
        CreateDB();
        DisplayVolume();
        
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);";
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE IF NOT EXISTS volume (level INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void AddWeapon(string weaponName, int weaponDamage)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO weapons (name, damage) VALUES ('" + weaponName + "', '" + weaponDamage + "');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    public void NewVolume(float volumeLevel)
    {
        Debug.Log("saved");
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from volume WHERE level";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO volume (level) VALUES ('" + volumeLevel + "');";
                command.ExecuteNonQuery();
            }

            connection.Close();
            DisplayVolume();
        }
    }

    public void DisplayWeapons()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM weapons;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDamage: " + reader["damage"]);
                    }
                    reader.Close();
                }
            }

            connection.Close();
        }
    }
    
    public void DisplayVolume()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM volume;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.Log("Volume Level: " + reader["level"]);
                        AudioListener.volume = PlayerPrefs.GetFloat("volume") / 10;
                    }
                    reader.Close();
                }
            }

            connection.Close();
        }
    }

}

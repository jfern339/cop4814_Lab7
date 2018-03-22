using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

//I'm adding this comment with Notepad through my local computer

namespace GamesScoresLibrary
{
    public class GameFactory
    {
        StreamWriter sw;
        XmlSerializer serial;
        List<Games> gamesList;
        const string FilePath = @"..\..\games.xml";

        public void CreateGameList()
        {
            gamesList = new List<Games>();
            Games G = new Games("Scarlet Knights", 78, "Buckeyes", 74);
            gamesList.Add(G);
            G = new Games("Patriots", 0, "Eagles", 34);
            gamesList.Add(G);
            G = new Games("Yankees", 8, "Red Sox", 1);
            gamesList.Add(G);
            G = new Games("Hurricanes", 28, "Golden Panthers", 30);
            gamesList.Add(G);
            G = new Games("Gators", 3, "Seminoles", 45);
            gamesList.Add(G);
            G = new Games("Marlins", 2, "Mets", 3);
            gamesList.Add(G);
                       
        }

        public Boolean SerializeGameList()
        {
            if (gamesList != null)
            {
                serial = new XmlSerializer(gamesList.GetType());
                sw = new StreamWriter(FilePath);
                serial.Serialize(sw, gamesList);
                sw.Close();
                return true;
            }
            else
                return false;
            
        }

        public List<Games> DeserializeGamesList(out string resultMessage)
        {
            try
            {
                gamesList = new List<games>();
                StreamReader sr = new StreamReader(FilePath);
                serial = new XmlSerializer(gamesList.GetType());
                gamesList = (List<Games>)serial.Deserialize(sr);
                sr.Close();
                resultMessage = "Success";
                return gamesList;
            }
            catch (Exception ex)
            {
                resultMessage = "Exception thrown: " + ex.Message;
                return null;
            }
        }
    
    //This is the GamesFactory Class
 }

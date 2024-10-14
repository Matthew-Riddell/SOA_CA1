// Matthew Riddell SOA CA1 - D00245674
// Steam Game object class

using SOA_CA1.Services;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOA_CA1
{
    public class SteamGame
    {
        public int Appid { get; set; }
        public string Name { get; set; }

        public SteamGame(int appid, string name)
        {
            Appid = appid;
            Name = name;
        }

        public SteamGame() { }
    }


    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.steampowered.com")]
    [XmlRoot(Namespace = "http://www.steampowered.com", IsNullable = false)]
    public partial class SteamGameResponse
    {
        private SteamGame[] gamesField;

        /// <remarks/>
        [XmlArray("games")]
        [XmlArrayItem("game", IsNullable = false)]
        public SteamGame[] Games
        {
            get { return this.gamesField; }
            set { this.gamesField = value; }
        }
    }
}

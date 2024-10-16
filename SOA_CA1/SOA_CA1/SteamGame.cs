// Matthew Riddell SOA CA1 - D00245674
// Steam Game object class

using SOA_CA1.Services;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SOA_CA1
{
    public class SteamGame
    {
        // JsonPropertyName 
        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability

        [JsonPropertyName("appid")]
        public int Appid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("playtime_forever")]
        public double PlaytimeForever { get; set; }

        [JsonPropertyName("img_icon_url")] 
        public string IconUrl { get; set; }



        public int CurrentPlayerCount { get; set; }

        public SteamGame(int appid, string name, double playtime_forever, string img_icon_url)
        {
            Appid = appid;
            Name = name;
            PlaytimeForever = playtime_forever;
            IconUrl = img_icon_url;
        }

        public SteamGame() { }
    }


    ///// <remarks/>
    //[Serializable]
    //[DesignerCategory("code")]
    //[XmlType(AnonymousType = true, Namespace = "http://www.steampowered.com")]
    //[XmlRoot(Namespace = "http://www.steampowered.com", IsNullable = false)]
    //public partial class SteamGameResponse
    //{
    //    private SteamGame[] gamesField;

    //    /// <remarks/>
    //    [XmlArray("games")]
    //    [XmlArrayItem("game", IsNullable = false)]
    //    public SteamGame[] Games
    //    {
    //        get { return this.gamesField; }
    //        set { this.gamesField = value; }
    //    }
    //}
}

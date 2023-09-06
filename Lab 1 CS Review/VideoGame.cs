using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_CS_Review
{
    internal class VideoGame : IComparable<VideoGame> //Step 2
    { //step 1
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string NA_Sales { get; set; }
        public string EU_Sales { get; set; }
        public string JP_Sales { get; set; }
        public string Other_Sales { get; set; }
        public string Global_Sales { get; set; }

        public VideoGame() { }

        public int CompareTo(VideoGame? other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString() //Step 2
        {
            string videoGameString = "";
            videoGameString += $"Title: {Name}\n";
            videoGameString += $"Platform: {Platform}\n";
            videoGameString += $"Year: {Year}\n";
            videoGameString += $"Genre: {Genre}\n\n";
            videoGameString += $"Publisher: {Publisher}\n\n";
            videoGameString += $"NA Sales: {NA_Sales}\n";
            videoGameString += $"EU Sales: {EU_Sales}\n";
            videoGameString += $"JP Sales: {JP_Sales}\n";
            videoGameString += $"Other Sales: {Other_Sales}\n";
            videoGameString += $"Total Sales: {Global_Sales}\n";

            videoGameString += $"---------------------------------------------------------------";
            return videoGameString;
        }
    }
}

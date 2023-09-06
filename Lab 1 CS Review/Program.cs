using System.Reflection.Metadata;

namespace Lab_1_CS_Review
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string dataPath = projectFolder + Path.DirectorySeparatorChar + "videogames.csv";

            List<VideoGame> games = new List<VideoGame>();

            using (var reader = new StreamReader(dataPath))
            {
                string fileHeader = reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] lineElements = line.Split(',');

                    VideoGame g = new VideoGame()
                    {
                        Name = lineElements[0],
                        Platform = lineElements[1],
                        Year = lineElements[2],
                        Genre = lineElements[3].ToLower(),
                        Publisher = lineElements[4].ToLower(),
                        NA_Sales = lineElements[5],
                        EU_Sales = lineElements[6],
                        JP_Sales = lineElements[7],
                        Other_Sales = lineElements[8],
                        Global_Sales = lineElements[9]
                    };
                    games.Add(g);
                }

                games.Sort();

                var orderedGameByTitle = games.OrderBy(g => g.Name);
                foreach (var game in orderedGameByTitle)
                {
                    Console.WriteLine(game);
                }

                var gamesPublishedByCapcom = games.Where(g => g.Publisher == "Capcom"); //Step 3
                foreach (var game in gamesPublishedByCapcom)
                {
                    Console.WriteLine(game);
                }

                static void PublisherData(List<VideoGame> game, string publisher) //Method to do step 4 and 7
                //While writing this I realized it works for step 7 so I renamed it accordingly
                {
                    float numGames = game.Count;
                    var publisherGames = new List<VideoGame>();
                    foreach (var g in game)
                    {
                        if(g.Publisher == publisher)
                            publisherGames.Add(g);
                    }
                    float numGamesByPublisher = publisherGames.Count;
                    var percentOfGamesByPublisher = (numGamesByPublisher / numGames) * 100;

                    Console.WriteLine($"Out of {numGames}, {numGamesByPublisher} are made by {publisher}, which is {percentOfGamesByPublisher:0.##}%");

                }
                var fightingGames = games.Where(g => g.Genre == "Fighting"); //Step 5
                foreach (var game in fightingGames)
                {
                    Console.WriteLine(game);
                }

                PublisherData(games, "capcom"); //Actually calling on the step 4 method

                static void GenreData(List<VideoGame> game, string genre) //Method to do step 6, reused from step 4
                {
                //Had the same epiphany here as with the PublisherData method.
                    float numGames = game.Count;
                    var genreGames = new List<VideoGame>();
                    foreach (var g in game)
                    {
                        if (g.Genre == genre)
                            genreGames.Add(g);
                    }
                    float numGamesInGenre = genreGames.Count;
                    var percentOfGamesInGenre = (numGamesInGenre / numGames) * 100;

                    Console.WriteLine($"Out of {numGames}, {numGamesInGenre} are in the {genre} genre, which is {percentOfGamesInGenre:0.##}%");

                }

                GenreData(games, "fighting"); //Using the step 6 method

                Console.WriteLine("What publisher's data would you like to check?");
                string userChoiceOfPublisher = Console.ReadLine().ToLower();
                
                PublisherData(games, userChoiceOfPublisher);

                Console.WriteLine();
                Console.WriteLine("What genre's data would you like to check?");
                string userChoiceOfGenre = Console.ReadLine().ToLower();

                GenreData(games, userChoiceOfGenre);




            }
        }
    }
}
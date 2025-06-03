namespace MovieMatch
{
    public class MovieQuery(string name, string id, string year, bool getMovieByName)
    {
        private readonly string Name = name;
        private readonly string Id = id;
        private readonly string Year = year;
        private readonly bool GetMovieByName = getMovieByName;

        private const string apiUrl = "http://www.omdbapi.com";
        private const string apiKey = "&apikey=930aab22";
        private const string titleQuerier = "?t=";
        private const string idQuerier = "?i=";
        private const string yearQuerier = "&y=";

        public string GenerateQuery()
        {
            string query = "";
            if (GetMovieByName && Name is not null && Name != string.Empty)
            {
                query = titleQuerier + Name.ToLower().Replace(' ', '+');
                if (Year  != null && Year != string.Empty)
                {
                    query += yearQuerier + Year;
                }
            }
            else if (!GetMovieByName && Id is not null && Id != string.Empty)
            {
                query = idQuerier + Id.ToLower().Replace(' ', '+');
            }
            else
            {
                throw new Exception("Invalid input");
            }
                return apiUrl + query + apiKey;
        }
    }
}

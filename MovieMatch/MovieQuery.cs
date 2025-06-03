namespace MovieMatch
{
    public class MovieQuery(string name, string id, string? year, bool getMovieByName)
    {
        private string Name = name;
        private string Id = id;
        private string Year = year;
        private bool GetMovieByName = getMovieByName;

        private readonly string apiUrl = "http://www.omdbapi.com";
        private readonly string apiKey = "&apikey=930aab22";
        private readonly string titleQuerier = "?t=";
        private readonly string idQuerier = "?i=";
        private readonly string yearQuerier = "&y=";

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

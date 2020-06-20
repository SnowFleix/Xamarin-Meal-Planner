using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using MealPlannerMobile.Objects;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MealPlannerMobile
{
    public class spoontacularAPI
    {
        private readonly string host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com"; //DotNetEnv.Env.GetString("RAPID_APIHOST");
        private readonly string key = "62431552c5msh0329ee0958a0b99p1180a6jsndbc779cdf5fa"; //DotNetEnv.Env.GetString("RAPID_APIKEY");
        // private readonly string spoonKey = DotNetEnv.Env.GetString("SPOONACULAR_APIKEY"); // The key for the main api website

        private readonly Dictionary<String, String> _defaultHeaderMap = new Dictionary<String, String>();

        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        /// <value>The base path</value>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient { get; set; }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        public Dictionary<String, String> DefaultHeader
        {
            get { return _defaultHeaderMap; }
        }

        /// <summary>
        /// Default constructor, creates the restclient and adds the api key to the headers
        /// </summary>
        /// <param name="basePath">Path used to connect to the spoonacular api</param>
        public spoontacularAPI(String basePath = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com")
        {
            BasePath = basePath;
            RestClient = new RestClient(BasePath);
            _defaultHeaderMap.Add("x-rapidapi-host", host);
            _defaultHeaderMap.Add("x-rapidapi-key", key);
        }

        /// <summary>
        /// Sends the request to the api
        /// </summary>
        /// <param name="path">Additions to the path</param>
        /// <param name="method">Get or Post</param>
        /// <param name="queryParams">A dictionary of the queries to convert to JSON</param>
        /// <returns></returns>
        private Object SendRequest(String path, RestSharp.Method method, Dictionary<String, String> queryParams)
        {
            var request = new RestRequest(path, method);

            // add default header, if any
            foreach (var defaultHeader in _defaultHeaderMap)
                request.AddHeader(defaultHeader.Key, defaultHeader.Value);

            // add query parameter, if any
            foreach (var param in queryParams)
                request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);

            return (Object)RestClient.Execute(request);
        }

        /// <summary>
        /// Get a random recipe from spoonacular according to the users requirements
        /// </summary>
        /// <param name="cuisine">What type of meal the user wants</param>
        /// <param name="diet">What diet the user is on</param>
        /// <param name="intolerences">Intolerences the user may have</param>
        /// <param name="mealType">The mealtype to be returned from spoonacular</param>
        /// <param name="query">The query sent to spoonacular, usually something like 'Burgers' or 'Spaghetti'</param>
        ///                     the query by default is set to empty by default because it is not needed unless a specific meal is needed
        /// <param name="number">The numbers of recipes to get back from spoonacular</param>
        /// <returns>Returns the complete array of results including metadata</returns>
        public Result GetRandomRecipe(string cuisine, string diet, string intolerences, string mealType, int number = 1, string query = "")
        {
            var path = String.Format("/recipes/complexSearch?query={0}&cuisine={1}&diet={2}&intolerances={3}&type={4}&instructionsRequired=true&fillIngredients=true&addRecipeInformation=true&number={5}",
                                     query,
                                     cuisine,
                                     diet,
                                     intolerences,
                                     mealType,
                                     number);

            path = path.Replace("{format}", "json");

            // make the HTTP request
            IRestResponse response = (IRestResponse)SendRequest(path, Method.GET, new Dictionary<String, String>()); // just create an empty query param dictionary because we already built the query params

            if (((int)response.StatusCode) >= 400)
                throw new Exception((int)response.StatusCode + "Error calling GetRandomRecipes: " + response.Content + response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Exception((int)response.StatusCode + "Error calling GetRandomRecipes: " + response.ErrorMessage + response.ErrorMessage);

            return JsonConvert.DeserializeObject<Result>(response.Content);
        }

        /// <summary>
        /// Uses the spoonacularAPI to convert the ingredient amounts
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient to convert</param>
        /// <param name="amount">Amount to convert</param>
        /// <param name="originalUnit">The unit used in the ingredient to be converted</param>
        /// <param name="targetUnit">The unit which you want to convert to</param>
        /// <returns></returns>
        public double ConvertAmount(string ingredientName, double amount, string originalUnit, string targetUnit)
        {
            var path = String.Format("/recipes/convert?ingredientName={0}&sourceAmount={1}&sourceUnit={2}&targetUnit={3}",
                                     ingredientName,
                                     amount,
                                     originalUnit,
                                     targetUnit);
            path = path.Replace("{format}", "json");

            // make the HTTP request
            IRestResponse response = (IRestResponse)SendRequest(path, Method.GET, new Dictionary<String, String>()); // just create an empty query param dictionary because we already built the query params

            if (((int)response.StatusCode) >= 400)
                throw new Exception((int)response.StatusCode + "Error calling GetRandomRecipes: " + response.Content + response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Exception((int)response.StatusCode + "Error calling GetRandomRecipes: " + response.ErrorMessage + response.ErrorMessage);

            return JsonConvert.DeserializeObject<ConversionResponse>(response.Content).targetAmount;
        }
    }
}

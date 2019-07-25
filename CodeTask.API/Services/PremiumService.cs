using CodeTask.API.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CodeTask.API.Services
{
    public interface IPremiumService
    {
        PremiumCalculationResponse Calculate(PremiumCalculationRequest request, IHostingEnvironment env);
    }

    public class PremiumService : IPremiumService
    {
        PremiumCalculationResponse response;
        public PremiumService()
        {
            response = new PremiumCalculationResponse();
        }


        /// <summary>
        /// Calculates the Premium using the formula.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public PremiumCalculationResponse Calculate(PremiumCalculationRequest request, IHostingEnvironment env)
        {

            //Get Age
            request.age = GetYears(request.dateOfBirth);

            //Get rating from occupation.
            request.Rating = GetRating(request.Occupation, env);

            //Get Factor from Rating.
            request.Factor = GetFactor(request.Rating, env);
            response.PremiumValue = CalculatePremium(request.age, request.sumIssured, request.Factor);
            response.userName = request.userName;
            return response;
        }

        private decimal CalculatePremium(int age, string sumIssured, decimal factor)
        {
            return ((age * Convert.ToDecimal(sumIssured) * factor) / 1000) * 12;
        }

        private decimal GetFactor(string rating, IHostingEnvironment env)
        {
            string jsonObject = GetJsonData(env, "App_Data\\ratingmap.json");
            var ratings = JsonConvert.DeserializeObject<RatingRoot>(jsonObject);
            var factor = Convert.ToDecimal(ratings.occupationRating.SingleOrDefault(x => x.rating == rating).factor);
            return factor;
        }

        private static string GetJsonData(IHostingEnvironment env, string path)
        {
            var contentRootPath = env.ContentRootPath;
            var jsonFilePath = System.IO.Path.Combine(contentRootPath, path);
            var jsonObject = System.IO.File.ReadAllText(jsonFilePath);
            return jsonObject;
        }

        private string GetRating(string occupation, IHostingEnvironment env)
        {
            string jsonObject = GetJsonData(env, "App_Data\\resx.json");
            var occupations = JsonConvert.DeserializeObject<OccupationRoot>(jsonObject);
            var rating = occupations.occupationList.SingleOrDefault(x => x.name == occupation).rating;
            return rating;

        }

        private int GetYears(string dob)
        {
            var dateOfBirth = DateTime.Parse(dob);
            return (DateTime.Today.Year - dateOfBirth.Year);
        }



    }
}

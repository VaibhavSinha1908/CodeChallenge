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
        public PremiumCalculationResponse Calculate(PremiumCalculationRequest request, IHostingEnvironment env)
        {

            //Get Age
            request.age = GetYears(request.dateOfBirth);


            //Get rating from occupation.
            request.Rating = GetRating(request.Occupation, env);
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
            var contentRootPath = env.ContentRootPath;
            var jsonFilePath = System.IO.Path.Combine(contentRootPath, "App_Data\\ratingmap.json");
            var jsonObject = System.IO.File.ReadAllText(jsonFilePath);
            var ratings = JsonConvert.DeserializeObject<RatingRoot>(jsonObject);
            var factor = Convert.ToDecimal(ratings.occupationRating.SingleOrDefault(x => x.rating == rating).factor);
            return factor;
        }

        private string GetRating(string occupation, IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;
            var jsonFilePath = System.IO.Path.Combine(contentRootPath, "App_Data\\resx.json");
            var jsonObject = System.IO.File.ReadAllText(jsonFilePath);
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

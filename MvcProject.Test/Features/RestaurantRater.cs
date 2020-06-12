using System;
using System.Linq;
using MvcProject.Models;

namespace MvcProject.Test.Features
{
    internal class RestaurantRater
    {
        private readonly Restaurant restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this.restaurant = restaurant;
        }

        public int ComputeRating(IRatingAlgorithm ratingAlgorithm ,int numberOfReviewsTouse)
        {
            var restaurantToRate = restaurant.Reviews.Take(numberOfReviewsTouse).ToList();
            return ratingAlgorithm.Compute(restaurantToRate);
        }
    }
}
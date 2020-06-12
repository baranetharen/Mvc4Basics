using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcProject.Models;

namespace MvcProject.Test.Features
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
           
        }
        
        [TestMethod]
        public void Compute_SimpleRating()
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = new List<RestaurantReview>()
            { new RestaurantReview() { Rating = 4 } };

            var rater = new RestaurantRater(restaurant);
            var rate = rater.ComputeRating(new SimpleRatingAlgorithm(),10);

            Assert.AreEqual(rate, 4);

        }

        [TestMethod]
        public void Compute_WeightedRating()
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = new List<RestaurantReview>()
            { new RestaurantReview() { Rating = 4 } ,new RestaurantReview() { Rating = 9 } };

            var rater = new RestaurantRater(restaurant);
            var rate = rater.ComputeRating(new WeightedRatingAlgorithm(),10);

            Assert.AreEqual(rate, 5);

        }
    }
}

using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Test.Features
{
    public interface IRatingAlgorithm
    {
         int Compute(List<RestaurantReview> restaurantReview);
    }

    public class SimpleRatingAlgorithm : IRatingAlgorithm
    {
        public int Compute(List<RestaurantReview> restaurantReview)
        {
            return (int)restaurantReview.Average(x => x.Rating);
        }
    }
    public class WeightedRatingAlgorithm : IRatingAlgorithm
    {
        public int Compute(List<RestaurantReview> restaurantReview)
        {
            int counter = 0;
            int total = 0;

            for(int i=0; i < restaurantReview.Count(); i++)
            {
                if(i < restaurantReview.Count()/2)
                {
                    counter += 2;
                    total = restaurantReview[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total = restaurantReview[i].Rating;
                }
            }

            return total / counter;
        }
    }
}

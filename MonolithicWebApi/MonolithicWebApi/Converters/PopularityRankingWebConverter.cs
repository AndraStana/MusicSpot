using Core.DTOs;
using MonolithicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Converters
{
    public class PopularityRankingWebConverter
    {
        public static PopularityRankingModel ToModel(PopularityRankingDTO popularityRankingDTO)
        {
            if (popularityRankingDTO == null)
            {
                return null;
            }

            return new PopularityRankingModel()
            {
                Id = popularityRankingDTO.Id,
                Name = popularityRankingDTO.Name,
            };
        }
    }
}

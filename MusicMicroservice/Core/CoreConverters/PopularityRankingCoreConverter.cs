using Core.DTO;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class PopularityRankingCoreConverter
    {
        public static PopularityRankingDTO ToDTO(PopularityRanking popularityRanking)
        {
            if (popularityRanking == null)
            {
                return null;
            }

            return new PopularityRankingDTO()
            {
                Id = popularityRanking.Id,
                Name = popularityRanking.Name
            };
        }
    }
}
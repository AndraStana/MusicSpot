using Common.Models;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverter
{
    public static class PopularityRankingGrpcConverter
    {
        public static PopularityRankingModel ToMessage(PopularityRankingMessage popularityRanking)
        {
            if (popularityRanking == null)
            {
                return null;
            }

            return new PopularityRankingModel()
            {
                Id = new Guid(popularityRanking.Id),
                Name = popularityRanking.Name,
            };
        }
    }
}
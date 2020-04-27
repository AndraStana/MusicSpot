using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class NewsService: INewsService
    {

        //const string channelTarget = "localhost:50051";

        //public async Task<CourseModel> GetCourseAsync(Guid id)
        //{
        //    var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
        //    try
        //    {
        //        var client = new CoursesGrpcService.CoursesGrpcServiceClient(channel);
        //        var request = new GetCourseRequest() { CourseId = id.ToString() };

        //        var response = await client.GetCourseAsync(request);

        //        return new CourseModel()
        //        { Id = Guid.Parse(response.Id), Name = response.Name };
        //    }
        //    finally
        //    {
        //        await channel.ShutdownAsync();
        //    }
        //}
    }
}

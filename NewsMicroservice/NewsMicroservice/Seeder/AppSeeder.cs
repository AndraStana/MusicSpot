using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Core.Services;
using Core.Interfaces.Services;
using Core.DTO;

namespace NewsMicroservice.Seeder
{
    public class AppSeeder
    {
        public const int NEWS_NR = 1;

        private INewsService newsService;

        public AppSeeder(INewsService _newsService)
        {
            newsService = _newsService;
        }

        public void SeedNews()
        {
            {
                if ( newsService.GetCount() == 0)
                {
                    var news = new List<NewsDTO>();
                    for (int i = 0; i < NEWS_NR; i++)
                    {
                        news.Add(new NewsDTO
                        {
                            Description = "Isle Of Wight Festival announces new dates and ticket details for 2021",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://www.banatulazi.ro/wp-content/uploads/2019/06/festival.jpg"

                        });
                        news.Add(new NewsDTO
                        {
                            Description = "Billie Eilish warns fans of fake Snapchat account: “I’m sorry to those who have been scammed",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://static01.nyt.com/images/2020/03/15/magazine/15mag-billie-03/15mag-billie-03-mediumSquareAt3X-v3.jpg"
                        });
                        news.Add(new NewsDTO
                        {
                            Description = "The Weeknd shares three new songs from ‘After Hours’ deluxe album",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://img.discogs.com/K55jpWrMIcY1J5TshfZTz2_NQ1s=/600x750/smart/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/A-2171152-1578550845-1748.jpeg.jpg"
                        });
                        news.Add(new NewsDTO
                        {
                            Description = "The 1975 ask fans to “share moments from their lives” for new video",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://www.cheatsheet.com/wp-content/uploads/2020/01/The-1975-Me-and-You-Together-Song-1024x751.jpg"
                        });

                        //-------
                        news.Add(new NewsDTO
                        {
                            Description = "Placebo have signed with independent label So Recordings for the release of their next studio album",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://api.unsitedemuzica.ro/resized/articole/photo/placebo.jpg?w=1200"
                        });
                        news.Add(new NewsDTO
                        {
                            Description = "Akon officially owns a city in Senegal and he's named it after himself",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://www.aceshowbiz.com/images/photo/akon.jpg"
                        });
                        //-------
                        news.Add(new NewsDTO
                        {
                            Description = "Ten years later, Bill and Tom Kaulitz tell MTV News what happened the night they won Best New Artist",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://taiyasmusictips.files.wordpress.com/2013/05/tokio-hotel-band-pic.jpg"


                        });
                        news.Add(new NewsDTO
                        {
                            Description = "Strictly Come Dancing: Radiohead frontman Thom Yorke says he was once asked to be on competition",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://static.independent.co.uk/s3fs-public/thumbnails/image/2019/09/11/20/gettyimages-1025888030.jpg"
                        });
                        //-------
                        news.Add(new NewsDTO
                        {
                            Description = "Twenty One Pilots to perform at 2020 Electric Castle festival in Romania",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://i.pinimg.com/originals/33/e5/a6/33e5a68527499d3e83188087b04be3f5.jpg"
                        });
                        news.Add(new NewsDTO
                        {
                            Description = "Ludovico Einaudi gained the title of most-streamed classical music artist of all time",
                            CreationDate = DateTime.Now,
                            UrlPicture = "https://i.hurimg.com/i/hdn/75/0x0/5e33c8237152d80f2c9e3c5e.jpg"
                        });

                    }
                    newsService.AddNewsList(news);
                }
            }




            //var newService = new NewsService();

            //newsService.AddNewsList(new News
            //{
            //    Description = "Isle Of Wight Festival announces new dates and ticket details for 2021",
            //    CreationDate = DateTime.Now,
            //    UrlPicture = "https://www.banatulazi.ro/wp-content/uploads/2019/06/festival.jpg"

            //});

            //var all = newsService.GetAll();


        }


    }

    }
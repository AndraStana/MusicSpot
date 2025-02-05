﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }
        public List<SongDTO> Songs { get; set; }
    }
}

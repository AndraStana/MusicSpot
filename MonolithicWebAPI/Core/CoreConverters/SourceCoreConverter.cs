using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CoreConverters
{
    public class SourceCoreConverter
    {

        public static SourceDTO ToDTO(Source source)
        {
            if (source == null)
            {
                return null;
            }

            return new SourceDTO()
            {
                Id = source.Id,
                Name = source.Name,
            };
        }
    }
}

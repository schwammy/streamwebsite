﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Dto
{
    public class GetHistoryArgsDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SearchCriteria { get; set; }

    }
}

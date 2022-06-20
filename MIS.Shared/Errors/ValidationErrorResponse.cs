﻿using System.Collections.Generic;

namespace MIS.Shared.Errors
{
    public class ValidationErrorResponse : ApiResponse
    {
        public ValidationErrorResponse() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set; }
    }
}

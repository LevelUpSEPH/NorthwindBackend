﻿using System;
namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(success:false)
        {

        }

        public ErrorResult(string message) : base(success:false, message)
        {
        }
    }
}


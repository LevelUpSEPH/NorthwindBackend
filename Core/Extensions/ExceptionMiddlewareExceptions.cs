﻿using System;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
	public static class ExceptionMiddlewareExceptions
	{
		public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();
		}
	}
}


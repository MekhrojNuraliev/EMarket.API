using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.Exeption
{
	public static class CustomExeptionMiddleware
	{
		public static IApplicationBuilder UseExeptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestExeptionMiddleware>();
		}
	}
	public class RequestExeptionMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestExeptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
                await Console.Out.WriteLineAsync("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
            }
		}
	}
}

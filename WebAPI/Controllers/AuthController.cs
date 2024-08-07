﻿using System;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Dtos;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController:ControllerBase
	{
		private IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public IActionResult Register(UserForRegisterDto userForRegisterDto)
		{
			var userExists = _authService.UserExists(userForRegisterDto.Email);
			if(!userExists.Success)
			{
				return BadRequest(BadRequest(userExists.Message));
			}

			var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
			var result = _authService.CreateAccessToken(registerResult.Data);
			if(result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}

		[HttpPost("login")]
		public IActionResult Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = _authService.Login(userForLoginDto);

			if(!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}
			var result = _authService.CreateAccessToken(userToLogin.Data);

			if(result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}
	}
}


﻿using gateway.DTO;

namespace gateway.Model;

public interface IAuth
{
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task RegisterAsync(RegisterDto registerDto);
    Task VerifyEmailAsync(EmailTokenDto dto);
}
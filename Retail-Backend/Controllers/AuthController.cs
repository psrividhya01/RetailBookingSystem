//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Retail_Backend.Data;
//using Retail_Backend.DTO;
//using Retail_Backend.Models;
//using System.Security.Cryptography;
//using System.Text;

//[Route("api/[controller]")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly AppDbContext _context;
//    private readonly JwtService _jwtService;

//    public AuthController(AppDbContext context, JwtService jwtService)
//    {
//        _context = context;
//        _jwtService = jwtService;
//    }

//    // 🔐 REGISTER
//    [HttpPost("register")]
//    public async Task<IActionResult> Register(RegisterDTO dto)
//    {
//        if (await _context.Users.AnyAsync(x => x.Email == dto.Email))
//            return BadRequest("Email already exists");

//        var user = new User
//        {
//            Name = dto.Name,
//            Email = dto.Email,
//            PasswordHash = HashPassword(dto.Password),
//            Role = "User"
//        };

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();

//        return Ok("User registered successfully");
//    }

//    // 🔐 LOGIN
//    [HttpPost("login")]
//    public async Task<IActionResult> Login(loginDto dto)
//    {
//        var user = await _context.Users
//            .FirstOrDefaultAsync(x => x.Email == dto.Email);

//        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
//            return Unauthorized("Invalid credentials");

//        var token = _jwtService.GenerateToken(user);

//        return Ok(new
//        {
//            token,
//            user.Id,
//            user.Name,
//            user.Email,
//            user.Role
//        });
//    }

//    // 🔒 Password Hashing
//    private string HashPassword(string password)
//    {
//        using var sha256 = SHA256.Create();
//        var bytes = Encoding.UTF8.GetBytes(password);
//        var hash = sha256.ComputeHash(bytes);
//        return Convert.ToBase64String(hash);
//    }

//    private bool VerifyPassword(string password, string storedHash)
//    {
//        return HashPassword(password) == storedHash;
//    }
//}
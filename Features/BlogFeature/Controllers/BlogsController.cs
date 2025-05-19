using BlogAppApi.Core;
using BlogAppApi.Features.BlogFeature.Dtos;
using BlogAppApi.Features.BlogFeature.Models;
using BlogAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApi.Features.BlogFeature.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BlogsController(ApplicationDbContext context,UserManager<AppUser> userManager) : AppController(userManager)
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await _context.Blogs
            .Include(b => b.Posts)
            .ToListAsync();

        return Ok(blogs.Select(BlogDto.FromBlog));
    }

    [HttpPost]
    public async Task<IActionResult> AddBlog([FromBody] BlogDto dto)
    {
        var blog = Blog.FromDto(dto);

        await _context.Blogs.AddAsync(blog);

        await _context.SaveChangesAsync();

        return Ok(blog);
    }
}
﻿using BlogAppApi.Core;
using BlogAppApi.Features.BlogFeature.Dtos;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.BlogFeature.Models;

public class Blog : BaseModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Title { get; set; }

    [MaxLength(20)]
    public BlogStatus Status { get; set; }

    public ICollection<Post> Posts { get; set; } = [];

    // FromDto method
    public static Blog FromDto(BlogDto blogDto) => new() { Title = blogDto.Title };
}

public enum BlogStatus
{
    Draft,
    Published,
    Archived
}
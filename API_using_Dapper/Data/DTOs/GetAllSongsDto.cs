﻿using System.ComponentModel.DataAnnotations;

namespace API_with_EntityFramework.Data.DTOs
{
    public class GetAllSongsDto
    {
        [Required(ErrorMessage = "Page number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "Page size is required.")]
        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int PageSize { get; set; }
    }
}

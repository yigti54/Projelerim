using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Dtos
{
    // Görev verisini döndürmek için kullanılacak ana DTO
    public class TaskDto : IDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTime? DueDate { get; set; }
    }

    // Yeni bir görev oluşturmak için kullanılacak DTO
    public class TaskCreateDto : IDto
    {
        [Required]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTime? DueDate { get; set; }
    }

    // Mevcut bir görevi güncellemek için kullanılacak DTO
    public class TaskUpdateDto : IDto
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTime? DueDate { get; set; }
    }
}
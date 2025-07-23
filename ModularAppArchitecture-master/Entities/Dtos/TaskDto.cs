using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Dtos
{
    public class AddTaskDto : IDto
    {
        [JsonPropertyName("Title")]
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [JsonPropertyName("Description")]
        [StringLength(1000)]
        public string Description { get; set; }

        [JsonPropertyName("DueDate")]
        [Required]
        public DateTime DueDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SportsStore.BLL.DTO
{
    public class ImageDto
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string Name { get; set; }

        public string ContentType { get; set; }
        [JsonIgnore]
        public string Base64 { private get; set; }
        public string ImageUrl => $"data:{ContentType};base64,{Base64}";
    }
}
using System.ComponentModel.DataAnnotations;

namespace SportsStore.BLL.DTO
{
    public class ImageDto
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string Name { get; set; }

        public string ContentType { get; set; }
        public string Base64 { private get; set; }
        public string ImageUrl => $"data:{ContentType};base64,{Base64}";
    }
}
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Api.Presentations
{
    public class PresentationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

        [Required]
        public bool HasStarted { get; set; }

        [Required]
        public int NumberOfSlides { get; set; }

        [Required]
        public int CurrentSlideIndex { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using FaqBuilder.Helpers;

namespace FaqBuilder.ViewModels
{
    public class PlatformViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Platform Name")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
    }
}
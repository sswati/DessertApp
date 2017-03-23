using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DessertApp.Models
{
    public class Dessert
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Title for your recipe")]
        [StringLength(100, MinimumLength = 3)]

        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a dietary requirement")]
        [StringLength(400, MinimumLength = 1)]
        public string Dietary { get; set; }

        [Required(ErrorMessage = "Please enter a list of ingredients")]

        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Please enter the cooking time in minutes")]
        [Display(Name = "Cooking Time")]
        [Range(0, 300)]
        public int CookTime { get; set; }

        [Required(ErrorMessage = "Please enter the preparation time in minutes")]
        [Display(Name = "Preparation Time")]
        [Range(0, 60)]
        public int PrepTime { get; set; }

        [Required(ErrorMessage = "Please enter a recipe")]

        [Display(Name = "Recipe")]
        [DataType(DataType.MultilineText)]
        public string RecipeMethod { get; set; }

        [Required(ErrorMessage = "Please enter the number of servings")]

        [Display(Name = "Serves")]
        public int Servings { get; set; }

        [Display(Name = "Image")]
        public string DessertArtUrl { get; set; }

        [Display(Name = "Likes")]
        public int Like { get; set; }
        [Display(Name = "Dislikes")]
        public int Dislikes { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2)]
        public string User { get; set; }

    }
}
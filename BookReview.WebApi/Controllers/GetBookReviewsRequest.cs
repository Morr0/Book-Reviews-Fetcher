using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReview.WebApi.Controllers
{
    public class GetBookReviewsRequest : IValidatableObject
    {
        [Required] public string Topic { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool isMultiWord = Topic.Split().Length > 1;
            if (isMultiWord) yield return new ValidationResult("Please only enter one word", 
                new[] {nameof(Topic)});
        }
    }
}
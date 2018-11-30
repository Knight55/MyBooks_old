using System.ComponentModel.DataAnnotations;

namespace MyBooks.Api.Dtos
{
    public class Rating
    {
        public int Id { get; set; }

        /// <summary>
        /// The value of the rating. Must be between 1 and 5.
        /// </summary>
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int Value { get; set; }
    }
}
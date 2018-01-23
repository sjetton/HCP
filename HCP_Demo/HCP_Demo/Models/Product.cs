using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCP_Demo.Models
{
    /// <summary>
    /// Product data class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Unique ISBN number.
        /// </summary>
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        /// <summary>
        /// Product title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Product list price.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "List Price")]
        public decimal List_Price { get; set; }

        /// <summary>
        /// Product release date.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Collection of favorites.
        /// </summary>
        public ICollection<Favorite> Favorites { get; set; }
    }
}
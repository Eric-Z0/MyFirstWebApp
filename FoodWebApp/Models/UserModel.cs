using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodWebApp.Models
{
    public class UserModel
    {
        //[Display(Name ="User ID")]
        //[Range(1000, 9999)]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "User Name DA")]    // For front-end display
        [BsonElement("Name")]               // For JSON data attribute (or key)
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10)]
        [BsonElement("PWD")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [BsonElement("Email")]
        [Display(Name = "Email Address DA")]
        public string EmailAddress { get; set; }
    }
}
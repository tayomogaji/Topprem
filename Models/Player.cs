//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Player
    {
        public int Id { get; set; }
        public string Img1 { get; set; }
        [Required(ErrorMessage = "Please enter the players name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the players age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter the players nationality")]
        public string Nation { get; set; }
        [Required(ErrorMessage = "Please enter the players current football club")]
        public string Team { get; set; }
        [Required(ErrorMessage = "Please enter the players common field position")]
        [StringLength(4, ErrorMessage = "This entry must not exceed more than 4 characters")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please enter the players number of appearances")]
        public int Appearances { get; set; }
        public string Img2 { get; set; }
        [Required(ErrorMessage = "Please write something about the player")]
        public string Bio { get; set; }
    }
}

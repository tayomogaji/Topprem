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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nation { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public int Appearances { get; set; }
        public string Img2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
        public string Video { get; set; }
    }
}

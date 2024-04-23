using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace TH69LS_HFT_2023241.Models
{
    public class Cat_Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OID { get; set; }
        [StringLength(50)]
        [Required]
        public string Owner_Name { get; set; }

        //[Range(20,99)]
        public int Owner_Age { get; set; }
        [JsonIgnore]
        public bool Is_Married { get; set; }
        [JsonIgnore]
        public string Nationality { get; set; }



        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Cat> Cats { get; set; }

        public Cat_Owner()
        {
            Cats = new HashSet<Cat>();
        }


    }
}

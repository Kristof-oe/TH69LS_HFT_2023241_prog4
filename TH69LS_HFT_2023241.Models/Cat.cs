using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace TH69LS_HFT_2023241.Models
{
    public class Cat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }
        [StringLength(50)]
        public string Breed {get; set; }

        [StringLength(50)]
        [Required]
        public string Cat_Name { get; set; }
        public bool Is_Mixed { get; set; }


        [NotMapped]
        public virtual Cat_Owner Cat_Owner { get; set; }
        [ForeignKey(nameof(Cat_Owner))]
        [NotMapped]
        public int OID { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Cat_Sitter> Cat_Sitter { get; set; }
        public Cat()
        {
              Cat_Sitter=new HashSet<Cat_Sitter>();
        }



    }
}

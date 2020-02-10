using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class AspNetUserLogins
    {
        [Key]
        [MaxLength(128)]
        public string LoginProvider { get; set; }

        [MaxLength(128)]
        public string ProviderKey { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AspNetUsers AspNetUsers { get; set; }
    }
}

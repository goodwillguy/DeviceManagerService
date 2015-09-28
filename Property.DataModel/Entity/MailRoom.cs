using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Property.DataModel.Entity
{
    [Table("MailRoom")]
    public class MailRoom
    {
        [Key]
        public Guid MailRoomId { get; set; }

        public String MailRoomCode { get; set; }

    }
}

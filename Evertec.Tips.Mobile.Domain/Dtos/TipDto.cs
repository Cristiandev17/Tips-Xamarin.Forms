using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Domain.Dtos
{
    public class TipDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime UpdateDate { get; set; }

        public int AuthorId { get; set; }
    }
}

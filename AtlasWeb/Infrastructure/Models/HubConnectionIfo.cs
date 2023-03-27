using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class HubConnectionInfo
    {
        public string ConnectionId { get; set; }

        public string userId
        {
            get;
            set;
        }
        public string userName
        {
            get;
            set;
        }
    }
}

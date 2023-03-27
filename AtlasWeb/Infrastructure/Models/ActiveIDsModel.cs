using System;

namespace Infrastructure.Models
{
    public class ActiveIDsModel
    {
        public Guid? EpisodeActionId { get; set; }
        public Guid? EpisodeId { get; set; }
        public Guid? PatientId { get; set; }
    }
}

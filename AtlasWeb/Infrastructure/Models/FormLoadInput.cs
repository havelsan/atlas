using System;

namespace Infrastructure.Models
{
    public class FormLoadInput
    {
        public Guid? Id { get; set; }
        public ActiveIDsModel Model { get; set; }
    }
}

using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TestObject
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public int? Telephone { get; set; }
        public string Address { get; set; }
        public Guid? CityRef { get; set; }
    }
}
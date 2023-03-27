using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace Core.Models
{
    public class EpisodeActionDisplayFormViewModel
    {
        public string ObjectID;
        public string ObjectDefName;
        public string FormDefID;
        public string InputParam;

    }
    public class ActiveInfoDVO
    {
        public Guid EpisodeActionObjectID;
        public Guid EpisodeObjectID;
        public Guid PatientObjectID;
    }
}
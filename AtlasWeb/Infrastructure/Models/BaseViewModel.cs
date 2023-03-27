using System;
using System.Collections.Generic;
using TTDefinitionManagement;
using TTInstanceManagement;

namespace Infrastructure.Models
{
    public class BaseViewModel
    {
        public bool ReadOnly { get; set; }
        public List<string> ReadOnlyFields { get; set; }
        public IList<TTObjectStateTransitionDef> OutgoingTransitions { get; set; }
        public IList<TTReportDef> CurrentStateReports { get; set; }
        public IList<TTObject> UpdatedObjects { get; set; }
        public IDictionary<string, object> ListDefDisplayExpressions { get; set; } = new Dictionary<string, object>();

        public ActiveIDsModel ActiveIDsModel { get; set; }

        public Guid? GetSelectedEpisodeActionID()
        {
            return ActiveIDsModel?.EpisodeActionId;
        }

        public Guid? GetSelectedEpisodeID()
        {
            return ActiveIDsModel?.EpisodeId;
        }

        public Guid? GetSelectedPatientID()
        {
            return ActiveIDsModel?.PatientId;
        }

    }
}
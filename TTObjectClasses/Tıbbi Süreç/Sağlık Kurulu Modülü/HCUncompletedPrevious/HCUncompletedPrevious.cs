
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class HCUncompletedPrevious : TTObject
    {
        
                    
#region Methods
        [Serializable]
        public class HCUPDetail
        {
            public string reasonForExamination;
            public string currentState;
            public List<HCUncompletedPrevious.HCUPExamination> examinations;
        }
        
        [Serializable]
        public class HCUPExamination
        {
            public string masterResource;
            public string currentState;
            public string offerOfDecision;
            public string report;
            public string reportDate;
            public List<string> diagnosis;
            public List<string> matterSliceAnectodes;
        }
        
        /*
        public HCUncompletedPrevious.HCUPDetail RunGetHCUPDetails()
        {
            HCUncompletedPrevious.HCUPDetail HCUPDetail = new HCUncompletedPrevious.HCUPDetail();
            HCUPDetail = HCUncompletedPrevious.RemoteMethods.GetHCUPDetail(Site.ObjectID, HCObjectID, HealthCommittee.Episode.Patient.ObjectID, EpisodeHospitalProtocolNo, HCActionID);
            return HCUPDetail;
        }
        */
        
#endregion Methods

    }
}
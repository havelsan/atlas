
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
    public  partial class PsychologyTest : SubActionProcedure
    {

        /*public override ResUser GetPerformanceDoctor()
        {
            if (this.EpisodeAction is PsychologicExamination)
                return ((PsychologicExamination)this.EpisodeAction).PsychologyBasedObjects[0].RequestDoctor;
            else if(this.RequestedByUser.TakesPerformanceScore == true)
                return this.RequestedByUser;
            return null;
        }

        public override bool IsPerformanceDoctorChanged()
        {

            if (this.EpisodeAction is PsychologicExamination)
                return ((PsychologicExamination)this.EpisodeAction).PsychologyBasedObjects[0].HasMemberChanged("RequestDoctor");
            else if (this.RequestedByUser!= null && this.RequestedByUser.TakesPerformanceScore == true)
                return this.HasMemberChanged("RequestedByUser"); 
            return false;
          
        }*/

        public override void SetPerformedDate()
        {
            if(PerformedDate == null)
                PerformedDate = Common.RecTime();
        }
        

        
    }
}
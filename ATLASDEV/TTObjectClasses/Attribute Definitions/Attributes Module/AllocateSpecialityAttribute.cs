
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
    public partial class AllocateSpecialityAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            Allocation allocation = new Allocation(ObjectContext);
            allocation.Episode=Interface.GetEpisode();
            allocation.EpisodeAction=Interface.GetMyEpisodeAction();
            allocation.SubActionProcedure=Interface.GetMySubActionProcedure();
            allocation.Speciality=Interface.GetProcedureSpeciality();
            allocation.CurrentStateDefID=Allocation.States.Allocated;
            allocation.AllocateDate = Convert.ToDateTime(Common.RecTime());
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
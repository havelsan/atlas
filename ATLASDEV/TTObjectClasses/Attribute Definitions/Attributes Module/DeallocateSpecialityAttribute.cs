
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
    public partial class DeallocateSpecialityAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            IList allocationList;
            if(Interface.GetMySubActionProcedure()==null && Interface.GetProcedureSpeciality()==null)
            {
                allocationList=Allocation.GetByStateEpisodeActionAndNullSpeciality(ObjectContext,Convert.ToString(Allocation.States.Allocated),Interface.GetEpisode().ObjectID.ToString(),Interface.GetMyEpisodeAction().ObjectID.ToString());
            }
            else if (Interface.GetMySubActionProcedure()==null)
            {
                allocationList=Allocation.GetByAllocatePropertiesExceptSubActionProcedure(ObjectContext,Convert.ToString(Allocation.States.Allocated),Interface.GetEpisode().ObjectID.ToString(),Interface.GetMyEpisodeAction().ObjectID.ToString(),Interface.GetProcedureSpeciality().ObjectID.ToString());
            }
            else if (Interface.GetProcedureSpeciality()==null)
            {
                allocationList=Allocation.GetByAllocatePropertiesWithNullSpeciality(ObjectContext,Convert.ToString(Allocation.States.Allocated),Interface.GetEpisode().ObjectID.ToString(),Interface.GetMyEpisodeAction().ObjectID.ToString(),Interface.GetMySubActionProcedure().ObjectID.ToString());
            }
            else
            {
                allocationList=Allocation.GetByAllocateProperties(ObjectContext,Convert.ToString(Allocation.States.Allocated),Interface.GetEpisode().ObjectID.ToString(),Interface.GetMyEpisodeAction().ObjectID.ToString(),Interface.GetProcedureSpeciality().ObjectID.ToString(),Interface.GetMySubActionProcedure().ObjectID.ToString());
            }
            foreach (Allocation allocation in allocationList)
            {
                if (Interface.GetMySubActionProcedure() != null)
                {
                    if (allocation.SubActionProcedure.ObjectID == Interface.GetMySubActionProcedure().ObjectID)
                    {
                        allocation.CurrentStateDefID = Allocation.States.Deallocated;
                        allocation.DeallocateDate = Common.RecTime();
                    }
                }
                else
                {
                    allocation.CurrentStateDefID = Allocation.States.Deallocated;
                    allocation.DeallocateDate = Common.RecTime();
                }
               
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
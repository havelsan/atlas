
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
    public  partial class BaseDentalEpisodeAction : PhysicianApplication
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

#region Methods
        /// <summary>
        /// kullanici Doktor ise işlemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if(CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if(ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    IList userResources = UserResource.GetByUserAndResource(ObjectContext,Common.CurrentResource.ObjectID,MasterResource.ObjectID);
                    if(userResources.Count>0)
                        ProcedureDoctor = Common.CurrentResource;
                }
            }
        }
        
#endregion Methods

    }
}
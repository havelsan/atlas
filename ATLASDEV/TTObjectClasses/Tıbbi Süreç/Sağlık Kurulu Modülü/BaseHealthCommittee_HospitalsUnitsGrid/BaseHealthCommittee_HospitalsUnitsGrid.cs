
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
    public  partial class BaseHealthCommittee_HospitalsUnitsGrid : HospitalsUnitsGrid
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            //Heryerde zorunlu olmadığından kaldırıldı.
//            if(this.Hospital== null || this.Unit== null){
//                
//                throw new TTException("Birim/XXXXXX boş olamaz.");
//                
//            }

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            //Heryerde zorunlu olmadığından kaldırıldı.
//            if(this.Hospital== null || this.Unit== null){
//                
//                throw new TTException("Birim/XXXXXX boş olamaz.");
//                
//            }

#endregion PreUpdate
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if(((ITTObject)this).IsNew)
            {
                Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
                ResHospital hospital = (ResHospital)ObjectContext.GetObject(hospID, typeof(ResHospital));
               // this.Hospital = hospital;
            }
        }
        
#endregion Methods

    }
}
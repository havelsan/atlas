
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
    public  partial class HealthCommittee_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public partial class GetMatterSliceAnectodeByParentObjectID_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
     

#endregion PreInsert
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();

#endregion PreDelete
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
           

        }

        public HealthCommittee_MatterSliceAnectodeGrid PrepareForRemoteMethod(bool withNewObjectID)
        {
            // Çağırılan yerde yeni Save Point Konulup sonra savepointe dönülmeli
            if(withNewObjectID)
            {
                HealthCommittee_MatterSliceAnectodeGrid sendingMatterSliceAnectodeGrid = (HealthCommittee_MatterSliceAnectodeGrid)Clone();
                //Diğer tarafda bilinmeyen nesne içeren tüm relationlar temizleniyor...
     
                return sendingMatterSliceAnectodeGrid;
            }
            else
            {
                return this;
            }
        }
        
#endregion Methods

    }
}
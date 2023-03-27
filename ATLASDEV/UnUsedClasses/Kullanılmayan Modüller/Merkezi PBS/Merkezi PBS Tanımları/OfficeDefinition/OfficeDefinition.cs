
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
    public  partial class OfficeDefinition : TerminologyManagerDef, ITMK
    {
        public partial class GetOfficeDefinitionList_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetOfficeDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            
            base.PreUpdate();

            if (GetOwnerSite() == null)
                throw new Exception(SystemMessage.GetMessage(575));
            
           /*  ITTObject iTTObject = (ITTObject)this;
            if (iTTObject.IsNew == false)
            {
                OfficeDefinition originalOfficeDefinition = iTTObject.Original as OfficeDefinition;
                if (originalOfficeDefinition != null)
                {
                    if (originalOfficeDefinition.UnitId != this.UnitId)
                    {
                        IList mainToeDefinitions = this.ObjectContext.QueryObjects<MainToeDefinition>("UNITID = " + ConnectionManager.GuidToString(originalOfficeDefinition.UnitId.ObjectID));
                        if(mainToeDefinitions.Count>0)
                            
                         
                    }
                }
            }*/

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
        /*     ITTObject iTTObject = (ITTObject)this;
            if (iTTObject.IsNew == false)
            {
                OfficeDefinition originalOfficeDefinition = iTTObject.Original as OfficeDefinition;
                if (originalOfficeDefinition != null)
                {
                    if (originalOfficeDefinition.UnitId != this.UnitId)
                    {
                        IList mainToeDefinitions = this.ObjectContext.QueryObjects<MainToeDefinition>("UNITID = " + ConnectionManager.GuidToString(originalOfficeDefinition.UnitId.ObjectID));
                        foreach (MainToeDefinition mainToeDefinition in mainToeDefinitions)
                          mainToeDefinition.UnitId = this.UnitId;
                         
                    }
                }
            }*/
#endregion PostUpdate
        }

#region Methods
        public override bool IsActiveLocal()
        {
            return false;
        }
        #region ITMK Members

        public ISites GetOwnerSite()
        {
            return (ISites)UnitId.UnitEnclosureID.MilitaryUnit.Site; 
        }

        #endregion
        
#endregion Methods

    }
}
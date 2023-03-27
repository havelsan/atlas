
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
    public  partial class LineToeDefinition : TerminologyManagerDef, ITMK
    {
        public partial class OLAP_GetLineToeMissionDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class GetLineToeDefinitionList_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            


            base.PreUpdate();
            if (GetOwnerSite() == null)
                throw new Exception(SystemMessage.GetMessage(575));


#endregion PreUpdate
        }

#region Methods
        public override bool IsActiveLocal()
        {
            return false;
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();

          /*  ITTObject iTTobject = (ITTObject)this;

            if (!iTTobject.IsNew && iTTobject.IsImported == false)
            {
                if (this.SectionId != null && this.SectionId.OfficeId != null)
                {
                    this.mainToeDefinition = this.SectionId.OfficeId.UnitId.MAINTOECODE + " " + this.SectionId.OfficeId.UnitId.NAME;
                    this.paragraphToeDefinition = this.SectionId.PARAGRAPHTOECODE + " " + this.SectionId.NAME;

                }
            }*/
        }



        #region ITMK Members

        public ISites GetOwnerSite()
        {
            return (ISites)SectionId.OfficeId.UnitId.UnitEnclosureID.MilitaryUnit.Site; 
        }

        #endregion
        
#endregion Methods

    }
}
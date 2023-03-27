
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
    public  partial class SectionDefinition : TerminologyManagerDef, ITMK
    {
        public partial class GetSectionDefinitionList_Class : TTReportNqlObject 
        {
        }

        public partial class GetSectionDefinitionListDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetSectionDefinition_Class : TTReportNqlObject 
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

        protected override void PostUpdate()
        {
#region PostUpdate
            
   
            base.PostUpdate();

         /*   ITTObject iTTObject = (ITTObject)this;
            if (iTTObject.IsNew == false)
            {
                SectionDefinition originalSectionDefinition = iTTObject.Original as SectionDefinition;
                if (originalSectionDefinition != null)
                {
                    if (originalSectionDefinition.OfficeId != this.OfficeId)
                    {
                        IList paragraphToeDefinitions = this.ObjectContext.QueryObjects<ParagraphToeDefinition>("SECTIONID = " + ConnectionManager.GuidToString(originalSectionDefinition.ObjectID));
                        foreach (ParagraphToeDefinition paragraphToeDefinition in paragraphToeDefinitions)
                            paragraphToeDefinition.OfficeId = this.OfficeId;
                    }
                    
                    if (originalSectionDefinition.UnitId != this.UnitId)
                    {
                        IList paragraphToeDefinitions = this.ObjectContext.QueryObjects<ParagraphToeDefinition>("SECTIONID = " + ConnectionManager.GuidToString(originalSectionDefinition.ObjectID));
                        foreach (ParagraphToeDefinition paragraphToeDefinition in paragraphToeDefinitions)
                            paragraphToeDefinition.OfficeId = this.OfficeId;
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
            return (ISites)OfficeId.UnitId.UnitEnclosureID.MilitaryUnit.Site; 
        }

        #endregion
        
#endregion Methods

    }
}
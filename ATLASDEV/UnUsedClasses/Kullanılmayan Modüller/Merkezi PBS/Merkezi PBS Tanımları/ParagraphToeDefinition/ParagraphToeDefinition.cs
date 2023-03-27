
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
    public  partial class ParagraphToeDefinition : TerminologyManagerDef, ITMK
    {
        public partial class GetParagraphToeDefinitionList_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetParagraphToeDefinition_Class : TTReportNqlObject 
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
          

  ITTObject iTTObject = (ITTObject)this;
            if (iTTObject.IsNew == false)
            {
                ParagraphToeDefinition originalParagraphToeDefinition = iTTObject.Original as ParagraphToeDefinition;
                if (originalParagraphToeDefinition != null)
                {
                    if (originalParagraphToeDefinition.SectionId != SectionId)
                    {
                        IList lineToeDefinitions = ObjectContext.QueryObjects<LineToeDefinition>("SECTIONID = " + ConnectionManager.GuidToString(originalParagraphToeDefinition.SectionId.ObjectID));
                        foreach (LineToeDefinition lineToeDefinition in lineToeDefinitions)
                          lineToeDefinition.SectionId = SectionId;
                         
                    }
                }
            }
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
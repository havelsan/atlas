
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Muayene Muhtırası Tanzim
    /// </summary>
    public partial class InspectionMemorandumPreparingForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region InspectionMemorandumPreparingForm_PreScript
    base.PreScript();
            
            if (ExaminationCommision.Rows.Count > 0)
                return;
            
            int type = Convert.ToInt32(CommisionTypeEnum.PurchaseExaminationCommision);
            
            IList commision = CommisionDefinition.GetCommisionByType(_PurchaseExamination.ObjectContext, type);
            if(commision.Count > 0)
            {
                CommisionDefinition cd = (CommisionDefinition)commision[0];
                foreach(CommisionDefinitionMember cdm in cd.CommisionDefinitionMembers)
                {
                    ExaminationCommisionMember pm = new ExaminationCommisionMember(_PurchaseExamination.ObjectContext);
                    pm.PurchaseExamination = _PurchaseExamination;
                    pm.PrimeBackup = true;
                    pm.ResUser = cdm.ResUser;
                }
            }
#endregion InspectionMemorandumPreparingForm_PreScript

            }
                }
}
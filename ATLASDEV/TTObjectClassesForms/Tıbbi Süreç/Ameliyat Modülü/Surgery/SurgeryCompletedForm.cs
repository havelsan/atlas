
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
    /// Tamamlandı
    /// </summary>
    public partial class SurgeryCompletedForm : EpisodeActionForm
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
#region SurgeryCompletedForm_PreScript
    base.PreScript();
            ArrangeToothColumnsOfSurgeryGrid();
#endregion SurgeryCompletedForm_PreScript

            }
            
#region SurgeryCompletedForm_Methods
        // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir, Diş ameliyatı ise Diş Numarası doldurulur
        public void ArrangeToothColumnsOfSurgeryGrid()
        {
            foreach (ITTGridRow row in GridMainSurgeryProcedures.Rows)
            {
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)row.TTObject;
                if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                {
                    if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
                    {
                        string toothNumberNames = string.Empty;
                        string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
                        foreach (string toothNumber in toothNumbers)
                        {
                            TTDataDictionary.EnumValueDef enumValueDef = Common.GetEnumValueDefOfEnumValueV2("ToothNumberEnum", Int32.Parse(toothNumber));
                            toothNumberNames += enumValueDef.DisplayText + ",";
                        }

                        if (!string.IsNullOrEmpty(toothNumberNames))
                            row.Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
                    }
                }
            }
        }
        
#endregion SurgeryCompletedForm_Methods
    }
}
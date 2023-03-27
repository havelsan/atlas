
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
    /// MSB İlaç Üretim İşlemi - Serbest Bırakma
    /// </summary>
    public partial class MilitaryDrugProductionProcedureReleasedForm : MilitaryDrugProductionBaseForm
    {
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MilitaryDrugProductionProcedureReleasedForm_PostScript
    if (transDef != null)
                if (transDef.ToStateDefID == MilitaryDrugProductionProcedure.States.Completed)
                {
                    foreach (DrugProductionTest drugProductionTest in this._MilitaryDrugProductionProcedure.DrugProductionTests)
                        if (drugProductionTest.CurrentStateDefID == DrugProductionTest.States.Request || drugProductionTest.CurrentStateDefID == DrugProductionTest.States.QualityControl)
                            throw new TTException("Testler tamamlanmadan bu aşamayı geçemezsiniz.");
                }
#endregion MilitaryDrugProductionProcedureReleasedForm_PostScript

            }
                }
}
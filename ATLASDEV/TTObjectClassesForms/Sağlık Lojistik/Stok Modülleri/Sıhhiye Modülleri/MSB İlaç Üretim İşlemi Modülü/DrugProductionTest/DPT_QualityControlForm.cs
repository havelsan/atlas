
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
    /// Kalite Kontrol
    /// </summary>
    public partial class DPT_QualityControlForm : TTForm
    {
        override protected void BindControlEvents()
        {
            TestsGrid.CellValueChanged += new TTGridCellEventDelegate(TestsGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TestsGrid.CellValueChanged -= new TTGridCellEventDelegate(TestsGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void TestsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DPT_QualityControlForm_TestsGrid_CellValueChanged
   if(TestsGrid.CurrentCell == null)
                return;
            
            if(TestsGrid.CurrentCell.OwningColumn.Name == "TestDef")
            {
                DrugProductionTestDetail dptd = (DrugProductionTestDetail)TestsGrid.CurrentCell.OwningRow.TTObject;
                dptd.RequestedBy = (ResUser)Common.CurrentUser.UserObject;
            }
#endregion DPT_QualityControlForm_TestsGrid_CellValueChanged
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DPT_QualityControlForm_PostScript
    base.PostScript(transDef);
            
            foreach(DrugProductionTestDetail dptd in _DrugProductionTest.DrugProductionTestDetails)
            {
                if(dptd.Analyser == null)
                {
                    throw new TTUtils.TTException("'Analizi Yapan' sütunu boş geçilemez");
                    //return;
                }
            }
#endregion DPT_QualityControlForm_PostScript

            }
                }
}
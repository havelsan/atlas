
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
    /// Lojistik İnceleme
    /// </summary>
    public partial class PurchaseItemAnalysesFormIn : TTForm
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
#region PurchaseItemAnalysesFormIn_PreScript
    base.PreScript();
            
//            if (ApproveDetailsGrid.Rows.Count == 0)
//            {
//                ApproveDetailsGrid.Rows.Add();
//                ApproveDetailsGrid.Rows.Add();
//                ApproveDetailsGrid.Rows.Add();
//                ApproveDetailsGrid.Rows.Add();
//                
//                ApproveDetailsGrid.Rows[0].Cells[0].Value = 0;
//                ApproveDetailsGrid.Rows[1].Cells[0].Value = 1;
//                ApproveDetailsGrid.Rows[2].Cells[0].Value = 2;
//                ApproveDetailsGrid.Rows[3].Cells[0].Value = 3;
//            }
#endregion PurchaseItemAnalysesFormIn_PreScript

            }
                }
}
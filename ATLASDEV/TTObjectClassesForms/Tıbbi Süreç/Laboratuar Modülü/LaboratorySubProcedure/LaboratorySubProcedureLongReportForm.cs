
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
    public partial class LaboratorySubProcedureLongReportForm : TTForm
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
#region LaboratorySubProcedureLongReportForm_PreScript
    base.PreScript();
            //TODO:pnlButtons!
            //for (int i = 0; i < (this.pnlButtons.Controls.Count); i++)
            //{
            //    if (this.pnlButtons.Controls[i].Name.ToString() == "cmdOK")
            //    {
            //        this.pnlButtons.Controls[i].Visible = false;
            //    }
            //}
#endregion LaboratorySubProcedureLongReportForm_PreScript

            }
                }
}
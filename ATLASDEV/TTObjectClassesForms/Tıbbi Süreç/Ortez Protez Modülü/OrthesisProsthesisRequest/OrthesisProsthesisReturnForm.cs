
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisReturnForm : EpisodeActionForm
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
#region OrthesisProsthesisReturnForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            if (this._OrthesisProsthesisRequest.ReturnDescriptions.Count > 0)
            {
                this.ReturnDescriptionsLabel.Visible = true;
                this.ReturnDescriptionGrid.Visible = true;
            }
            
            foreach(ITTGridRow theRow in this.OrthesisProsthesisProcedures.Rows)
            {
                foreach(ITTGridCell theCell in theRow.Cells)
                {
                    theCell.ReadOnly = true;
                }
            }
#endregion OrthesisProsthesisReturnForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisReturnForm_PostScript
    base.PostScript(transDef);
            if (this.ProcedureDoctor.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisReturnForm_PostScript

            }
                }
}
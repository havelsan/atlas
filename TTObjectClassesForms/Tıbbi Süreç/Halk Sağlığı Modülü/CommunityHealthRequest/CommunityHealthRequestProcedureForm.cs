
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
    public partial class CommunityHealthRequestProcedureForm : ActionForm
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
#region CommunityHealthRequestProcedureForm_PreScript
    base.PreScript();
            
            
            foreach ( ITTGridRow  row in this.ProcedureGrid.Rows)
            {
                CommunityHealthProcedure procedure = (CommunityHealthProcedure)row.TTObject;

                if( procedure.Unit == null)
                    procedure.Unit = procedure.ProcedureObject.Unit;
            }
            ArrangeMeqAndMValInProceduresGrid();
#endregion CommunityHealthRequestProcedureForm_PreScript

            }
            
#region CommunityHealthRequestProcedureForm_Methods
        private void ArrangeMeqAndMValInProceduresGrid()
        {
            if(this._CommunityHealthRequest.CurrentStateDefID == CommunityHealthRequest.States.Completed)
            {
                var toplamMeq = this._CommunityHealthRequest.ToplamMeq;
                foreach ( ITTGridRow  row in this.ProcedureGrid.Rows)
                {                   
                    CommunityHealthProcedure procedure = (CommunityHealthProcedure)row.TTObject;
                    var meq = procedure.Meq;
                    row.Cells["Meq"].Value = Math.Round(Convert.ToDecimal(meq),3);
                    row.Cells["MVal"].Value = Math.Round(Convert.ToDecimal(100 * meq/toplamMeq),3);
                }
                
            }
            else
            {
                ((ITTGridColumn)ProcedureGrid.Columns["Meq"]).Visible = false;
                ((ITTGridColumn)ProcedureGrid.Columns["MVal"]).Visible = false;
            }
        }
        
#endregion CommunityHealthRequestProcedureForm_Methods
    }
}
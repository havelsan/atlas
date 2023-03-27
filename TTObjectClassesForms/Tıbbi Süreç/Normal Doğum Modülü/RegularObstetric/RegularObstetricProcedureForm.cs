
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridManipulations.CellContentClick += new TTGridCellEventDelegate(GridManipulations_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridManipulations.CellContentClick -= new TTGridCellEventDelegate(GridManipulations_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridManipulations_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region RegularObstetricProcedureForm_GridManipulations_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridManipulations.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            //         {

            //             RegularObstetricCokluOzelDurumForm codf = new RegularObstetricCokluOzelDurumForm();
            //             codf.ShowEdit(this.FindForm(), _RegularObstetric);
            //         }
            var a = 1;
#endregion RegularObstetricProcedureForm_GridManipulations_CellContentClick
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RegularObstetricProcedureForm_PostScript
    base.PostScript(transDef);
#endregion RegularObstetricProcedureForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RegularObstetricProcedureForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.ToStateDefID  == RegularObstetric.States.Completed ) {
                    foreach ( var Subactionprocedure in this._RegularObstetric.SubactionProcedures)
                    {
                        if ( Subactionprocedure.ProcedureDoctor == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessage(994));
                    }
                    this._EpisodeAction.CreateNewBirthReportRequest();
                }
            }
#endregion RegularObstetricProcedureForm_ClientSidePostScript

        }
    }
}
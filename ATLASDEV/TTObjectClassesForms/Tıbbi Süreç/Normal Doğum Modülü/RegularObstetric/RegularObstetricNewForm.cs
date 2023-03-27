
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
    public partial class RegularObstetricNewForm : EpisodeActionForm
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
            #region RegularObstetricNewForm_GridManipulations_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridManipulations.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            //         {

            //             RegularObstetricCokluOzelDurumForm codf = new RegularObstetricCokluOzelDurumForm();
            //             codf.ShowEdit(this.FindForm(), _RegularObstetric);
            //         }
            var a = 1;
#endregion RegularObstetricNewForm_GridManipulations_CellContentClick
        }

        protected override void PreScript()
        {
#region RegularObstetricNewForm_PreScript
    if(_RegularObstetric.Episode.Patient.Sex.ADI == "ERKEK")
                throw new TTUtils.TTException("Bu işlemi erkek hastalara başlatamazsınız.");
                
            base.PreScript();
            ManipulationProcedure  sp= new ManipulationProcedure(_RegularObstetric.ObjectContext);
            Guid regularObstetricGUID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("RegularObstetricProcedure","8de3b1a7-5779-4646-b882-0ee24fc407a4").Trim());
            sp.ProcedureObject = (ProcedureDefinition)_RegularObstetric.ObjectContext.GetObject( regularObstetricGUID, typeof(ProcedureDefinition)) ;
            this.SetProcedureDoctorAsCurrentResource();
            sp.ProcedureDepartment = (ResSection)_RegularObstetric.MasterResource;
            _RegularObstetric.RegularObstetricProcedures.Add(sp) ;
#endregion RegularObstetricNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RegularObstetricNewForm_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                //if(transDef.ToStateDefID==RegularObstetric.States.RegularObstetricProcedures)
                //{
                //    this._RegularObstetric.IsPatientApprovalFormGiven=this.GetIfPatientApprovalFormIsGiven(this._RegularObstetric.IsPatientApprovalFormGiven);
                //}
            }
#endregion RegularObstetricNewForm_PostScript

            }
                }
}
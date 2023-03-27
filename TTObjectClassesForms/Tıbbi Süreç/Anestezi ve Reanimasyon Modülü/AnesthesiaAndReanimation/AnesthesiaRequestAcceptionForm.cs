
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaRequestAcceptionForm : EpisodeActionForm
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
#region AnesthesiaRequestAcceptionForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            this.DropStateButton(AnesthesiaAndReanimation.States.Cancelled);
            if(this._AnesthesiaAndReanimation.CurrentStateDefID==AnesthesiaAndReanimation.States.RequestAcception)
            {
                if(this._AnesthesiaAndReanimation.MainSurgery==null)
                {
                    this.RequestedProcedure.Visible=true;
                    this.labelPlannedSurgeryDescription.Visible=false;
                    this.PlannedSurgeryDescription.Visible = false;
                    this.GridSurgeryProcedures.Visible=false;
                    this.DropStateButton(AnesthesiaAndReanimation.States.SurgeryAnestesia);
                }
                else
                {
                    this.RequestedProcedure.Visible=false;
                    this.labelPlannedSurgeryDescription.Visible=true;
                    this.PlannedSurgeryDescription.Visible = true;
                    this.GridSurgeryProcedures.Visible=true;
                    this.DropStateButton(AnesthesiaAndReanimation.States.AnesthesiaExpend);
                    if(this._AnesthesiaAndReanimation.IsSurgeryDelay())
                    {
                        InfoBox.Show(SystemMessage.GetMessage(208));
                         //InfoBox.Show("Ameliyat İşlemi Ertelenmiştir.");
                    }
                }
                
            }
#endregion AnesthesiaRequestAcceptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnesthesiaRequestAcceptionForm_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.ToStateDef.StateDefID == AnesthesiaAndReanimation.States.ReturnedToDoctor)
                {
                    //                    try {
                    StringEntryForm frm = new StringEntryForm();
                    this._BaseAction.ReasonOfReject= frm.ShowAndGetStringForm("İade Sebebi");

                    //                    } catch (Exception ex) {
                    //                        throw new Exception ("İadeden Vazgeçildi");
                    //                    }
                }
                else if(transDef.ToStateDefID==AnesthesiaAndReanimation.States.AnesthesiaExpend || transDef.ToStateDefID==AnesthesiaAndReanimation.States.SurgeryAnestesia)
                {
                    this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven= this.GetIfPatientApprovalFormIsGiven(this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven);
                }
            }
#endregion AnesthesiaRequestAcceptionForm_PostScript

            }
                }
}
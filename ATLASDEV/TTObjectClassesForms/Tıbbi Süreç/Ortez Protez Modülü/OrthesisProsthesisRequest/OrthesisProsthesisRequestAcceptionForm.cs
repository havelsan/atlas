
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
    public partial class OrthesisProsthesisRequestAcceptionForm : EpisodeActionForm
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
#region OrthesisProsthesisRequestAcceptionForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            // episodedaki tüm Protez isteklerini toplayıp totalDescription alanına atar

            //TODO: Burası geçici olarak kaldırıldı eski sistemden kopylandığı için, gerek görülmedi...YY
            //string totalDescription="";
            //foreach(OrthesisProsthesisRequest orthesisProsthesisRequest in this._OrthesisProsthesisRequest.Episode.OrthesisProsthesisRequests)
            //{
            //   totalDescription= totalDescription + " \n " + orthesisProsthesisRequest.Description;
            //}
            //if (totalDescription != "")
            //{
            //   this.TotalDescription.Text= "Ortez-Protez Raporu \n " + totalDescription;
            //}

            if (this._OrthesisProsthesisRequest.ReturnDescriptions.Count > 0)
            {
                this.ReturnDescriptionsLabel.Visible = true;
                this.ReturnDescriptionGrid.Visible = true;
            }
            
            //ikisi de Drop olsun diye bu da kaldırıldı
            //            foreach(OrthesisProsthesisProcedure procedure in this._OrthesisProsthesisRequest.OrthesisProsthesisProcedures)
            //            {
            //                OrtesisProsthesisDefinition pDef = procedure.ProcedureObject as OrtesisProsthesisDefinition;
            //                if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommittee)
            //                    this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist);
            //                else if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommitteeWithThreeSpecialist)
            //                    this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommittee);

            //                break;//tek bir procedure olmalı
            //            }
            
            if(string.IsNullOrEmpty(this._OrthesisProsthesisRequest.FinancialDepartmentNot))
            {
                this.NotesTab.TabPages.Remove(this.NoteFinance);
            }
            
            this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommittee);
            this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist);
            //Normalde ikisi de Drop olsun diye kladırıldı
            //            if(this._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.Count > 0 && !this._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[0].IsRequestReport.Value)
            //            {
            //                this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommittee);
            //                this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist);
            //            }
            var a = 1;
            #endregion OrthesisProsthesisRequestAcceptionForm_PreScript

        }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisRequestAcceptionForm_PostScript
    base.PostScript(transDef);
            
            
            if (this.ProcedureDoctor.SelectedObject == null)
                    throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisRequestAcceptionForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisRequestAcceptionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef != null)
            {
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestReturn) )
                {
                    this.AddReturnDescriptionInput(this._OrthesisProsthesisRequest);
                }
                
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
                {
                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
                }
                
            }
#endregion OrthesisProsthesisRequestAcceptionForm_ClientSidePostScript

        }

#region OrthesisProsthesisRequestAcceptionForm_Methods
        /* private void ReturnDescriptionInput()
        {
            StringEntryForm pReturnForm = new StringEntryForm();
            DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
            if(res == DialogResult.OK)
            {
                OrthesisProsthesis_ReturnDescriptionsGrid theGrid = null;
                theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._OrthesisProsthesisRequest.ObjectContext);
                theGrid.Description = pReturnForm.StringContent;
                theGrid.EntryDate = Common.RecTime();
                theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;
                
                this._OrthesisProsthesisRequest.ReturnDescriptions.Add(theGrid);
            }
        }*/
        
#endregion OrthesisProsthesisRequestAcceptionForm_Methods
    }
}
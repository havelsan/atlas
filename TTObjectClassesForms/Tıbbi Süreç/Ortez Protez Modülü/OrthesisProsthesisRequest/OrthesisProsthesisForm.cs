
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
    public partial class OrthesisProsthesisForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            OrthesisProsthesisProcedures.CellValueChanged += new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellValueChanged);
            OrthesisProsthesisProcedures.CellContentClick += new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrthesisProsthesisProcedures.CellValueChanged -= new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellValueChanged);
            OrthesisProsthesisProcedures.CellContentClick -= new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellContentClick);
            base.UnBindControlEvents();
        }

        private void OrthesisProsthesisProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region OrthesisProsthesisForm_OrthesisProsthesisProcedures_CellValueChanged
   ITTGridCell changedCell = OrthesisProsthesisProcedures.Rows[rowIndex].Cells[columnIndex];
            if (changedCell.OwningColumn.Name == AnesteziDrTescilNo.Name)
            {
                if(changedCell.Value != null)
                {
                    OrthesisProsthesisProcedure obj=(OrthesisProsthesisProcedure)changedCell.OwningRow.TTObject;
                    TTObjectContext context = _OrthesisProsthesisRequest.ObjectContext;
                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
                    obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
                }
                
                
            }
#endregion OrthesisProsthesisForm_OrthesisProsthesisProcedures_CellValueChanged
        }

        private void OrthesisProsthesisProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region OrthesisProsthesisForm_OrthesisProsthesisProcedures_CellContentClick
            //TODO:Showedit!
            //if ((((ITTGridCell)OrthesisProsthesisProcedures.CurrentCell).OwningColumn != null) && (((ITTGridCell)OrthesisProsthesisProcedures.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //{
            //    OrthesisProsthesisProcedure_CokluOzelDurumForm codf = new OrthesisProsthesisProcedure_CokluOzelDurumForm();
            //    OrthesisProsthesisProcedure inp = (OrthesisProsthesisProcedure)OrthesisProsthesisProcedures.CurrentCell.OwningRow.TTObject;
            //    codf.ShowEdit(this.FindForm(), inp);
            //}
            var a = 1;
            #endregion OrthesisProsthesisForm_OrthesisProsthesisProcedures_CellContentClick
        }

        protected override void PreScript()
        {
#region OrthesisProsthesisForm_PreScript
    base.PreScript();
            
            
            //if(string.IsNullOrEmpty(this._OrthesisProsthesisRequest.FinancialDepartmentNot))
            //{
            //    this.NotesTab.TabPages.Remove(this.NoteFinance);
            //}
            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.ControlApproval)
            {
                this.ChiefTechnicianNote.ReadOnly=false;
                this.TechnicianNote.ReadOnly=true;
            }

            this.SetProcedureDoctorAsCurrentResource();

            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterials.Columns["MMaterial"]);
            // episodedaki tüm Protez isteklerini toplayıp totalDescription alanına atar
            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.Procedure)
            {
                if(this._OrthesisProsthesisRequest.ProcessDate==null)
                {
                    this._OrthesisProsthesisRequest.ProcessDate=Common.RecTime();
                }
            }
            
            //if(_OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.Procedure.DoctorProcedure) // State kontrolüne gerek var mı? BB
            //{ 
                this.SetDirectPurchaseListFilter((ITTGridColumn)this.OPDirectPurchaseGrid.Columns["DPADetailFirmPriceOffer"]);

            //}

            //            else if (this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.RequestAcception)
            //            {
            //                //TODO: Burası geçici olarak kaldırıldı eski sistemden kopylandığı için, gerek görülmedi...YY
            //                //string totalDescription="";
            //                //foreach(OrthesisProsthesisRequest orthesisProsthesisRequest in this._OrthesisProsthesisRequest.Episode.OrthesisProsthesisRequests)
            //                //{
            //                //   totalDescription= totalDescription + " \n " + orthesisProsthesisRequest.Description;
            //                //}
            //                //if (totalDescription != "")
            //                //{
            //                //   this.TotalDescription.Text= "Ortez-Protez Raporu \n " + totalDescription;
            //                //}
            //
            //                if(this._OrthesisProsthesisRequest.ReturnDescriptions.Count > 0)
            //                {
            //                    this.ReturnDescriptionsLabel.Visible = true;
            //                    this.ReturnDescriptionGrid.Visible = true;
            //                }
            //
            //                foreach(OrthesisProsthesisProcedure procedure in this._OrthesisProsthesisRequest.OrthesisProsthesisProcedures)
            //                {
            //                    OrtesisProsthesisDefinition pDef = procedure.ProcedureObject as OrtesisProsthesisDefinition;
            //                    if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommittee)
            //                        this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist);
            //                    else if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommitteeWithThreeSpecialist)
            //                        this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommittee);
            //
            //                    break;//tek bir procedure olmalı
            //                }
            //            }
            var a = 1;
            #endregion OrthesisProsthesisForm_PreScript

        }
            
        protected override void ClientSidePreScript()
        {
#region OrthesisProsthesisForm_ClientSidePreScript
    base.ClientSidePreScript();
            this.DirectPurchaseMaterialByPatient();
#endregion OrthesisProsthesisForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisForm_PostScript
    base.PostScript(transDef);
            if (this.ProcedureDoctor.SelectedObject == null)
                    throw new Exception(SystemMessage.GetMessage(669));
            
            if(_OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach(SurgeryDirectPurchaseGrid sdg in _OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
                {
                    if(materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            if (_OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach (CodelessMaterialDirectPurchaseGrid cdg in _OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids)
                {
                    if(materials.Contains(cdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(cdg.DPADetailFirmPriceOffer);
                }
            }
            
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach(SurgeryDirectPurchaseGrid sdg in this._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
            {
                sdg.Material = (Material)this._OrthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
            
            foreach(CodelessMaterialDirectPurchaseGrid cdg in _OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids)
            {
                cdg.Material = (Material)_OrthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
            
            if(transDef != null)
            {
                /*if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestReturn) ||
                   transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.Procedure) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestAcception))
                {
                    this.ReturnDescriptionInput();
                }
                
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
                {
                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
                }*/

                OrthesisProsthesisRequest.MakingDirectPurchaseHasUsed(this._OrthesisProsthesisRequest);
                
                if (transDef.ToStateDefID == OrthesisProsthesisRequest.States.ControlApproval || transDef.ToStateDefID == OrthesisProsthesisRequest.States.DoctorApproval || transDef.ToStateDefID == OrthesisProsthesisRequest.States.Completed)
                {
                    if(transDef.ToStateDefID == OrthesisProsthesisRequest.States.Completed)
                    {
                        Guid savePointGuid = this._OrthesisProsthesisRequest.ObjectContext.BeginSavePoint();
                        try
                        {
                            OrthesisProsthesisRequest.CreateSubActionMatPricingDet(_OrthesisProsthesisRequest);
                            this._OrthesisProsthesisRequest.ObjectContext.Update();
                        }
                        catch(Exception ex)
                        {
                            if(this._OrthesisProsthesisRequest.ObjectContext.HasSavePoint(savePointGuid))
                                this._OrthesisProsthesisRequest.ObjectContext.RollbackSavePoint(savePointGuid);
                            throw ex;
                        }                        
                    }
                    else
                        OrthesisProsthesisRequest.CreateSubActionMatPricingDet(_OrthesisProsthesisRequest);
                }
                
            }
#endregion OrthesisProsthesisForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef != null)
            {
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestReturn) ||
                   transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.Procedure) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestAcception))
                {
                    this.AddReturnDescriptionInput(this._OrthesisProsthesisRequest);
                }
                
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
                {
                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
                }
            }
#endregion OrthesisProsthesisForm_ClientSidePostScript

        }

#region OrthesisProsthesisForm_Methods
        /*private void ReturnDescriptionInput()
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
        
#endregion OrthesisProsthesisForm_Methods
    }
}
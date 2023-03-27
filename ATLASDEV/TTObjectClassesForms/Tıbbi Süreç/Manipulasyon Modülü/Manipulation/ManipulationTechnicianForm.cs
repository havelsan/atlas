
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManipulationTechnicianForm : EpisodeActionForm
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
            #region ManipulationTechnicianForm_GridManipulations_CellContentClick
            //TODO ShowEdit!
            //if ((((ITTGridCell)GridManipulations.CurrentCell).OwningColumn != null) && (((ITTGridCell)GridManipulations.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //         {

            //             BaseSurAndManProcedure_CokluOzelDurumForm codf = new BaseSurAndManProcedure_CokluOzelDurumForm();
            //             BaseSurgeryAndManipulationProcedure inp = (BaseSurgeryAndManipulationProcedure)GridManipulations.CurrentCell.OwningRow.TTObject;

            //             codf.ShowEdit(this.FindForm(), inp);
            //         }
            var a = 1;
            #endregion ManipulationTechnicianForm_GridManipulations_CellContentClick
        }

        protected override void PreScript()
        {
#region ManipulationTechnicianForm_PreScript
    base.PreScript();

            _Manipulation.Technician = (ResUser)_Manipulation.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
            //            if(this._Manipulation.ReasonToContinue==null)
            //            {
            //                this.ReasonToContinue.Visible=false;
            //                this.labelReasonToContinue.Visible=false;
            //            }
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["ManipulationTreatmentMaterial"], (ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);

            // TODO Medula!
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            //if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Manipulation.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //{
            //    if (this._Manipulation.MedulaProvision == null)
            //    {
            //        MedulaProvision _medulaProvision = new MedulaProvision(this._Manipulation.ObjectContext);
            //        this._Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
            //        this._Manipulation.MedulaProvision = _medulaProvision;
            //    }
            //}
            //else
            //{
            //    this._Manipulation.CreateSubEpisode = false;
            //}
            
            //if(Common.CurrentDoctor == null)
            //    this.GridDiagnosis.ReadOnly = true;
            //else
            //    this.GridDiagnosis.ReadOnly = false;
            
            
            
            //this.SetDirectPurchaseListFilter((ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"]);
#endregion ManipulationTechnicianForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ManipulationTechnicianForm_ClientSidePreScript
    base.ClientSidePreScript();
            this.DirectPurchaseMaterialByPatient();
#endregion ManipulationTechnicianForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationTechnicianForm_PostScript
    base.PostScript(transDef);
#endregion ManipulationTechnicianForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationTechnicianForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(_Manipulation.Manipulation_SurgeryDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach(SurgeryDirectPurchaseGrid sdg in _Manipulation.Manipulation_SurgeryDirectPurchaseGrids)
                {
                    if(materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            if (_Manipulation.Manipulation_CodelessMaterialDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach (CodelessMaterialDirectPurchaseGrid cdg in _Manipulation.Manipulation_CodelessMaterialDirectPurchaseGrids)
                {
                    if(materials.Contains(cdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(cdg.DPADetailFirmPriceOffer);
                }
            }
            
            if (transDef != null)
            {
                if (this._Manipulation.TransDef.ToStateDefID == Manipulation.States.Completed)
                {
                    if (this.Technician == null || this.Technician.SelectedObject == null)
                        throw new TTUtils.TTException("Teknisyen bilgisini giriniz!");
                }
                
                if (this._Manipulation.TransDef.ToStateDefID == Manipulation.States.ResultEntry)
                {
                    if (this._Manipulation.ManipulationPersonnel.Count < 1)
                    {
                        throw new Exception(SystemMessage.GetMessage(1131));
                    }
                    this.CreateSubActionMatPricingDet();
                    
                }

                if (transDef.ToStateDef.StateDefID == Manipulation.States.RequestingDoctorFromTechnicianProcedure)
                {
                    StringEntryForm frm = new StringEntryForm();
                    ManipulationReturnReasonsGrid mrg = new ManipulationReturnReasonsGrid(_Manipulation.ObjectContext);
                    mrg.ReturnReason = frm.ShowAndGetStringForm("İade Sebebi").ToString();
                    _Manipulation.ManipulationReturnReasons.Add(mrg);
                }

                /* if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                {
                    if(this._Manipulation.ManipulationRequest != null && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    {
                        if (this._Manipulation.Episode.Diagnosis.Count <= 0)
                            if (this._Manipulation.Diagnosis.Count <= 0)
                            throw new Exception(SystemMessage.GetMessage(635));
                    }
                    
                }*/

            }
            
            this.MakingDirectPurchaseHasUsed();
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach(SurgeryDirectPurchaseGrid sdg in _Manipulation.Manipulation_SurgeryDirectPurchaseGrids )
            {
                sdg.Material = (Material)_Manipulation.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
            foreach(CodelessMaterialDirectPurchaseGrid cdg in _Manipulation.Manipulation_CodelessMaterialDirectPurchaseGrids )
            {
                cdg.Material = (Material)_Manipulation.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
#endregion ManipulationTechnicianForm_ClientSidePostScript

        }
    }
}
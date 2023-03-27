
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
    public partial class ManipulationResultEntryForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnImportFromPdf.Click += new TTControlEventDelegate(btnImportFromPdf_Click);
            GridTreatmentMaterials.CellValueChanged += new TTGridCellEventDelegate(GridTreatmentMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnImportFromPdf.Click -= new TTControlEventDelegate(btnImportFromPdf_Click);
            GridTreatmentMaterials.CellValueChanged -= new TTGridCellEventDelegate(GridTreatmentMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void btnImportFromPdf_Click()
        {
            #region ManipulationResultEntryForm_btnImportFromPdf_Click
            //TODO pdf!
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //         openFileDialog.Filter = "Rapor (*.pdf)|*.pdf";
            //         openFileDialog.DefaultExt = ".pdf";
            //         DialogResult dialogResult = openFileDialog.ShowDialog();
            //         if (dialogResult == DialogResult.OK)
            //         {
            //              _Manipulation.ReportPDF = null;
            //             _Manipulation.ObjectContext.Save();
            //             string fileName = @openFileDialog.FileName;
            //             System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
            //             long len;
            //             len = fileStream.Length;
            //             Byte[] fileAsByte = new Byte[len];
            //             fileStream.Read(fileAsByte, 0, fileAsByte.Length);
            //             System.IO.MemoryStream memoryStream = new System.IO.MemoryStream (fileAsByte);
            //             _Manipulation.ReportPDF = memoryStream.ToArray();
            //             _Manipulation.ObjectContext.Save();
            //             InfoBox.Show("Dosya Kaydedildi");
            //         }
            var a = 1;
            #endregion ManipulationResultEntryForm_btnImportFromPdf_Click
        }

        private void GridTreatmentMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationResultEntryForm_GridTreatmentMaterials_CellValueChanged
   //
            //            
            //            if(GridTreatmentMaterials.CurrentCell.OwningColumn.Name ==  "Material")
            //            {
            //                BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)GridTreatmentMaterials.Rows[rowIndex]).TTObject;
            //
            //                if(baseTreatmentMaterial.Material is ConsumableMaterialDefinition)
            //                {
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["DistributionType"].Value =baseTreatmentMaterial.Material.StockCard.DistributionType.DistributionType.ToString();
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UnitType"].Value = "-";
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UseAmount"].Value= "-";
            //                }
            //                
            //                else if(baseTreatmentMaterial.Material is DrugDefinition)
            //                {
            //                    
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UnitType"].Value =((DrugDefinition)baseTreatmentMaterial.Material).Unit.Name.ToString();
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["DistributionType"].Value = ((DrugDefinition)baseTreatmentMaterial.Material).StockCard.DistributionType.DistributionType.ToString();
            //                }
            //            }
#endregion ManipulationResultEntryForm_GridTreatmentMaterials_CellValueChanged
        }

        protected override void PreScript()
        {
#region ManipulationResultEntryForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();

            if(Common.CurrentResource.UserType.HasValue && Common.CurrentResource.UserType.Value == UserTypeEnum.Psychologist)
                _Manipulation.ResponsiblePersonnel = (ResUser)_Manipulation.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
            
            /*Listeleme sırasında tanımlanan kriterlere göre sarf listesini filtreler. */
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["ManipulationTreatmentMaterial"], (ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);

        
            
            if(Common.CurrentDoctor == null)
                this.GridDiagnosis.ReadOnly = true;
            else
                this.GridDiagnosis.ReadOnly = false;

            
            this.SetDirectPurchaseListFilter((ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"]);
            //_Manipulation.DirectPurchaseMaterialByPatient();
#endregion ManipulationResultEntryForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ManipulationResultEntryForm_ClientSidePreScript
    base.ClientSidePreScript();
            this.DirectPurchaseMaterialByPatient();
#endregion ManipulationResultEntryForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationResultEntryForm_PostScript
    base.PostScript(transDef);
#endregion ManipulationResultEntryForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationResultEntryForm_ClientSidePostScript
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
                if (transDef.ToStateDefID == Manipulation.States.Completed)
                {
                    if (this.TTListBoxSorumluDoktor == null || this.TTListBoxSorumluDoktor.SelectedObject == null)
                        throw new TTUtils.TTException("Sorumlu doktor bilgisini giriniz!");
                    
                    this.CreateSubActionMatPricingDet();
                }

                if (transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure)
                {
                    StringEntryForm frm = new StringEntryForm();
                    ManipulationReturnReasonsGrid mrg = new ManipulationReturnReasonsGrid(_Manipulation.ObjectContext);
                    mrg.ReturnReason = frm.ShowAndGetStringForm("İade Sebebi").ToString();
                    _Manipulation.ManipulationReturnReasons.Add(mrg);

                }
                if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                {
                    if(_Manipulation.ManipulationRequest != null && !(_Manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(_Manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    {
                        if (_Manipulation.Episode.Diagnosis.Count <= 0)
                            if (_Manipulation.Diagnosis.Count <= 0)
                            throw new Exception(SystemMessage.GetMessage(635));
                    }
                }
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

            //TODO Medula!
            //if(transDef.FromStateDefID == Manipulation.States.ResultEntry && transDef.ToStateDefID == Manipulation.States.TechnicianProcedure)
            //{
            //   // Medula Takip İşlemleri
            //   if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && _Manipulation.Episode.IsMedulaEpisode() == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //   {
            //       if(_Manipulation.IsGunubirlikTakip == true){
            //           if (_Manipulation.MedulaProvision == null)
            //           {
            //               MedulaProvision _medulaProvision = new MedulaProvision(_Manipulation.ObjectContext);
            //               _Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
            //               _Manipulation.MedulaProvision = _medulaProvision;
            //           }
            //           _Manipulation.GetManipulationMedulaTakip();
            //       }
            //       else
            //       {
            //           string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uyarı", "Günübirlik Takip Al alanı işaretlenmediğinden takip alınmadan işleme devam edilecektir.Devam Etmek İstiyor Musunuz?");
            //           if (result == "V")
            //           {
            //               InfoBox.Show("Takip almak için Günübirlik Takip Al alanını işaretleyip gerekli alanları doldurmalısınız.", MessageIconEnum.InformationMessage );
            //               return;
            //           }
            //       }
            //   }
            //}
            var a = 1;
            #endregion ManipulationResultEntryForm_ClientSidePostScript

        }
    }
}
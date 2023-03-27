
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
    public partial class ManipulationDoctorForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnOpenFromPdf.Click += new TTControlEventDelegate(btnOpenFromPdf_Click);
            GridDiagnosis.RowEnter += new TTGridCellEventDelegate(GridDiagnosis_RowEnter);
            GridDiagnosis.SelectionChanged += new TTControlEventDelegate(GridDiagnosis_SelectionChanged);
            GridManipulations.CellContentClick += new TTGridCellEventDelegate(GridManipulations_CellContentClick);
            GridTreatmentMaterials.CurrentCellChanged += new TTControlEventDelegate(GridTreatmentMaterials_CurrentCellChanged);
            GridTreatmentMaterials.CellValueChanged += new TTGridCellEventDelegate(GridTreatmentMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnOpenFromPdf.Click -= new TTControlEventDelegate(btnOpenFromPdf_Click);
            GridDiagnosis.RowEnter -= new TTGridCellEventDelegate(GridDiagnosis_RowEnter);
            GridDiagnosis.SelectionChanged -= new TTControlEventDelegate(GridDiagnosis_SelectionChanged);
            GridManipulations.CellContentClick -= new TTGridCellEventDelegate(GridManipulations_CellContentClick);
            GridTreatmentMaterials.CurrentCellChanged -= new TTControlEventDelegate(GridTreatmentMaterials_CurrentCellChanged);
            GridTreatmentMaterials.CellValueChanged -= new TTGridCellEventDelegate(GridTreatmentMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void btnOpenFromPdf_Click()
        {
            #region ManipulationDoctorForm_btnOpenFromPdf_Click
            //TODO PdfOpen!
            //   string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //            string filePath = appPath + @"\ManipulationReport";
            //            filePath += "(" + System.DateTime.Now.ToShortDateString() + ")" + ".pdf";
            //            Byte[] memoryStream = (byte[])_Manipulation.ReportPDF;
            //            const int myBufferSize = 1024;
            //            System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
            //            System.IO.Stream myOutputStream = System.IO.File.OpenWrite(filePath);
            //            byte[] buffer = new Byte[myBufferSize];
            //            int numbytes;
            //            while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
            //            {
            //                myOutputStream.Write(buffer, 0, numbytes);
            //            }
            //            myInputStream.Close();
            //            myOutputStream.Close();
            //            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //            proc.EnableRaisingEvents = false;
            //            proc.StartInfo.FileName = filePath ;
            //            proc.StartInfo.Arguments = "WINWORD.EXE";
            //            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            //            proc.Start();
            ////            proc.WaitForExit();
            var a = 1;
            #endregion ManipulationDoctorForm_btnOpenFromPdf_Click
        }

        private void GridDiagnosis_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationDoctorForm_GridDiagnosis_RowEnter
   //
#endregion ManipulationDoctorForm_GridDiagnosis_RowEnter
        }

        private void GridDiagnosis_SelectionChanged()
        {
#region ManipulationDoctorForm_GridDiagnosis_SelectionChanged
   //
#endregion ManipulationDoctorForm_GridDiagnosis_SelectionChanged
        }

        private void GridManipulations_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region ManipulationDoctorForm_GridManipulations_CellContentClick
            //TODO ShowEdit!
            //if ((((ITTGridCell)GridManipulations.CurrentCell).OwningColumn != null) && (((ITTGridCell)GridManipulations.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //         {

            //             BaseSurAndManProcedure_CokluOzelDurumForm codf = new BaseSurAndManProcedure_CokluOzelDurumForm();
            //             BaseSurgeryAndManipulationProcedure inp = (BaseSurgeryAndManipulationProcedure)GridManipulations.CurrentCell.OwningRow.TTObject;

            //             codf.ShowEdit(this.FindForm(), inp);
            //         }
            var a = 1;
            #endregion ManipulationDoctorForm_GridManipulations_CellContentClick
        }

        private void GridTreatmentMaterials_CurrentCellChanged()
        {
#region ManipulationDoctorForm_GridTreatmentMaterials_CurrentCellChanged
   //            
            //            if(GridTreatmentMaterials.CurrentCell.OwningColumn.Name ==  "UseAmount")
            //            {
            //                BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)GridTreatmentMaterials.Rows[rowIndex]).TTObject;
            //                if(baseTreatmentMaterial.Material is DrugDefinition){
            //                    try{
            //                        this.GridTreatmentMaterials.Rows[rowIndex].Cells["StockOutAmount"].Value = Convert.ToDouble(this.GridTreatmentMaterials.Rows[rowIndex].Cells["UseAmount"].Value) /  Convert.ToDouble(((DrugDefinition)baseTreatmentMaterial.Material).Dose);
            //                    }
            //                    catch(DivideByZeroException d){
            //                        throw new DivideByZeroException("Seçilen ilaç için İlaç Tanımlarında Doz değeri girilmemiştir.");
            //                    }
            //                    catch(ArithmeticException a){
            //                        throw new ArithmeticException ("Seçilen ilaç için Stoktan Düşülecek miktar değerini hesaplarken hata oluştu. Kullanılan miktar ve İlaç Tanımlarındaki Doz alanını kontrol ediniz. ");
            //                    }
            //                    catch(Exception e){
            //                        throw new Exception ("Seçilen ilaç için Stoktan Düşülecek miktar değerini hesaplarken hata oluştu. Kullanılan miktar ve İlaç Tanımlarındaki Doz alanını kontrol ediniz. ");
            //                    }
            //                }
            //            }


            //            if(GridTreatmentMaterials.CurrentCell.OwningColumn.Name ==  "StockOutAmount")
            //            {
            //                BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)GridTreatmentMaterials.Rows[rowIndex]).TTObject;
            //                if(baseTreatmentMaterial.Material is DrugDefinition)
            //                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UseAmount"].Value = Convert.ToDouble(this.GridTreatmentMaterials.Rows[rowIndex].Cells["StockOutAmount"].Value)  *  Convert.ToDouble(((DrugDefinition)baseTreatmentMaterial.Material).Dose) ;
            //            }
#endregion ManipulationDoctorForm_GridTreatmentMaterials_CurrentCellChanged
        }

        private void GridTreatmentMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationDoctorForm_GridTreatmentMaterials_CellValueChanged
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
            //
#endregion ManipulationDoctorForm_GridTreatmentMaterials_CellValueChanged
        }

        protected override void PreScript()
        {
#region ManipulationDoctorForm_PreScript
    base.PreScript();

            //            if(this._Manipulation.ReasonToContinue==null)
            //            {
            //                this.ReasonToContinue.Visible=false;
            //                this.labelReasonToContinue.Visible=false;
            //            }

            /* Eğer ProcedureDoctor set edilmemişse ve şimdiki kullanıcı doktorsa, ProcedureDoctor'a şimdiki doktor kullanıcısını atar.    */
            this.SetProcedureDoctorAsCurrentResource();
            
            if(Common.CurrentResource.UserType.HasValue && Common.CurrentResource.UserType.Value == UserTypeEnum.Psychologist)
                _Manipulation.ResponsiblePersonnel = (ResUser)_Manipulation.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));

            /*Listeleme sırasında tanımlanan kriterlere göre sarf listesini filtreler. */
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["ManipulationTreatmentMaterial"], (ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);


            //TODO Medula!
            //// Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.

            //if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(this._Manipulation.Episode) == true && this._Manipulation.IsMedulaProvisionNecessaryProcedureExists() == true)
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

           if(Common.CurrentDoctor == null)
                this.GridDiagnosis.ReadOnly = true;
            else
                this.GridDiagnosis.ReadOnly = false;
            
            if(_Manipulation.CurrentStateDefID == Manipulation.States.DoctorProcedure)
            {
                this.SetDirectPurchaseListFilter((ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"]);      
            }
            
            if(_Manipulation.CurrentStateDefID == Manipulation.States.Completed)
                btnOpenFromPdf.Visible = true;
            else
                btnOpenFromPdf.Visible = false;
#endregion ManipulationDoctorForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ManipulationDoctorForm_ClientSidePreScript
    base.ClientSidePreScript();
            if(_Manipulation.CurrentStateDefID == Manipulation.States.DoctorProcedure)
            {
                this.DirectPurchaseMaterialByPatient();
            }
#endregion ManipulationDoctorForm_ClientSidePreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationDoctorForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (SubEpisode.IsSGKSubEpisode(_Manipulation.SubEpisode))
                this.CheckDiagnosisOzelDurums();
            
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
            base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == Manipulation.States.Completed)
                {
                    if (this.TTListBoxSorumluDoktor == null || this.TTListBoxSorumluDoktor.SelectedObject == null)
                        throw new TTUtils.TTException("Sorumlu doktor bilgisini giriniz!");
                    this.CreateSubActionMatPricingDet();
                }
                
                
                if (transDef.ToStateDef.StateDefID == Manipulation.States.RequestingDoctorFromDoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure)
                {
                    StringEntryForm frm = new StringEntryForm();
                    ManipulationReturnReasonsGrid mrg = new ManipulationReturnReasonsGrid(this._Manipulation.ObjectContext);
                    mrg.ReturnReason = frm.ShowAndGetStringForm("İade Sebebi").ToString();
                    _Manipulation.ManipulationReturnReasons.Add(mrg);

                }

                if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                {
                    if(_Manipulation.ManipulationRequest != null && !(_Manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    {
                        if (_Manipulation.Episode.Diagnosis.Count == 0 && _Manipulation.Diagnosis.Count == 0)
                            throw new Exception(SystemMessage.GetMessage(635));
                        else
                            this.CreateDiagnosisGridFromEpisode();
                    }
                }

                if (_Manipulation.TransDef.ToStateDefID == Manipulation.States.ResultEntry)
                {
                    if (this._Manipulation.ManipulationPersonnel.Count < 1)
                    {
                        throw new Exception(SystemMessage.GetMessage(1131));
                    }
                }
                    
                
                
                
            }
            

            this.MakingDirectPurchaseHasUsed();
            
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            
            foreach(SurgeryDirectPurchaseGrid sdg in this._Manipulation.Manipulation_SurgeryDirectPurchaseGrids )
            {
                sdg.Material = (Material)this._Manipulation.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
            foreach(CodelessMaterialDirectPurchaseGrid cdg in _Manipulation.Manipulation_CodelessMaterialDirectPurchaseGrids )
            {
                cdg.Material = (Material)_Manipulation.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
#endregion ManipulationDoctorForm_ClientSidePostScript

        }

        public void CreateDiagnosisGridFromEpisode()
        {
            DiagnosisGrid episodeDG = null;
            DiagnosisGrid newDG = null;
            TTObjectContext context = this._EpisodeAction.ObjectContext;

            if (this._EpisodeAction.Episode.Diagnosis.Count > 0 && this._EpisodeAction.Episode.Diagnosis.Count == 0)
            {
                episodeDG = (DiagnosisGrid)this._EpisodeAction.Episode.Diagnosis[0];

                newDG = new DiagnosisGrid(context);
                newDG.EpisodeAction = this._Manipulation;
                newDG.Diagnose = episodeDG.Diagnose;
                newDG.AddToHistory = false;
                newDG.IsMainDiagnose = false;
                newDG.DiagnosisType = episodeDG.DiagnosisType;

                if (episodeDG.ResponsibleUser != null)
                    newDG.ResponsibleUser = episodeDG.ResponsibleUser;
            }


        }
    }
}
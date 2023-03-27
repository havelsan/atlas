
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
           // GridParticipantDepartmants.CellValueChanged += new TTGridCellEventDelegate(GridParticipantDepartmants_CellValueChanged);
            //GridMainSurgeryProcedures.UserDeletedRow += new TTGridRowEventDelegate(GridMainSurgeryProcedures_UserDeletedRow);
            //GridMainSurgeryProcedures.CellValueChanged += new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellValueChanged);
            //GridMainSurgeryProcedures.CellContentClick += new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellContentClick);
            GridSurgeryPersonnels.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //GridParticipantDepartmants.CellValueChanged -= new TTGridCellEventDelegate(GridParticipantDepartmants_CellValueChanged);
            //GridMainSurgeryProcedures.UserDeletedRow -= new TTGridRowEventDelegate(GridMainSurgeryProcedures_UserDeletedRow);
            //GridMainSurgeryProcedures.CellValueChanged -= new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellValueChanged);
            //GridMainSurgeryProcedures.CellContentClick -= new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellContentClick);
            GridSurgeryPersonnels.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridParticipantDepartmants_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryForm_GridParticipantDepartmants_CellValueChanged
   //            if(this.GridParticipantDepartmants.Columns["Department"].Index==columnIndex)
            //            {
            //                ((TTListBoxCell)this.GridParticipantDepartmants.Rows[rowIndex].Cells["ResponsibleDoctor"]).LinkFilterExpression=" RESOURCEUSERS.RESOURCE= '" + GridParticipantDepartmants.Rows[rowIndex].Cells[columnIndex].Value.ToString() + "'";
            //            }
            //
#endregion SurgeryForm_GridParticipantDepartmants_CellValueChanged
        }

        private void GridMainSurgeryProcedures_UserDeletedRow()
        {
#region SurgeryForm_GridMainSurgeryProcedures_UserDeletedRow
   this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
#endregion SurgeryForm_GridMainSurgeryProcedures_UserDeletedRow
        }

        private void GridMainSurgeryProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryForm_GridMainSurgeryProcedures_CellValueChanged
   // Ameliyat veya Kesi Bilgisi değiştirilirse
            //if (((ITTGrid)this.GridMainSurgeryProcedures).Columns[columnIndex].Name == "CAProcedureObject" || ((ITTGrid)this.GridMainSurgeryProcedures).Columns[columnIndex].Name == "IncisionType")
            //    this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();

            //if (GridMainSurgeryProcedures.CurrentCell == null)
            //    return;

            //if (this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Surgery.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //{
            //    foreach (MainSurgeryProcedure item in this._Surgery.MainSurgeryProcedures)
            //    {
            //        if (item.ProcedureObject.MedulaProvisionNecessity.HasValue)
            //        {
            //            if (item.ProcedureObject.MedulaProvisionNecessity.Value)
            //            {
            //                this.TabSubaction.ShowTabPage(MedulaTakipBilgileriTabPage);
            //                this.BransMedulaProvision.Required = true;
            //                this.TedaviTipiMedulaProvision.Required = true;
            //                this.TakipTipiMedulaProvision.Required = true;
            //                _Surgery.CreateSubEpisode = true;
            //                if (this._Surgery.MedulaProvision == null)
            //                {
            //                    MedulaProvision _medulaProvision = new MedulaProvision(_Surgery.ObjectContext);
            //                    this._Surgery.SetMedulaProvisionInitalProperties(_medulaProvision);
            //                    this._Surgery.MedulaProvision = _medulaProvision;
            //                }
            //            }
            //        }
            //    }
            //}
            
            //// Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir
            //if (GridMainSurgeryProcedures.CurrentCell != null && GridMainSurgeryProcedures.CurrentCell.OwningColumn != null && GridMainSurgeryProcedures.CurrentCell.OwningColumn.Name == "CAProcedureObject")
            //{
            //    SurgeryProcedure surgeryProcedure = (SurgeryProcedure)this.GridMainSurgeryProcedures.CurrentCell.OwningRow.TTObject;
            //    if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
            //    {
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = false;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = false;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = false;
            //    }
            //    else
            //    {
            //        surgeryProcedure.ToothNumber = string.Empty;
            //        surgeryProcedure.ToothAnomaly = null;
            //        surgeryProcedure.ToothCommitmentNumber = null;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = true;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
            //        this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = true;
            //        this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = true;
            //    }
            //}
#endregion SurgeryForm_GridMainSurgeryProcedures_CellValueChanged
        }

//        private void GridMainSurgeryProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region SurgeryForm_GridMainSurgeryProcedures_CellContentClick
//   if(rowIndex < this.GridMainSurgeryProcedures.Rows.Count && rowIndex > -1)
//            {
//                if( columnIndex == 10)
//                {
//                    try
//                    {
//                        SurgeryProcedure surgeryProcedure = (SurgeryProcedure)((ITTGridRow)this.GridMainSurgeryProcedures.Rows[rowIndex]).TTObject;
//                        if (surgeryProcedure != null)
//                        {

//                                if(surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
//                                {
//                                    //TODO ShowEdit!
//                                    //BaseSurgeryProcedureToothSchema frm = new BaseSurgeryProcedureToothSchema();
//                                    //frm.ShowEdit(this.FindForm(), surgeryProcedure, true);
                                    
//                                    this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
//                                    if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
//                                    {
//                                        string toothNumberNames = string.Empty;
//                                        string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
//                                        foreach (string toothNumber in toothNumbers)
//                                        {
//                                            string enumDisplayText = Common.GetDisplayTextOfEnumValue("ToothNumberEnum", Int32.Parse(toothNumber));
//                                            toothNumberNames += enumDisplayText + ",";
//                                        }

//                                        if (!string.IsNullOrEmpty(toothNumberNames))
//                                            this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
//                                    }
//                                }
//                                else
//                                    InfoBox.Show("Sadece diş ameliyatları için diş şeması açılabilir.", MessageIconEnum.InformationMessage);
//                        }
//                    }
//                    catch (System.Exception ex)
//                    {
//                        InfoBox.Show(ex);
//                    }
//                }
//            }
//#endregion SurgeryForm_GridMainSurgeryProcedures_CellContentClick
//        }


        private void GridSurgeryPersonnels_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region SurgeryForm_GridSurgeryPersonnels_CellValueChanged
            if (rowIndex < this.GridSurgeryPersonnels.Rows.Count && rowIndex > -1)
            {
                SurgeryPersonnel surgeryPersonel = (SurgeryPersonnel)((ITTGridRow)this.GridSurgeryPersonnels.Rows[rowIndex]).TTObject;

                if (surgeryPersonel.Personnel != null && surgeryPersonel.Role != null)
                {
                    if (surgeryPersonel.Personnel.UserType == UserTypeEnum.Technician)
                    {
                        return;
                    }
                    else
                    {
                        if (surgeryPersonel.Personnel.UserType != UserTypeEnum.Dentist && surgeryPersonel.Personnel.UserType != UserTypeEnum.Doctor)
                            InfoBox.Show(surgeryPersonel.Personnel.Name.ToString() + "kullanıcısı doktor değildir lütfen rolünü kontrol ediniz");
                    }
                }
            }
            #endregion SurgeryForm_GridSurgeryPersonnels_CellValueChanged
        }



        protected override void PreScript()
        {
#region SurgeryForm_PreScript
    base.PreScript();
            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            //if (this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Surgery.Episode) == true  && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //{
                //                if (this._Surgery.MedulaProvision == null)
                //                {
                //                    TTObjectContext context = new TTObjectContext(false);
                //                    MedulaProvision _medulaProvision = new MedulaProvision(context);
                //                    this._Surgery.SetMedulaProvisionInitalProperties(_medulaProvision);
                //                    this._Surgery.MedulaProvision = _medulaProvision;
                //                    context.Save();
                //                }
            //}
            //else
            //{
            //    this._Surgery.CreateSubEpisode = false;
            //    this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
            //    this.TedaviTipiMedulaProvision.Required = false;
            //    this.TakipTipiMedulaProvision.Required = false;
            //    this.BransMedulaProvision.Required = false;
            //}
            
            //ArrangeToothColumnsOfSurgeryGrid();
#endregion SurgeryForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SurgeryForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion SurgeryForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryForm_PostScript
    base.PostScript(transDef);

         this.CheckSurgeryFormPost(transDef,this.ProcedureDoctor.SelectedObject );

#endregion SurgeryForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == Surgery.States.Rejected)
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._Surgery.ReasonOfReject = frm.ShowAndGetStringForm("Ameliyatın Yapılamama Nedeni");
                }
            }
#endregion SurgeryForm_ClientSidePostScript

        }

#region SurgeryForm_Methods
        //// Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir, Diş ameliyatı ise Diş Numarası doldurulur
        //public void ArrangeToothColumnsOfSurgeryGrid()
        //{
        //    foreach (ITTGridRow row in GridMainSurgeryProcedures.Rows)
        //    {
        //        SurgeryProcedure surgeryProcedure = (SurgeryProcedure)row.TTObject;
        //        if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
        //        {
        //            row.Cells["ToothSchema"].ReadOnly = false;
        //            row.Cells["ToothNumber"].ReadOnly = true;
        //            row.Cells["ToothAnomaly"].ReadOnly = false;
        //            row.Cells["ToothCommitmentNumber"].ReadOnly = false;
                    
        //            if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
        //            {
        //                string toothNumberNames = string.Empty;
        //                string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
        //                foreach (string toothNumber in toothNumbers)
        //                {
        //                   string enumDisplayText = Common.GetDisplayTextOfEnumValue("ToothNumberEnum", Int32.Parse(toothNumber));
        //                    toothNumberNames += enumDisplayText + ",";
        //                }

        //                if (!string.IsNullOrEmpty(toothNumberNames))
        //                    row.Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
        //            }
        //        }
        //        else
        //        {
        //            row.Cells["ToothSchema"].ReadOnly = true;
        //            row.Cells["ToothNumber"].ReadOnly = true;
        //            row.Cells["ToothAnomaly"].ReadOnly = true;
        //            row.Cells["ToothCommitmentNumber"].ReadOnly = true;
        //        }
        //    }
        //}
        
        
        public void CheckSurgeryFormPost(TTObjectStateTransitionDef transDef, TTObject procedureDoctor)
        {
            if (transDef != null)
            {
                
                if (transDef.ToStateDefID == Surgery.States.Completed || transDef.ToStateDefID == Surgery.States.SurgeryRequest)
                {
                    if (procedureDoctor == null)
                        throw new TTUtils.TTException("Sorumlu cerrah bilgisini giriniz!");
                }
                
                if (transDef.ToStateDefID == Surgery.States.Completed || transDef.ToStateDefID == Surgery.States.WaitingForSubSurgeries)
                {

                    if (this._Surgery.AnesthesiaAndReanimation != null)
                    {
                        if (this._Surgery.AnesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.ReturnedToDoctor)
                            throw new Exception("Anestezi isteği , istek yapan doktora iade edilmiştir, ameliyat işlemine devam edilemez.");
                        else if (this._Surgery.AnesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.RequestAcception)
                            throw new Exception("İşleme devam edebilmek  için önce ilgili Anestezi isteğinin kabul edilmesi gerekir.");
                        else if (this._Surgery.AnesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.Cancelled)
                            throw new Exception("İlgili Anestezi isteği iptal edilmiştir.Ameliyat İşlemine devam edilemez.");

                        //Ameliyat sırasında yapılan skorlamalar girilecek ve kendileri AnesthesiaExpend'e geçirecekler
                        /*else if(mySurgery.AnesthesiaAndReanimation.CurrentStateDefID==AnesthesiaAndReanimation.States.SurgeryAnesthesia)
                        {
                            mySurgery.AnesthesiaAndReanimation.CurrentStateDefID=AnesthesiaAndReanimation.States.AnesthesiaExpend;
                        }*/
                    }
                    if (this._Surgery.SurgeryRoom == null)
                        throw new Exception("'Ameliyat Odası' Alanı boş olamaz");

                    if (this._Surgery.SurgeryStartTime == null)
                        throw new Exception("'Ameliyatı Başlatma Tarih/Saat' Alanı boş olamaz");
                    if (this._Surgery.SurgeryEndTime == null)
                        throw new Exception("'Ameliyatı Bitirme Tarih/Saat' Alanı boş olamaz");

                    //if (this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(this._Surgery.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
                    //{
                        // uyarı olmadığı için method dışına alındı
                        //if (mySurgery.MedulaProvision == null)
                        //{
                        //    MedulaProvision _medulaProvision = new MedulaProvision(mySurgery.ObjectContext);
                        //    mySurgery.SetMedulaProvisionInitalProperties(_medulaProvision);
                        //    mySurgery.MedulaProvision = _medulaProvision;
                        //    mySurgery.CreateSubEpisode = true;
                        //}
                        //mySurgery.GetSurgeryMedulaTakip();
                    //}
                }
            }
        }
        
#endregion SurgeryForm_Methods
    }
}
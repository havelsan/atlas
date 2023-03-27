
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
    /// Tıbbi/Cerrahi Uygulama İstek
    /// </summary>
    public partial class ManipulationRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            //chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            GridManipulationProcedures.CellDoubleClick += new TTGridCellEventDelegate(GridManipulationProcedures_CellDoubleClick);
            GridManipulationProcedures.CellValueChanged += new TTGridCellEventDelegate(GridManipulationProcedures_CellValueChanged);
            cmdHistory.Click += new TTControlEventDelegate(cmdHistory_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            GridManipulationProcedures.CellDoubleClick -= new TTGridCellEventDelegate(GridManipulationProcedures_CellDoubleClick);
            GridManipulationProcedures.CellValueChanged -= new TTGridCellEventDelegate(GridManipulationProcedures_CellValueChanged);
            cmdHistory.Click -= new TTControlEventDelegate(cmdHistory_Click);
            base.UnBindControlEvents();
        }


        // TODO Webservis! 
//        private void chkDisXXXXXXRaporu_CheckedChanged()
//        {
//#region ManipulationRequestForm_chkDisXXXXXXRaporu_CheckedChanged
//   if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
//            {
//                if (this._ManipulationRequest.Episode.Patient.UniqueRefNo == null)
//                {
//                    InfoBox.Show("Ki?inin Sistemde Tan?ml? Bir Kimlik Numaras? Yoktur. ??lem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
//                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked = false;
//                    return;
//                }
//                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
//                //TODO : MEDULA20140501
//                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
//                _raporOkuTCKimlikNodanDVO.raporTuru = "1";
//                _raporOkuTCKimlikNodanDVO.tckimlikNo = this._ManipulationRequest.Episode.Patient.UniqueRefNo.Value.ToString();
//                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);

//                if (response != null)
//                {
//                    if (!response.sonucKodu.Equals(0))
//                    {
//                        InfoBox.Show("Sonuc Aç?klamas? : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu);
//                        return;
//                    }
//                    if (response.raporlar == null)
//                    {
//                        InfoBox.Show("Ki?inin D?? XXXXXX Rapor Bilgisi Bulunamam??t?r.");
//                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked = false;
//                        return;
//                    }
//                    if (response.sonucKodu.Equals(0))
//                    {
//                        if (response.raporlar != null && response.raporlar.Length > 0)
//                        {
//                            bool isValid = false;
//                            MultiSelectForm multiSelectForm = new MultiSelectForm();
//                            foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
//                            {
//                                if (item.tedaviRapor != null)
//                                {
//                                    string raporBilgileri = string.Empty;
//                                    if (item.tedaviRapor.tedaviRaporTuru == 4)
//                                    {
//                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
//                                        {
//                                            Array tValues = Enum.GetValues(typeof(TupBebekRaporTuruEnum));
//                                            foreach (TupBebekRaporTuruEnum tType in tValues)
//                                            {
//                                                if ((Common.GetEnumValueDefOfEnumValue(tType).Value).Equals(tedaviIslemBilgisiDVO.tupBebekRaporBilgisi.tupBebekRaporTuru - 1))
//                                                {
//                                                    raporBilgileri += " Rapor Türü :" +  Common.GetDisplayTextOfDataTypeEnum(tType);
//                                                }
//                                            }
//                                        }
//                                        isValid = true;
//                                        multiSelectForm.AddMSItem("Rapor Takip Numaras? : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih, item.raporTakipNo.ToString());
//                                    }
//                                }
//                            }
//                            string mkey = multiSelectForm.GetMSItem(null, "?lgili Raporu Seçiniz", true);
//                            if (isValid)
//                            {
//                                if (string.IsNullOrEmpty(mkey))
//                                {
//                                    InfoBox.Show("?lgili raporu seçmeden i?leme devam edemezsiniz.");
//                                    return;
//                                }
//                                string raporTakipNo = multiSelectForm.MSSelectedItemObject as string;
//                            }
//                            else
//                            {
//                                InfoBox.Show("Ki?inin D?? XXXXXX Rapor Bilgisi Bulunamam??t?r.");
//                                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked = false;
//                                return;
//                            }


//                            if (!string.IsNullOrEmpty(mkey))
//                            {
//                                MedulaRaporTakipNo.Visible = true;
//                                labelMedulaRaporTakipNo.Visible = true;
//                                lblRaporBilgileri.Visible = true;
//                                MedulaRaporBilgileri.Visible = true;
//                                MedulaRaporTakipNo.Text = mkey;

//                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
//                                {
//                                    if (mkey == item.raporTakipNo.ToString())
//                                    {
//                                        _ManipulationRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
//                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
//                                        {
//                                            Array tValues = Enum.GetValues(typeof(TupBebekRaporTuruEnum));
//                                            foreach (TupBebekRaporTuruEnum tType in tValues)
//                                            {
//                                                 if ((Common.GetEnumValueDefOfEnumValue(tType).Value).Equals(tedaviIslemBilgisiDVO.tupBebekRaporBilgisi.tupBebekRaporTuru - 1))
//                                                {
//                                                    MedulaRaporBilgileri.Text += " Rapor Türü :" + Common.GetDisplayTextOfDataTypeEnum(tType);
//                                                }
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                MedulaRaporTakipNo.Visible = false;
//                                labelMedulaRaporTakipNo.Visible = false;
//                                lblRaporBilgileri.Visible = false;
//                                MedulaRaporBilgileri.Visible = false;
//                                MedulaRaporTakipNo.Text = "";
//                                MedulaRaporBilgileri.Text = "";
//                            }
//                        }
//                        else
//                        {
//                            InfoBox.Show("Ki?inin D?? XXXXXX Rapor Bilgisi Bulunamam??t?r.");
//                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked = false;
//                            return;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                _ManipulationRequest.ReportNo = null;
//                MedulaRaporTakipNo.Visible = false;
//                labelMedulaRaporTakipNo.Visible = false;
//                lblRaporBilgileri.Visible = false;
//                MedulaRaporBilgileri.Visible = false;
//                MedulaRaporTakipNo.Text = "";
//                MedulaRaporBilgileri.Text = "";
//            }
//#endregion ManipulationRequestForm_chkDisXXXXXXRaporu_CheckedChanged
//        }

        private void GridManipulationProcedures_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationRequestForm_GridManipulationProcedures_CellDoubleClick
            // TODO ShowEdit!
   ////Bu şekilde Maniplusyonun app'ı verilemiyor o yüzden commentlendi...
   //         if (rowIndex < this.GridManipulationProcedures.Rows.Count && rowIndex > -1)
   //         {
   //             ManipulationProcedure maniplationProcedure = (ManipulationProcedure)(((ITTGridRow)this.GridManipulationProcedures.Rows[rowIndex]).TTObject);
   //             if (maniplationProcedure != null)
   //             {
   //                 if (maniplationProcedure.EpisodeAction != null)
   //                 {
   //                     Guid actionID = (Guid)maniplationProcedure.EpisodeAction.ObjectID;
   //                     TTObjectContext objectContext = new TTObjectContext(false);

   //                     try
   //                     {
   //                         Manipulation manipulation = (Manipulation)(objectContext.GetObject(actionID, typeof(Manipulation)));

   //                         TTForm frm = TTForm.GetEditForm(manipulation);
   //                         if (frm == null)
   //                         {
   //                             MessageBox.Show(manipulation.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
   //                         }
   //                         frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
   //                         frm.ShowEdit(this.FindForm(), manipulation);
   //                     }
   //                     catch (System.Exception ex)
   //                     {
   //                         InfoBox.Show(ex);
   //                     }
   //                     finally
   //                     {
   //                         objectContext.Dispose();
   //                     }
   //                 }
   //             }
   //       }
#endregion ManipulationRequestForm_GridManipulationProcedures_CellDoubleClick
        }

        private void GridManipulationProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationRequestForm_GridManipulationProcedures_CellValueChanged
   ITTGridRow enteredRow = GridManipulationProcedures.Rows[rowIndex];

            if (enteredRow != null)
            {
                ManipulationProcedure manipulationProcedure = enteredRow.TTObject as ManipulationProcedure;
                if (manipulationProcedure != null && manipulationProcedure.ProcedureObject != null && manipulationProcedure.ProcedureObject.Code !=null )
                {
                    if (((SurgeryDefinition)manipulationProcedure.ProcedureObject).InVitroFertilizationProcess.HasValue)
                    {
                        //labelReportStartDate.Visible=true;
                        //ReportStartDate.Visible=true;
                        //labelReportEndDate.Visible=true;
                        //ReportEndDate.Visible=true;
                        //lblTupBebekTuru.Visible=true;
                        //cmbTupBebekTuru.Visible=true;
                        chkDisXXXXXXRaporu.Visible=true;
                        this._ManipulationRequest.ButKodu=manipulationProcedure.ProcedureObject.Code;
                    }
                }
            }
            else
            {
                //labelReportStartDate.Visible=false;
                //ReportStartDate.Visible=false;
                //labelReportEndDate.Visible=false;
                //ReportEndDate.Visible=false;
                //lblTupBebekTuru.Visible=false;
                //cmbTupBebekTuru.Visible=false;
                chkDisXXXXXXRaporu.Visible=false;
                labelMedulaRaporTakipNo.Visible=false;
                MedulaRaporTakipNo.Visible=false;
                MedulaRaporTakipNo.Text="";
            }
#endregion ManipulationRequestForm_GridManipulationProcedures_CellValueChanged
        }

        private void cmdHistory_Click()
        {
            #region ManipulationRequestForm_cmdHistory_Click
            //TODO GridRow!
            //ManipulationGrid.Rows.Clear();
            //         BindingList<ManipulationProcedure> manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfEpisode(_ManipulationRequest.ObjectContext, this._ManipulationRequest.Episode.ObjectID.ToString());
            //         foreach (ManipulationProcedure mp in manipulationProcedureList)
            //         {
            //             ITTGridRow gridRow = this.ManipulationGrid.Rows.Add();
            //             gridRow.Cells["OldManipulationActionDate"].Value = mp.ActionDate;

            //             gridRow.Cells["OldEmergency"].Value = mp.Emergency;
            //             if(mp.ProcedureObject!=null)
            //                 gridRow.Cells["OldProcedureObject"].Value =  mp.ProcedureObject.ObjectID ;
            //             if(mp.ProcedureDepartment!=null)
            //                 gridRow.Cells["OldDepartment"].Value = mp.ProcedureDepartment.ObjectID ;//emin değilim
            //             if(mp.ProcedureDoctor!=null)
            //                 gridRow.Cells["OldManipulationDoctor"].Value =  mp.ProcedureDoctor.ObjectID ;

            //             gridRow.Cells["OldDescription"].Value = mp.Description;
            //         }
            var a = 1;
            #endregion ManipulationRequestForm_cmdHistory_Click
        }

        protected override void PreScript()
        {
#region ManipulationRequestForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            this.SetProcedureDoctorListFilter();
#endregion ManipulationRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationRequestForm_PostScript
    base.PostScript(transDef);
            
            if(this._ManipulationRequest.ButKodu!=null)
            {
                //if(this._ManipulationRequest.TestTubeBabyType ==null)
                //{
                //   throw new Exception("Tüp Bebek Türü bilgisini seçmediniz.");
                //}
            }
            if (transDef.ToStateDef.StateDefID != ManipulationRequest.States.Cancelled)
            {
                if (this._ManipulationRequest.SubactionProcedures.Count < 1)
                {
                    throw new Exception("Tıbbi/Cerrahi Uygulama bilgisini seçmediniz.");
                }            
            }
            //İstek Kabül adımına taşındı.
//            if (transDef != null)
//            {
//                if (transDef.ToStateDef.StateDefID == ManipulationRequest.States.Completed)
//                {
//                    _ManipulationRequest.IsPatientApprovalFormGiven = GetIfPatientApprovalFormIsGiven(_ManipulationRequest.IsPatientApprovalFormGiven);
//                }
//            }
#endregion ManipulationRequestForm_PostScript

            }
            
#region ManipulationRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                // if(!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                //                {
                //                    TTObjectContext context = new TTObjectContext(false);
                //                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                //                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                //                    medulaReportResult.ReportNumber =  "";
                //                    medulaReportResult.ReportRowNumber = 0;
                //                    medulaReportResult.ReportChasingNo = MedulaRaporTakipNo.Text;
                //                    medulaReportResult.SendReportDate = DateTime.Now;
                //                    medulaReportResult.ResultCode="0";
                //                    medulaReportResult.ResultExplanation = "Rapor Takip Numaras? D?? XXXXXX Taraf?ndan Verilmi?tir!!!";
                //                    medulaReportResult.Manipulation = this._ManipulationRequest.Manipulations[0];
                //                    context.Save();

                // if(this._ManipulationRequest.ButKodu!=null)
                //  {
                //TODO Medula!
                //if (this._ManipulationRequest.SubEpisode != null && this._ManipulationRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._ManipulationRequest.SubEpisode.SGKSEP.MedulaTakipNo))
                //{
                //    try
                //    {
                //        if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                //        {
                //            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //            //TODO : MEDULA20140501
                //            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                //            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                //            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._ManipulationRequest.Episode.Patient.UniqueRefNo.Value.ToString();
                //            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                //            if (response != null)
                //            {                                
                //                    if (response.sonucKodu.Equals(0))
                //                    {
                //                        if(response.raporlar!=null && response.raporlar.Length>0)
                //                        {
                //                            foreach (RaporIslemleri.raporCevapDVO raporCevapDVO in response.raporlar)
                //                            {
                //                                if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 4 )
                //                                {  
                //                                            if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
                //                                            {

                //                                                TTObjectContext context = new TTObjectContext(false);
                //                                                MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                //                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                //                                                medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                //                                                medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                //                                                medulaReportResult.ReportChasingNo =  raporCevapDVO.raporTakipNo.ToString();
                //                                                medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.tarih);
                //                                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                //                                                medulaReportResult.Manipulation = this._ManipulationRequest.Manipulations[0];
                //                                                context.Save();
                //                                            }
                //                                }
                //                            }
                //                        }
                //                    }
                //            }
                //        }
                //    }
                //    catch (Exception)
                //   {
                //           throw;
                //   }
                //}
                var a = 1;
            }
        }



        protected void SetProcedureDoctorListFilter()
        {
            if ((TTObjectClasses.SystemParameter.GetParameterValue("MANIPULATIONREQUESTDOCTORFILTER", "FALSE") == "TRUE"))
            {
                TTObjectContext context = new TTObjectContext(true);
                string filterString = "OBJECTID IN (''";

                IList userList = ResUser.GetResUserByUserTypeAndResource(context, UserTypeEnum.Doctor, this._EpisodeAction.MasterResource.ObjectID);
                foreach (ResUser user in userList)
                {
                    filterString += " ,'" + user.ObjectID.ToString() + "'";
                }
                filterString += ")";
                ((ITTObjectListBox)ProcedureDoctor).ListFilterExpression = filterString;
            }
        }
        
#endregion ManipulationRequestForm_Methods
    }
}
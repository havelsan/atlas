
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
    public partial class PCC_NewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdFindPatients.Click += new TTControlEventDelegate(cmdFindPatients_Click);
            grdPatients.CellContentClick += new TTGridCellEventDelegate(grdPatients_CellContentClick);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdSearchSubactionMaterials.Click += new TTControlEventDelegate(cmdSearchSubactionMaterials_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdFindPatients.Click -= new TTControlEventDelegate(cmdFindPatients_Click);
            grdPatients.CellContentClick -= new TTGridCellEventDelegate(grdPatients_CellContentClick);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdSearchSubactionMaterials.Click -= new TTControlEventDelegate(cmdSearchSubactionMaterials_Click);
            base.UnBindControlEvents();
        }

        private void cmdFindPatients_Click()
        {
#region PCC_NewForm_cmdFindPatients_Click
   if(txtMaterial.SelectedObject == null)
            {
                InfoBox.Show("Malzeme seçmediniz.");
                return;
            }
            
            if (_PatientConsumptionCancel.StartDate == null || _PatientConsumptionCancel.EndDate == null)
            {
                InfoBox.Show("Başlangıç ve(veya) Bitiş tarihleri boş olamaz");
                return;
            }

            grdPatients.Rows.Clear();
            Material material = (Material)txtMaterial.SelectedObject;
            string startDate = _PatientConsumptionCancel.StartDate.Value.ToString("yyyy-MM-dd 00:00:00");
            string endDate = _PatientConsumptionCancel.EndDate.Value.ToString("yyyy-MM-dd 23:59:59");
            if (txtStore.SelectedObject == null)
            {
                IList stocks = Stock.GetStock(_PatientConsumptionCancel.ObjectContext, material.ObjectID.ToString());
                List<Guid> patientsAllStore = new List<Guid>();
                foreach (Stock materialStock in stocks)
                {
                    IList sStocktransactions = StockTransaction.GetCompletedOUTStockTransactionbyDate(_PatientConsumptionCancel.ObjectContext, materialStock.ObjectID, startDate, endDate, string.Empty);
                    foreach (StockTransaction strx in sStocktransactions)
                    {
                        IList baseTreatmentMaterial = _PatientConsumptionCancel.ObjectContext.QueryObjects(typeof(BaseTreatmentMaterial).Name, "STOCKACTIONDETAIL =" + ConnectionManager.GuidToString(strx.StockActionDetail.ObjectID));
                        if (baseTreatmentMaterial.Count > 0)
                        {
                            BaseTreatmentMaterial btm = (BaseTreatmentMaterial)baseTreatmentMaterial[0];
                            if (patientsAllStore.Contains(btm.Episode.Patient.ObjectID) == false)
                            {
                                patientsAllStore.Add(btm.Episode.Patient.ObjectID);
                                ITTGridRow row = grdPatients.Rows.Add();
                                row.Cells["UniqueRefNo"].Value = btm.Episode.Patient.UniqueRefNo.ToString();
                                row.Cells["ForeignUniqueRefNo"].Value = btm.Episode.Patient.ForeignUniqueRefNo.ToString();
                                row.Cells["Id"].Value = btm.Episode.Patient.ID.ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                Store store = (Store)txtStore.SelectedObject;
                Stock stock = (Stock)Stock.GetStockFromStoreAndMaterial(material.ObjectID, store.ObjectID)[0].TTObject;
                IList stocktransactions = StockTransaction.GetCompletedOUTStockTransactionbyDate(_PatientConsumptionCancel.ObjectContext, stock.ObjectID, startDate, endDate, string.Empty);
                List<Guid> patients = new List<Guid>();
                foreach (StockTransaction trx in stocktransactions)
                {
                    IList baseTreatmentMaterial = _PatientConsumptionCancel.ObjectContext.QueryObjects(typeof(BaseTreatmentMaterial).Name, "STOCKACTIONDETAIL =" + ConnectionManager.GuidToString(trx.StockActionDetail.ObjectID));
                    if (baseTreatmentMaterial.Count > 0)
                    {
                        BaseTreatmentMaterial btm = (BaseTreatmentMaterial)baseTreatmentMaterial[0];
                        if (patients.Contains(btm.Episode.Patient.ObjectID) == false)
                        {
                            patients.Add(btm.Episode.Patient.ObjectID);
                            ITTGridRow row = grdPatients.Rows.Add();
                            row.Cells["UniqueRefNo"].Value = btm.Episode.Patient.UniqueRefNo.ToString();
                            row.Cells["ForeignUniqueRefNo"].Value = btm.Episode.Patient.ForeignUniqueRefNo.ToString();
                            row.Cells["Id"].Value = btm.Episode.Patient.ID.ToString();
                        }
                    }
                }
            }
#endregion PCC_NewForm_cmdFindPatients_Click
        }

        private void grdPatients_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PCC_NewForm_grdPatients_CellContentClick
   if (grdPatients.CurrentCell.OwningColumn.Name == "Choose")
            {
                if(grdPatients.CurrentCell.OwningRow.Cells["Id"].Value != null)
                {
                    BindingList<Patient> patients = Patient.GetPatientByPID(_PatientConsumptionCancel.ObjectContext, Convert.ToInt64(grdPatients.CurrentCell.OwningRow.Cells["Id"].Value.ToString()));
                    if (patients.Count == 0)
                        InfoBox.Show("Bu TC Kimlik no ile kayıtlı bir hasta bulunamadı");
                    else if (patients.Count > 1)
                        InfoBox.Show("Bu TC Kimlik no ile kayıtlı birden fazla hasta bulundu");
                    else
                    {
                        _PatientConsumptionCancel.Patient = patients[0];
                        cmdSearchPatient.Text = _PatientConsumptionCancel.Patient.UniqueRefNo.ToString() + " - " + _PatientConsumptionCancel.Patient.FullName;
                    }
                }
            }
#endregion PCC_NewForm_grdPatients_CellContentClick
        }

        private void cmdSearchPatient_Click()
        {
#region PCC_NewForm_cmdSearchPatient_Click
   using(PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();

                if(patient != null)
                {
                    _PatientConsumptionCancel.Patient = patient;
                    cmdSearchPatient.Text = patient.UniqueRefNo.ToString() + " - " + patient.FullName;
                }
                else
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
            }
#endregion PCC_NewForm_cmdSearchPatient_Click
        }

        private void cmdSearchSubactionMaterials_Click()
        {
#region PCC_NewForm_cmdSearchSubactionMaterials_Click
   if( _PatientConsumptionCancel.Patient == null)
            {
                InfoBox.Show("Önce hasta seçiniz");
                return;
            }
            
            _PatientConsumptionCancel.PCC_SubactionMaterials.DeleteChildren();
            BindingList<SubActionMaterial> subActionMateriaList = SubActionMaterial.GetByOpenedAndClosedToNewEpisode(_PatientConsumptionCancel.ObjectContext, _PatientConsumptionCancel.Patient.ObjectID.ToString());
            if (subActionMateriaList.Count > 0)
            {
                foreach (SubActionMaterial subActionMaterial in subActionMateriaList)
                {
                    if (subActionMaterial is BaseTreatmentMaterial)
                    {
                        if (subActionMaterial.CurrentStateDefID == BaseTreatmentMaterial.States.Cancelled)
                            continue;
                    }
                    else
                    {
                        if (subActionMaterial.CurrentStateDefID == SubActionMaterial.States.Cancelled)
                            continue;
                    }


                    if (subActionMaterial.EpisodeAction != null)
                        if (subActionMaterial.EpisodeAction.ActionType == ActionTypeEnum.Prescription)
                        continue;

                    bool available = false;
                    if (txtMaterial.SelectedObject == null)
                        available = true;
                    else
                    {
                        if (((Material)txtMaterial.SelectedObject).ObjectID == subActionMaterial.Material.ObjectID)
                            available = true;
                    }

                    if (available)
                    {
                        PCC_SubactionMaterial pcc = new PCC_SubactionMaterial(_PatientConsumptionCancel.ObjectContext);
                        pcc.PatientConsumptionCancel = _PatientConsumptionCancel;
                        if (subActionMaterial.EpisodeAction == null)
                            pcc.EpisodeProtocolNo_Desc = subActionMaterial.Episode.HospitalProtocolNo.Value.ToString() + " - " + ((TTObject)subActionMaterial).ObjectDef.ToString();
                        else
                            pcc.EpisodeProtocolNo_Desc = subActionMaterial.Episode.HospitalProtocolNo.Value.ToString() + " - " + ((TTObject)subActionMaterial.EpisodeAction).ObjectDef.ToString();
                        pcc.DetailCancel = false;
                        pcc.SubActionMaterial = subActionMaterial;
                    }
                }
            }
            else
                InfoBox.Show("Hastaya ait açık yada açık-devam durumunda vaka bulunamadı.");


            //BindingList<Episode> episodes = Episode.GetEpisodesByPatient(_PatientConsumptionCancel.ObjectContext, _PatientConsumptionCancel.Patient.ObjectID.ToString());
            //if (episodes.Count > 0)
            //{
            //    List<Episode> availableEpisodes = new List<Episode>();
            //    foreach (Episode episode in episodes)
            //    {
            //        if (episode.CurrentStateDefID == Episode.States.Open || episode.CurrentStateDefID == Episode.States.ClosedToNew)
            //            availableEpisodes.Add(episode);
            //    }

            //    if (availableEpisodes.Count > 0)
            //    {
            //        foreach (Episode episode in availableEpisodes)
            //        {
            //            foreach (SubActionMaterial subActionMaterial in episode.SubActionMaterials)
            //            {
            //                if(subActionMaterial is BaseTreatmentMaterial)
            //                {
            //                    if(subActionMaterial.CurrentStateDefID == BaseTreatmentMaterial.States.Cancelled)
            //                        continue;
            //                }
            //                else
            //                {
            //                    if(subActionMaterial.CurrentStateDefID == SubActionMaterial.States.Cancelled)
            //                        continue;
            //                }

            
            //                if(subActionMaterial.EpisodeAction != null)
            //                    if(subActionMaterial.EpisodeAction.ActionType == ActionTypeEnum.Prescription)
            //                    continue;
            
            //                bool available = false;
            //                if(txtMaterial.SelectedObject == null)
            //                    available = true;
            //                else
            //                {
            //                    if(((Material)txtMaterial.SelectedObject).ObjectID == subActionMaterial.Material.ObjectID)
            //                        available = true;
            //                }
            
            //                if(available)
            //                {
            //                    PCC_SubactionMaterial pcc = new PCC_SubactionMaterial(_PatientConsumptionCancel.ObjectContext);
            //                    pcc.PatientConsumptionCancel = _PatientConsumptionCancel;
            //                    if(subActionMaterial.EpisodeAction == null)
            //                        pcc.EpisodeProtocolNo_Desc = episode.HospitalProtocolNo.Value.ToString() + " - " + ((TTObject)subActionMaterial).ObjectDef.ToString();
            //                    else
            //                        pcc.EpisodeProtocolNo_Desc = episode.HospitalProtocolNo.Value.ToString() + " - " + ((TTObject)subActionMaterial.EpisodeAction).ObjectDef.ToString();
            //                    pcc.Cancel = false;
            //                    pcc.SubActionMaterial = subActionMaterial;
            //                }
            //            }
            //        }
            //    }
            //    else
            //        InfoBox.Show("Hastaya ait açık yada açık-devam durumunda vaka bulunamadı.");
            //}
            //else
            //    InfoBox.Show("Hastaya ait vaka bulunamadı.");
#endregion PCC_NewForm_cmdSearchSubactionMaterials_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PCC_NewForm_PostScript
    base.PostScript(transDef);
            
            string errMsg = null;
            List<SubActionMaterial> cancelList = new List<SubActionMaterial>();
            
            foreach(PCC_SubactionMaterial pcc in _PatientConsumptionCancel.PCC_SubactionMaterials)
            {
                if((bool)pcc.DetailCancel)
                    cancelList.Add(pcc.SubActionMaterial);
                else
                    continue;
                
                foreach (AccountTransaction at in pcc.SubActionMaterial.AccountTransactions)
                {
                    if (at.CurrentStateDefID != AccountTransaction.States.New && at.CurrentStateDefID != AccountTransaction.States.ToBeNew && at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                    {
                        errMsg += "\r\n" + pcc.SubActionMaterial.Material.Name + "\r\nFaturalanmış sarf girişi iptal edilemez. Önce faturayı iptal ediniz.";
                        grdConsumptions.CurrentCell.Value = false;
                    }
                }
            }
            
            if(cancelList.Count == 0)
                errMsg += "\r\nİptal edilecek herhangi bir malzeme seçmediniz.";
            
            if(errMsg != null)
                throw new TTUtils.TTException(errMsg);
            else
            {
                foreach(SubActionMaterial sm in cancelList)
                {
                    foreach(AccountTransaction acc in sm.AccountTransactions)
                        acc.CurrentStateDefID = AccountTransaction.States.Cancelled;
                    
                    if(sm.StockActionDetail != null)
                    {
                        sm.StockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;
                        if(sm.StockActionDetail.StockAction.StockActionDetails.Count == 1 && sm.StockActionDetail.StockAction is StockOut)
                            ((StockOut)sm.StockActionDetail.StockAction).CurrentStateDefID = StockOut.States.Cancelled;
                        
                        foreach (StockTransaction transaction in sm.StockActionDetail.StockTransactions.Select(""))
                            transaction.CurrentStateDefID = StockTransaction.States.Cancelled;
                    }
                    
                    if(sm is BaseTreatmentMaterial)
                        sm.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                    else
                        sm.CurrentStateDefID = SubActionMaterial.States.Cancelled;
                }
            }
#endregion PCC_NewForm_PostScript

            }
                }
}
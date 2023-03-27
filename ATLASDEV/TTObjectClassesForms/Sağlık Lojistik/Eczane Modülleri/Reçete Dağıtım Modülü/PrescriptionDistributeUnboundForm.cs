
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
    /// Reçete Dağıtım
    /// </summary>
    public partial class PrescriptionDistributeUnboundForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cmdSelect.Click += new TTControlEventDelegate(cmdSelect_Click);
            cmdUnSelect.Click += new TTControlEventDelegate(cmdUnSelect_Click);
            PrescriptionDateTime.ValueChanged += new TTControlEventDelegate(PrescriptionDateTime_ValueChanged);
            cmdSelectPharmacy.Click += new TTControlEventDelegate(cmdSelectPharmacy_Click);
            PharmacyCountCombo.SelectedIndexChanged += new TTControlEventDelegate(PharmacyCountCombo_SelectedIndexChanged);
            cmdDistribute.Click += new TTControlEventDelegate(cmdDistribute_Click);
            cmdClear.Click += new TTControlEventDelegate(cmdClear_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cmdSelect.Click -= new TTControlEventDelegate(cmdSelect_Click);
            cmdUnSelect.Click -= new TTControlEventDelegate(cmdUnSelect_Click);
            PrescriptionDateTime.ValueChanged -= new TTControlEventDelegate(PrescriptionDateTime_ValueChanged);
            cmdSelectPharmacy.Click -= new TTControlEventDelegate(cmdSelectPharmacy_Click);
            PharmacyCountCombo.SelectedIndexChanged -= new TTControlEventDelegate(PharmacyCountCombo_SelectedIndexChanged);
            cmdDistribute.Click -= new TTControlEventDelegate(cmdDistribute_Click);
            cmdClear.Click -= new TTControlEventDelegate(cmdClear_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region PrescriptionDistributeUnboundForm_ttbutton2_Click
   Close();
#endregion PrescriptionDistributeUnboundForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region PrescriptionDistributeUnboundForm_ttbutton1_Click
   TTObjectContext context = new TTObjectContext(false);
            for ( int i = 0; i < this.DistributeGrid.Rows.Count; i++)
            {
                Guid pharmacyGuid = new Guid(this.DistributeGrid.Rows[i].Cells["PharmacyGuid"].Value.ToString());
                ExternalPharmacy externalPharmacy = (ExternalPharmacy)context.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
                Guid prescriptionGuid = new Guid(this.DistributeGrid.Rows[i].Cells["PrescriptionGuid"].Value.ToString());
                Prescription prescription = (Prescription)context.GetObject(prescriptionGuid, "PRESCRIPTION");
                if(prescription is InpatientPrescription)
                {
                    ((InpatientPrescription)prescription).ExternalPharmacy = externalPharmacy ;
                }
                else
                {
                    ((OutPatientPrescription)prescription).ExternalPharmacy = externalPharmacy ;
                }
                
                ExternalPharmacyPrescriptionTransaction prescriptionTransaction = new ExternalPharmacyPrescriptionTransaction(context);
                prescriptionTransaction.ExternalPharmacy = externalPharmacy ;
                prescriptionTransaction.Prescription = prescription ;
                prescriptionTransaction.Cancelled = false ;
                prescriptionTransaction.TransactionDate = DateTime.Now;
                prescriptionTransaction.Price = (double)this.DistributeGrid.Rows[i].Cells["DPrice"].Value;
            }
            context.Save();
            Close();
#endregion PrescriptionDistributeUnboundForm_ttbutton1_Click
        }

        private void cmdSelect_Click()
        {
#region PrescriptionDistributeUnboundForm_cmdSelect_Click
   if(this.PrescriptionGrid.Rows.Count > 0)
            {
                for (int i = 0; i < this.PrescriptionGrid.Rows.Count; i++)
                {
                    this.PrescriptionGrid.Rows[i].Cells["Distribute"].Value = 1 ;
                }
            }
#endregion PrescriptionDistributeUnboundForm_cmdSelect_Click
        }

        private void cmdUnSelect_Click()
        {
#region PrescriptionDistributeUnboundForm_cmdUnSelect_Click
   if(this.PrescriptionGrid.Rows.Count > 0)
            {
                for (int i = 0; i < this.PrescriptionGrid.Rows.Count; i++)
                {
                    this.PrescriptionGrid.Rows[i].Cells["Distribute"].Value = 0 ;
                }
            }
#endregion PrescriptionDistributeUnboundForm_cmdUnSelect_Click
        }

        private void PrescriptionDateTime_ValueChanged()
        {
#region PrescriptionDistributeUnboundForm_PrescriptionDateTime_ValueChanged
   TTObjectContext context = new TTObjectContext(false);
            
            DateTime startDate = Convert.ToDateTime(this.PrescriptionDateTime.NullableValue.Value.ToShortDateString() + " 00:00:00");
            DateTime endDate = Convert.ToDateTime(this.PrescriptionDateTime.NullableValue.Value.ToShortDateString()+" 23:59:59");
            
            IList myPrescriptions = Prescription.GetPrescription(context, startDate, endDate);
            if ( myPrescriptions.Count>0 )
            {
                foreach (Prescription prescription in myPrescriptions)
                {
                    
                    /*if(prescription is InpatientPrescription)
                    {
                        if(prescription.CurrentStateDefID == InpatientPrescription.States.ExternalPharmacySupply & ((InpatientPrescription)prescription).ExternalPharmacy == null)
                        {
                            ITTGridRow addedRow = this.PrescriptionGrid.Rows.Add();
                            addedRow.Cells["Distribute"].Value =0;
                            addedRow.Cells["PPrescriptionType"].Value = "Yatan Hasta";
                            addedRow.Cells["PPrescriptionNo"].Value = prescription.PrescriptionNO.ToString();
                            addedRow.Cells["PPatientName"].Value = prescription.Episode.Patient.Name.ToString();
                            addedRow.Cells["PQuarantineNo"].Value = prescription.Episode.QuarantineProtocolNo.ToString();
                            //addedRow.Cells["PProtocolNo"].Value = prescription.SubEpisode.PatientAdmission.Protocol..ProtocolNo.ToString();
                            addedRow.Cells["PResource"].Value = prescription.MasterResource.Name.ToString();
                            double price = 0;
                            foreach (InpatientDrugOrder inpatientDrugOrder in ((InpatientPrescription)prescription).InpatientDrugOrders)
                            {
                                foreach(MaterialPrice materialPrice in inpatientDrugOrder.Material.MaterialPrices)
                                {
                                    if(materialPrice.PricingDetail.PricingList.Code == "1" & materialPrice.PricingDetail.DateEnd >= DateTime.Today.Date)//Hastanın kurumun fiyat listesi bakılacak
                                        price = price + (Double)materialPrice.PricingDetail.Price * (Double)inpatientDrugOrder.Amount;
                                }
                            }
                            addedRow.Cells["PPrice"].Value = price ;
                            addedRow.Cells["PGuid"].Value = prescription.ObjectID.ToString();
                        }
                        
                    }
                    if(prescription is OutPatientPrescription)
                    {
                        if(prescription.CurrentStateDefID == OutPatientPrescription.States.ExternalPharmacySupply & ((OutPatientPrescription)prescription).ExternalPharmacy == null)
                        {
                            ITTGridRow addedRow = this.PrescriptionGrid.Rows.Add();
                            addedRow.Cells["Distribute"].Value =0;
                            addedRow.Cells["PPrescriptionType"].Value = "Ayaktan Hasta";
                            addedRow.Cells["PPrescriptionNo"].Value = prescription.PrescriptionNO.ToString();
                            addedRow.Cells["PPatientName"].Value = prescription.Episode.Patient.Name.ToString();
                            addedRow.Cells["PQuarantineNo"].Value = prescription.Episode.QuarantineProtocolNo.ToString();
                            //addedRow.Cells["PProtocolNo"].Value = prescription.Episode.ProtocolNo.ToString();
                            addedRow.Cells["PResource"].Value = prescription.MasterResource.Name.ToString();
                            double price = 0;
                            foreach (OutPatientDrugOrder  outpatientDrugOrder in ((OutPatientPrescription)prescription).OutPatientDrugOrders )
                            {
                                foreach(MaterialPrice materialPrice in outpatientDrugOrder.Material.MaterialPrices)
                                {
                                    if(materialPrice.PricingDetail.PricingList.Code == "1" & materialPrice.PricingDetail.DateEnd >= DateTime.Today.Date)//Hastanın kurumun fiyat listesi bakılacak
                                        price = price + (Double)materialPrice.PricingDetail.Price * (Double)outpatientDrugOrder.Amount;
                                }
                            }
                            addedRow.Cells["PPrice"].Value = price ;
                            addedRow.Cells["PGuid"].Value = prescription.ObjectID.ToString();
                        }
                        
                    }*/
                    
                }
            }
#endregion PrescriptionDistributeUnboundForm_PrescriptionDateTime_ValueChanged
        }

        private void cmdSelectPharmacy_Click()
        {
#region PrescriptionDistributeUnboundForm_cmdSelectPharmacy_Click
   TTObjectContext context = new TTObjectContext (false);
            this.PharmacyCountCombo.Enabled = false ;
            MultiSelectForm multiSelectForm = new MultiSelectForm();
            ExternalPharmacy externalPharmacy;
            BindingList<ExternalPharmacy> externalPharmacys = ExternalPharmacy.GetExternalPharmacys(context) ;
            for (int i=0; i< externalPharmacys.Count ; i++)
            {
                bool exists = false ;
                for ( int p=0; p< this.PharmacyGrid.Rows.Count ; p++)
                {
                    if ( this.PharmacyGrid.Rows[p].Cells["Guid"].Value.ToString() == ((ExternalPharmacy)externalPharmacys[i]).ObjectID.ToString())
                        exists = true ;
                }
                if(!exists)
                    multiSelectForm.AddMSItem (((ExternalPharmacy)externalPharmacys[i]).Name ,((ExternalPharmacy)externalPharmacys[i]).Name,((ExternalPharmacy)externalPharmacys[i]));
            }
            string key = multiSelectForm.GetMSItem(ParentForm ,"İşlem yapacağınız sınıfı seçin");
            
            if (!string.IsNullOrEmpty(key))
            {
                externalPharmacy  = multiSelectForm.MSSelectedItemObject as ExternalPharmacy;
                double totalPrice = 0 ;
                foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in  externalPharmacy.PrescriptionTransactions)
                {
                    totalPrice = totalPrice +(double)prescriptionTransaction.Price;
                }
                ITTGridRow addedRow = this.PharmacyGrid.Rows.Add();
                addedRow.Cells[0].Value = externalPharmacy.Name.ToString();
                addedRow.Cells[1].Value = totalPrice.ToString() ;
                addedRow.Cells[2].Value = externalPharmacy.ObjectID.ToString() ;
            }
#endregion PrescriptionDistributeUnboundForm_cmdSelectPharmacy_Click
        }

        private void PharmacyCountCombo_SelectedIndexChanged()
        {
#region PrescriptionDistributeUnboundForm_PharmacyCountCombo_SelectedIndexChanged
   if(PharmacyCountCombo.Text != "")
            {
                TTObjectContext context = new TTObjectContext(false);
                BindingList<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetExternalPharmacys(context);
                this.PharmacyGrid.Rows.Clear();
                this.cmdSelectPharmacy.Enabled = false;
                Hashtable unSortedPharmacyList = new Hashtable();
                
                foreach ( ExternalPharmacy externalPharmacy in myExternalPharmacy )
                {
                    Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
                    pharmacyListItem.ID = externalPharmacy.ObjectID.ToString();
                    double totalPrice = 0 ;
                    foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in  externalPharmacy.PrescriptionTransactions)
                    {
                        totalPrice = totalPrice +(double)prescriptionTransaction.Price;
                    }
                    pharmacyListItem.Value = totalPrice ;
                    unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
                }
                List<Common.TTDoubleSortableList> pharmacyList = Common.SortedDoubleItems(unSortedPharmacyList);

                for (int i = 0; i < Convert.ToInt64(this.PharmacyCountCombo.Text); i++)
                {
                    Guid pharmacyGuid = new Guid(pharmacyList[i].ID.ToString());
                    ExternalPharmacy sortedExternalPharmacy = (ExternalPharmacy) context.GetObject(pharmacyGuid, "EXTERNALPHARMACY");
                    
                    ITTGridRow addedRow = this.PharmacyGrid.Rows.Add();
                    addedRow.Cells[0].Value = sortedExternalPharmacy.Name.ToString();
                    addedRow.Cells[1].Value = pharmacyList[i].Value;
                    addedRow.Cells[2].Value = pharmacyList[i].ID.ToString() ;
                }
            }
            else
            {
                this.PharmacyGrid.Rows.Clear();
                this.cmdSelectPharmacy.Enabled = true;
            }
#endregion PrescriptionDistributeUnboundForm_PharmacyCountCombo_SelectedIndexChanged
        }

        private void cmdDistribute_Click()
        {
#region PrescriptionDistributeUnboundForm_cmdDistribute_Click
   TTObjectContext context = new TTObjectContext(false);
            Hashtable unSortedPrescriptionList = new Hashtable();
            
            for (int i = 0; i < this.PrescriptionGrid.Rows.Count; i++)
            {
                if(Convert.ToBoolean(this.PrescriptionGrid.Rows[i].Cells["Distribute"].Value))
                {
                    Common.TTDoubleSortableList prescriptionListItem = new Common.TTDoubleSortableList();
                    prescriptionListItem.ID = this.PrescriptionGrid.Rows[i].Cells["PGuid"].Value.ToString();
                    prescriptionListItem.Value = Convert.ToDouble(this.PrescriptionGrid.Rows[i].Cells["PPrice"].Value);
                    unSortedPrescriptionList.Add(prescriptionListItem.ID, prescriptionListItem);
                }
            }
            
            List<Common.TTDoubleSortableList> prescriptionList = Common.SortedDoubleItems(unSortedPrescriptionList);
            prescriptionList.Reverse();
            
            Hashtable unSortedPharmacyList = new Hashtable();

            for (int y = 0; y < this.PharmacyGrid.Rows.Count; y++)
            {
                Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
                pharmacyListItem.ID = this.PharmacyGrid.Rows[y].Cells["Guid"].Value.ToString();
                pharmacyListItem.Value = Convert.ToDouble(this.PharmacyGrid.Rows[y].Cells["Balance"].Value);
                unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
            }
            
            List<Common.TTDoubleSortableList> pharmacyList = Common.SortedDoubleItems(unSortedPharmacyList);
            
            foreach(Common.TTDoubleSortableList sortedItem in prescriptionList)
            {
                double newValue = pharmacyList[0].Value  + sortedItem.Value ;
                object guid = pharmacyList[0].ID ;
                pharmacyList.RemoveAt(0);
                unSortedPharmacyList.Remove(guid);
                
                Common.TTDoubleSortableList newPharmacyListItem = new Common.TTDoubleSortableList();
                newPharmacyListItem.ID = guid ;
                newPharmacyListItem.Value = newValue ;
                unSortedPharmacyList.Add(newPharmacyListItem.ID, newPharmacyListItem);
                pharmacyList = Common.SortedDoubleItems(unSortedPharmacyList);

                Guid prescriptionGuid = new Guid(sortedItem.ID.ToString());
                Prescription prescription = (Prescription)context.GetObject(prescriptionGuid,"PRESCRIPTION");

                Guid pharmacyGuid = new Guid(guid.ToString());
                ExternalPharmacy externalPharmacy = (ExternalPharmacy)context.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
                
                ITTGridRow addedRow = this.DistributeGrid.Rows.Add();
                addedRow.Cells["DPrescriptionNo"].Value = prescription.PrescriptionNO.ToString();
                addedRow.Cells["DPatientNo"].Value = prescription.Episode.Patient.Name.ToString();
                if(prescription.SubEpisode.InpatientAdmission != null)
                addedRow.Cells["DProtocolNo"].Value = prescription.SubEpisode.InpatientAdmission.QuarantineProtocolNo.ToString();
                //addedRow.Cells["DQuarantineNo"].Value = inPatienPrescription.Episode.ProtocolNo.ToString();
                addedRow.Cells["DResource"].Value = prescription.MasterResource.Name.ToString();
                addedRow.Cells["DPrice"].Value = sortedItem.Value  ;
                addedRow.Cells["DPharmacy"].Value = externalPharmacy.Name.ToString();
                addedRow.Cells["PrescriptionGuid"].Value = sortedItem.ID.ToString();
                addedRow.Cells["PharmacyGuid"].Value = guid.ToString();
            }

            this.PharmacyGrid.Rows.Clear();
            foreach (Common.TTDoubleSortableList sortedpharmacy in pharmacyList)
            {
                Guid pharmacyGuid = new Guid(sortedpharmacy.ID.ToString());
                ExternalPharmacy newExternalPharmacy = (ExternalPharmacy)context.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
                ITTGridRow refreshPharmacy = this.PharmacyGrid.Rows.Add();
                refreshPharmacy.Cells[0].Value = newExternalPharmacy.Name.ToString();
                refreshPharmacy.Cells[1].Value = sortedpharmacy.Value.ToString();
                refreshPharmacy.Cells[2].Value = sortedpharmacy.ID.ToString();
            }
            this.cmdDistribute.Enabled = false;
            this.PharmacyCountCombo.Enabled = false;
#endregion PrescriptionDistributeUnboundForm_cmdDistribute_Click
        }

        private void cmdClear_Click()
        {
#region PrescriptionDistributeUnboundForm_cmdClear_Click
   this.DistributeGrid.Rows.Clear();
            this.PharmacyGrid.Rows.Clear();
            this.PharmacyCountCombo .Enabled = true;
            this.cmdSelectPharmacy.Enabled = true;
            this.PharmacyCountCombo.Text = "";
            this.cmdDistribute.Enabled = true ;
            //            PrescriptionDistribute pd = _PrescriptionDistribute ;
            //            IList myExternalPharmacy = pd.ObjectContext.QueryObjects("EXTERNALPHARMACY","");
//
            //            Hashtable unSortedPharmacyList = new Hashtable();
//
            //            foreach ( ExternalPharmacy externalPharmacy in myExternalPharmacy )
            //            {
            //                Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
            //                pharmacyListItem.ID = externalPharmacy.ObjectID.ToString();
            //                double totalPrice = 0 ;
            //                foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in  externalPharmacy.PrescriptionTransactions)
            //                {
            //                    totalPrice = totalPrice +(double)prescriptionTransaction.Price;
            //                }
            //                pharmacyListItem.Value = totalPrice ;
            //                unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
            //            }
            //            List<Common.TTDoubleSortableList> pharmacyList = Common.SortedDoubleItems(unSortedPharmacyList);
//
            //            for (int i=0;  i < Convert.ToInt64(this.PharmacyCountCombo.Text); i++)
            //            {
            //                Guid pharmacyGuid = new Guid(pharmacyList[i].ID.ToString());
            //                ExternalPharmacy sortedExternalPharmacy = (ExternalPharmacy)this._ttObject.ObjectContext.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
//
            //                ITTGridRow addedRow = this.PharmacyGrid.Rows.Add();
            //                addedRow.Cells[0].Value = sortedExternalPharmacy.Name.ToString();
            //                addedRow.Cells[1].Value = pharmacyList[i].Value;
            //                addedRow.Cells[2].Value = pharmacyList[i].ID.ToString() ;
            //            }
            //            this.cmdDistribute.Enabled = true ;
            //            this.PharmacyCountCombo.Enabled = true;
#endregion PrescriptionDistributeUnboundForm_cmdClear_Click
        }

#region PrescriptionDistributeUnboundForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            TTObjectContext context = new TTObjectContext(false);
            this.PrescriptionDateTime.NullableValue = DateTime.Today;
            //PrescriptionDistribute pd = _PrescriptionDistribute ;
            IList myExternalPharmacy = context.QueryObjects("EXTERNALPHARMACY","STATUS = 1") ;
            PharmacyCountCombo.Items.Add(new TTComboBoxItem("",0));
            for (int i = 0; i < myExternalPharmacy.Count; i++)
            {
                int count = i+1 ;
                PharmacyCountCombo.Items.Add(new TTComboBoxItem(count.ToString() , i+1));
            }
        }
        
        
//        protected override void OnFormClosing(FormClosingEventArgs e)
//        {
//            TTObjectContext context = new TTObjectContext(false);
//            for ( int i = 0; i < this.DistributeGrid.Rows.Count; i++)
//            {
//                Guid pharmacyGuid = new Guid(this.DistributeGrid.Rows[i].Cells["PharmacyGuid"].Value.ToString());
//                ExternalPharmacy externalPharmacy = (ExternalPharmacy)context.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
//                Guid prescriptionGuid = new Guid(this.DistributeGrid.Rows[i].Cells["PrescriptionGuid"].Value.ToString());
//                Prescription prescription = (Prescription)context.GetObject(prescriptionGuid, "PRESCRIPTION");
//                if(prescription is InpatientPrescription)
//                {
//                    ((InpatientPrescription)prescription).ExternalPharmacy = externalPharmacy ;
//                }
//                else
//                {
//                    ((OutPatientPrescription)prescription).ExternalPharmacy = externalPharmacy ;
//                }
//                
//                ExternalPharmacyPrescriptionTransaction prescriptionTransaction = new ExternalPharmacyPrescriptionTransaction(context);
//                prescriptionTransaction.ExternalPharmacy = externalPharmacy ;
//                prescriptionTransaction.Prescription = prescription ;
//                prescriptionTransaction.Cancelled = false ;
//                prescriptionTransaction.TransactionDate = DateTime.Now;
//                prescriptionTransaction.Price = (double)this.DistributeGrid.Rows[i].Cells["DPrice"].Value;
//            }
//
//        }
        
#endregion PrescriptionDistributeUnboundForm_Methods
    }
}
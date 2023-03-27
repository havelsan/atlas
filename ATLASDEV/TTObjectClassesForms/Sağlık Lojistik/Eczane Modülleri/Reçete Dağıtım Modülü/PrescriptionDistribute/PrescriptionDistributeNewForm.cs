
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
    public partial class PrescriptionDistributeNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdDistribute.Click += new TTControlEventDelegate(cmdDistribute_Click);
            cmdSelectPharmacy.Click += new TTControlEventDelegate(cmdSelectPharmacy_Click);
            PharmacyCountCombo.SelectedIndexChanged += new TTControlEventDelegate(PharmacyCountCombo_SelectedIndexChanged);
            cmdClear.Click += new TTControlEventDelegate(cmdClear_Click);
            cmdSelect.Click += new TTControlEventDelegate(cmdSelect_Click);
            cmdUnSelect.Click += new TTControlEventDelegate(cmdUnSelect_Click);
            PrescriptionDateTime.ValueChanged += new TTControlEventDelegate(PrescriptionDateTime_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdDistribute.Click -= new TTControlEventDelegate(cmdDistribute_Click);
            cmdSelectPharmacy.Click -= new TTControlEventDelegate(cmdSelectPharmacy_Click);
            PharmacyCountCombo.SelectedIndexChanged -= new TTControlEventDelegate(PharmacyCountCombo_SelectedIndexChanged);
            cmdClear.Click -= new TTControlEventDelegate(cmdClear_Click);
            cmdSelect.Click -= new TTControlEventDelegate(cmdSelect_Click);
            cmdUnSelect.Click -= new TTControlEventDelegate(cmdUnSelect_Click);
            PrescriptionDateTime.ValueChanged -= new TTControlEventDelegate(PrescriptionDateTime_ValueChanged);
            base.UnBindControlEvents();
        }

        private void cmdDistribute_Click()
        {
#region PrescriptionDistributeNewForm_cmdDistribute_Click
   TTObjectContext context = _PrescriptionDistribute.ObjectContext;
            Hashtable unSortedPrescriptionList = new Hashtable();
            
            foreach (PrescriptionDetail prescriptionDetail in _PrescriptionDistribute.PrescriptionDetails)
            {
                if(prescriptionDetail.Distribute == true)
                {
                    Common.TTDoubleSortableList prescriptionListItem = new Common.TTDoubleSortableList();
                    prescriptionListItem.ID = prescriptionDetail.PrescriptionGuid.ToString();
                    prescriptionListItem.Value = (double)prescriptionDetail.Price ;
                    unSortedPrescriptionList.Add(prescriptionListItem.ID, prescriptionListItem);
                }
            }
            
            List<Common.TTDoubleSortableList> prescriptionList = Common.SortedDoubleItems(unSortedPrescriptionList);
            prescriptionList.Reverse();
            
            Hashtable unSortedPharmacyList = new Hashtable();

            Dictionary<string, double> firstPharmacyList = new Dictionary<string, double>();
            foreach(PharmacyDetail pharmacyDetail in _PrescriptionDistribute.PharmacyDetails)
            {
                Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
                pharmacyListItem.ID = pharmacyDetail.PharmacyGuid.ToString();
                pharmacyListItem.Value = (double)pharmacyDetail.Balance;
                unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
                firstPharmacyList.Add(pharmacyDetail.PharmacyGuid.ToString(),(double)pharmacyDetail.PrescriptionCount);
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
                
                DistributeDetail distributeDetail = new DistributeDetail(context);
                distributeDetail.ExternalPharmacy = externalPharmacy ;
                distributeDetail.Prescription = prescription;
                distributeDetail.PatientName = prescription.Episode.Patient.FullName ;
                distributeDetail.PatientProtocolNo = prescription.Episode.HospitalProtocolNo.Value ;
                distributeDetail.PatientQuarantineNo = 0 ;
                // Karantina numarasına bakılacak SS
                //distributeDetail.PatientQuarantineNo = (long)prescription.Episode.InpatientAdmissions[0].QuarantineProtocolNo.Value;
                distributeDetail.Price = (double)sortedItem.Value;
                distributeDetail.PrescriptionDistribute = _PrescriptionDistribute ;
                firstPharmacyList[pharmacyGuid.ToString()] = firstPharmacyList[pharmacyGuid.ToString()] + 1;
            }

            this.PharmacyDetails.Rows.Clear();
            foreach (Common.TTDoubleSortableList sortedpharmacy in pharmacyList)
            {
                Guid pharmacyGuid = new Guid(sortedpharmacy.ID.ToString());
                ExternalPharmacy newExternalPharmacy = (ExternalPharmacy)context.GetObject(pharmacyGuid,"EXTERNALPHARMACY");
                PharmacyDetail refreshPharmacy = new PharmacyDetail(context);
                refreshPharmacy.Pharmacy = newExternalPharmacy.Name.ToString();
                refreshPharmacy.Balance = sortedpharmacy.Value;
                refreshPharmacy.PharmacyGuid = sortedpharmacy.ID.ToString();
                refreshPharmacy.PrescriptionCount = firstPharmacyList[pharmacyGuid.ToString()];
                refreshPharmacy.PrescriptionDistribute = _PrescriptionDistribute;

            }
            this.cmdDistribute.Enabled = false;
            this.PharmacyCountCombo.Enabled = false;
#endregion PrescriptionDistributeNewForm_cmdDistribute_Click
        }

        private void cmdSelectPharmacy_Click()
        {
#region PrescriptionDistributeNewForm_cmdSelectPharmacy_Click
   TTObjectContext context = _PrescriptionDistribute.ObjectContext ;
            this.PharmacyCountCombo.Enabled = false ;
            MultiSelectForm multiSelectForm = new MultiSelectForm();
            ExternalPharmacy externalPharmacy;
            if (Common.RecTime().Hour >= 17)
            {
                List<ExternalPharmacy> externalPharmacys = ExternalPharmacy.GetNightPharmacy(Common.RecTime());
                for (int i = 0; i < externalPharmacys.Count; i++)
                {
                    bool exists = false;
                    foreach (PharmacyDetail detail in _PrescriptionDistribute.PharmacyDetails)
                    {
                        if (detail.PharmacyGuid.ToString() == ((ExternalPharmacy)externalPharmacys[i]).ObjectID.ToString())
                            exists = true;
                    }
                    if (!exists)
                        multiSelectForm.AddMSItem(((ExternalPharmacy)externalPharmacys[i]).Name, ((ExternalPharmacy)externalPharmacys[i]).Name, ((ExternalPharmacy)externalPharmacys[i]));
                }
            }
            else
            {
                List<ExternalPharmacy> externalPharmacys = ExternalPharmacy.GetAvaliblePharmacy(Common.RecTime());
                for (int i = 0; i < externalPharmacys.Count; i++)
                {
                    bool exists = false;
                    foreach (PharmacyDetail detail in _PrescriptionDistribute.PharmacyDetails)
                    {
                        if (detail.PharmacyGuid.ToString() == ((ExternalPharmacy)externalPharmacys[i]).ObjectID.ToString())
                            exists = true;
                    }
                    if (!exists)
                        multiSelectForm.AddMSItem(((ExternalPharmacy)externalPharmacys[i]).Name, ((ExternalPharmacy)externalPharmacys[i]).Name, ((ExternalPharmacy)externalPharmacys[i]));
                }
            }
            string key = multiSelectForm.GetMSItem(ParentForm ,"İşlem yapacağınız sınıfı seçin");
            
            if (!string.IsNullOrEmpty(key))
            {
                externalPharmacy  = multiSelectForm.MSSelectedItemObject as ExternalPharmacy;
                BindingList<ExternalPharmacyDistributionTerm> openterm = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_PrescriptionDistribute.ObjectContext); 
                double totalPrice = 0 ;
                double prescriptionCount = 0;
                foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in externalPharmacy.PrescriptionTransactions.Select("DISTRIBUTIONTERM ='" + openterm[0].ObjectID.ToString() + "'"))
                {
                    totalPrice = totalPrice +(double)prescriptionTransaction.Price;
                    if (prescriptionTransaction.Price > 0)
                    {
                        prescriptionCount++;
                    }
                }
                PharmacyDetail pharmacyDetail = new PharmacyDetail(context);
                pharmacyDetail.Pharmacy = externalPharmacy.Name.ToString();
                pharmacyDetail.PharmacyGuid = externalPharmacy.ObjectID.ToString() ;
                pharmacyDetail.Balance = totalPrice;
                pharmacyDetail.PrescriptionCount = prescriptionCount;
                pharmacyDetail.PrescriptionDistribute = _PrescriptionDistribute ;
            }
#endregion PrescriptionDistributeNewForm_cmdSelectPharmacy_Click
        }

        private void PharmacyCountCombo_SelectedIndexChanged()
        {
#region PrescriptionDistributeNewForm_PharmacyCountCombo_SelectedIndexChanged
   if(PharmacyCountCombo.Text != "")
            {
                TTObjectContext context = _PrescriptionDistribute.ObjectContext ;
                ((ITTGrid)this.PharmacyDetails).Rows.Clear();
                this.cmdSelectPharmacy.Enabled = false;
                Hashtable unSortedPharmacyList = new Hashtable();
                if (Common.RecTime().Hour >= 17)
                {
                    List<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetNightPharmacy(Common.RecTime());
                    foreach (ExternalPharmacy externalPharmacy in myExternalPharmacy)
                    {
                        Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
                        pharmacyListItem.ID = externalPharmacy.ObjectID.ToString();
                        BindingList<ExternalPharmacyDistributionTerm> openTerm = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_PrescriptionDistribute.ObjectContext);
                        double totalPrice = 0;
                        foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in externalPharmacy.PrescriptionTransactions.Select("DISTRIBUTIONTERM = '" + openTerm[0].ObjectID.ToString() + "'"))
                        {
                            totalPrice = totalPrice + (double)prescriptionTransaction.Price;
                        }
                        pharmacyListItem.Value = totalPrice;
                        unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
                    }
                }
                else
                {
                    List<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetAvaliblePharmacy(Common.RecTime()) ;
                    foreach (ExternalPharmacy externalPharmacy in myExternalPharmacy)
                    {
                        Common.TTDoubleSortableList pharmacyListItem = new Common.TTDoubleSortableList();
                        pharmacyListItem.ID = externalPharmacy.ObjectID.ToString();
                        BindingList<ExternalPharmacyDistributionTerm> openTerm = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_PrescriptionDistribute.ObjectContext);
                        double totalPrice = 0;
                        foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in externalPharmacy.PrescriptionTransactions.Select("DISTRIBUTIONTERM = '" + openTerm[0].ObjectID.ToString() + "'"))
                        {
                            totalPrice = totalPrice + (double)prescriptionTransaction.Price;
                        }
                        pharmacyListItem.Value = totalPrice;
                        unSortedPharmacyList.Add(pharmacyListItem.ID, pharmacyListItem);
                    }
                }
                List<Common.TTDoubleSortableList> pharmacyList = Common.SortedDoubleItems(unSortedPharmacyList);

                for (int i = 0; i < Convert.ToInt64(this.PharmacyCountCombo.Text); i++)
                {
                    Guid pharmacyGuid = new Guid(pharmacyList[i].ID.ToString());
                    ExternalPharmacy sortedExternalPharmacy = (ExternalPharmacy) context.GetObject(pharmacyGuid, "EXTERNALPHARMACY");
                    
                    PharmacyDetail pharmacyDetail = new PharmacyDetail(context);
                    pharmacyDetail.Pharmacy = sortedExternalPharmacy.Name.ToString();
                    pharmacyDetail.Balance = pharmacyList[i].Value;
                    pharmacyDetail.PharmacyGuid = pharmacyList[i].ID.ToString();
                    pharmacyDetail.PrescriptionDistribute = _PrescriptionDistribute;
                    
                    BindingList<ExternalPharmacyDistributionTerm> openPharmacyTerm = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_PrescriptionDistribute.ObjectContext);
                    double prescriptionCount = 0;
                    foreach (ExternalPharmacyPrescriptionTransaction prescriptionTransaction in sortedExternalPharmacy.PrescriptionTransactions.Select("DISTRIBUTIONTERM = '" + openPharmacyTerm[0].ObjectID.ToString() + "'"))
                    {
                        if(prescriptionTransaction.Price > 0)
                        {
                            prescriptionCount ++ ;
                        }
                    }
                    pharmacyDetail.PrescriptionCount = prescriptionCount ;
                }
            }
            else
            {
                ((ITTGrid)this.PharmacyDetails).Rows.Clear();
                this.cmdSelectPharmacy.Enabled = true;
            }
#endregion PrescriptionDistributeNewForm_PharmacyCountCombo_SelectedIndexChanged
        }

        private void cmdClear_Click()
        {
#region PrescriptionDistributeNewForm_cmdClear_Click
   this.DistributeDetails.Rows.Clear();
            this.PharmacyDetails.Rows.Clear();
            this.PharmacyCountCombo .Enabled = true;
            this.cmdSelectPharmacy.Enabled = true;
            this.PharmacyCountCombo.Text = "";
            this.cmdDistribute.Enabled = true ;

            this.PrescriptionDateTime.NullableValue = DateTime.Today;
            if (Common.RecTime().Hour >= 17)
            {
                IList<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetNightPharmacy(Common.RecTime());
                PharmacyCountCombo.Items.Add(new TTComboBoxItem("", 0));
                for (int i = 0; i < myExternalPharmacy.Count; i++)
                {
                    int count = i + 1;
                    PharmacyCountCombo.Items.Add(new TTComboBoxItem(count.ToString(), i + 1));
                }
            }
            else
            {
                IList<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetAvaliblePharmacy(Common.RecTime());
                PharmacyCountCombo.Items.Add(new TTComboBoxItem("", 0));
                for (int i = 0; i < myExternalPharmacy.Count; i++)
                {
                    int count = i + 1;
                    PharmacyCountCombo.Items.Add(new TTComboBoxItem(count.ToString(), i + 1));
                }
            }
#endregion PrescriptionDistributeNewForm_cmdClear_Click
        }

        private void cmdSelect_Click()
        {
#region PrescriptionDistributeNewForm_cmdSelect_Click
   if(_PrescriptionDistribute.PrescriptionDetails.Count > 0)
            {
                foreach(PrescriptionDetail detail in _PrescriptionDistribute.PrescriptionDetails)
                {
                    detail.Distribute = true ;
                }
            }
#endregion PrescriptionDistributeNewForm_cmdSelect_Click
        }

        private void cmdUnSelect_Click()
        {
#region PrescriptionDistributeNewForm_cmdUnSelect_Click
   if(_PrescriptionDistribute.PrescriptionDetails.Count > 0)
            {
                foreach(PrescriptionDetail detail in _PrescriptionDistribute.PrescriptionDetails)
                {
                    detail.Distribute = false ;
                }
            }
#endregion PrescriptionDistributeNewForm_cmdUnSelect_Click
        }

        private void PrescriptionDateTime_ValueChanged()
        {
#region PrescriptionDistributeNewForm_PrescriptionDateTime_ValueChanged
   this.PrescriptionDetails.Rows.Clear();
            PrescriptionDistribute pd = _PrescriptionDistribute ;
            TTObjectContext context = _PrescriptionDistribute.ObjectContext;
            
            DateTime startDate = Convert.ToDateTime(this.PrescriptionDateTime.NullableValue.Value.ToShortDateString() + " 00:00:00");
            DateTime endDate = Convert.ToDateTime(this.PrescriptionDateTime.NullableValue.Value.ToShortDateString()+" 23:59:59");
            
            IList myPrescriptions = Prescription.GetPrescription(context, startDate, endDate);
            if ( myPrescriptions.Count>0 )
            {
                foreach (Prescription prescription in myPrescriptions)
                {
                   /* if(prescription.DistributeDetail.Count == 0)
                    {
                        if(prescription is InpatientPrescription)
                        {
                            if(prescription.CurrentStateDefID == InpatientPrescription.States.ExternalPharmacySupply & ((InpatientPrescription)prescription).ExternalPharmacy == null)
                            {
                                PrescriptionDetail prescriptionDetail = new PrescriptionDetail(context);
                                prescriptionDetail.Distribute = false;
                                prescriptionDetail.PrescriptionType = "Yatan Hasta";
                                if (prescription.PrescriptionPaper != null)
                                    prescriptionDetail.PrescriptionNo = prescription.PrescriptionPaper.SerialNo + " - " + prescription.PrescriptionPaper.VolumeNo; 
                                prescriptionDetail.PatientName = prescription.Episode.Patient.FullName.ToString();
                                prescriptionDetail.DistributionNo = prescription.DistributionNo ;
                           /*     if(prescription.Episode.Patient.MilitaryUnit != null)
                                {
                                    prescriptionDetail.PatientMilitaryUnit = prescription.Episode.Patient.MilitaryUnit.Name.ToString();
                                }
                                prescriptionDetail.QuarantineNo = Convert.ToInt32(prescription.Episode.InpatientAdmissions[0].QuarantineProtocolNo.Value) ;
                                prescriptionDetail.ProtocolNo = prescription.Episode.HospitalProtocolNo.Value ;
                                prescriptionDetail.Resource = prescription.MasterResource.Name.ToString();
                                prescriptionDetail.Price = prescription.PrescriptionPrice ;
                                prescriptionDetail.PrescriptionGuid = prescription.ObjectID.ToString();
                                pd.PrescriptionDetails.Add(prescriptionDetail);
                            }
                            
                        }
                        if(prescription is OutPatientPrescription)
                        {
                            if(prescription.CurrentStateDefID == OutPatientPrescription.States.ExternalPharmacySupply & ((OutPatientPrescription)prescription).ExternalPharmacy == null)
                            {
                                PrescriptionDetail prescriptionDetail = new PrescriptionDetail(context);
                                prescriptionDetail.Distribute = false;
                                prescriptionDetail.PrescriptionType = "Ayaktan Hasta";
                                if (prescription.PrescriptionPaper != null)
                                    prescriptionDetail.PrescriptionNo = prescription.PrescriptionPaper.SerialNo + " - " + prescription.PrescriptionPaper.VolumeNo;
                                prescriptionDetail.PatientName = prescription.Episode.Patient.FullName.ToString();
                                prescriptionDetail.DistributionNo = prescription.DistributionNo ;
                              /*  if(prescription.Episode.Patient.MilitaryUnit != null)
                                {
                                    prescriptionDetail.PatientMilitaryUnit = prescription.Episode.Patient.MilitaryUnit.Name.ToString();
                                }
                                prescriptionDetail.QuarantineNo = 0 ;
                                prescriptionDetail.ProtocolNo = prescription.Episode.HospitalProtocolNo.Value ;
                                prescriptionDetail.Resource = prescription.MasterResource.Name.ToString();
                                prescriptionDetail.Price = prescription.PrescriptionPrice;
                                prescriptionDetail.PrescriptionGuid = prescription.ObjectID.ToString();
                                pd.PrescriptionDetails.Add(prescriptionDetail);
                            }
                            
                        }
                    }*/
                }
            }
#endregion PrescriptionDistributeNewForm_PrescriptionDateTime_ValueChanged
        }

        protected override void PreScript()
        {
#region PrescriptionDistributeNewForm_PreScript
    if(_PrescriptionDistribute.PrevState == null )
            {
                base.PreScript();
                this.PrescriptionDateTime.NullableValue = DateTime.Today;
                if (Common.RecTime().Hour >= 17)
                {
                    IList<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetNightPharmacy(Common.RecTime());
                    PharmacyCountCombo.Items.Add(new TTComboBoxItem("", 0));
                    for (int i = 0; i < myExternalPharmacy.Count; i++)
                    {
                        int count = i + 1;
                        PharmacyCountCombo.Items.Add(new TTComboBoxItem(count.ToString(), i + 1));
                    }
                }
                else
                {
                    IList<ExternalPharmacy> myExternalPharmacy = ExternalPharmacy.GetAvaliblePharmacy(Common.RecTime());
                    PharmacyCountCombo.Items.Add(new TTComboBoxItem("", 0));
                    for (int i = 0; i < myExternalPharmacy.Count; i++)
                    {
                        int count = i + 1;
                        PharmacyCountCombo.Items.Add(new TTComboBoxItem(count.ToString(), i + 1));
                    }
                }
            }
            else
            {
                this.PrescriptionDateTime.ReadOnly = true ;
                this.PharmacyCountCombo.Enabled = false;
            }
#endregion PrescriptionDistributeNewForm_PreScript

            }
                }
}
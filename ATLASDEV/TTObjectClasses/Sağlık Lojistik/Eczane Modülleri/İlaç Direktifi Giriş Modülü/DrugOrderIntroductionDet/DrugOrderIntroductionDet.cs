
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class DrugOrderIntroductionDet : TTObject
    {
        /// <summary>
        /// İlaç Hacmi
        /// </summary>
        public string VolumeUnit
        {
            get
            {
                try
                {
                    #region VolumeUnit_GetScript                    
                    if (Material != null && Material is DrugDefinition)
                    {
                        DrugDefinition drug = (DrugDefinition)Material;
                        if (drug.Volume != null && drug.Unit != null)
                            return drug.Volume.ToString() + " " + drug.Unit.Name;
                    }
                    return string.Empty;
                    #endregion VolumeUnit_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "VolumeUnit") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
                    #region VolumeUnit_SetScript                    
                    this["VolumeUnit"] = value;
                    #endregion VolumeUnit_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "VolumeUnit") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            /*if (this.Frequency.HasValue == false && this.DrugOrder.HospitalTimeSchedule != null)
            {
                SetFrequencyByHospitalTimeSchedule(this.DrugOrder.HospitalTimeSchedule);
            }*/
            #endregion PostInsert
        }

        [TTStorageManager.Attributes.TTSerializeProperty]
        public HospitalTimeSchedule HospitalTimeSchedule { get; set; }

        [TTStorageManager.Attributes.TTSerializeProperty]
        public Guid? HospitalTimeScheduleObjectID { get; set; }

        protected override void PreDelete()
        {
            #region PreDelete




            base.PreDelete();
            if (DrugOrder != null)
            {
                if (DrugOrder.Type == TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
                {
                    IList<InpatientDrugOrder> drugOrders = new List<InpatientDrugOrder>();
                    IList<InpatientPrescription> prescriptions = new List<InpatientPrescription>();
                    IList<InpatientPresDetail> inpatientPresDetails = new List<InpatientPresDetail>();
                    foreach (InpatientPresDetail detail in DrugOrderIntroduction.InpatientPresDetails)
                    {
                        if (detail.InpatientPrescription.PrescriptionType == ((DrugDefinition)Material).PrescriptionType)
                        {
                            foreach (InpatientDrugOrder drugOrder in detail.InpatientPrescription.InpatientDrugOrders)
                            {
                                if (drugOrder.DrugOrderID.Equals(DrugOrder.ObjectID))
                                    drugOrders.Add(drugOrder);
                            }


                            foreach (InpatientDrugOrder inDrugOrder in drugOrders)
                                ((ITTObject)inDrugOrder).Delete();


                            if (detail.InpatientPrescription.InpatientDrugOrders.Count == 0)
                            {
                                prescriptions.Add(detail.InpatientPrescription);
                                detail.InpatientPrescription = null;
                                inpatientPresDetails.Add(detail);
                            }

                            foreach (InpatientPrescription inPres in prescriptions)
                            {
                                ((ITTObject)inPres).Delete();
                                inPres.SPTSDiagnosises.ClearChildren();
                            }
                        }
                    }

                    foreach (InpatientPresDetail presDetail in inpatientPresDetails)
                        ((ITTObject)presDetail).Delete();
                }
                else
                    ((ITTObject)DrugOrder).Delete();

            }

            #endregion PreDelete
        }
        [TTStorageManager.Attributes.TTSerializeProperty]
        public int DetailCount { get; set; }

        [TTStorageManager.Attributes.TTSerializeProperty]
        public DateTime PlannedEndTime { get; set; }

        private void SetFrequencyByHospitalTimeSchedule(HospitalTimeSchedule timeSchedule)
        {
            switch (timeSchedule.Frequency)
            {
                case RefactoredFrequencyEnum.Q1H:
                    Frequency = FrequencyEnum.Q1H;
                    break;
                case RefactoredFrequencyEnum.Q2H:
                    Frequency = FrequencyEnum.Q2H;
                    break;
                case RefactoredFrequencyEnum.Q3H:
                    Frequency = FrequencyEnum.Q3H;
                    break;
                case RefactoredFrequencyEnum.Q4H:
                    Frequency = FrequencyEnum.Q4H;
                    break;
                case RefactoredFrequencyEnum.Q6H:
                    Frequency = FrequencyEnum.Q6H;
                    break;
                case RefactoredFrequencyEnum.Q8H:
                    Frequency = FrequencyEnum.Q8H;
                    break;
                case RefactoredFrequencyEnum.Q12H:
                    Frequency = FrequencyEnum.Q12H;
                    break;
                case RefactoredFrequencyEnum.Q24H:
                    Frequency = FrequencyEnum.Q24H;
                    break;
                default:
                    break;
            }
        }
    }
}
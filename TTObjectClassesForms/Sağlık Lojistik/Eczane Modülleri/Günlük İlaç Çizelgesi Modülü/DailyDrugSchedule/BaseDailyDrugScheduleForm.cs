
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
    public partial class BaseDailyDrugScheduleForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            DailyDrugPatientsGrid.CellContentClick += new TTGridCellEventDelegate(DailyDrugPatientsGrid_CellContentClick);
            DailyDrugOrderGetByDate.Click += new TTControlEventDelegate(DailyDrugOrderGetByDate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DailyDrugPatientsGrid.CellContentClick -= new TTGridCellEventDelegate(DailyDrugPatientsGrid_CellContentClick);
            DailyDrugOrderGetByDate.Click -= new TTControlEventDelegate(DailyDrugOrderGetByDate_Click);
            base.UnBindControlEvents();
        }


        private void DailyDrugOrderGetByDate_Click()
        {
            if (_DailyDrugSchedule.StartDate != null && _DailyDrugSchedule.EndDate != null)
            {
                List<DailyDrugPatient> dailyDrugPatients = DailyDrugSchedule.PrapareDailyDrugPatient(_DailyDrugSchedule.ObjectContext ,_DailyDrugSchedule.DestinationStore.ObjectID, (DateTime)_DailyDrugSchedule.StartDate, (DateTime)_DailyDrugSchedule.EndDate);
                if (dailyDrugPatients.Count > 0)
                {
                    this.ttdatetimepicker1.ReadOnly = true;
                    this.ttdatetimepicker2.ReadOnly = true;
                    this.DailyDrugOrderGetByDate.ReadOnly = true;
                }
                foreach (DailyDrugPatient dailyDrugPatient in dailyDrugPatients)
                    _DailyDrugSchedule.DailyDrugPatients.Add(dailyDrugPatient);
            }
            else
                InfoBox.Alert("Baþlangýç ve bitiþ tarihi dolu olmak zorundadýr", MessageIconEnum.ErrorMessage);
        }

        private void DailyDrugPatientsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {

            DailyDrugPatient patient = (DailyDrugPatient)this.DailyDrugPatientsGrid.Rows[rowIndex].TTObject;

            if (patient.IsCheck == false) // false oldugunda ekleme yapýlacak.
            {
                patient = DailyDrugSchedule.PrepareDrugDetail(_DailyDrugSchedule.ObjectContext, patient, (DateTime)_DailyDrugSchedule.StartDate, (DateTime)_DailyDrugSchedule.EndDate);
                foreach (DailyDrugSchOrder order in patient.DailyDrugSchOrders)
                    _DailyDrugSchedule.DailyDrugSchOrders.Add(order);
                foreach (DailyDrugUnDrug unDrug in patient.DailyDrugUnDrugs)
                    _DailyDrugSchedule.DailyDrugUnDrugs.Add(unDrug);  
            }
            if (patient.IsCheck == true)
            {
                this._DailyDrugSchedule.DailyDrugSchOrders.DeleteChildren();
                this._DailyDrugSchedule.DailyDrugUnDrugs.DeleteChildren();

            }
            _DailyDrugSchedule.ObjectContext.Update();

        }

        protected override void PreScript()
        {
            if (this.ttdatetimepicker1 != null)
            {
                TTDateTimePicker startDate = ((TTDateTimePicker)this.ttdatetimepicker1);
                startDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + "00:00:00");
            }
            if (this.ttdatetimepicker2 != null)
            {
                TTDateTimePicker endDate = ((TTDateTimePicker)this.ttdatetimepicker2);
                endDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + "23:59:59");
            }
        }
        /*
        #region BaseDailyDrugScheduleForm_Methods
        public static List<DailyDrugPatient> PrapareDailyDrugPatient(TTObjectContext context, Guid storeID, DateTime startDate, DateTime endDate)
        {

            //TTObjectContext context = new TTObjectContext(false);
            List<DailyDrugPatient> dailyDrugPatients = new List<DailyDrugPatient>();


            BindingList<DrugOrderDetail> myDrugOrderDetails = DrugOrderDetail.GetDrugOrderDetails(context, startDate, endDate, storeID);
            Dictionary<Guid, double> detailsHashtable = new Dictionary<Guid, double>();

            double totalAmount = 0;

            foreach (DrugOrderDetail drugOrderDetail in myDrugOrderDetails)
            {
                if (drugOrderDetail.DrugOrder != null && drugOrderDetail.Amount > 0)
                {
                    if (detailsHashtable.ContainsKey(drugOrderDetail.DrugOrder.ObjectID))
                    {
                        totalAmount = 0;
                        totalAmount = detailsHashtable[drugOrderDetail.DrugOrder.ObjectID];
                        totalAmount += (double)drugOrderDetail.Amount;
                        detailsHashtable[drugOrderDetail.DrugOrder.ObjectID] = totalAmount;
                    }
                    else
                    {
                        detailsHashtable.Add(drugOrderDetail.DrugOrder.ObjectID, (double)drugOrderDetail.Amount);
                    }
                }
            }

            foreach (KeyValuePair<Guid, double> de in detailsHashtable)
            {
                DrugOrder drugOrder = (DrugOrder)context.GetObject(de.Key, typeof(DrugOrder));
                IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                if (dailyDrugPatients.Select(t => t.Patient == drugOrder.Episode.Patient).FirstOrDefault())
                {
                    DailyDrugPatient findDailyDrugPatient = dailyDrugPatients.Where(t => t.Patient == drugOrder.Episode.Patient).FirstOrDefault();


                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugPatientOrderDet dailyDrugPatientOrderDet = new DailyDrugPatientOrderDet(context);
                        dailyDrugPatientOrderDet.DrugOrderDetail = drugOrderDetail;
                        findDailyDrugPatient.DailyDrugPatientOrderDets.Add(dailyDrugPatientOrderDet);
                    }
                }
                else
                {
                    DailyDrugPatient dailyDrugPatient = new DailyDrugPatient(context);
                    dailyDrugPatient.Patient = drugOrder.Episode.Patient;
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugPatientOrderDet dailyDrugPatientOrderDet = new DailyDrugPatientOrderDet(context);
                        dailyDrugPatientOrderDet.DrugOrderDetail = drugOrderDetail;
                        dailyDrugPatient.DailyDrugPatientOrderDets.Add(dailyDrugPatientOrderDet);
                    }
                    dailyDrugPatients.Add(dailyDrugPatient);
                }
            }

            return dailyDrugPatients;
        }


        public static DailyDrugPatient PrepareDrugDetail(TTObjectContext context,DailyDrugPatient dailyDrugPatient, DateTime startDate, DateTime endDate)
        {
            //TTObjectContext context = new TTObjectContext(false);


            List<DrugOrderDetail> allDrugOrderDetails = new List<DrugOrderDetail>();
            foreach (DailyDrugPatientOrderDet det in dailyDrugPatient.DailyDrugPatientOrderDets)
                allDrugOrderDetails.Add(det.DrugOrderDetail);

            Dictionary<Guid, double> detailsHashtable = new Dictionary<Guid, double>();

            double totalAmount = 0;

            foreach (DrugOrderDetail drugOrderDetail in allDrugOrderDetails)
            {
                if (drugOrderDetail.DrugOrder != null && drugOrderDetail.Amount > 0)
                {
                    if (detailsHashtable.ContainsKey(drugOrderDetail.DrugOrder.ObjectID))
                    {
                        totalAmount = 0;
                        totalAmount = detailsHashtable[drugOrderDetail.DrugOrder.ObjectID];
                        totalAmount += (double)drugOrderDetail.Amount;
                        detailsHashtable[drugOrderDetail.DrugOrder.ObjectID] = totalAmount;
                    }
                    else
                    {
                        detailsHashtable.Add(drugOrderDetail.DrugOrder.ObjectID, (double)drugOrderDetail.Amount);
                    }
                }
            }

            foreach (KeyValuePair<Guid, double> de in detailsHashtable)
            {
                double restDose = 0;
                List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                DrugOrder drugOrder = (DrugOrder)context.GetObject(de.Key, typeof(DrugOrder));


                Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(drugOrder.Material, drugOrder.Episode);
                foreach (KeyValuePair<object, double> rest in rests)
                {
                    restDose = restDose + rest.Value;
                }

                if (restDose == 0)
                {
                    double rAmount = de.Value;
                    DailyDrugSchOrder schOrder = new DailyDrugSchOrder(context);
                    schOrder.Material = drugOrder.Material;
                    schOrder.DoseAmount = rAmount;
                    schOrder.DailyDrugPatient = dailyDrugPatient;
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugSchOrderDetail schdetail = new DailyDrugSchOrderDetail(context);
                        schdetail.DrugOrderDetail = drugOrderDetail;
                        schdetail.DailyDrugSchOrder = schOrder;
                    }
                    dailyDrugPatient.DailyDrugSchOrders.Add(schOrder);
                }

                if (restDose > 0 && restDose < (double)de.Value)
                {
                    double rAmount = (double)de.Value - restDose;
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                    List<DrugOrderDetail> schOrderDetails = new List<DrugOrderDetail>();
                    double schamount = 0;
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                        if (rAmount >= detail.Amount)
                        {
                            rAmount -= (double)drugOrderDetail.Amount;
                            schOrderDetails.Add(drugOrderDetail);
                            schamount += (double)drugOrderDetail.Amount;
                        }
                        else
                        {
                            unListDetails.Add(drugOrderDetail);
                        }
                    }

                    DailyDrugSchOrder schOrder = new DailyDrugSchOrder(context);
                    schOrder.Material = drugOrder.Material;
                    schOrder.DoseAmount = schamount;
                    schOrder.DailyDrugPatient = dailyDrugPatient;

                    foreach (DrugOrderDetail orderDetail in schOrderDetails)
                    {
                        DailyDrugSchOrderDetail schdetail = new DailyDrugSchOrderDetail(context);
                        schdetail.DrugOrderDetail = orderDetail;
                        schdetail.DailyDrugSchOrder = schOrder;
                    }
                    dailyDrugPatient.DailyDrugSchOrders.Add(schOrder);
                }

                if (restDose > 0 && restDose >= (double)de.Value)
                {
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                        unListDetails.Add(drugOrderDetail);
                    }
                }

                if (unListDetails.Count > 0)
                {

                    DailyDrugUnDrug undrug = new DailyDrugUnDrug(context);
                    undrug.Material = drugOrder.Material;
                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                    if (drugType)
                    {
                        undrug.DoseAmount = restDose;
                        undrug.UnlistVolume = restDose * ((DrugDefinition)drugOrder.Material).Volume;
                    }
                    else
                    {
                        undrug.DoseAmount = restDose / ((DrugDefinition)drugOrder.Material).Volume;
                        undrug.UnlistVolume = restDose;
                    }

                    undrug.DailyDrugPatient = dailyDrugPatient;
                    foreach (DrugOrderDetail unDrugDetail in unListDetails)
                    {
                        DailyDrugUnDrugDet unDetail = new DailyDrugUnDrugDet(context);
                        unDetail.DrugOrderDetail = unDrugDetail;
                        unDetail.DailyDrugUnDrug = undrug;

                    }
                }
            }
            return dailyDrugPatient;
        }
        #endregion BaseDailyDrugScheduleForm_Methods
        */
    }
}
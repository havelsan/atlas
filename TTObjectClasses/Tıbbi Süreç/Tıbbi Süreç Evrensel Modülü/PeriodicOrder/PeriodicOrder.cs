
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
    public  partial class PeriodicOrder : EpisodeAction, IAppointmentWithoutResources
    {
#region Methods
        public static double GetDetailCount  (FrequencyEnum? pFrequency)
        {
            if (pFrequency.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(615));
            FrequencyEnum Frequency = pFrequency.Value;

            double  detailCount = 0;

            switch (Frequency)
            {
                case FrequencyEnum.Q1H :
                    detailCount = 24;
                    break;
                case FrequencyEnum.Q2H :
                    detailCount = 12;
                    break;
                case FrequencyEnum.Q3H :
                    detailCount = 8;
                    break;
                case FrequencyEnum.Q4H :
                    detailCount = 6;
                    break;
                case FrequencyEnum.Q6H :
                    detailCount = 4;
                    break;
                case FrequencyEnum.Q8H :
                    detailCount = 3;
                    break;
                case FrequencyEnum.Q12H :
                    detailCount = 2;
                    break;
                case FrequencyEnum.Q24H :
                    detailCount = 1;
                    break;
                default:
                    throw new TTException(SystemMessage.GetMessage(983));
            }

            return detailCount;
        }
        
        public static double GetDetailTimePeriod(FrequencyEnum? pFrequency)
        {
            if (pFrequency.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(615));
            FrequencyEnum Frequency = pFrequency.Value;

            double detailTimePeriod = 0;

            switch (Frequency)
            {
                case FrequencyEnum.Q1H :
                    detailTimePeriod = 1;
                    break;
                case FrequencyEnum.Q2H :
                    detailTimePeriod = 2;
                    break;
                case FrequencyEnum.Q3H :
                    detailTimePeriod = 3;
                    break;
                case FrequencyEnum.Q4H :
                    detailTimePeriod = 4;
                    break;
                case FrequencyEnum.Q6H :
                    detailTimePeriod = 6;
                    break;
                case FrequencyEnum.Q8H :
                    detailTimePeriod = 8;
                    break;
                case FrequencyEnum.Q12H :
                    detailTimePeriod = 12;
                    break;
                case FrequencyEnum.Q24H :
                    detailTimePeriod = 24;
                    break;
                default:
                    throw new TTException(SystemMessage.GetMessage(983));
            }

            return detailTimePeriod;
        }
        
        public virtual PeriodicOrderDetail CreateOrderDetail()
        {
            //Bu metod PeriodicOrder türetilmiş tüm classlarda override edilmeli
            return null;
        }

        public static List<PeriodicOrderDetail> CreateOrderDetails(PeriodicOrder periodicOrder)
        {
            double totalAmount = 0;
            double detailCount = GetDetailCount(periodicOrder.Frequency);
            double detailTimePeriod = GetDetailTimePeriod(periodicOrder.Frequency);
            double unitAmount = 0;
            List<PeriodicOrderDetail> periodicOrderDetailList = new List<PeriodicOrderDetail>();
            if (periodicOrder.RecurrenceDayAmount != null && periodicOrder.RecurrenceDayAmount > 0)
                detailCount = detailCount * (double)periodicOrder.RecurrenceDayAmount;
            if (periodicOrder.AmountForPeriod != null && periodicOrder.AmountForPeriod > 0)
                unitAmount = (double)periodicOrder.AmountForPeriod;
            else
                unitAmount = 1;
            totalAmount = unitAmount * (double)detailCount;
            detailTimePeriod = (detailTimePeriod * 60) / unitAmount;

            DateTime detailTime = (DateTime)periodicOrder.PeriodStartTime;
            TTObjectContext objContext = new TTObjectContext(false);
            for (int i = 0; i < totalAmount; i++)
            {
                PeriodicOrderDetail orderDetail = periodicOrder.CreateOrderDetail();
                if (orderDetail != null)
                {
                    objContext = periodicOrder.ObjectContext != null ? periodicOrder.ObjectContext : objContext;

                    AppointmentWithoutResource appointmentWithoutResource = new AppointmentWithoutResource(objContext);
                    appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.New;
                    appointmentWithoutResource.AppDateTime = Convert.ToDateTime(detailTime);
                    orderDetail.WorkListDate = Convert.ToDateTime(detailTime);
                    orderDetail.PricingDate = orderDetail.WorkListDate;
                    orderDetail.AppointmentWithoutResources.Add(appointmentWithoutResource);
                    periodicOrderDetailList.Add(orderDetail);
                }
                detailTime = detailTime.AddMinutes(detailTimePeriod);
            }
            return periodicOrderDetailList;
        }

        public virtual void CreateOrderDetails()
        {
            double totalAmount = 0;
            double detailCount = GetDetailCount(Frequency);
            double detailTimePeriod = GetDetailTimePeriod(Frequency);
            double unitAmount = 0 ;
            
            if(RecurrenceDayAmount != null && RecurrenceDayAmount > 0)
                detailCount = detailCount * (double)RecurrenceDayAmount;
            if(AmountForPeriod != null && AmountForPeriod > 0)
                unitAmount = (double)AmountForPeriod ;
            else
                unitAmount = 1;
            totalAmount = unitAmount * (double)detailCount;
            detailTimePeriod = (detailTimePeriod*60)/unitAmount;

            DateTime detailTime = (DateTime)PeriodStartTime ;
            
            for (int i = 0; i < totalAmount ; i++)
            {
                PeriodicOrderDetail orderDetail = CreateOrderDetail();
                //bool control = (i==0 && this.OrderDetails.Count == 0)
                //if (orderDetail!=null && i >= this.OrderDetails.Count)//clientdan detylar doldurulmadan gelen orderlar için
                //{
                if (orderDetail != null)
                {
                    AppointmentWithoutResource appointmentWithoutResource = new AppointmentWithoutResource(ObjectContext);
                    appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.New;
                    appointmentWithoutResource.AppDateTime = Convert.ToDateTime(detailTime);
                    orderDetail.WorkListDate = Convert.ToDateTime(detailTime);
                    orderDetail.PricingDate = orderDetail.WorkListDate;
                    orderDetail.AppointmentWithoutResources.Add(appointmentWithoutResource);
                    OrderDetails.Add(orderDetail);
                }
                //}
                //else// detayları clientta  dolan orderlar için (Hemşirte direktif)
                //{
                //    AppointmentWithoutResource appointmentWithoutResource = new AppointmentWithoutResource(this.ObjectContext);
                //    appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.New;
                //    appointmentWithoutResource.AppDateTime = Convert.ToDateTime(this.OrderDetails[i].WorkListDate);
                //    this.OrderDetails[i].AppointmentWithoutResources.Add(appointmentWithoutResource);

                //    //((NursingOrderDetail)this.OrderDetails[i]).NursingApplication = ((NursingOrderDetail)orderDetail).NursingApplication;
                //}
                detailTime = detailTime.AddMinutes(detailTimePeriod);
                
                
                //                DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                //                drugOrderDetail.Material = (Material)drugOrder.Material  ;
                //                drugOrderDetail.MasterResource = drugOrder.MasterResource ;
                //                drugOrderDetail.FromResource = drugOrder.FromResource ;
                //                drugOrderDetail.Episode = drugOrder.Episode ;
                //                drugOrderDetail.ActionDate = drugOrder.ActionDate;// Bu actionun açıldığı tarih olmalı. SS
                //                drugOrderDetail.OrderPlannedDate = detailTime ;
                //                detailTime = detailTime.AddHours(detailTimePeriod);
                //                drugOrderDetail.Amount = unitAmount ;
                //                drugOrderDetail.Day = drugOrder.Day ;
                //                drugOrderDetail.DoseAmount = drugOrder.DoseAmount ;
                //                drugOrderDetail.Frequency = drugOrder.Frequency;
                //                drugOrderDetail.UsageNote = drugOrder.UsageNote ;
                //                drugOrderDetail.DrugOrder = drugOrder;
                //                drugOrderDetail.ID = 3000 + i;
                //                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                
                
            }
        }
        
#endregion Methods

    }
}
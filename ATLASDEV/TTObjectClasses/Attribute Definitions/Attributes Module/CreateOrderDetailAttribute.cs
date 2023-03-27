
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
    public partial class CreateOrderDetailAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            try
            {
                if (Interface.GetMyPlannedAction().IsOldAction != true)
                {
                    int j = Convert.ToInt32(Interface.GetMyPlannedAction().Amount);
                    int i = 0;
                    int k = 0;


                    while (i < j)
                    {
                        DateTime treatmentStartDateTime = Interface.GetMyPlannedAction().TreatmentStartDateTime.Value;
                        DateTime workListDate = treatmentStartDateTime.AddDays(k);
                        bool bayramMi = false;
                        if (workListDate.DayOfWeek != DayOfWeek.Saturday && workListDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            BindingList<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class> holidayList = TTObjectClasses.WorkDayExceptionDef.GetWorkDayExcesptionsQuery();
                            foreach (WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class item in holidayList)
                            {
                                if (item.Date != null)
                                {
                                    if (item.Date.Value.Date == workListDate.Date)
                                        bayramMi = true;
                                }
                            }
                            if (!bayramMi)
                            {
                                SubactionProcedureFlowable orderDetail = Interface.GetMyPlannedAction().CreateOrderDetail();
                                orderDetail.ActionDate = Common.RecTime();
                                orderDetail.MasterResource = (ResSection)Interface.GetMyPlannedAction().MasterResource;
                                orderDetail.FromResource = (ResSection)Interface.GetMyPlannedAction().FromResource;
                                orderDetail.Episode = Interface.GetMyPlannedAction().Episode;
                                orderDetail.ProcedureObject = Interface.GetMyPlannedAction().ProcedureObject;
                                orderDetail.Amount = 1;
                                BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)orderDetail).GetNextStateDefs();
                                if (states.Count > 0)
                                {
                                    orderDetail.CurrentStateDef = (TTObjectStateDef)states[0];
                                }
                                orderDetail.OrderObject = Interface.GetMyPlannedAction();
                                orderDetail.EpisodeAction = (EpisodeAction)Interface.GetMyPlannedAction().MasterAction;
                                orderDetail.WorkListDate = workListDate;
                                orderDetail.PricingDate = orderDetail.WorkListDate;
                                Interface.GetMyPlannedAction().CreateAppointmentForOrderDetail(orderDetail);
                                i++;
                            }
                        }
                        k++;
                    }
                }
            }
            catch
            {
                throw;
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
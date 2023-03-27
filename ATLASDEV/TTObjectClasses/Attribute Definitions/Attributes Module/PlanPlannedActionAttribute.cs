
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
    public partial class PlanPlannedActionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            try
            {
                if (Interface.GetMyNewAppointments().Count <= 0)
                    throw new Exception(SystemMessage.GetMessage(516));

                foreach (Appointment newAppointment in Interface.GetMyNewAppointments())
                {
                    SubactionProcedureFlowable orderDetail = Interface.GetMyPlannedAction().CreateOrderDetail(newAppointment);
                    orderDetail.ActionDate = Common.RecTime();
                    //orderDetail.ID = 1233; // bu alan daha sonra numberseed den alınmalı.
                    //orderDetail.ID.GetNextValue();
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
                    orderDetail.EpisodeAction = (EpisodeAction)Interface.GetMyPlannedAction();
                    orderDetail.WorkListDate = Convert.ToDateTime(newAppointment.StartTime);
                    orderDetail.PricingDate = Convert.ToDateTime(newAppointment.StartTime);

                    if (orderDetail.OrderObject.GetDefaultAppointmentResource() != null)
                    {
                        newAppointment.Resource = orderDetail.OrderObject.GetDefaultAppointmentResource();
                    }

                    newAppointment.SubActionProcedure = (SubActionProcedure)orderDetail;
                }
                foreach (PlannedAction plannedAction in Interface.GetMySiblingObjectListForAppointment())
                {
                    if (plannedAction.GetMyNewAppointments().Count > 0)
                    {
                        plannedAction.SetCurrentStateToTherapy();
                        //plannedAction.ObjectContext.Update();
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
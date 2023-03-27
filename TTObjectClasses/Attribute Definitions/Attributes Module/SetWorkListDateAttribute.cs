
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
    public partial class SetWorkListDateAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if(Interface.GetNotSetWorklist())
                return;
            if (Interface.GetIsOldAction() == true)
                return;
            if(Interface is StockAction)
            {
                Interface.SetWorkListDate(TTObjectDefManager.ServerTime);
                return;
            }
            else
            {
                bool setStaticWorkListDate = false;
                if(Interface is InPatientTreatmentClinicApplication)
                {
                    if(Interface.GetCurrentStateDefID() == InPatientTreatmentClinicApplication.States.Procedure)
                        setStaticWorkListDate = true;
                    else
                        setStaticWorkListDate = false;
                }
                else if(Interface is InPatientPhysicianApplication)
                {
                    //InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)ObjectContext.GetObject(Interface.ObjectID,"InPatientPhysicianApplication");
                    if((Interface.GetCurrentStateDefID() == InPatientPhysicianApplication.States.Application || Interface.GetCurrentStateDefID() == InPatientPhysicianApplication.States.PreDischarged) && ((InPatientPhysicianApplication)Interface).EmergencyIntervention == null)
                        setStaticWorkListDate = true;
                    else
                        setStaticWorkListDate = false;
                }
                else if(Interface is NursingApplication)
                {
                    // NursingApplication nursingApplication = (NursingApplication)ObjectContext.GetObject(Interface.ObjectID,"NursingApplication");
                    if((Interface.GetCurrentStateDefID() == NursingApplication.States.Application || Interface.GetCurrentStateDefID() == NursingApplication.States.PreDischarged) && ((NursingApplication)Interface).EmergencyIntervention == null)
                        setStaticWorkListDate = true;
                    else
                        setStaticWorkListDate = false;
                }
                else if (Interface is TreatmentDischarge)
                {
                    if (Interface.GetCurrentStateDefID() == TreatmentDischarge.States.New || Interface.GetCurrentStateDefID() == TreatmentDischarge.States.PreDischarge)
                        setStaticWorkListDate = true;
                    else
                        setStaticWorkListDate = false;
                }
                //TODO: ismail ileri tarihili istek yapılmasını isterlerse açıp düzenlenebilir
                //else if (Interface is OrthesisProsthesisRequest)
                //{
                //    if (Interface.CurrentStateDefID == OrthesisProsthesisRequest.States.Request || )
                //    {
                //        Interface.WorkListDate = ((EpisodeAction)Interface).RequestDate;
                //        return;
                //    }
                //}
                else if(Interface is Pathology)
                {
                    if (Interface.GetCurrentStateDefID() == Pathology.States.Report)
                    {
                        foreach (TTObjectState objectState in ((Pathology)Interface).GetStateHistory())
                        {
                            if(objectState.StateDefID == Pathology.States.Report)
                                Interface.SetWorkListDate(objectState.BranchDate);
                        }
                    }
                   
                    else if (Interface.GetCurrentStateDefID() == Pathology.States.Cancelled)
                    {
                        foreach (TTObjectState objectState in ((Pathology)Interface).GetStateHistory())
                        {
                            if (objectState.StateDefID == Pathology.States.Cancelled)
                                Interface.SetWorkListDate(objectState.BranchDate);
                        }
                    }
                    else
                    {
                        setStaticWorkListDate = false;
                    }
                }
                else if (Interface is Calibration)
                {
                    if (Interface.GetCurrentStateDefID() == Calibration.States.ForkNew)
                        return;
                }
                else if (Interface is Maintenance)
                {
                    if (Interface.GetCurrentStateDefID() == Maintenance.States.ForkNew)
                        return;
                }

                if(setStaticWorkListDate == true)
                {
                    Interface.SetWorkListDate(Common.MinDateTime());
                    return;
                }
                else
                {
                    // Action ve Subactionların İşlistesine gelecekleri tarihler varsa appointment tarihine göre yoksa appointmentWithoutResourcetraihine göre oda yoksa rectime olarak atılır.
                    if (Interface is IBaseAppointmentDef)
                    {
                        if (Interface.GetMyNewAppointments().Count > 0)
                        {
                            Interface.SetWorkListDate(Convert.ToDateTime(((Appointment)Interface.GetMyNewAppointments()[0]).StartTime));
                            return;
                        }
                    }
                    else if (Interface is IAppointmentWithoutResources)
                    {
                        DateTime workListDate = Common.RecTime();
                        foreach (AppointmentWithoutResource appointmentWithoutResource in Interface.GetAppointmentWithoutResources())
                        {
                            if (appointmentWithoutResource.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                            {
                                workListDate = Convert.ToDateTime(appointmentWithoutResource.AppDateTime);
                                break;
                            }
                        }
                        if (Interface is BaseNursingOrderDetails)//  Hemşire Ordersız Direktif girdiğinde Worklist dateini Clienttan alır
                        {
                            if (Interface.GetWorkListDate() == null)
                                Interface.SetWorkListDate(workListDate);
                        }
                        else
                            Interface.SetWorkListDate(workListDate);
                        return;
                    }
                }

                if (Interface is SubActionProcedure)  //İleri tarihli hizmet olusturuldugunda  WorkListDate tarihi CreationDate olur.
                {
                    if (((SubActionProcedure)Interface).CreationDate > Common.RecTime())
                    {
                        Interface.SetWorkListDate(((SubActionProcedure)Interface).CreationDate);
                        return;
                    }
                }

                Interface.SetWorkListDate(Common.RecTime());
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
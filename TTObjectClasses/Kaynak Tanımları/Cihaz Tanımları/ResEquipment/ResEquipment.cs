
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
    /// <summary>
    /// Cihaz
    /// </summary>
    public partial class ResEquipment : ResSection
    {
        public partial class GetEquipmentDefinition_Class : TTReportNqlObject
        {
        }

        public partial class VEM_CIHAZ_Class : TTReportNqlObject
        {
        }

        public static bool SendResEquipmentAppointment(Guid ResEquipmentAppointmentObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<ResEquipmentAppointment> resEquipmentApps = ResEquipmentAppointment.GetResEquipmentAppByObjectID(context, ResEquipmentAppointmentObjectID);
            if (resEquipmentApps != null && resEquipmentApps.Count > 0)
            {
                ResEquipmentAppointment resEquipmentApp = resEquipmentApps[0];

                BindingList<ResEquipment> resEquipments = ResEquipment.GETBYMKYSNO(context, resEquipmentApp.MkysNo);
                if (resEquipments != null && resEquipments.Count > 0)
                {
                    ResEquipment resEquipment = resEquipments[0];
                    DateTime appStartDate = Convert.ToDateTime(resEquipmentApp.StartDate.Value);
                    DateTime appEndDate = Convert.ToDateTime(resEquipmentApp.EndDate.Value);
                    BindingList<Appointment> appList = Appointment.GetByAppDateAndResource(context, appStartDate, appEndDate, resEquipment.ObjectID.ToString());
                    if (appList != null && appList.Count > 0)
                    {
                        foreach (Appointment app in appList)
                        {
                            if (app.CurrentStateDefID != Appointment.States.Cancelled)
                            {
                                if (resEquipmentApp.IsActive == true)
                                    app.ResEquipmentAppointment = resEquipmentApp;
                                else
                                    app.ResEquipmentAppointment = null;
                            }
                        }
                    }

                    BindingList<Schedule> schList = Schedule.GetByScheduleDateAndResource(context, appStartDate, appEndDate, resEquipment.ObjectID.ToString());
                    if (schList != null && schList.Count > 0)
                    {
                        foreach (Schedule sch in schList)
                        {
                            if (resEquipmentApp.IsActive == true)
                                sch.ResEquipmentAppointment = resEquipmentApp;
                            else
                                sch.ResEquipmentAppointment = null;
                        }
                    }
                    context.Save();
                    return true;
                }
            }
            return false;
        }
    }
}
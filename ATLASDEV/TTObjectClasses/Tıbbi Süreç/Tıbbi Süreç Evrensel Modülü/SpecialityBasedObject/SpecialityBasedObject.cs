
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
    public  partial class SpecialityBasedObject : TTObject
    {
        public List<AppointmentCarrier> MaternityAppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = null;

                appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.Maternity);

                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        appCarrier.DefaultAppointmentDefinition = appDef;
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "RESSURGERYDEPARTMENT";
                    carrier.SubResource = "RESSURGERYROOM";
                    carrier.RelationParentName = "SURGERYDEPARTMENT";
                    carrier.MasterResourceFilter = "this.Department.ResourceSpecialities(this.Speciality.Code in('3000')).EXISTS";
                    carrier.MasterResourceCaption = "Doğumhane";
                    carrier.SubResourceCaption = "Doğum Salonu";
                    carrier.AppointmentCount = 1;
                    carrier.AppointmentDuration = 15;
                    _appointmentList.Add(carrier);
                }
                
                return _appointmentList;
            }
        }
    }
}
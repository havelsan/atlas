
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
    public partial interface ISetWorkListDate : IAttributeInterface
    {
        bool? GetIsOldAction();

        void SetIsOldAction(bool? value);

        AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection GetAppointmentWithoutResources();

        BindingList<Appointment> GetMyNewAppointments();

        DateTime? GetWorkListDate();

        void SetWorkListDate(DateTime? value);

        bool GetNotSetWorklist(); 

        void SetNotSetWorklist(bool value);

        Guid? GetCurrentStateDefID();

        void SetCurrentStateDefID(Guid? value);
    }
}
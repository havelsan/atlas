
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormFollowUp : AppointmentFormBase
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTLabel LabelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("bee49d1b-86d9-480a-a7ee-a5626b0af6e0"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("3d6cbebe-b428-4ee6-842a-393726c11dce"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5d4f681d-f9bf-4417-a874-d411466152b2"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("65963aca-3467-4adc-8474-1d3505c8755c"));
            base.InitializeControls();
        }

        public AppointmentFormFollowUp() : base("FOLLOWUPEXAMINATION", "AppointmentFormFollowUp")
        {
        }

        protected AppointmentFormFollowUp(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
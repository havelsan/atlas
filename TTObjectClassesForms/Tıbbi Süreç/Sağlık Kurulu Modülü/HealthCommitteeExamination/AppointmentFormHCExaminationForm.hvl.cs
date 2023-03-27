
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
    public partial class AppointmentFormHCExamination : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExamination _HealthCommitteeExamination
        {
            get { return (TTObjectClasses.HealthCommitteeExamination)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("cce9263f-13da-48e1-9b5e-1c06f36b178e"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("a2d1cc96-72cc-4ede-815a-37ecc6de4db9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9c32770d-bfec-47fe-9e10-732c8604108b"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("7f303c90-a611-4b9d-be0e-0a002c48d4fc"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5f467f91-1a35-4a57-993e-6c1d9065bd85"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8771e8ff-b642-4ab3-8cba-a9252c51d3d4"));
            base.InitializeControls();
        }

        public AppointmentFormHCExamination() : base("HEALTHCOMMITTEEEXAMINATION", "AppointmentFormHCExamination")
        {
        }

        protected AppointmentFormHCExamination(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
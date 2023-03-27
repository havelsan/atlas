
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
    /// Randevu
    /// </summary>
    public partial class HCAppointmentForm : AppointmentFormBase
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("af8fdc9c-aebb-4d45-9126-e15c78cb491d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f1f84141-01a1-49b1-a6a1-97c8dda00885"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("20598417-9887-4cc6-94f2-29c93cea1a76"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5dec9cba-98d7-4346-b061-14bc3d1a4352"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("86a91442-2357-4cfa-9d3b-3a0a61cf673c"));
            base.InitializeControls();
        }

        public HCAppointmentForm() : base("HEALTHCOMMITTEE", "HCAppointmentForm")
        {
        }

        protected HCAppointmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
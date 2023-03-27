
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
    public partial class NursingAplicationDoctorForm : TTForm
    {
    /// <summary>
    /// Hemşirelik Hizmetlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.NursingApplication _NursingApplication
        {
            get { return (TTObjectClasses.NursingApplication)_ttObject; }
        }

        protected ITTLabel labelWorkListDate;
        protected ITTDateTimePicker WorkListDate;
        override protected void InitializeControls()
        {
            labelWorkListDate = (ITTLabel)AddControl(new Guid("cb49d6d3-51ee-4350-a868-9646837ec2ed"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("dd2ea54a-c7d6-4faa-872e-cdbc580ba288"));
            base.InitializeControls();
        }

        public NursingAplicationDoctorForm() : base("NURSINGAPPLICATION", "NursingAplicationDoctorForm")
        {
        }

        protected NursingAplicationDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
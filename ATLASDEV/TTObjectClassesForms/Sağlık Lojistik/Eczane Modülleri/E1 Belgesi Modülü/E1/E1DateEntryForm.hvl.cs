
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
    /// E1 Çizelgesi Periyot
    /// </summary>
    public partial class E1DateEntryForm : TTForm
    {
    /// <summary>
    /// E1 Çizelgesi
    /// </summary>
        protected TTObjectClasses.E1 _E1
        {
            get { return (TTObjectClasses.E1)_ttObject; }
        }

        protected ITTDateTimePicker StartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            StartDate = (ITTDateTimePicker)AddControl(new Guid("f9d32819-e94e-473f-acfd-c611e7ef2e9e"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("305b267a-6e7e-49de-a87b-a944817e1672"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("78ed2472-72b2-4340-aa4c-6fcf6bc063ca"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e1ffade3-5ea5-446e-9e50-92b426017e55"));
            base.InitializeControls();
        }

        public E1DateEntryForm() : base("E1", "E1DateEntryForm")
        {
        }

        protected E1DateEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
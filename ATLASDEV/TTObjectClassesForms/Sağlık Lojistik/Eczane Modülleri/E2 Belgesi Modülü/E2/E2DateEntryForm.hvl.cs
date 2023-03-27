
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
    /// E2 Çizelgesi Aylık  Periyot
    /// </summary>
    public partial class E2DateEntryForm : TTForm
    {
    /// <summary>
    /// E2 Belgesi
    /// </summary>
        protected TTObjectClasses.E2 _E2
        {
            get { return (TTObjectClasses.E2)_ttObject; }
        }

        protected ITTDateTimePicker StartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            StartDate = (ITTDateTimePicker)AddControl(new Guid("9bf6f5b1-048d-423f-9202-1e07c78dd8b2"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("16ca6e25-ee9a-41db-94c4-afa50214d25d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1c7cafc8-e9ee-4ae2-a5a7-d3c2e75efcc4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9c50b4bb-5e0c-4e80-88b3-9c57f1b93173"));
            base.InitializeControls();
        }

        public E2DateEntryForm() : base("E2", "E2DateEntryForm")
        {
        }

        protected E2DateEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
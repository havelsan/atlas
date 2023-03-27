
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
    public partial class PhototherapyForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.Phototherapy _Phototherapy
        {
            get { return (TTObjectClasses.Phototherapy)_ttObject; }
        }

        protected ITTLabel labelRequesterPerson;
        protected ITTObjectListBox RequesterPerson;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelProcessStartTime;
        protected ITTDateTimePicker ProcessStartTime;
        protected ITTLabel labelProcessEndTime;
        protected ITTDateTimePicker ProcessEndTime;
        protected ITTLabel labelProcessDate;
        protected ITTDateTimePicker ProcessDate;
        protected ITTCheckBox Complication;
        override protected void InitializeControls()
        {
            labelRequesterPerson = (ITTLabel)AddControl(new Guid("29b1b0b9-4e57-4a50-9b0a-e80f8684bdbd"));
            RequesterPerson = (ITTObjectListBox)AddControl(new Guid("34d0394a-6426-4e55-afed-8cc55be8aa1e"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("5d69c6c2-ad33-4963-a326-58ba5a93911b"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("6e014fc7-097b-494e-9a19-18fa1edf0487"));
            labelProcessStartTime = (ITTLabel)AddControl(new Guid("27f86dca-1fd6-42ac-aa7b-304d31e68055"));
            ProcessStartTime = (ITTDateTimePicker)AddControl(new Guid("55bffeae-ebfa-4589-9be4-b53414cef329"));
            labelProcessEndTime = (ITTLabel)AddControl(new Guid("3921d253-a1c3-45b4-acbf-399f6fd06db3"));
            ProcessEndTime = (ITTDateTimePicker)AddControl(new Guid("88596790-edba-4cd4-986b-59195af3ae32"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("6ab55cc3-22e2-40c6-81eb-1e9566ab2b66"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("5d2a66f7-8645-4199-a297-ce3fe6e38e13"));
            Complication = (ITTCheckBox)AddControl(new Guid("54daa8a1-c458-414a-b0f6-a120a79974bc"));
            base.InitializeControls();
        }

        public PhototherapyForm() : base("PHOTOTHERAPY", "PhototherapyForm")
        {
        }

        protected PhototherapyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
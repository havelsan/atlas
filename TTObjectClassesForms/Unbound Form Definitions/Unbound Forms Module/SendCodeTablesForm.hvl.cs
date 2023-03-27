
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
    /// Kod Tablolarını Gönderme
    /// </summary>
    public partial class SendCodeTablesForm : TTUnboundForm
    {
        protected ITTButton ttbutton1;
        protected ITTDateTimePicker startdate;
        protected ITTEnumComboBox SelectSendDataType;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton4;
        protected ITTButton ttbutton5;
        protected ITTButton ttbutton6;
        protected ITTButton ttbutton7;
        protected ITTButton ttbutton8;
        protected ITTButton ttbutton9;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("01459933-6652-480e-a2b5-f416559c0f21"));
            startdate = (ITTDateTimePicker)AddControl(new Guid("f0e62b6e-093e-4e94-948c-d458e7011f37"));
            SelectSendDataType = (ITTEnumComboBox)AddControl(new Guid("0ef2ee45-4da1-473e-840d-9f0471bfd8c7"));
            ttbutton2 = (ITTButton)AddControl(new Guid("4dab9d83-986a-4467-9f4e-77760c9eadb0"));
            ttbutton3 = (ITTButton)AddControl(new Guid("fb8cd9e6-3f9c-4cc3-a57e-e69467448d9a"));
            ttbutton4 = (ITTButton)AddControl(new Guid("afac4022-1dca-4d37-a8e0-7150d1ffa907"));
            ttbutton5 = (ITTButton)AddControl(new Guid("bc35d286-943a-4017-bc35-5b5b4a8e888a"));
            ttbutton6 = (ITTButton)AddControl(new Guid("83bb9c03-3490-4b71-93dd-16f76f9bfac4"));
            ttbutton7 = (ITTButton)AddControl(new Guid("4eed2545-90a5-4c3f-b581-87d870c248f6"));
            ttbutton8 = (ITTButton)AddControl(new Guid("44514bad-8467-4188-bbe4-b46c8c2c12c4"));
            ttbutton9 = (ITTButton)AddControl(new Guid("9ab3e77f-d624-4acb-b43d-b2c895d45990"));
            base.InitializeControls();
        }

        public SendCodeTablesForm() : base("SendCodeTablesForm")
        {
        }

        protected SendCodeTablesForm(string formDefName) : base(formDefName)
        {
        }
    }
}
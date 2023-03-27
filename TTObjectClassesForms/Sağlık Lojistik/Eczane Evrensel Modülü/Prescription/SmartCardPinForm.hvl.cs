
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
    public partial class SmartCardPinForm : PrescriptionBaseForm
    {
    /// <summary>
    /// Reçete Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.Prescription _Prescription
        {
            get { return (TTObjectClasses.Prescription)_ttObject; }
        }

        protected ITTComboBox cboCardList;
        protected ITTButton cmdPinOK;
        protected ITTTextBox SmartCardPin;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cboCardList = (ITTComboBox)AddControl(new Guid("4f27ff27-2117-4023-a3e9-4d88e941b320"));
            cmdPinOK = (ITTButton)AddControl(new Guid("0f99d2a5-e253-4457-843a-d1e08ea2ee7b"));
            SmartCardPin = (ITTTextBox)AddControl(new Guid("2d2d4396-89db-4e33-921c-65e51fae614c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("dc541ab2-9e06-4187-904b-f3dbe09e633d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("666df5e6-16ac-4b2e-aec3-b7d05b9b7958"));
            base.InitializeControls();
        }

        public SmartCardPinForm() : base("PRESCRIPTION", "SmartCardPinForm")
        {
        }

        protected SmartCardPinForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
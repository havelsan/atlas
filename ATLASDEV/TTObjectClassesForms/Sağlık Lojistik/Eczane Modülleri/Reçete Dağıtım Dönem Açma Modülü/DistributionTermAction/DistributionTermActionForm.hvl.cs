
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
    /// Reçete Dağıtım Dönem Açma
    /// </summary>
    public partial class DistributionTermActionForm : TTForm
    {
    /// <summary>
    /// Reçete Dağıtım Dönem Açma
    /// </summary>
        protected TTObjectClasses.DistributionTermAction _DistributionTermAction
        {
            get { return (TTObjectClasses.DistributionTermAction)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker OpenTermEndDate;
        protected ITTDateTimePicker OpenTermStartDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6136144d-1676-4d10-8199-40d1b2f49583"));
            OpenTermEndDate = (ITTDateTimePicker)AddControl(new Guid("0209f345-52c4-4fa3-94d7-06fa68ef6a16"));
            OpenTermStartDate = (ITTDateTimePicker)AddControl(new Guid("bda8fd45-8629-4db1-87e1-9b04360ea051"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d358a3ca-7b19-4db6-a8dd-27a57177944d"));
            labelID = (ITTLabel)AddControl(new Guid("88e4ccf4-a8b0-447e-b1d6-f22e909d666d"));
            ID = (ITTTextBox)AddControl(new Guid("aec1976f-132c-4b96-9860-b2ccb8a00084"));
            labelActionDate = (ITTLabel)AddControl(new Guid("3211df7e-0445-4457-8519-8b9ff98e68cd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2438b9a3-f0d1-4c97-88f2-ee2a4c407327"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bb322403-363f-4082-a498-a8d797fd9be0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bec8aa6a-95b7-47c2-9da6-fcb7bdf4a176"));
            base.InitializeControls();
        }

        public DistributionTermActionForm() : base("DISTRIBUTIONTERMACTION", "DistributionTermActionForm")
        {
        }

        protected DistributionTermActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
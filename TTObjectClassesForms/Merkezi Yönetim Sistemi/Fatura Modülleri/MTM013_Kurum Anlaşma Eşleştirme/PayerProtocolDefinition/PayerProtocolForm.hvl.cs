
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
    /// Kurum Anlaşma Eşleştirme
    /// </summary>
    public partial class PayerProtocol : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum anlasma eslestirme
    /// </summary>
        protected TTObjectClasses.PayerProtocolDefinition _PayerProtocolDefinition
        {
            get { return (TTObjectClasses.PayerProtocolDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox PROTOCOL;
        protected ITTObjectListBox PAYER;
        protected ITTDateTimePicker PROTOCOLENDDATE;
        protected ITTLabel labelProtocolEndDate;
        protected ITTLabel labelProtocolStartDate;
        protected ITTDateTimePicker PROTOCOLSTARTDATE;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("3fa2b886-d61a-4eaf-8406-6a4061c49904"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8cffbb1b-3a95-4ad6-a398-6c2d0cec0b46"));
            PROTOCOL = (ITTObjectListBox)AddControl(new Guid("16941b40-02b9-4222-9a9f-7312d11d6546"));
            PAYER = (ITTObjectListBox)AddControl(new Guid("bac2dfb1-35a6-45de-8a02-b8be1b61eb08"));
            PROTOCOLENDDATE = (ITTDateTimePicker)AddControl(new Guid("91f9ba5c-8d43-4e6e-abd9-bdd2d89fce56"));
            labelProtocolEndDate = (ITTLabel)AddControl(new Guid("c59dfa78-7650-460a-b566-c476e142c8e5"));
            labelProtocolStartDate = (ITTLabel)AddControl(new Guid("3343ff91-d303-41a7-9551-e95ca3932a59"));
            PROTOCOLSTARTDATE = (ITTDateTimePicker)AddControl(new Guid("d1d038c9-dbfb-4088-920e-f36ca22de5d4"));
            base.InitializeControls();
        }

        public PayerProtocol() : base("PAYERPROTOCOLDEFINITION", "PayerProtocol")
        {
        }

        protected PayerProtocol(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
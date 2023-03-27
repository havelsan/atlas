
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
    public partial class PCC_CompletedForm : TTForm
    {
    /// <summary>
    /// Hasta Sarf Giriş İptali
    /// </summary>
        protected TTObjectClasses.PatientConsumptionCancel _PatientConsumptionCancel
        {
            get { return (TTObjectClasses.PatientConsumptionCancel)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTGrid grdConsumptions;
        protected ITTTextBoxColumn EpisodeProtocolNo_Desc;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn CancelPC;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("f28e3ed2-43f7-4c4b-9a96-5e42e5dbccc2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("548562cb-1cfc-4c05-b79a-05969f367800"));
            grdConsumptions = (ITTGrid)AddControl(new Guid("729cef1c-e160-4d08-87c1-a8d89f890a2a"));
            EpisodeProtocolNo_Desc = (ITTTextBoxColumn)AddControl(new Guid("77b4c059-13b4-4b63-9c80-e1bb4ffcc57b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("51a8b96e-26cf-4266-921e-20bd189223c6"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b9b3030f-9592-4196-9a24-4dabc112ba84"));
            CancelPC = (ITTCheckBoxColumn)AddControl(new Guid("9f42b915-16e5-4fce-b9e9-3ff31475efdd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8212bdcc-6e8f-4ff8-8f45-5b165d651d8b"));
            base.InitializeControls();
        }

        public PCC_CompletedForm() : base("PATIENTCONSUMPTIONCANCEL", "PCC_CompletedForm")
        {
        }

        protected PCC_CompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
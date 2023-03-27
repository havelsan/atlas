
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
    public partial class SupplyRequestPoolCompletedForm : BaseSupplyRequestPoolForm
    {
    /// <summary>
    /// Satınalma Talep Havuzu
    /// </summary>
        protected TTObjectClasses.SupplyRequestPool _SupplyRequestPool
        {
            get { return (TTObjectClasses.SupplyRequestPool)_ttObject; }
        }

        protected ITTTextBox XXXXXXMesaj;
        protected ITTTextBox XXXXXXKayitId;
        protected ITTLabel labelXXXXXXMesaj;
        protected ITTButton ttSendToXXXXXX;
        protected ITTLabel labelXXXXXXKayitId;
        override protected void InitializeControls()
        {
            XXXXXXMesaj = (ITTTextBox)AddControl(new Guid("4a9aa82c-3c79-4bca-83bf-e12f977b4635"));
            XXXXXXKayitId = (ITTTextBox)AddControl(new Guid("ad9e6b9d-8291-4d71-b361-a17944e1bc0f"));
            labelXXXXXXMesaj = (ITTLabel)AddControl(new Guid("f7e7cdd7-b43a-4a36-9cb1-8e1ead6c224d"));
            ttSendToXXXXXX = (ITTButton)AddControl(new Guid("9883ab0a-9dff-4f43-8239-99df1ee53b30"));
            labelXXXXXXKayitId = (ITTLabel)AddControl(new Guid("eb03364a-476b-4d46-9e4b-35ec3dd780ae"));
            base.InitializeControls();
        }

        public SupplyRequestPoolCompletedForm() : base("SUPPLYREQUESTPOOL", "SupplyRequestPoolCompletedForm")
        {
        }

        protected SupplyRequestPoolCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
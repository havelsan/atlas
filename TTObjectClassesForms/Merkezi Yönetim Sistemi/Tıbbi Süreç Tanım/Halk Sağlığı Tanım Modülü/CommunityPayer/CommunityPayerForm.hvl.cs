
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
    public partial class CommunityPayerForm : TTDefinitionForm
    {
    /// <summary>
    /// Halk Sağlığı Kurum Tanımları
    /// </summary>
        protected TTObjectClasses.CommunityPayer _CommunityPayer
        {
            get { return (TTObjectClasses.CommunityPayer)_ttObject; }
        }

        protected ITTLabel labelTaxOffice;
        protected ITTTextBox TaxOffice;
        protected ITTTextBox TaxNumber;
        protected ITTTextBox Name;
        protected ITTTextBox Adress;
        protected ITTLabel labelTaxNumber;
        protected ITTLabel labelName;
        protected ITTLabel labelAdress;
        override protected void InitializeControls()
        {
            labelTaxOffice = (ITTLabel)AddControl(new Guid("b10b3148-5226-461e-9e50-11d3e3583b09"));
            TaxOffice = (ITTTextBox)AddControl(new Guid("c31d8cc8-7d2c-43db-956a-127135176778"));
            TaxNumber = (ITTTextBox)AddControl(new Guid("1bd82809-86b9-4371-8f9a-3955d39a402d"));
            Name = (ITTTextBox)AddControl(new Guid("03848292-e3ac-41b3-b803-0a67ae957837"));
            Adress = (ITTTextBox)AddControl(new Guid("7a238f93-768d-4251-8228-3580031a79fc"));
            labelTaxNumber = (ITTLabel)AddControl(new Guid("51b8ba5d-121a-4e6f-b2f4-b9e837aadd08"));
            labelName = (ITTLabel)AddControl(new Guid("1712b22c-044d-45b9-8896-0e0c9bf6a41a"));
            labelAdress = (ITTLabel)AddControl(new Guid("87e8eed4-6218-4b16-82ef-522c43cdb85c"));
            base.InitializeControls();
        }

        public CommunityPayerForm() : base("COMMUNITYPAYER", "CommunityPayerForm")
        {
        }

        protected CommunityPayerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
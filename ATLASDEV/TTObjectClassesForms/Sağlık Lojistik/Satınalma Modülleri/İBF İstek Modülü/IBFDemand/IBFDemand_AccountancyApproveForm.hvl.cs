
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
    /// Saymanlık Onay
    /// </summary>
    public partial class IBFDemand_AccountancyApproveForm : IBFDemand_BaseForm
    {
    /// <summary>
    /// İBF İstek Modülü ana sınıfıdır
    /// </summary>
        protected TTObjectClasses.IBFDemand _IBFDemand
        {
            get { return (TTObjectClasses.IBFDemand)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdApproveAll;
        protected ITTEnumComboBox IBFType;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel labelActionDate;
        protected ITTLabel IBFTypeLabel;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("2709a1b4-011b-466f-afb8-84a5ed271d90"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("6db12fc7-3eba-4895-92ad-da14256a158c"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("22131e0c-2adb-4d71-b81a-b0ec285790e5"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("4206b801-25d5-49b4-9f0b-1430411b4080"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a144d9e1-fa07-419a-8846-9821badc5002"));
            labelDescription = (ITTLabel)AddControl(new Guid("884b9c62-d25a-4f3c-9850-5719cd8985cd"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("38c24c56-acdb-48ce-8da7-ff2bd9f46b6a"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("8f56d7b4-69c6-4242-8b0d-7f6523301675"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4728e3fe-8ccf-4285-8914-daa1d0c87f34"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("b92ece71-0e19-4446-8aa7-48b88e62f904"));
            RequestNO = (ITTTextBox)AddControl(new Guid("f176e75d-1436-4b9b-9548-1cd402cbf9c5"));
            labelID = (ITTLabel)AddControl(new Guid("bdc2ff80-c9c8-4747-8a5a-fbba5dad0892"));
            Description = (ITTTextBox)AddControl(new Guid("38f2c206-8818-45b0-9859-7dfc7337465a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("db810dad-03c3-4ebc-99bc-ce587bf8db34"));
            base.InitializeControls();
        }

        public IBFDemand_AccountancyApproveForm() : base("IBFDEMAND", "IBFDemand_AccountancyApproveForm")
        {
        }

        protected IBFDemand_AccountancyApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
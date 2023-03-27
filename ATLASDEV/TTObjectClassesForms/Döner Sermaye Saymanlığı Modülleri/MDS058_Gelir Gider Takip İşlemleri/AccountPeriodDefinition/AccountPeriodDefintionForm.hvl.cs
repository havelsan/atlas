
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
    public partial class AccountPeriodDefintionForm : TTDefinitionForm
    {
        protected TTObjectClasses.AccountPeriodDefinition _AccountPeriodDefinition
        {
            get { return (TTObjectClasses.AccountPeriodDefinition)_ttObject; }
        }

        protected ITTLabel labelMonth;
        protected ITTEnumComboBox Month;
        protected ITTLabel labelYear;
        protected ITTTextBox Year;
        override protected void InitializeControls()
        {
            labelMonth = (ITTLabel)AddControl(new Guid("fbeae534-2b0c-41cb-ab6b-2817a9aa605e"));
            Month = (ITTEnumComboBox)AddControl(new Guid("83ee1d6c-44a5-4eec-bcd6-2d23a1841f73"));
            labelYear = (ITTLabel)AddControl(new Guid("2c0bb927-3c8b-43c7-8588-308f407af590"));
            Year = (ITTTextBox)AddControl(new Guid("965bd128-94f8-45d9-9f24-0369651875c7"));
            base.InitializeControls();
        }

        public AccountPeriodDefintionForm() : base("ACCOUNTPERIODDEFINITION", "AccountPeriodDefintionForm")
        {
        }

        protected AccountPeriodDefintionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
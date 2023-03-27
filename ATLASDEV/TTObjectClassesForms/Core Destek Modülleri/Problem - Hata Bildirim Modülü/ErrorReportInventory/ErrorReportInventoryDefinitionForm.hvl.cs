
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
    /// Problem / Hata Envanter Tanım Formu
    /// </summary>
    public partial class ErrorReportInventoryDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Problem / Hata Envanter Tanımı
    /// </summary>
        protected TTObjectClasses.ErrorReportInventory _ErrorReportInventory
        {
            get { return (TTObjectClasses.ErrorReportInventory)_ttObject; }
        }

        protected ITTCheckBox isActiveCheckBox;
        protected ITTLabel labelNo;
        protected ITTTextBox No;
        protected ITTTextBox Name;
        protected ITTTextBox Details;
        protected ITTLabel labelName;
        protected ITTLabel labelDetails;
        override protected void InitializeControls()
        {
            isActiveCheckBox = (ITTCheckBox)AddControl(new Guid("5a84222a-0b7f-46d5-8ae7-d94b98c6e3af"));
            labelNo = (ITTLabel)AddControl(new Guid("1203c29e-8ef9-4e25-8907-0416b8336ea7"));
            No = (ITTTextBox)AddControl(new Guid("c2282add-4617-41fe-ae6f-36e1cf4e93ec"));
            Name = (ITTTextBox)AddControl(new Guid("16dffa09-47bd-486e-aae4-1b84f87c2359"));
            Details = (ITTTextBox)AddControl(new Guid("d73e2754-6df7-499c-a047-6c987bbd63b6"));
            labelName = (ITTLabel)AddControl(new Guid("5f52e96b-b547-4c31-a5ba-79538ab4aab3"));
            labelDetails = (ITTLabel)AddControl(new Guid("7f4e4b4d-5983-45db-a930-686e3517ef53"));
            base.InitializeControls();
        }

        public ErrorReportInventoryDefinitionForm() : base("ERRORREPORTINVENTORY", "ErrorReportInventoryDefinitionForm")
        {
        }

        protected ErrorReportInventoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
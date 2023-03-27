
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
    /// Problem Hata Envanter Formu
    /// </summary>
    public partial class ErrorReportInventoryForm : TTForm
    {
    /// <summary>
    /// Problem / Hata Envanter Tanımı
    /// </summary>
        protected TTObjectClasses.ErrorReportInventory _ErrorReportInventory
        {
            get { return (TTObjectClasses.ErrorReportInventory)_ttObject; }
        }

        protected ITTLabel labelNo;
        protected ITTTextBox No;
        protected ITTTextBox Name;
        protected ITTTextBox Details;
        protected ITTLabel labelName;
        protected ITTLabel labelDetails;
        override protected void InitializeControls()
        {
            labelNo = (ITTLabel)AddControl(new Guid("23621174-9594-4d3d-817f-703c611a707c"));
            No = (ITTTextBox)AddControl(new Guid("61b36fae-27d1-4fd1-afe2-b920df320856"));
            Name = (ITTTextBox)AddControl(new Guid("3b5a5153-0ab3-4170-9395-715efda952da"));
            Details = (ITTTextBox)AddControl(new Guid("0b437619-ddc7-4f76-aea5-dafc2989643e"));
            labelName = (ITTLabel)AddControl(new Guid("ea1781b9-7430-44d2-aca4-cd57e0bf9710"));
            labelDetails = (ITTLabel)AddControl(new Guid("3ba74a12-3703-48c5-92e7-fe72cd021529"));
            base.InitializeControls();
        }

        public ErrorReportInventoryForm() : base("ERRORREPORTINVENTORY", "ErrorReportInventoryForm")
        {
        }

        protected ErrorReportInventoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
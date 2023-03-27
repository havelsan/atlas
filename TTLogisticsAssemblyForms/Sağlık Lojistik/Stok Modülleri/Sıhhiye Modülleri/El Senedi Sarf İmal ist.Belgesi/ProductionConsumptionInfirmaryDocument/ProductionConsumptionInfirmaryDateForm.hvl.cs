
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
    /// El Senedi Sarf Belgesi Tarih Giriş
    /// </summary>
    public partial class ProductionConsumptionInfirmaryDateForm : TTForm
    {
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionInfirmaryDocument _ProductionConsumptionInfirmaryDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionInfirmaryDocument)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("5739e548-4d36-4a21-8f7c-741c89a59d7c"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("6671d403-fcc3-424f-8aac-47999c8c6c2a"));
            labelEndDate = (ITTLabel)AddControl(new Guid("a402823b-828b-4d42-b5ad-8e687a64eb9e"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("32d98953-0d5b-4aea-8cd1-ef57460fc058"));
            base.InitializeControls();
        }

        public ProductionConsumptionInfirmaryDateForm() : base("PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT", "ProductionConsumptionInfirmaryDateForm")
        {
        }

        protected ProductionConsumptionInfirmaryDateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
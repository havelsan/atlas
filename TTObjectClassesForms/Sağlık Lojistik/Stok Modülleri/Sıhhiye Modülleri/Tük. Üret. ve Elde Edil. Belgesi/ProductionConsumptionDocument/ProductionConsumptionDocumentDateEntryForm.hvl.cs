
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
    public partial class ProductionConsumptionDocumentDateEntryForm : TTForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionDocument _ProductionConsumptionDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionDocument)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("4f170192-e779-4bba-9481-84ed545d0203"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("fba34826-4cb4-494b-9ab9-8e3935afa29e"));
            labelEndDate = (ITTLabel)AddControl(new Guid("0918b69b-eec2-462f-b071-b8b5d998c8fe"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("00f2ef67-b9ed-4078-a6c9-2000960a8bea"));
            base.InitializeControls();
        }

        public ProductionConsumptionDocumentDateEntryForm() : base("PRODUCTIONCONSUMPTIONDOCUMENT", "ProductionConsumptionDocumentDateEntryForm")
        {
        }

        protected ProductionConsumptionDocumentDateEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
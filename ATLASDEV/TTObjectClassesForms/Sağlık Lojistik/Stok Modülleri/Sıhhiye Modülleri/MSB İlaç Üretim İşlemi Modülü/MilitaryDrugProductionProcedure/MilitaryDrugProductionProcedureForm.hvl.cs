
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
    /// MSB İlaç Üretim İşlemi - Kalite Kontrol Hammadde
    /// </summary>
    public partial class MilitaryDrugProductionProcedureForm : MilitaryDrugProductionBaseForm
    {
    /// <summary>
    /// MSB İlaç Üretim İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MilitaryDrugProductionProcedure _MilitaryDrugProductionProcedure
        {
            get { return (TTObjectClasses.MilitaryDrugProductionProcedure)_ttObject; }
        }

        protected ITTButton ReviewInheldButton;
        protected ITTButton AddProductButton;
        override protected void InitializeControls()
        {
            ReviewInheldButton = (ITTButton)AddControl(new Guid("4ae5872c-fedf-4916-8def-ae5d65b8863c"));
            AddProductButton = (ITTButton)AddControl(new Guid("ff026622-15f6-45ee-9ccb-fdb5ca95602f"));
            base.InitializeControls();
        }

        public MilitaryDrugProductionProcedureForm() : base("MILITARYDRUGPRODUCTIONPROCEDURE", "MilitaryDrugProductionProcedureForm")
        {
        }

        protected MilitaryDrugProductionProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
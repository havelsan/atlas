
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
    /// MSB İlaç Üretim İşlemi - Serbest Bırakma
    /// </summary>
    public partial class MilitaryDrugProductionProcedureReleasedForm : MilitaryDrugProductionBaseForm
    {
    /// <summary>
    /// MSB İlaç Üretim İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MilitaryDrugProductionProcedure _MilitaryDrugProductionProcedure
        {
            get { return (TTObjectClasses.MilitaryDrugProductionProcedure)_ttObject; }
        }

        public MilitaryDrugProductionProcedureReleasedForm() : base("MILITARYDRUGPRODUCTIONPROCEDURE", "MilitaryDrugProductionProcedureReleasedForm")
        {
        }

        protected MilitaryDrugProductionProcedureReleasedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
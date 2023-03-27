
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
    /// Nükleer Tıp Cihaz Tanımları
    /// </summary>
    public partial class NucMedEquipmntDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Nükleer Tıp Cihazı
    /// </summary>
        protected TTObjectClasses.ResNuclearMedicineEquipment _ResNuclearMedicineEquipment
        {
            get { return (TTObjectClasses.ResNuclearMedicineEquipment)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("60b63c17-6c46-4247-8d49-62a295957d30"));
            Name = (ITTTextBox)AddControl(new Guid("c714b487-bc87-4c66-adf1-74ebfa2d293d"));
            Active = (ITTCheckBox)AddControl(new Guid("0569b2f8-79d5-4d36-88d2-905a555cb1e9"));
            base.InitializeControls();
        }

        public NucMedEquipmntDefForm() : base("RESNUCLEARMEDICINEEQUIPMENT", "NucMedEquipmntDefForm")
        {
        }

        protected NucMedEquipmntDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
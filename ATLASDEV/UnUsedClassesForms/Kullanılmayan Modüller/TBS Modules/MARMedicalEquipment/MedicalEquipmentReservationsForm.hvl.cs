
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
    /// Tibbi Cihaz ve Reservasyonları
    /// </summary>
    public partial class MedicalEquipmentReservationsForm : TTForm
    {
    /// <summary>
    /// DE_Tıbbi Cihaz
    /// </summary>
        protected TTObjectClasses.MARMedicalEquipment _MARMedicalEquipment
        {
            get { return (TTObjectClasses.MARMedicalEquipment)_ttObject; }
        }

        public MedicalEquipmentReservationsForm() : base("MARMEDICALEQUIPMENT", "MedicalEquipmentReservationsForm")
        {
        }

        protected MedicalEquipmentReservationsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
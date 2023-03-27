
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
    /// Tıbbi Malzeme Grup Tanımlama
    /// </summary>
    public partial class MedicalStuffGroupForm : BaseMedicalStuffDefForm
    {
    /// <summary>
    /// Tıbbi Malzeme Grup Tanımlama
    /// </summary>
        protected TTObjectClasses.MedicalStuffGroup _MedicalStuffGroup
        {
            get { return (TTObjectClasses.MedicalStuffGroup)_ttObject; }
        }

        public MedicalStuffGroupForm() : base("MEDICALSTUFFGROUP", "MedicalStuffGroupForm")
        {
        }

        protected MedicalStuffGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
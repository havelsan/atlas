
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormDentalEx : EpisodeActionForm
    {
    /// <summary>
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalExamination _DentalExamination
        {
            get { return (TTObjectClasses.DentalExamination)_ttObject; }
        }

        protected ITTTextBox tttextboxProtokolNo;
        protected ITTTextBox tttextboxDescription;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("a727d0a1-1837-40f8-986c-221e68b64d1a"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("67b2946b-a6cd-4b00-8385-2e30cfd425de"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cc33810f-f53f-4820-ae07-a15c3e16ddff"));
            base.InitializeControls();
        }

        public AppointmentFormDentalEx() : base("DENTALEXAMINATION", "AppointmentFormDentalEx")
        {
        }

        protected AppointmentFormDentalEx(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
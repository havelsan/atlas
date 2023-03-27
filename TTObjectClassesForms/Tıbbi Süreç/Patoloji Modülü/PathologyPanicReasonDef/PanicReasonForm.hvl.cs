
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
    /// Panik Tanı Bildirim Tanımlama
    /// </summary>
    public partial class PanicReasonForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Patoloji Panik Tanı Tanımları
    /// </summary>
        protected TTObjectClasses.PathologyPanicReasonDef _PathologyPanicReasonDef
        {
            get { return (TTObjectClasses.PathologyPanicReasonDef)_ttObject; }
        }

        protected ITTLabel labelReasonName;
        protected ITTTextBox ReasonName;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelReasonName = (ITTLabel)AddControl(new Guid("73f4bb16-fda6-42b6-891e-75053d0365c6"));
            ReasonName = (ITTTextBox)AddControl(new Guid("598a4760-8fdb-4118-a567-ac46540eee89"));
            Aktif = (ITTCheckBox)AddControl(new Guid("e9fff2b1-de67-4202-bec1-6a2130a7a19e"));
            base.InitializeControls();
        }

        public PanicReasonForm() : base("PATHOLOGYPANICREASONDEF", "PanicReasonForm")
        {
        }

        protected PanicReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
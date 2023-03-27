
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
    /// Nükleer Tıp İş Listesi
    /// </summary>
    public partial class NuclearWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        protected ITTTextBox TestSequenceNo;
        protected ITTLabel ttlabel11;
        override protected void InitializeControls()
        {
            TestSequenceNo = (ITTTextBox)AddControl(new Guid("36d37af2-2152-45fc-8afa-10b3706c4d13"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("58e4b598-e48e-416b-aead-c3b80839d5c6"));
            base.InitializeControls();
        }

        public NuclearWLCriteriaForm() : base("NuclearWLCriteriaForm")
        {
        }

        protected NuclearWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}
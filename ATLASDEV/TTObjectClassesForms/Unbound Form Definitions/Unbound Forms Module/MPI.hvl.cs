
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
    /// MPI
    /// </summary>
    public partial class MPI : TTUnboundForm
    {
        protected ITTButton Button;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttNAme;
        protected ITTTextBox UniqueRefNo;
        protected ITTTextBox Surname;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Button = (ITTButton)AddControl(new Guid("21bead30-6814-4ad3-9e0a-c37337410e50"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8b4db4f2-1542-417d-84c0-d7da8abb3643"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2b87af73-cedb-4ad0-ba02-0e6de433d296"));
            ttNAme = (ITTLabel)AddControl(new Guid("1c27c0f0-9a15-461e-b86e-23421b9f9603"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("a8dcfef1-468a-4ede-8436-a3a7386a9595"));
            Surname = (ITTTextBox)AddControl(new Guid("2ed681aa-3477-4672-825c-8fcf2a780dd7"));
            Name = (ITTTextBox)AddControl(new Guid("46a1bf44-cbf4-4131-b882-17c48e6e4230"));
            base.InitializeControls();
        }

        public MPI() : base("MPI")
        {
        }

        protected MPI(string formDefName) : base(formDefName)
        {
        }
    }
}
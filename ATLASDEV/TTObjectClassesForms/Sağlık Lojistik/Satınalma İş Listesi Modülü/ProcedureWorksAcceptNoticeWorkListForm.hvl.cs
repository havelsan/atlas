
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
    public partial class ProcedureWorksAcceptNoticeWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            txtID = (ITTTextBox)AddControl(new Guid("46f792d1-9ca2-4ba4-b097-db51a186cb84"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("87a13be4-7b89-4124-b33d-10b1da795af3"));
            base.InitializeControls();
        }

        public ProcedureWorksAcceptNoticeWorkListForm() : base("ProcedureWorksAcceptNoticeWorkListForm")
        {
        }

        protected ProcedureWorksAcceptNoticeWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}
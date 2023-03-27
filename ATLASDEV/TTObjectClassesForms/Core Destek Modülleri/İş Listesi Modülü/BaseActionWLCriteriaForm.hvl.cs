
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
    /// Genel İş Listesi
    /// </summary>
    public partial class BaseActionWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTTextBox ActionID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("c6bb4a58-1bf3-453c-af4e-be51f9d624c8"));
            StatusBox = (ITTComboBox)AddControl(new Guid("a5f2d7fc-a27c-46f9-8d52-561f8ab77401"));
            ActionID = (ITTTextBox)AddControl(new Guid("a661f73f-aac0-40df-9f9b-7dfc8244b5c3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0c87f58e-f744-4cf7-b4c9-bb610ccd81da"));
            base.InitializeControls();
        }

        public BaseActionWLCriteriaForm() : base("BaseActionWLCriteriaForm")
        {
        }

        protected BaseActionWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}
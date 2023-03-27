
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
    /// Doğum Tarihi Giriniz
    /// </summary>
    public partial class BirthDateEntryUForm : TTUnboundForm
    {
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTMaskedTextBox BirthDate;
        protected ITTButton Ok;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("926ba5d5-500e-47cc-8d66-cc0eddb650bf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1ac7af75-8562-4420-b093-9568870b9871"));
            BirthDate = (ITTMaskedTextBox)AddControl(new Guid("50e82272-a0fd-4548-af01-7a7293772381"));
            Ok = (ITTButton)AddControl(new Guid("266d9b65-c464-4075-a9a6-11380e547e88"));
            base.InitializeControls();
        }

        public BirthDateEntryUForm() : base("BirthDateEntryUForm")
        {
        }

        protected BirthDateEntryUForm(string formDefName) : base(formDefName)
        {
        }
    }
}
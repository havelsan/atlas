
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
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
    public partial class DistiributionDepStoreCompForm : BaseDistributionDepStoreFrom
    {
    /// <summary>
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
        protected TTObjectClasses.DistributionDepStore _DistributionDepStore
        {
            get { return (TTObjectClasses.DistributionDepStore)_ttObject; }
        }

        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        override protected void InitializeControls()
        {
            SequenceNumber = (ITTTextBox)AddControl(new Guid("f02f5bf5-4d50-4027-9ca8-f07a1aba270e"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("3735da10-556e-4b7a-8818-85bd3f955bc2"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("734180e1-2b7c-414e-b3a6-664cec085edb"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("5787615d-c78c-4055-99a4-a6ac8c62fd28"));
            base.InitializeControls();
        }

        public DistiributionDepStoreCompForm() : base("DISTRIBUTIONDEPSTORE", "DistiributionDepStoreCompForm")
        {
        }

        protected DistiributionDepStoreCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
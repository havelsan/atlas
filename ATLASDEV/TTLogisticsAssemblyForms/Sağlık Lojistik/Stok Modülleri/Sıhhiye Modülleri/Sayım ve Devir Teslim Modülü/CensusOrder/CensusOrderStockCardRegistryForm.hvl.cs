
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
    /// Sayım Emri Belgesi
    /// </summary>
    public partial class CensusOrderStockCardRegistryForm : BaseCensusOrderForm
    {
    /// <summary>
    /// Sayım Emri için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusOrder _CensusOrder
        {
            get { return (TTObjectClasses.CensusOrder)_ttObject; }
        }

        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        override protected void InitializeControls()
        {
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("ad34fca9-47e0-4b23-9b22-34cf4291e2ad"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("c65c916a-750a-4d47-995c-694d68aa2b47"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("5fedccd9-cb5f-4d4f-b731-45f6d7ba8159"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("22e62f71-4912-4b8c-aefa-65eff51ed123"));
            base.InitializeControls();
        }

        public CensusOrderStockCardRegistryForm() : base("CENSUSORDER", "CensusOrderStockCardRegistryForm")
        {
        }

        protected CensusOrderStockCardRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
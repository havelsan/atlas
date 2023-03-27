
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
    public partial class DietOrderForm : TTForm
    {
    /// <summary>
    /// Yatan Hasta Diyet Order
    /// </summary>
        protected TTObjectClasses.DietOrder _DietOrder
        {
            get { return (TTObjectClasses.DietOrder)_ttObject; }
        }

        protected ITTLabel labelWorkListDate;
        protected ITTDateTimePicker WorkListDate;
        override protected void InitializeControls()
        {
            labelWorkListDate = (ITTLabel)AddControl(new Guid("c606328a-5649-4b9f-9530-82b4545cc224"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("2e10b092-bade-4f57-a408-bdec800ce945"));
            base.InitializeControls();
        }

        public DietOrderForm() : base("DIETORDER", "DietOrderForm")
        {
        }

        protected DietOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
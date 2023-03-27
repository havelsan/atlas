
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
    public partial class ManipulationProcedureRequestInfo : TTForm
    {
    /// <summary>
    /// Manipülasyon Sekmesi
    /// </summary>
        protected TTObjectClasses.ManipulationProcedure _ManipulationProcedure
        {
            get { return (TTObjectClasses.ManipulationProcedure)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("8f52af92-7ca4-42df-960b-97821c0b4c5f"));
            Description = (ITTTextBox)AddControl(new Guid("2de68dab-1db9-4b1a-8862-de2b3ef7ac50"));
            base.InitializeControls();
        }

        public ManipulationProcedureRequestInfo() : base("MANIPULATIONPROCEDURE", "ManipulationProcedureRequestInfo")
        {
        }

        protected ManipulationProcedureRequestInfo(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
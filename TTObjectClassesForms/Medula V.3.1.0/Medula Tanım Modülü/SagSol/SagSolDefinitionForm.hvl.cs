
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
    /// Sağ Sol Tanımlama
    /// </summary>
    public partial class SagSolDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sağ Sol
    /// </summary>
        protected TTObjectClasses.SagSol _SagSol
        {
            get { return (TTObjectClasses.SagSol)_ttObject; }
        }

        protected ITTLabel labelsagSolKodu;
        protected ITTTextBox sagSolKodu;
        protected ITTLabel labelsagSolAdi;
        protected ITTTextBox sagSolAdi;
        override protected void InitializeControls()
        {
            labelsagSolKodu = (ITTLabel)AddControl(new Guid("af25c833-f554-47ed-bae4-ecb3aae26129"));
            sagSolKodu = (ITTTextBox)AddControl(new Guid("e65e6173-4aa2-4195-abea-7ee31b7d3628"));
            labelsagSolAdi = (ITTLabel)AddControl(new Guid("031d07c6-251a-4a80-a88b-fb642435f7f1"));
            sagSolAdi = (ITTTextBox)AddControl(new Guid("66c1369c-22df-4231-a168-b74d962997aa"));
            base.InitializeControls();
        }

        public SagSolDefinitionForm() : base("SAGSOL", "SagSolDefinitionForm")
        {
        }

        protected SagSolDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
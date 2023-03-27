
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
    /// Yatak Hizmeti Tanımlama
    /// </summary>
    public partial class BedProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Yatak Türleri Listesi
    /// </summary>
        protected TTObjectClasses.BedProcedureDefinition _BedProcedureDefinition
        {
            get { return (TTObjectClasses.BedProcedureDefinition)_ttObject; }
        }

        protected ITTObjectListBox PandemicProcedure;
        protected ITTLabel lblPandemicProcedure;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox Description;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Code;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelCode;
        protected ITTCheckBox Chargable;
        override protected void InitializeControls()
        {
            PandemicProcedure = (ITTObjectListBox)AddControl(new Guid("aec252f8-4726-43fe-8827-570f874d3b06"));
            lblPandemicProcedure = (ITTLabel)AddControl(new Guid("8f617730-a703-4290-850a-e828e3b52679"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("bd64f6e5-e581-4157-8e9f-cc2320aa24c0"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("4c4fb603-46d4-4afa-b8db-fe260953a428"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("3852a436-5234-4fed-be22-616dce384690"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("213f0648-5f5e-4b61-a861-7a7978d4c030"));
            Description = (ITTTextBox)AddControl(new Guid("716b37e0-604c-47e6-996e-16f5ccd2887f"));
            Qref = (ITTTextBox)AddControl(new Guid("989fc232-8903-4d89-9a29-90a53cebb386"));
            Name = (ITTTextBox)AddControl(new Guid("2d13b514-7c62-45a9-8504-2b94b72b1124"));
            EnglishName = (ITTTextBox)AddControl(new Guid("63decfcc-04d8-4522-87cb-b3373268fe86"));
            Code = (ITTTextBox)AddControl(new Guid("eb0f3817-c2a8-4e39-b695-28c45d218235"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("f1d1a07e-c1ca-46d3-81fb-3a12dc27db70"));
            labelQref = (ITTLabel)AddControl(new Guid("cdaa8875-8cfd-4387-8675-4189d0986bdf"));
            labelName = (ITTLabel)AddControl(new Guid("6595258f-df9c-46d8-9f58-36b5f84545b6"));
            IsActive = (ITTCheckBox)AddControl(new Guid("7fcfe4a6-c92a-4b33-a22d-caf039bd1a81"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("edf2512f-62ee-4913-a4e9-dbd3cb6fa8df"));
            labelDescription = (ITTLabel)AddControl(new Guid("93a204ee-bab5-45f6-9167-cc0789235855"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("dfd99d0b-6a82-42f0-923e-8bb3df8a873d"));
            labelCode = (ITTLabel)AddControl(new Guid("68e14bfb-d44e-447f-bb77-c27df1f983ad"));
            Chargable = (ITTCheckBox)AddControl(new Guid("bbafd1af-5e41-4930-9236-0993dd23e52a"));
            base.InitializeControls();
        }

        public BedProcedureDefinitionForm() : base("BEDPROCEDUREDEFINITION", "BedProcedureDefinitionForm")
        {
        }

        protected BedProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
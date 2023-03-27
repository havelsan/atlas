
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
    /// Fiziksel Tıp ve Rehabilitasyon İşlemleri Tanımlama
    /// </summary>
    public partial class PhysiotherapyDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Fiziksel Tıp ve Rehabilitasyon İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.PhysiotherapyDefinition _PhysiotherapyDefinition
        {
            get { return (TTObjectClasses.PhysiotherapyDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox TreatmentDuration;
        protected ITTTextBox ID;
        protected ITTCheckBox ESWTTransaction;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox ExaminationSubClass;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTGrid TreatmentUnits;
        protected ITTListBoxColumn TreatmentDiagnosisUnit0;
        protected ITTGrid TreatmentRooms;
        protected ITTListBoxColumn TreatmentRoom0;
        protected ITTLabel labelTreatmentDuration;
        protected ITTLabel labelID;
        protected ITTCheckBox Chargable;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("de6175ce-1769-4703-bb76-81e41d660034"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("2b949fcc-db01-48d0-9bbd-890e211aaf28"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("61a52535-f834-49e3-bb36-b796c4549fa3"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("030994f9-b869-4405-b83f-57dbae97a5f9"));
            OrderNo = (ITTTextBox)AddControl(new Guid("506ec97e-ec41-42ee-a97e-88044667bd1b"));
            Qref = (ITTTextBox)AddControl(new Guid("00027673-66e6-4f7c-baa5-bf1025f24a7a"));
            Name = (ITTTextBox)AddControl(new Guid("10bef3f5-55fb-494f-a7f5-65ee9daaca9c"));
            EnglishName = (ITTTextBox)AddControl(new Guid("3a7f5431-6cba-4600-8f57-6dee062670d1"));
            Description = (ITTTextBox)AddControl(new Guid("1dc586ed-bd90-476f-a4b1-b8c2c00c04fe"));
            Code = (ITTTextBox)AddControl(new Guid("4ba84fab-9837-446f-989c-9337e790d8db"));
            TreatmentDuration = (ITTTextBox)AddControl(new Guid("8bbfbf3c-efca-4dd2-a41a-fd1a8e1e7fae"));
            ID = (ITTTextBox)AddControl(new Guid("1c1618d4-3ae2-452b-a634-8073ff0845a3"));
            ESWTTransaction = (ITTCheckBox)AddControl(new Guid("c33bf8ef-605b-4207-8a1b-c184e88e0855"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1b6ef288-c1f9-4ba4-8189-ebd7e9502794"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("10cda3fe-743d-4c87-95a3-2e391bd0f3a6"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9d39b6e7-dd9b-42b4-8204-16ee9f7bdec8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5c28d820-091a-4506-82dc-5569a9ade3a1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("35be7d73-35cb-4f1a-a863-c99ec0380e7e"));
            ExaminationSubClass = (ITTEnumComboBox)AddControl(new Guid("6c63a0ab-e9ad-42b0-88a8-474a22566da6"));
            labelQref = (ITTLabel)AddControl(new Guid("1829d1c1-c0fc-44b3-9553-d3720e52e470"));
            labelName = (ITTLabel)AddControl(new Guid("54085101-7e04-42dd-9a8a-35760afd7ca6"));
            IsActive = (ITTCheckBox)AddControl(new Guid("6adfcce8-7277-4b76-9902-50b78f39290d"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("500b365c-eb19-427f-b0d2-ffaecc42ff94"));
            labelDescription = (ITTLabel)AddControl(new Guid("654bc38b-b65a-4186-a7a2-d7d8987a9d0a"));
            labelCode = (ITTLabel)AddControl(new Guid("1364c395-dd88-4ed9-a79b-a26ab2be0b13"));
            TreatmentUnits = (ITTGrid)AddControl(new Guid("151acb02-30fc-4f7b-99dd-c44e90c54269"));
            TreatmentDiagnosisUnit0 = (ITTListBoxColumn)AddControl(new Guid("764222bb-9320-494a-a1ae-95a3319b856f"));
            TreatmentRooms = (ITTGrid)AddControl(new Guid("786978f0-0735-49a3-afdf-1bd10a5985cc"));
            TreatmentRoom0 = (ITTListBoxColumn)AddControl(new Guid("034b9523-9f48-43fc-a6c4-f2e468a4b935"));
            labelTreatmentDuration = (ITTLabel)AddControl(new Guid("f68d7d5d-34c0-4394-b452-9373515e2902"));
            labelID = (ITTLabel)AddControl(new Guid("5331a93f-bd89-42b3-a691-e7f17bd535ee"));
            Chargable = (ITTCheckBox)AddControl(new Guid("66a00f7b-6cee-4a19-a773-4884cac3282f"));
            base.InitializeControls();
        }

        public PhysiotherapyDefinitionForm() : base("PHYSIOTHERAPYDEFINITION", "PhysiotherapyDefinitionForm")
        {
        }

        protected PhysiotherapyDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}

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
    public partial class HastaSorgulamaFormu : TTUnboundForm
    {
        protected ITTGrid gridHAstaGruplari;
        protected ITTEnumComboBoxColumn hastaGrubu;
        protected ITTGrid gridInpatientPatient;
        protected ITTTextBoxColumn textUniqueRefNo;
        protected ITTTextBoxColumn textPatientName;
        protected ITTTextBoxColumn textPatientSurname;
        protected ITTTextBoxColumn textRank;
        protected ITTTextBoxColumn textclass;
        protected ITTTextBoxColumn textMilitaryUnit;
        protected ITTTextBoxColumn textHospital;
        protected ITTTextBoxColumn textService;
        protected ITTTextBoxColumn textRoomBed;
        protected ITTTextBoxColumn textbed;
        protected ITTTextBoxColumn textInpatientDate;
        protected ITTTextBoxColumn textPatientGroup;
        protected ITTButton btnExceleAktar;
        protected ITTButton ttbtnListele;
        protected ITTLabel lblPatientGroup;
        override protected void InitializeControls()
        {
            gridHAstaGruplari = (ITTGrid)AddControl(new Guid("c70f5242-e6c8-4622-a452-8cb310bb5e28"));
            hastaGrubu = (ITTEnumComboBoxColumn)AddControl(new Guid("5152957a-4aa3-4977-bf4d-7b4bf78c7726"));
            gridInpatientPatient = (ITTGrid)AddControl(new Guid("753239b9-b184-4d41-bb01-9a7305bd0004"));
            textUniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("63305229-a0cb-4856-a7f1-84b6dc60e77c"));
            textPatientName = (ITTTextBoxColumn)AddControl(new Guid("c187f353-6d87-4e29-87cd-88daaae942a1"));
            textPatientSurname = (ITTTextBoxColumn)AddControl(new Guid("6537f0fa-047c-4bce-87b7-f56578a882ae"));
            textRank = (ITTTextBoxColumn)AddControl(new Guid("109e1fbf-bbac-46e6-bca3-beb2d3973450"));
            textclass = (ITTTextBoxColumn)AddControl(new Guid("de64587e-1895-419d-83e7-819e20ff45fd"));
            textMilitaryUnit = (ITTTextBoxColumn)AddControl(new Guid("384a10e7-13d8-4403-9042-033dcfb57bf5"));
            textHospital = (ITTTextBoxColumn)AddControl(new Guid("d3854069-943a-4301-a2b5-5d1736faf7ee"));
            textService = (ITTTextBoxColumn)AddControl(new Guid("71f19c60-a84e-4a5b-b0e3-ddb97aa128f4"));
            textRoomBed = (ITTTextBoxColumn)AddControl(new Guid("bb45e081-ffd1-4e3a-9ad3-0deec1708084"));
            textbed = (ITTTextBoxColumn)AddControl(new Guid("db9c4011-f090-4414-9dae-c605061b8a86"));
            textInpatientDate = (ITTTextBoxColumn)AddControl(new Guid("8be2115a-44a8-493c-a54c-7f943710629d"));
            textPatientGroup = (ITTTextBoxColumn)AddControl(new Guid("a3b9ea64-990a-40b9-81f6-3a97e158ceac"));
            btnExceleAktar = (ITTButton)AddControl(new Guid("d84eea7f-810d-4aa1-8d60-fef47d2f89c2"));
            ttbtnListele = (ITTButton)AddControl(new Guid("af4b07c7-7721-49ac-978c-6a1fa0388086"));
            lblPatientGroup = (ITTLabel)AddControl(new Guid("8e9bbb71-29ec-46a5-a9bc-f01949e6b549"));
            base.InitializeControls();
        }

        public HastaSorgulamaFormu() : base("HastaSorgulamaFormu")
        {
        }

        protected HastaSorgulamaFormu(string formDefName) : base(formDefName)
        {
        }
    }
}
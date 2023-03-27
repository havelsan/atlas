
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
    public partial class TeshisDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.Teshis _Teshis
        {
            get { return (TTObjectClasses.Teshis)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid DiagnosisDefTeshis;
        protected ITTListBoxColumn DiagnosisDefinitionDiagnosisDefTeshis;
        protected ITTLabel labelteshisAdi;
        protected ITTTextBox teshisAdi;
        protected ITTTextBox teshisKodu;
        protected ITTLabel labelteshisKodu;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("b0b8974d-5e98-46d0-8465-3a418a966380"));
            DiagnosisDefTeshis = (ITTGrid)AddControl(new Guid("7243d290-5942-447d-9f26-ef6410be2f7d"));
            DiagnosisDefinitionDiagnosisDefTeshis = (ITTListBoxColumn)AddControl(new Guid("2a2a7351-11de-4fa7-899e-09bc3acbdac9"));
            labelteshisAdi = (ITTLabel)AddControl(new Guid("3b779d34-24f8-49ff-b5c0-81be6a4450e2"));
            teshisAdi = (ITTTextBox)AddControl(new Guid("f7ae3288-a2b6-4c66-bf5c-29fbab837de6"));
            teshisKodu = (ITTTextBox)AddControl(new Guid("f7de88c9-e1ba-43b0-8120-44c3404e3a36"));
            labelteshisKodu = (ITTLabel)AddControl(new Guid("5c651fb7-fc8d-4db9-8be0-fa5c05fa7647"));
            base.InitializeControls();
        }

        public TeshisDefinitionForm() : base("TESHIS", "TeshisDefinitionForm")
        {
        }

        protected TeshisDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
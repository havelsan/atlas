
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
    /// Medula Hizmet Kayıt
    /// </summary>
    public partial class MedulaProcedureRegistrationForm : TTUnboundForm
    {
        protected ITTTextBox TAKIPNO;
        protected ITTLabel ttNAme;
        protected ITTTabControl TabProcedureMaterialDiagnose;
        protected ITTTabPage TabProcedure;
        protected ITTGrid GRIDProcedures;
        protected ITTTextBoxColumn PACTIONDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PSTATUS;
        protected ITTTextBoxColumn PMEDULASIRANO;
        protected ITTCheckBoxColumn PSEND;
        protected ITTTextBoxColumn POBJECTID;
        protected ITTTextBoxColumn PSENDABLE;
        protected ITTTabPage TabMaterial;
        protected ITTGrid GRIDMaterials;
        protected ITTTextBoxColumn MACTIONDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTTextBoxColumn MAMOUNT;
        protected ITTTextBoxColumn MSTATUS;
        protected ITTTextBoxColumn MMEDULASIRANO;
        protected ITTCheckBoxColumn MSEND;
        protected ITTTextBoxColumn MOBJECTID;
        protected ITTTextBoxColumn MSENDABLE;
        protected ITTTabPage TabPackage;
        protected ITTGrid GRIDDiagnoses;
        protected ITTTextBoxColumn DIAGNOSECODE;
        protected ITTTextBoxColumn DIAGNOSENAME;
        protected ITTTextBoxColumn DMEDULASIRANO;
        protected ITTCheckBoxColumn DSEND;
        protected ITTTextBoxColumn DOBJECTID;
        protected ITTTextBoxColumn DSENDABLE;
        protected ITTButton CANCELBUTTON;
        protected ITTButton SAVEBUTTON;
        protected ITTButton LISTBUTTON;
        protected ITTButton UNSELECTBUTTON;
        protected ITTButton SELECTBUTTON;
        override protected void InitializeControls()
        {
            TAKIPNO = (ITTTextBox)AddControl(new Guid("5a703274-d4c0-4424-95b7-5d6b8a609e8d"));
            ttNAme = (ITTLabel)AddControl(new Guid("2b5407c0-a4bd-413f-9652-6953bc3b31d0"));
            TabProcedureMaterialDiagnose = (ITTTabControl)AddControl(new Guid("3ccb9eeb-8b7d-4ce4-81a2-85c036ecc649"));
            TabProcedure = (ITTTabPage)AddControl(new Guid("b65dcea6-41e3-4c10-84a2-58ef04834860"));
            GRIDProcedures = (ITTGrid)AddControl(new Guid("56181b5e-2394-4509-a69f-40c9b0e1a416"));
            PACTIONDATE = (ITTTextBoxColumn)AddControl(new Guid("ea0e05b2-a426-4258-850f-c84aae234169"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("a8d0f6f6-5843-4c9a-be7e-f2b6d938995e"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("263189f6-1500-4266-b95a-398fff12d765"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("11226d8c-e42c-4641-8b2d-03331a51aab2"));
            PSTATUS = (ITTTextBoxColumn)AddControl(new Guid("c80737d0-062c-4019-998b-97a54911a767"));
            PMEDULASIRANO = (ITTTextBoxColumn)AddControl(new Guid("d3143686-30a6-4302-be55-18b091525411"));
            PSEND = (ITTCheckBoxColumn)AddControl(new Guid("306f2c13-bbb2-4825-8980-64797f714abf"));
            POBJECTID = (ITTTextBoxColumn)AddControl(new Guid("f9883dd1-eb4a-4355-b9f9-40783a7879dd"));
            PSENDABLE = (ITTTextBoxColumn)AddControl(new Guid("ee0357ec-cda9-45d3-862d-5fba2681125a"));
            TabMaterial = (ITTTabPage)AddControl(new Guid("51040fba-685f-4481-988c-6c8b7b4a138b"));
            GRIDMaterials = (ITTGrid)AddControl(new Guid("2ff2d252-af23-41a5-92c3-72c4709928dc"));
            MACTIONDATE = (ITTTextBoxColumn)AddControl(new Guid("32ed9139-b40e-46a0-a31e-7b8a414c458c"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("214b0a9e-a496-4f75-85cf-2eb96e4c5bb3"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("6ccf75a4-92de-4821-a452-1383f833f455"));
            MAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("3507198d-eca0-4b99-a26c-ce333bd7f104"));
            MSTATUS = (ITTTextBoxColumn)AddControl(new Guid("d81431f8-c2f5-4678-b975-a7bf2cc0b1c9"));
            MMEDULASIRANO = (ITTTextBoxColumn)AddControl(new Guid("8c9a3c20-1979-4cd5-a871-d9b4a1d1a9fc"));
            MSEND = (ITTCheckBoxColumn)AddControl(new Guid("0f0365fc-5955-4f4e-926f-38650b66df5f"));
            MOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("fab1e644-14ff-4341-9e3a-91ba98a3d4d0"));
            MSENDABLE = (ITTTextBoxColumn)AddControl(new Guid("18adbb84-802a-48a6-8b06-42a068e5325a"));
            TabPackage = (ITTTabPage)AddControl(new Guid("d5c5965e-914d-402f-a885-d9b2c1c1422d"));
            GRIDDiagnoses = (ITTGrid)AddControl(new Guid("5cc42e74-a47a-4b66-aa13-a98bcc55bd23"));
            DIAGNOSECODE = (ITTTextBoxColumn)AddControl(new Guid("6d29aa3e-28d3-4448-a950-39bf1bfddf70"));
            DIAGNOSENAME = (ITTTextBoxColumn)AddControl(new Guid("00cc5d66-c55d-4fc0-9f9e-95c75776bee4"));
            DMEDULASIRANO = (ITTTextBoxColumn)AddControl(new Guid("e1233dea-f6a8-4463-89dc-26acc5aaf7d9"));
            DSEND = (ITTCheckBoxColumn)AddControl(new Guid("cd718bd6-688f-4090-8b49-eeddf97e8f3b"));
            DOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("496b2d55-8db0-4268-80fa-ce389ac10dbb"));
            DSENDABLE = (ITTTextBoxColumn)AddControl(new Guid("ac366cf7-c5d3-49d8-a897-c316feb4c98e"));
            CANCELBUTTON = (ITTButton)AddControl(new Guid("091b2d72-450d-4feb-95c3-ed3b954c8c54"));
            SAVEBUTTON = (ITTButton)AddControl(new Guid("a0b8ce3d-2e29-4879-8be8-cc3ff2adc6af"));
            LISTBUTTON = (ITTButton)AddControl(new Guid("4e7e5a28-3adf-41e8-9e25-281a226708da"));
            UNSELECTBUTTON = (ITTButton)AddControl(new Guid("e30e820b-a457-4327-aa82-aa68c93d8ebd"));
            SELECTBUTTON = (ITTButton)AddControl(new Guid("85ee45ce-c93d-4c3a-9044-ae064038b229"));
            base.InitializeControls();
        }

        public MedulaProcedureRegistrationForm() : base("MedulaProcedureRegistrationForm")
        {
        }

        protected MedulaProcedureRegistrationForm(string formDefName) : base(formDefName)
        {
        }
    }
}
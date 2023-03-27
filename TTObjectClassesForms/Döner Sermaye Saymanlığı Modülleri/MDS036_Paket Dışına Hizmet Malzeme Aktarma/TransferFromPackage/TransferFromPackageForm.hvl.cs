
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
    /// Paket Dışına Hizmet/Malzeme Aktarma
    /// </summary>
    public partial class TransferFromPackageForm : TTForm
    {
    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma
    /// </summary>
        protected TTObjectClasses.TransferFromPackage _TransferFromPackage
        {
            get { return (TTObjectClasses.TransferFromPackage)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox PACKAGEOUTREASON;
        protected ITTGrid GridPackages;
        protected ITTDateTimePickerColumn TRXDATE;
        protected ITTTextBoxColumn EXTERNALCODE;
        protected ITTTextBoxColumn DESCRIPTION;
        protected ITTTextBoxColumn STATUS;
        protected ITTButtonColumn LISTSUBACTIONS;
        protected ITTLabel ttlabel1;
        protected ITTTabControl TABProcedureMaterial;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridSubActionProcedures;
        protected ITTDateTimePickerColumn PTRXDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTTextBoxColumn PSTATUS;
        protected ITTTextBoxColumn PPACKAGEINFO;
        protected ITTCheckBoxColumn PTRANSFER;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridSubActionMaterials;
        protected ITTDateTimePickerColumn MTRXDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTTextBoxColumn MSTATUS;
        protected ITTTextBoxColumn MPACKAGEINFO;
        protected ITTCheckBoxColumn TRANSFERTARGETPACKAGE;
        protected ITTObjectListBox TARGETPROTOCOL;
        protected ITTLabel Label1;
        protected ITTObjectListBox TARGETPAYER;
        protected ITTLabel ttlabel3;
        protected ITTButton SelectAllMaterialBtn;
        protected ITTButton UnSelectAllMaterialBtn;
        protected ITTDateTimePicker FILTERENDDATE;
        protected ITTLabel labelProtocolEndDate;
        protected ITTLabel labelProtocolStartDate;
        protected ITTDateTimePicker FILTERSTARTDATE;
        protected ITTButton FilterButton;
        protected ITTCheckBox FILTERTYPE;
        protected ITTObjectListBox MATERIAL;
        protected ITTObjectListBox PROCEDURE;
        protected ITTLabel MaterialLbl;
        protected ITTLabel ProcedureLbl;
        protected ITTButton UnSelectAllProcedureBtn;
        protected ITTButton SelectAllProcedureBtn;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("144bb6c0-6b93-46e5-9b23-c2a1cbcc1367"));
            PACKAGEOUTREASON = (ITTEnumComboBox)AddControl(new Guid("30de5ef5-4aa9-488a-9fb5-0bc8ddf94de6"));
            GridPackages = (ITTGrid)AddControl(new Guid("d64fb1a2-249f-4c65-a85f-148a89e57852"));
            TRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("89a4da01-127d-4a5d-80e7-60fedad1f89d"));
            EXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("464a4c48-5ea0-476a-9b28-e9b2528f5bf8"));
            DESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("0e802038-c5cf-42c1-8222-6223109b1333"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("da6027fe-9382-4157-a1c7-479b76d50af4"));
            LISTSUBACTIONS = (ITTButtonColumn)AddControl(new Guid("72611c22-b145-43e5-910a-a3bddee0cab2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b7eac93f-9c1c-4d95-b857-0b52dada883d"));
            TABProcedureMaterial = (ITTTabControl)AddControl(new Guid("13c14a09-1dcd-4163-8232-b5730f216918"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("37d8a34b-cb84-484b-8a2a-ad70fb18dec3"));
            GridSubActionProcedures = (ITTGrid)AddControl(new Guid("ebe2098b-f1c6-4c62-b71a-903b2f6d9414"));
            PTRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("1ba2eddc-d38f-4d08-8bc8-deab0db91d0d"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("043ed9ae-2e3c-4fe9-9e39-22f8d79df103"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("70a425f7-a486-497a-bd9c-820ecc24a746"));
            PSTATUS = (ITTTextBoxColumn)AddControl(new Guid("92548fda-6736-4447-8b80-be9b62242bc2"));
            PPACKAGEINFO = (ITTTextBoxColumn)AddControl(new Guid("4254a603-922c-47a6-916a-f9268f7fd889"));
            PTRANSFER = (ITTCheckBoxColumn)AddControl(new Guid("ecc3cc8b-13b3-4742-a019-ed03c4eea59c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("bd8e6963-5e52-4362-8962-3b3906c75ffc"));
            GridSubActionMaterials = (ITTGrid)AddControl(new Guid("39537c3a-05e5-4e29-8745-2971e1341a12"));
            MTRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("11e7a70e-b1c6-419a-8e67-66a8db513494"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("b06ed267-de53-448b-8447-36fc0c1c0992"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("7dfd5802-b6cd-47b7-810c-f904e8792619"));
            MSTATUS = (ITTTextBoxColumn)AddControl(new Guid("710b05db-43fb-4ec5-acf7-b2565fb62c90"));
            MPACKAGEINFO = (ITTTextBoxColumn)AddControl(new Guid("7dca610f-c19d-49a1-a21e-b248ec2c7bee"));
            TRANSFERTARGETPACKAGE = (ITTCheckBoxColumn)AddControl(new Guid("7a048d27-57c3-407d-8731-dbcaee3ed55f"));
            TARGETPROTOCOL = (ITTObjectListBox)AddControl(new Guid("cc90c029-78eb-4479-ab22-0870f55abb80"));
            Label1 = (ITTLabel)AddControl(new Guid("eefb2bb9-43cd-4123-af06-6a2d9a1b3f7d"));
            TARGETPAYER = (ITTObjectListBox)AddControl(new Guid("aa05292a-1a67-4c18-8100-235e6dd12589"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2cf69163-1e95-44f7-a15d-f46489a2324e"));
            SelectAllMaterialBtn = (ITTButton)AddControl(new Guid("9f44b82b-e9be-4a44-91f9-67c78b710854"));
            UnSelectAllMaterialBtn = (ITTButton)AddControl(new Guid("cbbe9caf-eec6-4212-ba0a-19d07df4cf44"));
            FILTERENDDATE = (ITTDateTimePicker)AddControl(new Guid("2ba99acc-980b-420a-90bd-7bbfef125842"));
            labelProtocolEndDate = (ITTLabel)AddControl(new Guid("7d45a5b6-d54c-4aba-997b-02e8729d835c"));
            labelProtocolStartDate = (ITTLabel)AddControl(new Guid("7a8df6ad-5d7e-4a0b-b179-920e37bc2e42"));
            FILTERSTARTDATE = (ITTDateTimePicker)AddControl(new Guid("4fa1041f-6d97-43fa-b0ac-8d9cd06b2feb"));
            FilterButton = (ITTButton)AddControl(new Guid("6109bf1f-80be-4ca2-80ab-b1e32350c545"));
            FILTERTYPE = (ITTCheckBox)AddControl(new Guid("425d56d7-476c-4e0d-a98d-e5e7c7c7e191"));
            MATERIAL = (ITTObjectListBox)AddControl(new Guid("af22db96-56a1-40ac-a744-c19968e3d50a"));
            PROCEDURE = (ITTObjectListBox)AddControl(new Guid("9d41a275-dab8-45ce-bce1-dececb6de9fd"));
            MaterialLbl = (ITTLabel)AddControl(new Guid("fac0c482-9bed-4421-8eab-20c96546f6fd"));
            ProcedureLbl = (ITTLabel)AddControl(new Guid("fa4f9319-8330-422a-8a67-fee2238a9624"));
            UnSelectAllProcedureBtn = (ITTButton)AddControl(new Guid("d68964c9-971f-4afc-9e05-1d94ccf0553e"));
            SelectAllProcedureBtn = (ITTButton)AddControl(new Guid("b4cb9e47-3ae7-4e8d-aeb7-129684e18ccd"));
            base.InitializeControls();
        }

        public TransferFromPackageForm() : base("TRANSFERFROMPACKAGE", "TransferFromPackageForm")
        {
        }

        protected TransferFromPackageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
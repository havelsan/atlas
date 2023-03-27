
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
    public partial class OptikEReceteIslemleri : TTUnboundForm
    {
        protected ITTLabel lblPatient;
        protected ITTGrid grdPrescriptions;
        protected ITTTextBoxColumn EReceteNo;
        protected ITTTextBoxColumn TakipNo;
        protected ITTTextBoxColumn ReceteTipi;
        protected ITTTextBoxColumn ReceteTarihi;
        protected ITTTextBoxColumn ProvizyonTipi;
        protected ITTTextBoxColumn ProtokolNo;
        protected ITTTextBoxColumn ReceteTeshis;
        protected ITTTextBoxColumn GozlukTuru1;
        protected ITTTextBoxColumn CamTipi1;
        protected ITTTextBoxColumn CamRengi1;
        protected ITTTextBoxColumn SagSferik1;
        protected ITTTextBoxColumn SagSilendirik1;
        protected ITTTextBoxColumn SagAks1;
        protected ITTTextBoxColumn SolSferik1;
        protected ITTTextBoxColumn SolSilendirik1;
        protected ITTTextBoxColumn SolAks1;
        protected ITTTextBoxColumn GozlukTuru2;
        protected ITTTextBoxColumn CamRengi2;
        protected ITTTextBoxColumn CamTipi2;
        protected ITTTextBoxColumn SagSferik2;
        protected ITTTextBoxColumn SagSilendirik2;
        protected ITTTextBoxColumn SagAks2;
        protected ITTTextBoxColumn SolSferik2;
        protected ITTTextBoxColumn SolSilendirik2;
        protected ITTTextBoxColumn SolAks2;
        protected ITTTextBoxColumn TesisKodu;
        protected ITTTextBoxColumn DrTCKimlikNo;
        protected ITTTextBoxColumn DrTescilNo;
        protected ITTButtonColumn DeletePrescription;
        protected ITTButton cmdQuery;
        protected ITTObjectListBox PatientSearchList;
        override protected void InitializeControls()
        {
            lblPatient = (ITTLabel)AddControl(new Guid("86c26796-5e22-4c22-89dc-e4c6cae3a9bc"));
            grdPrescriptions = (ITTGrid)AddControl(new Guid("38da6c9e-8e6a-46a8-a081-1064d4517cc8"));
            EReceteNo = (ITTTextBoxColumn)AddControl(new Guid("898ae7ed-81bd-45d9-8983-78d528c54430"));
            TakipNo = (ITTTextBoxColumn)AddControl(new Guid("2d8c67e5-2e16-497d-a48b-f9477a30bf9b"));
            ReceteTipi = (ITTTextBoxColumn)AddControl(new Guid("e524cdf2-0a97-4fcd-890b-cebb0823d2c5"));
            ReceteTarihi = (ITTTextBoxColumn)AddControl(new Guid("fcaff2d4-4fb1-4bd9-be4f-246f68876199"));
            ProvizyonTipi = (ITTTextBoxColumn)AddControl(new Guid("012b597b-fcb9-4f68-9669-5d738db3c5c3"));
            ProtokolNo = (ITTTextBoxColumn)AddControl(new Guid("9cc57572-7db9-4eeb-9c0c-9dc062541cea"));
            ReceteTeshis = (ITTTextBoxColumn)AddControl(new Guid("f0b62f9e-2bc0-4c98-9992-14305a482c03"));
            GozlukTuru1 = (ITTTextBoxColumn)AddControl(new Guid("d9fe3428-fb3a-462b-b357-e90b5b056734"));
            CamTipi1 = (ITTTextBoxColumn)AddControl(new Guid("fab56587-e22f-4005-b72f-d2d9215c91e6"));
            CamRengi1 = (ITTTextBoxColumn)AddControl(new Guid("b677e0a3-5840-4392-8e85-da51773a2a2e"));
            SagSferik1 = (ITTTextBoxColumn)AddControl(new Guid("11760cac-cd33-4a42-9fea-d7aaf1d3119c"));
            SagSilendirik1 = (ITTTextBoxColumn)AddControl(new Guid("78041d60-2fce-4094-8712-80548b8b962e"));
            SagAks1 = (ITTTextBoxColumn)AddControl(new Guid("97199090-f18b-44af-a69b-faece24c4cf8"));
            SolSferik1 = (ITTTextBoxColumn)AddControl(new Guid("589c4a65-d36f-4243-a56b-ac84f74af8f8"));
            SolSilendirik1 = (ITTTextBoxColumn)AddControl(new Guid("68d79aac-46f1-492f-a131-18f62b698f38"));
            SolAks1 = (ITTTextBoxColumn)AddControl(new Guid("b9105b7f-15e4-4ca7-a99e-ad4a58c7efc1"));
            GozlukTuru2 = (ITTTextBoxColumn)AddControl(new Guid("ae1a8b08-d5f1-4c27-b487-9c1059c8ced9"));
            CamRengi2 = (ITTTextBoxColumn)AddControl(new Guid("8b0eab00-645e-4cfa-8ecd-77a9eb85aa13"));
            CamTipi2 = (ITTTextBoxColumn)AddControl(new Guid("c5bc1483-ff83-4214-b934-35c5292bdc7e"));
            SagSferik2 = (ITTTextBoxColumn)AddControl(new Guid("f66090dd-5aaa-443d-9b49-80abbb35c3e7"));
            SagSilendirik2 = (ITTTextBoxColumn)AddControl(new Guid("2e6eea5c-cdb2-4651-9283-1d05152a60ff"));
            SagAks2 = (ITTTextBoxColumn)AddControl(new Guid("c0b91b27-cb0d-4b32-a17d-9156989d957c"));
            SolSferik2 = (ITTTextBoxColumn)AddControl(new Guid("5bae647d-9c35-4f18-93b0-fc4892717dc6"));
            SolSilendirik2 = (ITTTextBoxColumn)AddControl(new Guid("20b9ebc7-8888-4492-9537-a1a6465b89ef"));
            SolAks2 = (ITTTextBoxColumn)AddControl(new Guid("ec356ecd-6959-40ff-8b4f-e80a44424a8e"));
            TesisKodu = (ITTTextBoxColumn)AddControl(new Guid("db8b64d2-2fb4-4005-9100-2b3460d4d679"));
            DrTCKimlikNo = (ITTTextBoxColumn)AddControl(new Guid("4bd06a2e-c914-4e0f-94dc-4cea6c3c9ae7"));
            DrTescilNo = (ITTTextBoxColumn)AddControl(new Guid("0d210dec-b55c-497c-aee7-e7f85898893b"));
            DeletePrescription = (ITTButtonColumn)AddControl(new Guid("166e1205-074d-4b9f-b1b6-d9200fad112f"));
            cmdQuery = (ITTButton)AddControl(new Guid("ad87d739-b9e5-4db5-bd00-8a4a7ef896c1"));
            PatientSearchList = (ITTObjectListBox)AddControl(new Guid("d99a7fd5-e881-4ee4-a214-f1fb0ff675e0"));
            base.InitializeControls();
        }

        public OptikEReceteIslemleri() : base("OptikEReceteIslemleri")
        {
        }

        protected OptikEReceteIslemleri(string formDefName) : base(formDefName)
        {
        }
    }
}
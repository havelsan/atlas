
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
    public partial class BulasiciHastalikBildirimForm : TTForm
    {
    /// <summary>
    /// Tanı Gridi
    /// </summary>
        protected TTObjectClasses.DiagnosisGrid _DiagnosisGrid
        {
            get { return (TTObjectClasses.DiagnosisGrid)_ttObject; }
        }

        protected ITTLabel labelDiagnose;
        protected ITTObjectListBox Diagnose;
        protected ITTLabel labelSKRSVakaTipi;
        protected ITTObjectListBox SKRSVakaTipi;
        protected ITTLabel labelSKRSKoyKodlariPatient;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox SKRSKoyKodlariPatient;
        protected ITTObjectListBox SKRSMahalleKodlariPatient;
        protected ITTLabel labelSKRSILKodlariPatient;
        protected ITTObjectListBox SKRSILKodlariPatient;
        protected ITTLabel labelSKRSIlceKodlariPatient;
        protected ITTObjectListBox SKRSIlceKodlariPatient;
        protected ITTLabel labelDisKapiPatient;
        protected ITTTextBox DisKapiPatient;
        protected ITTTextBox BucakKoduPatient;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelBucakKoduPatient;
        protected ITTLabel labelCommunicationınfo;
        protected ITTGrid BulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSAdresTipiBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSIlBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSIlceBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSBucakKodlariBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSKoyKodlariBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSMahalleKodlariBulasiciAdresBilgisi;
        protected ITTTextBoxColumn DisKapi;
        protected ITTTextBoxColumn IcKapi;
        protected ITTTextBoxColumn CSBMKodu;
        protected ITTGrid BulasiciTelefonBilgisi;
        protected ITTListBoxColumn SKRSTelefonTipiBulasiciTelefonBilgisi;
        protected ITTTextBoxColumn Phone;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTMaskedTextBox ttMobilePhone;
        protected ITTMaskedTextBox ttHomePhoneTxt;
        protected ITTLabel BaselabelMobilePhone;
        protected ITTLabel BaselabelHomePhone;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelDiagnose = (ITTLabel)AddControl(new Guid("d1baf205-f07f-42fc-87ec-41095019afb4"));
            Diagnose = (ITTObjectListBox)AddControl(new Guid("14c95077-c5cb-4fc2-96b2-79d2618681f5"));
            labelSKRSVakaTipi = (ITTLabel)AddControl(new Guid("68fc8626-c58c-4276-8eea-4430ee06f91a"));
            SKRSVakaTipi = (ITTObjectListBox)AddControl(new Guid("6259c262-9074-40d9-bf94-10f06a9bbff2"));
            labelSKRSKoyKodlariPatient = (ITTLabel)AddControl(new Guid("2dfce9c6-8fef-4966-bf07-4df4e3dd8abe"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("10ee6ecf-de9a-400f-b9de-b0a1168b2fc1"));
            SKRSKoyKodlariPatient = (ITTObjectListBox)AddControl(new Guid("503dd433-6b9e-4b51-afd8-80e040e8db30"));
            SKRSMahalleKodlariPatient = (ITTObjectListBox)AddControl(new Guid("b9548186-7199-4445-a579-bf91be1250f1"));
            labelSKRSILKodlariPatient = (ITTLabel)AddControl(new Guid("f490ca11-011e-4ff3-aa9f-7fb7da6dd011"));
            SKRSILKodlariPatient = (ITTObjectListBox)AddControl(new Guid("21c91bd4-5c9d-4456-b0a8-2bd79a99b019"));
            labelSKRSIlceKodlariPatient = (ITTLabel)AddControl(new Guid("e1f9ec1d-3c08-4d33-9118-538bad8f0f4f"));
            SKRSIlceKodlariPatient = (ITTObjectListBox)AddControl(new Guid("84003733-2d93-43e7-a1e7-cddccf085a07"));
            labelDisKapiPatient = (ITTLabel)AddControl(new Guid("9a92d3db-9263-4dae-bae8-b9633b2e8132"));
            DisKapiPatient = (ITTTextBox)AddControl(new Guid("f4434cf8-a793-4cdb-b982-bc838f2cba99"));
            BucakKoduPatient = (ITTTextBox)AddControl(new Guid("3f85f308-b1c5-40c6-9391-9f5a8c57c10b"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4e885331-90a5-4970-8965-f4a6a7dcff82"));
            labelBucakKoduPatient = (ITTLabel)AddControl(new Guid("ac5e87fe-23a6-40e2-96ec-9fce695e6516"));
            labelCommunicationınfo = (ITTLabel)AddControl(new Guid("5459de10-19a8-458e-8d18-5e3a52c359a3"));
            BulasiciAdresBilgisi = (ITTGrid)AddControl(new Guid("7b2c9c15-4ef7-4945-b8f2-4e874821cf27"));
            SKRSAdresTipiBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("458ada59-81e1-4007-8c59-08e1d7d2cae2"));
            SKRSIlBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("7333b5f8-b4ee-4a4b-acf9-1a256fb57b8f"));
            SKRSIlceBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("e92aa8a7-0a85-42da-8626-b2cdd599e8d9"));
            SKRSBucakKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("1981d23c-c60e-4a1c-8ed6-a0a215d6e1e5"));
            SKRSKoyKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("2900a9c0-020d-4fdb-a3c4-a86ff2ead560"));
            SKRSMahalleKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("27be3924-127c-4bb3-9882-4a6c331202e1"));
            DisKapi = (ITTTextBoxColumn)AddControl(new Guid("99d5a8c0-400f-435d-8115-d792efdb7c21"));
            IcKapi = (ITTTextBoxColumn)AddControl(new Guid("e2086937-d7d0-4e6b-97cc-f1fdd5ffdc9f"));
            CSBMKodu = (ITTTextBoxColumn)AddControl(new Guid("6ffebd18-748f-4770-946a-7e738668d1b8"));
            BulasiciTelefonBilgisi = (ITTGrid)AddControl(new Guid("2ef3d51d-a2d8-4bdb-a560-c50470b9660d"));
            SKRSTelefonTipiBulasiciTelefonBilgisi = (ITTListBoxColumn)AddControl(new Guid("5b5b8f5f-4073-467e-ba2b-bb2c8a392a35"));
            Phone = (ITTTextBoxColumn)AddControl(new Guid("749201f4-55e7-4bb8-97b4-fc75835f9746"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8f60f024-7b22-449c-b4c5-2aa6347efbdf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d15bcb00-f1f7-4ec2-9c4c-3b41e079b190"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("086f54b9-2dad-4441-88fa-03063945d406"));
            ttMobilePhone = (ITTMaskedTextBox)AddControl(new Guid("8ca6c316-55dd-4c53-bba6-69a74f9dee6f"));
            ttHomePhoneTxt = (ITTMaskedTextBox)AddControl(new Guid("a6dbb790-f7dd-4dfc-875e-2bb7212b72e9"));
            BaselabelMobilePhone = (ITTLabel)AddControl(new Guid("d955bf4f-7e58-4423-9664-f9d2289370ac"));
            BaselabelHomePhone = (ITTLabel)AddControl(new Guid("3914c39f-e162-4aa8-8f67-204cc60d5f4e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("913be651-af2f-4885-bd68-d2436e2d9cb8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7815e216-44ca-4b67-9c77-1fba21ec1ced"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("68094c6a-233e-4d50-9619-f436f6c75e7c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("00875ac6-387f-4933-98fa-442a83e48d5f"));
            base.InitializeControls();
        }

        public BulasiciHastalikBildirimForm() : base("DIAGNOSISGRID", "BulasiciHastalikBildirimForm")
        {
        }

        protected BulasiciHastalikBildirimForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
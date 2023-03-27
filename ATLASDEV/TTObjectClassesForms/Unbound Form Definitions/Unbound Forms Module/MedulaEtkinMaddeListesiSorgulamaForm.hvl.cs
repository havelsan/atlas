
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
    public partial class MedulaEtkinMaddeListesiSorgulama : TTUnboundForm
    {
        protected ITTButton cmdClose;
        protected ITTTextBox edtDoktorTC;
        protected ITTTextBox txtSonucMesaji;
        protected ITTTextBox txtSonucKodu;
        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton1;
        protected ITTLabel lblSonucMesaji;
        protected ITTLabel lblSonucKodu;
        protected ITTGrid gridEtkinMadde;
        protected ITTTextBoxColumn etkinMaddeKodu;
        protected ITTTextBoxColumn etkinMaddeAdi;
        protected ITTTextBoxColumn adetMiktari;
        protected ITTTextBoxColumn icerikMiktari;
        protected ITTTextBoxColumn form;
        override protected void InitializeControls()
        {
            cmdClose = (ITTButton)AddControl(new Guid("643c3a1a-ec61-49d0-8dda-2c9d545af333"));
            edtDoktorTC = (ITTTextBox)AddControl(new Guid("825826f1-0050-4530-8c5d-677fb8d52eda"));
            txtSonucMesaji = (ITTTextBox)AddControl(new Guid("bb08c467-dc4e-4702-8a51-c52f8189d00c"));
            txtSonucKodu = (ITTTextBox)AddControl(new Guid("6fcb7ca0-057a-4b74-b664-22beb0d01f5e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3fca3c4a-88b6-41d3-8a6e-3ea7e2bdd177"));
            ttbutton1 = (ITTButton)AddControl(new Guid("235cd80a-dfba-4242-a643-7db09c267039"));
            lblSonucMesaji = (ITTLabel)AddControl(new Guid("fabec6a1-6680-496d-a772-b48c01833407"));
            lblSonucKodu = (ITTLabel)AddControl(new Guid("1385fe96-bb79-4e13-ac60-36095061f915"));
            gridEtkinMadde = (ITTGrid)AddControl(new Guid("601689aa-a539-4822-bf83-d5cb0d84a2cc"));
            etkinMaddeKodu = (ITTTextBoxColumn)AddControl(new Guid("70ab5fde-4785-458d-8f61-9b4a0f549579"));
            etkinMaddeAdi = (ITTTextBoxColumn)AddControl(new Guid("7fd51af4-e9db-4a1a-ac4d-f55ab35087fc"));
            adetMiktari = (ITTTextBoxColumn)AddControl(new Guid("d17cfa65-8838-48a3-bed8-c11eeec25760"));
            icerikMiktari = (ITTTextBoxColumn)AddControl(new Guid("cbbd06e2-2aa8-439a-898a-8529ad46d6cf"));
            form = (ITTTextBoxColumn)AddControl(new Guid("166359be-182c-4814-8bf4-9d2d36afd259"));
            base.InitializeControls();
        }

        public MedulaEtkinMaddeListesiSorgulama() : base("MedulaEtkinMaddeListesiSorgulama")
        {
        }

        protected MedulaEtkinMaddeListesiSorgulama(string formDefName) : base(formDefName)
        {
        }
    }
}
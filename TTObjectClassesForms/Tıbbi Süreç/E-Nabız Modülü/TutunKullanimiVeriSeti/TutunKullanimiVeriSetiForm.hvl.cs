
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
    public partial class TutunKullanimiVeriSetiForm : TTForm
    {
        protected TTObjectClasses.TutunKullanimiVeriSeti _TutunKullanimiVeriSeti
        {
            get { return (TTObjectClasses.TutunKullanimiVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSTutunDumaninaMaruzKalma;
        protected ITTObjectListBox SKRSTutunDumaninaMaruzKalma;
        protected ITTLabel labelSKRSSigaraKullanimi;
        protected ITTObjectListBox SKRSSigaraKullanimi;
        protected ITTGrid TutunKullanimiTedaviSonucu;
        protected ITTListBoxColumn SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu;
        protected ITTGrid TutunKullanimiTedaviSekli;
        protected ITTListBoxColumn SKRSTedaviSekliTutunKullanimiTedaviSekli;
        protected ITTGrid TutunKullanimiBagimOldUrun;
        protected ITTListBoxColumn SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun;
        protected ITTLabel labelSigaraAdedi;
        protected ITTTextBox SigaraAdedi;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            labelSKRSTutunDumaninaMaruzKalma = (ITTLabel)AddControl(new Guid("0ccc5321-5583-4f28-a5c6-3e5ee74e3c3f"));
            SKRSTutunDumaninaMaruzKalma = (ITTObjectListBox)AddControl(new Guid("59c4f4d7-8188-4a84-aed4-93baf9cb4e1d"));
            labelSKRSSigaraKullanimi = (ITTLabel)AddControl(new Guid("2fe3c932-1258-4908-941c-4e1ec2cc820f"));
            SKRSSigaraKullanimi = (ITTObjectListBox)AddControl(new Guid("becd37e8-f124-4463-9210-cb1bc4a1eed1"));
            TutunKullanimiTedaviSonucu = (ITTGrid)AddControl(new Guid("51d3b1cf-89be-48e5-8480-8bb843e07c1d"));
            SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu = (ITTListBoxColumn)AddControl(new Guid("4f87f961-e8ca-48d3-b4c3-09cc3712284f"));
            TutunKullanimiTedaviSekli = (ITTGrid)AddControl(new Guid("0bece8ad-4ad5-46d1-9251-3cad7ce3b96d"));
            SKRSTedaviSekliTutunKullanimiTedaviSekli = (ITTListBoxColumn)AddControl(new Guid("f9e97345-fa0d-4a79-b1c7-579ce0558dd9"));
            TutunKullanimiBagimOldUrun = (ITTGrid)AddControl(new Guid("16f369bf-8ded-4e25-bde1-4e01f93cce2b"));
            SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun = (ITTListBoxColumn)AddControl(new Guid("06a8c43a-a15a-4d98-ab06-4069a3f93657"));
            labelSigaraAdedi = (ITTLabel)AddControl(new Guid("118fa8a3-dfe6-41b9-a519-5db11d3dd990"));
            SigaraAdedi = (ITTTextBox)AddControl(new Guid("b7e16055-2dff-4e75-b88c-3d3ed7ec1976"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e62ca3bd-e835-43ec-ab86-1223a841e7ce"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("100e10d0-c851-4aea-8360-843540639490"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b441b835-8db8-4e3d-9d1b-3e49df540738"));
            base.InitializeControls();
        }

        public TutunKullanimiVeriSetiForm() : base("TUTUNKULLANIMIVERISETI", "TutunKullanimiVeriSetiForm")
        {
        }

        protected TutunKullanimiVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
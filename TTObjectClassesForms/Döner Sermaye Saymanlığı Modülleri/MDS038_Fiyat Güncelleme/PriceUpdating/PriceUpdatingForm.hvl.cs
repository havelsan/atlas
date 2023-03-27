
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
    /// Fiyat Güncelleme
    /// </summary>
    public partial class PriceUpdatingForm : TTForm
    {
    /// <summary>
    /// Fiyat Güncelleme
    /// </summary>
        protected TTObjectClasses.PriceUpdating _PriceUpdating
        {
            get { return (TTObjectClasses.PriceUpdating)_ttObject; }
        }

        protected ITTLabel ttlabel6;
        protected ITTObjectListBox PRICELIST;
        protected ITTLabel ttlabel3;
        protected ITTTextBox RESULTDATA;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MATERIALLIST;
        protected ITTObjectListBox PROCEDURELIST;
        protected ITTButton UNSELECTALL;
        protected ITTButton SELECTALL;
        protected ITTButton LISTBUTTON;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTTabControl TABProcedureMaterial;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDProcedures;
        protected ITTDateTimePickerColumn PTRXDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTCheckBoxColumn PUPDATE;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GRIDMaterials;
        protected ITTDateTimePickerColumn MTRXDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTCheckBoxColumn MUPDATE;
        override protected void InitializeControls()
        {
            ttlabel6 = (ITTLabel)AddControl(new Guid("de8fef76-561e-417f-92b1-897789be6403"));
            PRICELIST = (ITTObjectListBox)AddControl(new Guid("2cadfb49-12e0-4fa2-aaba-7aec033f7fbe"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c014d70f-c9fe-4fe3-bb21-aeb6f019dccc"));
            RESULTDATA = (ITTTextBox)AddControl(new Guid("7858a020-58a1-43d6-82a8-b327e03d43b5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c3ec9356-a4bf-404b-bf87-15ffa5e97676"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("55b1bded-6dfb-473d-9e72-7371d0faa895"));
            MATERIALLIST = (ITTObjectListBox)AddControl(new Guid("f1a09100-6e73-49e2-a7b7-654ae61be258"));
            PROCEDURELIST = (ITTObjectListBox)AddControl(new Guid("bfd60c06-a31c-4343-a373-7879b3803f11"));
            UNSELECTALL = (ITTButton)AddControl(new Guid("e03096b1-c796-4deb-b9c2-b700c6a2872c"));
            SELECTALL = (ITTButton)AddControl(new Guid("a385928e-b52e-4bfe-a7d8-ba87b46597f6"));
            LISTBUTTON = (ITTButton)AddControl(new Guid("7d5d3965-080c-4d79-be11-faf695cd6972"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8f91a79a-ceb3-4a7c-952b-c33eb7aa0c3d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8fb01a55-fcd8-4171-a8f6-7f2ffddec876"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("3000b24d-bd52-42c6-b79b-99897e14deca"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("bc710400-1fb5-4724-acb4-61af50de3aff"));
            TABProcedureMaterial = (ITTTabControl)AddControl(new Guid("90f81fc5-5fd9-46be-bd48-52b0dbb6c65e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("ffacde05-c760-43f2-880c-4ab73a65c048"));
            GRIDProcedures = (ITTGrid)AddControl(new Guid("f29bfd13-a195-45e0-8c75-3f7c992625ff"));
            PTRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("08a3ef46-f94f-4531-aba1-acfba06e2b79"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("3ec8b48c-18ba-4c3f-8370-eab9c8d5eeee"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("b51aa773-f5f0-4dee-aec1-2cd7d138113d"));
            PUPDATE = (ITTCheckBoxColumn)AddControl(new Guid("5294c9b4-161b-41a9-be4b-f96be2402aaa"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("80be71df-9aa9-4f63-a4a7-e3a986f7d3d8"));
            GRIDMaterials = (ITTGrid)AddControl(new Guid("8ec52f32-f811-449e-976a-b3f84d44567d"));
            MTRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("4f55a9e4-269c-4847-b069-b1dfff11a446"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("aab639df-6812-47e1-a36a-72530d2c4fef"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("315bf9be-dd62-4cd3-aca7-83581196afbc"));
            MUPDATE = (ITTCheckBoxColumn)AddControl(new Guid("91337853-015e-418e-a24d-73ecb565ccc5"));
            base.InitializeControls();
        }

        public PriceUpdatingForm() : base("PRICEUPDATING", "PriceUpdatingForm")
        {
        }

        protected PriceUpdatingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
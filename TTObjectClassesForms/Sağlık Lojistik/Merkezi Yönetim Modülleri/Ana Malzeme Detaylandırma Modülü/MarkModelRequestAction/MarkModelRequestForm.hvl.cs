
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
    /// Marka/Model/Gövde Yapısı/ Uç Yapısı / Uzunluk İstek  
    /// </summary>
    public partial class MarkModelRequestForm : CentralActionBaseForm
    {
    /// <summary>
    /// Marka/Model/Gövde Yapısı/ Uç Yapısı / Uzunluk İstek  
    /// </summary>
        protected TTObjectClasses.MarkModelRequestAction _MarkModelRequestAction
        {
            get { return (TTObjectClasses.MarkModelRequestAction)_ttObject; }
        }

        protected ITTGroupBox BodyEdgeLengthRequestBox;
        protected ITTObjectListBox FixedAssetDetailEdgeDefFixedAssetDetailLengthDef;
        protected ITTLabel labelBodyName;
        protected ITTLabel labelEdgeName;
        protected ITTLabel labelLength;
        protected ITTObjectListBox FixedAssetDetailBodyDef;
        protected ITTLabel labelFixedAssetDetailBodyDef;
        protected ITTObjectListBox FixedAssetDetailEdgeDef;
        protected ITTLabel labelFixedAssetDetailEdgeDef;
        protected ITTCheckBox NoEdge;
        protected ITTTextBox BodyName;
        protected ITTCheckBox NoLength;
        protected ITTTextBox EdgeName;
        protected ITTLabel labelFixedAssetDetailEdgeDefFixedAssetDetailLengthDef;
        protected ITTTextBox Length;
        protected ITTCheckBox NoBody;
        protected ITTGroupBox MarkModelRequestBox;
        protected ITTObjectListBox FixedAssetDetailMarkDefFixedAssetDetailModelDef;
        protected ITTLabel labelMarkName;
        protected ITTLabel labelModelName;
        protected ITTObjectListBox FixedAssetDetailMarkDef;
        protected ITTLabel labelFixedAssetDetailMarkDef;
        protected ITTTextBox MarkName;
        protected ITTTextBox ModelName;
        protected ITTLabel labelFixedAssetDetailMarkDefFixedAssetDetailModelDef;
        protected ITTCheckBox NoMark;
        protected ITTCheckBox NoModel;
        protected ITTCheckBox BodyEdgeLengt;
        protected ITTCheckBox MarkModelReason;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelFixedAssetDetailMainClassDef;
        protected ITTObjectListBox FixedAssetDetailMainClassDef;
        override protected void InitializeControls()
        {
            BodyEdgeLengthRequestBox = (ITTGroupBox)AddControl(new Guid("1b32ccfa-c78e-4a68-a7ab-8ef055fb146c"));
            FixedAssetDetailEdgeDefFixedAssetDetailLengthDef = (ITTObjectListBox)AddControl(new Guid("f0843b67-38af-484f-9d65-483850ad8fe9"));
            labelBodyName = (ITTLabel)AddControl(new Guid("5d650d3d-f259-4c1e-b4f1-1966bdf0f7a5"));
            labelEdgeName = (ITTLabel)AddControl(new Guid("f45bf53b-b8dd-45b7-8c72-2d53f2c8190e"));
            labelLength = (ITTLabel)AddControl(new Guid("bfc62d24-01f4-4b77-9d92-e4f14351d44f"));
            FixedAssetDetailBodyDef = (ITTObjectListBox)AddControl(new Guid("03b8e7cb-6fe0-4f5d-9efd-7624538de368"));
            labelFixedAssetDetailBodyDef = (ITTLabel)AddControl(new Guid("01033cc0-4262-4527-b7a7-2065600b7eea"));
            FixedAssetDetailEdgeDef = (ITTObjectListBox)AddControl(new Guid("b0085ac5-fb13-4d48-a350-67c7faecd0fb"));
            labelFixedAssetDetailEdgeDef = (ITTLabel)AddControl(new Guid("b828e462-dd26-4df3-b98b-28560f2d0f88"));
            NoEdge = (ITTCheckBox)AddControl(new Guid("a2e7a696-4c65-437d-a16b-68597968a768"));
            BodyName = (ITTTextBox)AddControl(new Guid("2952be9c-a829-4ead-85f4-29b3ad6411ef"));
            NoLength = (ITTCheckBox)AddControl(new Guid("48381670-cd8a-4ee6-bcf3-4019b3b4651e"));
            EdgeName = (ITTTextBox)AddControl(new Guid("d3e9546c-4b39-4d2c-95e3-2e1c84433884"));
            labelFixedAssetDetailEdgeDefFixedAssetDetailLengthDef = (ITTLabel)AddControl(new Guid("9d55b4e1-165a-42d3-96f8-5aa11692ced4"));
            Length = (ITTTextBox)AddControl(new Guid("7674e220-37eb-447e-80df-4956cfefef1a"));
            NoBody = (ITTCheckBox)AddControl(new Guid("38d98287-1854-4a6e-8387-5533e79f0397"));
            MarkModelRequestBox = (ITTGroupBox)AddControl(new Guid("8485038b-f96d-4369-88ea-dd2489a5a018"));
            FixedAssetDetailMarkDefFixedAssetDetailModelDef = (ITTObjectListBox)AddControl(new Guid("e5009e60-2bc2-4d9d-a913-a300c35eb9ab"));
            labelMarkName = (ITTLabel)AddControl(new Guid("a32de838-569d-4a3c-8b4a-3b7b8ca2c71e"));
            labelModelName = (ITTLabel)AddControl(new Guid("c0513072-fced-4888-b497-2e3eb9e65f1e"));
            FixedAssetDetailMarkDef = (ITTObjectListBox)AddControl(new Guid("3743c9ae-c7e3-418e-97d1-917071270a47"));
            labelFixedAssetDetailMarkDef = (ITTLabel)AddControl(new Guid("b136c120-536c-4c34-bf2c-365fe53c42d0"));
            MarkName = (ITTTextBox)AddControl(new Guid("d3036352-1ca9-48da-8875-25d50b7b081b"));
            ModelName = (ITTTextBox)AddControl(new Guid("fd25a936-c2fc-4317-a92f-a5eb8f392243"));
            labelFixedAssetDetailMarkDefFixedAssetDetailModelDef = (ITTLabel)AddControl(new Guid("e74a1dba-7426-48d4-9cda-98bedf9017f3"));
            NoMark = (ITTCheckBox)AddControl(new Guid("685d5e83-fe10-4119-bfe4-24e94bb4d8e6"));
            NoModel = (ITTCheckBox)AddControl(new Guid("4367bd53-c7de-496e-bf02-8eaf508a63ad"));
            BodyEdgeLengt = (ITTCheckBox)AddControl(new Guid("607b1004-3822-40c6-94a5-ca4f6b536f63"));
            MarkModelReason = (ITTCheckBox)AddControl(new Guid("9b2a5d3f-b939-42cd-a339-7c0631cb7b12"));
            labelDescription = (ITTLabel)AddControl(new Guid("a7ae60ba-5cd0-434d-8ded-211242662c8f"));
            Description = (ITTTextBox)AddControl(new Guid("115492ec-9cf9-4f27-ba1f-335ae6a25dff"));
            labelFixedAssetDetailMainClassDef = (ITTLabel)AddControl(new Guid("b24d0b5a-1ee0-4a86-a200-c865732bc06e"));
            FixedAssetDetailMainClassDef = (ITTObjectListBox)AddControl(new Guid("21243495-0448-44f4-8ec0-c1fdd5f0a3de"));
            base.InitializeControls();
        }

        public MarkModelRequestForm() : base("MARKMODELREQUESTACTION", "MarkModelRequestForm")
        {
        }

        protected MarkModelRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}
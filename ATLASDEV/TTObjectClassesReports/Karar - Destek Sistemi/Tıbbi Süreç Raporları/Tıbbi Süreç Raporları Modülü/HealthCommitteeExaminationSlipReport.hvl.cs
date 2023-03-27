
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Sağlık Kurulu Muayene Fişi A4(Arkalı-Önlü)
    /// </summary>
    public partial class HealthCommitteeExaminationSlipReport : TTReport
    {
#region Methods
   public List<ResourceAndProcedure> ResourceAndProcedureList = new List<ResourceAndProcedure>();
        
        public int counter = 0;
        
        public class ResourceAndProcedure
        {
            public string Resource = "";
            public string Procedure = "";
            public ResourceAndProcedure(string resource, string procedure)
            {
                this.Resource = resource;
                this.Procedure = procedure;
            }
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("C7203EFB-0742-4709-9E32-6D3608F9C34F");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeExaminationSlipReport MyParentReport
            {
                get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public HealthCommitteeExaminationSlipReport MyParentReport
                {
                    get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeExaminationSlipReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID",Guid.Empty.ToString()));
            string hizmetler = "";
            string kaynak = "";
            ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList.Clear();
            
            
            foreach(BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in hc.HospitalsUnits) // Gride girilen sağlık kurulu muayeneleri
            {
                kaynak = "";
                hizmetler = "";
                
                if (hospitalUnit.Unit != null)
                {
                    kaynak = hospitalUnit.Unit.Name;
                }                
                if(hospitalUnit.Speciality != null)
                    kaynak += ", " + hospitalUnit.Speciality.Name;
                
                ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList.Add(new ResourceAndProcedure(kaynak,""));
                
                if (hospitalUnit.EpisodeActionTemplate != null && hospitalUnit.EpisodeActionTemplate.ActionType != null && hospitalUnit.EpisodeActionTemplate.ActionType == ActionTypeEnum.ManipulationRequest) // tipi manipulation ise şablonu ekle
                {
                    hizmetler = "";
                    kaynak = "";
                    if (hospitalUnit.EpisodeActionTemplate.Resource != null && hospitalUnit.EpisodeActionTemplate.Resource.Name != null)
                        kaynak = hospitalUnit.EpisodeActionTemplate.Resource.Name.ToString();

                    if (hospitalUnit.EpisodeActionTemplate.ProcedureDefinitions.Count > 0)
                    {
                        foreach (EpisodeActionProcedureObjectTemplate procedure in hospitalUnit.EpisodeActionTemplate.ProcedureDefinitions)
                        {
                            hizmetler += procedure.ProcedureDefinition.Code + " " + procedure.ProcedureDefinition.Name + " , ";
                        }
                        hizmetler = hizmetler.Substring(0, hizmetler.Length - 3);
                    }
                    ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList.Add(new ResourceAndProcedure(kaynak,hizmetler));
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HealthCommitteeExaminationSlipReport MyParentReport
                {
                    get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class ArkasayfaGroup : TTReportGroup
        {
            public HealthCommitteeExaminationSlipReport MyParentReport
            {
                get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
            }

            new public ArkasayfaGroupHeader Header()
            {
                return (ArkasayfaGroupHeader)_header;
            }

            new public ArkasayfaGroupFooter Footer()
            {
                return (ArkasayfaGroupFooter)_footer;
            }

            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportField BIRIM13 { get {return Header().BIRIM13;} }
            public TTReportField BIRIM14 { get {return Header().BIRIM14;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportShape NewLine9 { get {return Header().NewLine9;} }
            public TTReportShape NewLine10 { get {return Header().NewLine10;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField NewField50 { get {return Header().NewField50;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportField ACIKLAMA13 { get {return Header().ACIKLAMA13;} }
            public TTReportField ACIKLAMA14 { get {return Header().ACIKLAMA14;} }
            public TTReportField BIRIM15 { get {return Header().BIRIM15;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportField ACIKLAMA15 { get {return Header().ACIKLAMA15;} }
            public TTReportField BIRIM16 { get {return Header().BIRIM16;} }
            public TTReportShape NewLine21 { get {return Header().NewLine21;} }
            public TTReportField ACIKLAMA16 { get {return Header().ACIKLAMA16;} }
            public TTReportField BIRIM12 { get {return Header().BIRIM12;} }
            public TTReportField ACIKLAMA12 { get {return Header().ACIKLAMA12;} }
            public TTReportShape NewLine22 { get {return Header().NewLine22;} }
            public TTReportField SKBSK { get {return Header().SKBSK;} }
            public TTReportField TBP1 { get {return Header().TBP1;} }
            public TTReportField TBP2 { get {return Header().TBP2;} }
            public TTReportField TBP3 { get {return Header().TBP3;} }
            public TTReportField TBP4 { get {return Header().TBP4;} }
            public TTReportField TBP5 { get {return Header().TBP5;} }
            public TTReportField TBP6 { get {return Header().TBP6;} }
            public TTReportField TBP7 { get {return Header().TBP7;} }
            public TTReportField TBP8 { get {return Header().TBP8;} }
            public TTReportField TBP10 { get {return Header().TBP10;} }
            public TTReportField TBP11 { get {return Header().TBP11;} }
            public TTReportField TBP12 { get {return Header().TBP12;} }
            public TTReportField TBP13 { get {return Header().TBP13;} }
            public TTReportField TBP14 { get {return Header().TBP14;} }
            public TTReportField TBP15 { get {return Header().TBP15;} }
            public TTReportField TBP16 { get {return Header().TBP16;} }
            public TTReportField TBP9 { get {return Header().TBP9;} }
            public TTReportField TBP17 { get {return Header().TBP17;} }
            public TTReportField TBP19 { get {return Header().TBP19;} }
            public TTReportField TBP20 { get {return Header().TBP20;} }
            public TTReportField TBP21 { get {return Header().TBP21;} }
            public TTReportField TBP22 { get {return Header().TBP22;} }
            public TTReportField TBP23 { get {return Header().TBP23;} }
            public TTReportField TBP24 { get {return Header().TBP24;} }
            public TTReportField TBP25 { get {return Header().TBP25;} }
            public TTReportField TBP18 { get {return Header().TBP18;} }
            public TTReportShape NewLine102 { get {return Header().NewLine102;} }
            public TTReportField BIRIM17 { get {return Header().BIRIM17;} }
            public TTReportField ACIKLAMA17 { get {return Header().ACIKLAMA17;} }
            public TTReportField BIRIM18 { get {return Footer().BIRIM18;} }
            public TTReportField ACIKLAMA18 { get {return Footer().ACIKLAMA18;} }
            public TTReportField BIRIM19 { get {return Footer().BIRIM19;} }
            public TTReportField ACIKLAMA19 { get {return Footer().ACIKLAMA19;} }
            public TTReportField BIRIM20 { get {return Footer().BIRIM20;} }
            public TTReportField ACIKLAMA20 { get {return Footer().ACIKLAMA20;} }
            public TTReportField BIRIM21 { get {return Footer().BIRIM21;} }
            public TTReportField ACIKLAMA21 { get {return Footer().ACIKLAMA21;} }
            public TTReportField BIRIM22 { get {return Footer().BIRIM22;} }
            public TTReportField ACIKLAMA22 { get {return Footer().ACIKLAMA22;} }
            public TTReportField BIRIM23 { get {return Footer().BIRIM23;} }
            public TTReportField ACIKLAMA23 { get {return Footer().ACIKLAMA23;} }
            public TTReportField BIRIM24 { get {return Footer().BIRIM24;} }
            public TTReportField ACIKLAMA24 { get {return Footer().ACIKLAMA24;} }
            public TTReportField BIRIM25 { get {return Footer().BIRIM25;} }
            public TTReportField ACIKLAMA25 { get {return Footer().ACIKLAMA25;} }
            public TTReportField BIRIM26 { get {return Footer().BIRIM26;} }
            public TTReportField ACIKLAMA26 { get {return Footer().ACIKLAMA26;} }
            public TTReportField BIRIM27 { get {return Footer().BIRIM27;} }
            public TTReportField ACIKLAMA27 { get {return Footer().ACIKLAMA27;} }
            public TTReportField BIRIM28 { get {return Footer().BIRIM28;} }
            public TTReportField ACIKLAMA28 { get {return Footer().ACIKLAMA28;} }
            public TTReportField BIRIM29 { get {return Footer().BIRIM29;} }
            public TTReportField ACIKLAMA29 { get {return Footer().ACIKLAMA29;} }
            public TTReportField BIRIM30 { get {return Footer().BIRIM30;} }
            public TTReportField ACIKLAMA30 { get {return Footer().ACIKLAMA30;} }
            public TTReportField BIRIM31 { get {return Footer().BIRIM31;} }
            public TTReportField ACIKLAMA31 { get {return Footer().ACIKLAMA31;} }
            public TTReportField BIRIM32 { get {return Footer().BIRIM32;} }
            public TTReportField ACIKLAMA32 { get {return Footer().ACIKLAMA32;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine5 { get {return Footer().NewLine5;} }
            public TTReportShape NewLine18 { get {return Footer().NewLine18;} }
            public TTReportShape NewLine19 { get {return Footer().NewLine19;} }
            public TTReportShape NewLine181 { get {return Footer().NewLine181;} }
            public TTReportShape NewLine182 { get {return Footer().NewLine182;} }
            public TTReportShape NewLine183 { get {return Footer().NewLine183;} }
            public TTReportShape NewLine184 { get {return Footer().NewLine184;} }
            public TTReportShape NewLine185 { get {return Footer().NewLine185;} }
            public TTReportShape NewLine186 { get {return Footer().NewLine186;} }
            public TTReportShape NewLine187 { get {return Footer().NewLine187;} }
            public TTReportShape NewLine188 { get {return Footer().NewLine188;} }
            public TTReportShape NewLine189 { get {return Footer().NewLine189;} }
            public TTReportShape NewLine190 { get {return Footer().NewLine190;} }
            public TTReportShape NewLine191 { get {return Footer().NewLine191;} }
            public TTReportShape NewLine192 { get {return Footer().NewLine192;} }
            public TTReportShape NewLine193 { get {return Footer().NewLine193;} }
            public TTReportShape NewLine194 { get {return Footer().NewLine194;} }
            public ArkasayfaGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ArkasayfaGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ArkasayfaGroupHeader(this);
                _footer = new ArkasayfaGroupFooter(this);

            }

            public partial class ArkasayfaGroupHeader : TTReportSection
            {
                public HealthCommitteeExaminationSlipReport MyParentReport
                {
                    get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine6;
                public TTReportField BIRIM13;
                public TTReportField BIRIM14;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportShape NewLine13;
                public TTReportField NewField21;
                public TTReportShape NewLine14;
                public TTReportField NewField50;
                public TTReportField NewField51;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportField ACIKLAMA13;
                public TTReportField ACIKLAMA14;
                public TTReportField BIRIM15;
                public TTReportShape NewLine20;
                public TTReportField ACIKLAMA15;
                public TTReportField BIRIM16;
                public TTReportShape NewLine21;
                public TTReportField ACIKLAMA16;
                public TTReportField BIRIM12;
                public TTReportField ACIKLAMA12;
                public TTReportShape NewLine22;
                public TTReportField SKBSK;
                public TTReportField TBP1;
                public TTReportField TBP2;
                public TTReportField TBP3;
                public TTReportField TBP4;
                public TTReportField TBP5;
                public TTReportField TBP6;
                public TTReportField TBP7;
                public TTReportField TBP8;
                public TTReportField TBP10;
                public TTReportField TBP11;
                public TTReportField TBP12;
                public TTReportField TBP13;
                public TTReportField TBP14;
                public TTReportField TBP15;
                public TTReportField TBP16;
                public TTReportField TBP9;
                public TTReportField TBP17;
                public TTReportField TBP19;
                public TTReportField TBP20;
                public TTReportField TBP21;
                public TTReportField TBP22;
                public TTReportField TBP23;
                public TTReportField TBP24;
                public TTReportField TBP25;
                public TTReportField TBP18;
                public TTReportShape NewLine102;
                public TTReportField BIRIM17;
                public TTReportField ACIKLAMA17; 
                public ArkasayfaGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 276;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 7, 200, 7, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 7, 200, 276, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 276, 200, 276, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 7, 7, 276, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 22, 45, 34, false);
                    BIRIM13.Name = "BIRIM13";
                    BIRIM13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM13.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM13.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM13.TextFont.Size = 8;
                    BIRIM13.TextFont.Bold = true;
                    BIRIM13.Value = @"";

                    BIRIM14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 36, 45, 48, false);
                    BIRIM14.Name = "BIRIM14";
                    BIRIM14.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM14.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM14.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM14.TextFont.Size = 8;
                    BIRIM14.TextFont.Bold = true;
                    BIRIM14.Value = @"";

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 49, 200, 49, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 35, 200, 35, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 94, 44, 111, false);
                    NewField10.Name = "NewField10";
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Size = 8;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Tanı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 99, 52, 103, false);
                    NewField11.Name = "NewField11";
                    NewField11.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"2";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 107, 52, 111, false);
                    NewField12.Name = "NewField12";
                    NewField12.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"4";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 103, 52, 107, false);
                    NewField13.Name = "NewField13";
                    NewField13.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"3";

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 105, 57, 105, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 109, 57, 109, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 113, 200, 113, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 125, 200, 125, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 114, 44, 124, false);
                    NewField18.Name = "NewField18";
                    NewField18.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Size = 8;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Tavsiye";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 126, 44, 141, false);
                    NewField19.Name = "NewField19";
                    NewField19.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.NoClip = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 8;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Hastalık veya malüliyetin sebebi";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 142, 200, 142, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 143, 44, 158, false);
                    NewField21.Name = "NewField21";
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.NoClip = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Size = 8;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"Karar (*)";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 180, 200, 180, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField50 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 268, 199, 284, false);
                    NewField50.Name = "NewField50";
                    NewField50.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField50.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField50.MultiLine = EvetHayirEnum.ehEvet;
                    NewField50.WordBreak = EvetHayirEnum.ehEvet;
                    NewField50.TextFont.Size = 8;
                    NewField50.TextFont.Bold = true;
                    NewField50.Value = @"(*) Karar hanesine XXXXXX Sağlık Yeteneği yönetmeliğinin tanıya uygun madde, dilim ve fıkra numaralarının yazılması zorunludur.";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 95, 52, 99, false);
                    NewField51.Name = "NewField51";
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField51.TextFont.Size = 8;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"1";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 97, 57, 97, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 101, 57, 101, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 46, 7, 46, 180, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    ACIKLAMA13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 22, 199, 34, false);
                    ACIKLAMA13.Name = "ACIKLAMA13";
                    ACIKLAMA13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA13.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA13.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA13.TextFont.Size = 8;
                    ACIKLAMA13.TextFont.Bold = true;
                    ACIKLAMA13.Value = @"";

                    ACIKLAMA14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 36, 199, 48, false);
                    ACIKLAMA14.Name = "ACIKLAMA14";
                    ACIKLAMA14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA14.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA14.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA14.TextFont.Size = 8;
                    ACIKLAMA14.TextFont.Bold = true;
                    ACIKLAMA14.Value = @"";

                    BIRIM15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 50, 45, 62, false);
                    BIRIM15.Name = "BIRIM15";
                    BIRIM15.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM15.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM15.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM15.TextFont.Size = 8;
                    BIRIM15.TextFont.Bold = true;
                    BIRIM15.Value = @"";

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 63, 200, 63, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    ACIKLAMA15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 50, 199, 62, false);
                    ACIKLAMA15.Name = "ACIKLAMA15";
                    ACIKLAMA15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA15.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA15.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA15.TextFont.Size = 8;
                    ACIKLAMA15.TextFont.Bold = true;
                    ACIKLAMA15.Value = @"";

                    BIRIM16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 64, 45, 76, false);
                    BIRIM16.Name = "BIRIM16";
                    BIRIM16.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM16.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM16.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM16.TextFont.Size = 8;
                    BIRIM16.TextFont.Bold = true;
                    BIRIM16.Value = @"";

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 92, 200, 92, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    ACIKLAMA16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 64, 199, 76, false);
                    ACIKLAMA16.Name = "ACIKLAMA16";
                    ACIKLAMA16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA16.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA16.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA16.TextFont.Size = 8;
                    ACIKLAMA16.TextFont.Bold = true;
                    ACIKLAMA16.Value = @"";

                    BIRIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 45, 20, false);
                    BIRIM12.Name = "BIRIM12";
                    BIRIM12.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM12.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM12.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM12.TextFont.Size = 8;
                    BIRIM12.TextFont.Bold = true;
                    BIRIM12.Value = @"";

                    ACIKLAMA12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 8, 199, 20, false);
                    ACIKLAMA12.Name = "ACIKLAMA12";
                    ACIKLAMA12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA12.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA12.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA12.TextFont.Size = 8;
                    ACIKLAMA12.TextFont.Bold = true;
                    ACIKLAMA12.Value = @"";

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 21, 200, 21, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    SKBSK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 181, 38, 187, false);
                    SKBSK.Name = "SKBSK";
                    SKBSK.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKBSK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SKBSK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SKBSK.MultiLine = EvetHayirEnum.ehEvet;
                    SKBSK.NoClip = EvetHayirEnum.ehEvet;
                    SKBSK.WordBreak = EvetHayirEnum.ehEvet;
                    SKBSK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SKBSK.TextFont.Size = 8;
                    SKBSK.TextFont.Bold = true;
                    SKBSK.Value = @"Sağlık Kurulu
Bşk.
İmza, Sicil Nu.";

                    TBP1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 181, 68, 194, false);
                    TBP1.Name = "TBP1";
                    TBP1.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP1.MultiLine = EvetHayirEnum.ehEvet;
                    TBP1.WordBreak = EvetHayirEnum.ehEvet;
                    TBP1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP1.TextFont.Size = 8;
                    TBP1.TextFont.Bold = true;
                    TBP1.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 181, 89, 194, false);
                    TBP2.Name = "TBP2";
                    TBP2.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP2.MultiLine = EvetHayirEnum.ehEvet;
                    TBP2.WordBreak = EvetHayirEnum.ehEvet;
                    TBP2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP2.TextFont.Size = 8;
                    TBP2.TextFont.Bold = true;
                    TBP2.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 181, 110, 194, false);
                    TBP3.Name = "TBP3";
                    TBP3.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP3.MultiLine = EvetHayirEnum.ehEvet;
                    TBP3.WordBreak = EvetHayirEnum.ehEvet;
                    TBP3.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP3.TextFont.Size = 8;
                    TBP3.TextFont.Bold = true;
                    TBP3.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 181, 131, 194, false);
                    TBP4.Name = "TBP4";
                    TBP4.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP4.MultiLine = EvetHayirEnum.ehEvet;
                    TBP4.WordBreak = EvetHayirEnum.ehEvet;
                    TBP4.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP4.TextFont.Size = 8;
                    TBP4.TextFont.Bold = true;
                    TBP4.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 181, 152, 194, false);
                    TBP5.Name = "TBP5";
                    TBP5.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP5.MultiLine = EvetHayirEnum.ehEvet;
                    TBP5.WordBreak = EvetHayirEnum.ehEvet;
                    TBP5.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP5.TextFont.Size = 8;
                    TBP5.TextFont.Bold = true;
                    TBP5.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 181, 173, 194, false);
                    TBP6.Name = "TBP6";
                    TBP6.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP6.MultiLine = EvetHayirEnum.ehEvet;
                    TBP6.WordBreak = EvetHayirEnum.ehEvet;
                    TBP6.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP6.TextFont.Size = 8;
                    TBP6.TextFont.Bold = true;
                    TBP6.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 181, 194, 194, false);
                    TBP7.Name = "TBP7";
                    TBP7.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP7.MultiLine = EvetHayirEnum.ehEvet;
                    TBP7.WordBreak = EvetHayirEnum.ehEvet;
                    TBP7.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP7.TextFont.Size = 8;
                    TBP7.TextFont.Bold = true;
                    TBP7.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 211, 25, 224, false);
                    TBP8.Name = "TBP8";
                    TBP8.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP8.MultiLine = EvetHayirEnum.ehEvet;
                    TBP8.WordBreak = EvetHayirEnum.ehEvet;
                    TBP8.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP8.TextFont.Size = 8;
                    TBP8.TextFont.Bold = true;
                    TBP8.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 211, 68, 224, false);
                    TBP10.Name = "TBP10";
                    TBP10.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP10.MultiLine = EvetHayirEnum.ehEvet;
                    TBP10.WordBreak = EvetHayirEnum.ehEvet;
                    TBP10.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP10.TextFont.Size = 8;
                    TBP10.TextFont.Bold = true;
                    TBP10.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 211, 89, 224, false);
                    TBP11.Name = "TBP11";
                    TBP11.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP11.MultiLine = EvetHayirEnum.ehEvet;
                    TBP11.WordBreak = EvetHayirEnum.ehEvet;
                    TBP11.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP11.TextFont.Size = 8;
                    TBP11.TextFont.Bold = true;
                    TBP11.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 211, 110, 224, false);
                    TBP12.Name = "TBP12";
                    TBP12.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP12.MultiLine = EvetHayirEnum.ehEvet;
                    TBP12.WordBreak = EvetHayirEnum.ehEvet;
                    TBP12.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP12.TextFont.Size = 8;
                    TBP12.TextFont.Bold = true;
                    TBP12.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 211, 131, 224, false);
                    TBP13.Name = "TBP13";
                    TBP13.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP13.MultiLine = EvetHayirEnum.ehEvet;
                    TBP13.WordBreak = EvetHayirEnum.ehEvet;
                    TBP13.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP13.TextFont.Size = 8;
                    TBP13.TextFont.Bold = true;
                    TBP13.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 211, 152, 224, false);
                    TBP14.Name = "TBP14";
                    TBP14.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP14.MultiLine = EvetHayirEnum.ehEvet;
                    TBP14.WordBreak = EvetHayirEnum.ehEvet;
                    TBP14.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP14.TextFont.Size = 8;
                    TBP14.TextFont.Bold = true;
                    TBP14.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 211, 173, 224, false);
                    TBP15.Name = "TBP15";
                    TBP15.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP15.MultiLine = EvetHayirEnum.ehEvet;
                    TBP15.WordBreak = EvetHayirEnum.ehEvet;
                    TBP15.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP15.TextFont.Size = 8;
                    TBP15.TextFont.Bold = true;
                    TBP15.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 211, 194, 224, false);
                    TBP16.Name = "TBP16";
                    TBP16.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP16.MultiLine = EvetHayirEnum.ehEvet;
                    TBP16.WordBreak = EvetHayirEnum.ehEvet;
                    TBP16.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP16.TextFont.Size = 8;
                    TBP16.TextFont.Bold = true;
                    TBP16.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 211, 47, 224, false);
                    TBP9.Name = "TBP9";
                    TBP9.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP9.MultiLine = EvetHayirEnum.ehEvet;
                    TBP9.WordBreak = EvetHayirEnum.ehEvet;
                    TBP9.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP9.TextFont.Size = 8;
                    TBP9.TextFont.Bold = true;
                    TBP9.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 241, 25, 254, false);
                    TBP17.Name = "TBP17";
                    TBP17.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP17.MultiLine = EvetHayirEnum.ehEvet;
                    TBP17.WordBreak = EvetHayirEnum.ehEvet;
                    TBP17.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP17.TextFont.Size = 8;
                    TBP17.TextFont.Bold = true;
                    TBP17.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 241, 68, 254, false);
                    TBP19.Name = "TBP19";
                    TBP19.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP19.MultiLine = EvetHayirEnum.ehEvet;
                    TBP19.WordBreak = EvetHayirEnum.ehEvet;
                    TBP19.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP19.TextFont.Size = 8;
                    TBP19.TextFont.Bold = true;
                    TBP19.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 241, 89, 254, false);
                    TBP20.Name = "TBP20";
                    TBP20.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP20.MultiLine = EvetHayirEnum.ehEvet;
                    TBP20.WordBreak = EvetHayirEnum.ehEvet;
                    TBP20.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP20.TextFont.Size = 8;
                    TBP20.TextFont.Bold = true;
                    TBP20.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 241, 110, 254, false);
                    TBP21.Name = "TBP21";
                    TBP21.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP21.MultiLine = EvetHayirEnum.ehEvet;
                    TBP21.WordBreak = EvetHayirEnum.ehEvet;
                    TBP21.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP21.TextFont.Size = 8;
                    TBP21.TextFont.Bold = true;
                    TBP21.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 241, 131, 254, false);
                    TBP22.Name = "TBP22";
                    TBP22.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP22.MultiLine = EvetHayirEnum.ehEvet;
                    TBP22.WordBreak = EvetHayirEnum.ehEvet;
                    TBP22.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP22.TextFont.Size = 8;
                    TBP22.TextFont.Bold = true;
                    TBP22.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 241, 152, 254, false);
                    TBP23.Name = "TBP23";
                    TBP23.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP23.MultiLine = EvetHayirEnum.ehEvet;
                    TBP23.WordBreak = EvetHayirEnum.ehEvet;
                    TBP23.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP23.TextFont.Size = 8;
                    TBP23.TextFont.Bold = true;
                    TBP23.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 241, 173, 254, false);
                    TBP24.Name = "TBP24";
                    TBP24.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP24.MultiLine = EvetHayirEnum.ehEvet;
                    TBP24.WordBreak = EvetHayirEnum.ehEvet;
                    TBP24.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP24.TextFont.Size = 8;
                    TBP24.TextFont.Bold = true;
                    TBP24.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 241, 194, 254, false);
                    TBP25.Name = "TBP25";
                    TBP25.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP25.MultiLine = EvetHayirEnum.ehEvet;
                    TBP25.WordBreak = EvetHayirEnum.ehEvet;
                    TBP25.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP25.TextFont.Size = 8;
                    TBP25.TextFont.Bold = true;
                    TBP25.Value = @"Tbp.
İmza
Sicil Nu.";

                    TBP18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 241, 47, 254, false);
                    TBP18.Name = "TBP18";
                    TBP18.FillStyle = FillStyleConstants.vbFSTransparent;
                    TBP18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TBP18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TBP18.MultiLine = EvetHayirEnum.ehEvet;
                    TBP18.WordBreak = EvetHayirEnum.ehEvet;
                    TBP18.ExpandTabs = EvetHayirEnum.ehEvet;
                    TBP18.TextFont.Size = 8;
                    TBP18.TextFont.Bold = true;
                    TBP18.Value = @"Tbp.
İmza
Sicil Nu.";

                    NewLine102 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 77, 200, 77, false);
                    NewLine102.Name = "NewLine102";
                    NewLine102.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 78, 45, 91, false);
                    BIRIM17.Name = "BIRIM17";
                    BIRIM17.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM17.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM17.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM17.TextFont.Size = 8;
                    BIRIM17.TextFont.Bold = true;
                    BIRIM17.Value = @"";

                    ACIKLAMA17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 78, 199, 91, false);
                    ACIKLAMA17.Name = "ACIKLAMA17";
                    ACIKLAMA17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA17.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA17.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA17.TextFont.Size = 8;
                    ACIKLAMA17.TextFont.Bold = true;
                    ACIKLAMA17.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BIRIM13.CalcValue = BIRIM13.Value;
                    BIRIM14.CalcValue = BIRIM14.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField50.CalcValue = NewField50.Value;
                    NewField51.CalcValue = NewField51.Value;
                    ACIKLAMA13.CalcValue = ACIKLAMA13.Value;
                    ACIKLAMA14.CalcValue = ACIKLAMA14.Value;
                    BIRIM15.CalcValue = BIRIM15.Value;
                    ACIKLAMA15.CalcValue = ACIKLAMA15.Value;
                    BIRIM16.CalcValue = BIRIM16.Value;
                    ACIKLAMA16.CalcValue = ACIKLAMA16.Value;
                    BIRIM12.CalcValue = BIRIM12.Value;
                    ACIKLAMA12.CalcValue = ACIKLAMA12.Value;
                    SKBSK.CalcValue = SKBSK.Value;
                    TBP1.CalcValue = TBP1.Value;
                    TBP2.CalcValue = TBP2.Value;
                    TBP3.CalcValue = TBP3.Value;
                    TBP4.CalcValue = TBP4.Value;
                    TBP5.CalcValue = TBP5.Value;
                    TBP6.CalcValue = TBP6.Value;
                    TBP7.CalcValue = TBP7.Value;
                    TBP8.CalcValue = TBP8.Value;
                    TBP10.CalcValue = TBP10.Value;
                    TBP11.CalcValue = TBP11.Value;
                    TBP12.CalcValue = TBP12.Value;
                    TBP13.CalcValue = TBP13.Value;
                    TBP14.CalcValue = TBP14.Value;
                    TBP15.CalcValue = TBP15.Value;
                    TBP16.CalcValue = TBP16.Value;
                    TBP9.CalcValue = TBP9.Value;
                    TBP17.CalcValue = TBP17.Value;
                    TBP19.CalcValue = TBP19.Value;
                    TBP20.CalcValue = TBP20.Value;
                    TBP21.CalcValue = TBP21.Value;
                    TBP22.CalcValue = TBP22.Value;
                    TBP23.CalcValue = TBP23.Value;
                    TBP24.CalcValue = TBP24.Value;
                    TBP25.CalcValue = TBP25.Value;
                    TBP18.CalcValue = TBP18.Value;
                    BIRIM17.CalcValue = BIRIM17.Value;
                    ACIKLAMA17.CalcValue = ACIKLAMA17.Value;
                    return new TTReportObject[] { BIRIM13,BIRIM14,NewField10,NewField11,NewField12,NewField13,NewField18,NewField19,NewField21,NewField50,NewField51,ACIKLAMA13,ACIKLAMA14,BIRIM15,ACIKLAMA15,BIRIM16,ACIKLAMA16,BIRIM12,ACIKLAMA12,SKBSK,TBP1,TBP2,TBP3,TBP4,TBP5,TBP6,TBP7,TBP8,TBP10,TBP11,TBP12,TBP13,TBP14,TBP15,TBP16,TBP9,TBP17,TBP19,TBP20,TBP21,TBP22,TBP23,TBP24,TBP25,TBP18,BIRIM17,ACIKLAMA17};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeExaminationSlipReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            TTReportField field;
            TTReportField descField;
            ((HealthCommitteeExaminationSlipReport)ParentReport).counter = 1;
            
            foreach(ResourceAndProcedure resourceAndProcedure in ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList)
            {
                if(((HealthCommitteeExaminationSlipReport)ParentReport).counter > 11 && ((HealthCommitteeExaminationSlipReport)ParentReport).counter < 18)
                {
                    field = this.FieldsByName("BIRIM" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    descField = this.FieldsByName("ACIKLAMA" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    field.CalcValue = resourceAndProcedure.Resource;
                    descField.CalcValue = resourceAndProcedure.Procedure;
                }
                ((HealthCommitteeExaminationSlipReport)ParentReport).counter++;
            }
            
            for(int k = 1; k <= 25; k++)
            {
                field = this.FieldsByName("TBP" + k.ToString());
                
                if (k <= hc.HospitalsUnits.Count)
                    field.Visible = EvetHayirEnum.ehEvet;
                else
                    field.Visible = EvetHayirEnum.ehHayir;
            }
#endregion ARKASAYFA HEADER_Script
                }
            }
            public partial class ArkasayfaGroupFooter : TTReportSection
            {
                public HealthCommitteeExaminationSlipReport MyParentReport
                {
                    get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
                }
                
                public TTReportField BIRIM18;
                public TTReportField ACIKLAMA18;
                public TTReportField BIRIM19;
                public TTReportField ACIKLAMA19;
                public TTReportField BIRIM20;
                public TTReportField ACIKLAMA20;
                public TTReportField BIRIM21;
                public TTReportField ACIKLAMA21;
                public TTReportField BIRIM22;
                public TTReportField ACIKLAMA22;
                public TTReportField BIRIM23;
                public TTReportField ACIKLAMA23;
                public TTReportField BIRIM24;
                public TTReportField ACIKLAMA24;
                public TTReportField BIRIM25;
                public TTReportField ACIKLAMA25;
                public TTReportField BIRIM26;
                public TTReportField ACIKLAMA26;
                public TTReportField BIRIM27;
                public TTReportField ACIKLAMA27;
                public TTReportField BIRIM28;
                public TTReportField ACIKLAMA28;
                public TTReportField BIRIM29;
                public TTReportField ACIKLAMA29;
                public TTReportField BIRIM30;
                public TTReportField ACIKLAMA30;
                public TTReportField BIRIM31;
                public TTReportField ACIKLAMA31;
                public TTReportField BIRIM32;
                public TTReportField ACIKLAMA32;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine5;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine181;
                public TTReportShape NewLine182;
                public TTReportShape NewLine183;
                public TTReportShape NewLine184;
                public TTReportShape NewLine185;
                public TTReportShape NewLine186;
                public TTReportShape NewLine187;
                public TTReportShape NewLine188;
                public TTReportShape NewLine189;
                public TTReportShape NewLine190;
                public TTReportShape NewLine191;
                public TTReportShape NewLine192;
                public TTReportShape NewLine193;
                public TTReportShape NewLine194; 
                public ArkasayfaGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 265;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BIRIM18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 38, 27, false);
                    BIRIM18.Name = "BIRIM18";
                    BIRIM18.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM18.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM18.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM18.TextFont.Size = 8;
                    BIRIM18.TextFont.Bold = true;
                    BIRIM18.Value = @"";

                    ACIKLAMA18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 13, 198, 27, false);
                    ACIKLAMA18.Name = "ACIKLAMA18";
                    ACIKLAMA18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA18.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA18.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA18.TextFont.Size = 8;
                    ACIKLAMA18.TextFont.Bold = true;
                    ACIKLAMA18.Value = @"";

                    BIRIM19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 29, 38, 43, false);
                    BIRIM19.Name = "BIRIM19";
                    BIRIM19.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM19.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM19.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM19.TextFont.Size = 8;
                    BIRIM19.TextFont.Bold = true;
                    BIRIM19.Value = @"";

                    ACIKLAMA19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 29, 198, 43, false);
                    ACIKLAMA19.Name = "ACIKLAMA19";
                    ACIKLAMA19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA19.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA19.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA19.TextFont.Size = 8;
                    ACIKLAMA19.TextFont.Bold = true;
                    ACIKLAMA19.Value = @"";

                    BIRIM20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 45, 38, 59, false);
                    BIRIM20.Name = "BIRIM20";
                    BIRIM20.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM20.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM20.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM20.TextFont.Size = 8;
                    BIRIM20.TextFont.Bold = true;
                    BIRIM20.Value = @"";

                    ACIKLAMA20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 198, 59, false);
                    ACIKLAMA20.Name = "ACIKLAMA20";
                    ACIKLAMA20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA20.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA20.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA20.TextFont.Size = 8;
                    ACIKLAMA20.TextFont.Bold = true;
                    ACIKLAMA20.Value = @"";

                    BIRIM21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 61, 38, 75, false);
                    BIRIM21.Name = "BIRIM21";
                    BIRIM21.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM21.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM21.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM21.TextFont.Size = 8;
                    BIRIM21.TextFont.Bold = true;
                    BIRIM21.Value = @"";

                    ACIKLAMA21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 61, 198, 75, false);
                    ACIKLAMA21.Name = "ACIKLAMA21";
                    ACIKLAMA21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA21.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA21.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA21.TextFont.Size = 8;
                    ACIKLAMA21.TextFont.Bold = true;
                    ACIKLAMA21.Value = @"";

                    BIRIM22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 77, 38, 91, false);
                    BIRIM22.Name = "BIRIM22";
                    BIRIM22.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM22.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM22.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM22.TextFont.Size = 8;
                    BIRIM22.TextFont.Bold = true;
                    BIRIM22.Value = @"";

                    ACIKLAMA22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 77, 198, 91, false);
                    ACIKLAMA22.Name = "ACIKLAMA22";
                    ACIKLAMA22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA22.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA22.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA22.TextFont.Size = 8;
                    ACIKLAMA22.TextFont.Bold = true;
                    ACIKLAMA22.Value = @"";

                    BIRIM23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 38, 107, false);
                    BIRIM23.Name = "BIRIM23";
                    BIRIM23.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM23.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM23.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM23.TextFont.Size = 8;
                    BIRIM23.TextFont.Bold = true;
                    BIRIM23.Value = @"";

                    ACIKLAMA23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 93, 198, 107, false);
                    ACIKLAMA23.Name = "ACIKLAMA23";
                    ACIKLAMA23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA23.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA23.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA23.TextFont.Size = 8;
                    ACIKLAMA23.TextFont.Bold = true;
                    ACIKLAMA23.Value = @"";

                    BIRIM24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 109, 38, 123, false);
                    BIRIM24.Name = "BIRIM24";
                    BIRIM24.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM24.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM24.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM24.TextFont.Size = 8;
                    BIRIM24.TextFont.Bold = true;
                    BIRIM24.Value = @"";

                    ACIKLAMA24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 109, 198, 123, false);
                    ACIKLAMA24.Name = "ACIKLAMA24";
                    ACIKLAMA24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA24.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA24.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA24.TextFont.Size = 8;
                    ACIKLAMA24.TextFont.Bold = true;
                    ACIKLAMA24.Value = @"";

                    BIRIM25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 125, 38, 139, false);
                    BIRIM25.Name = "BIRIM25";
                    BIRIM25.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM25.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM25.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM25.TextFont.Size = 8;
                    BIRIM25.TextFont.Bold = true;
                    BIRIM25.Value = @"";

                    ACIKLAMA25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 125, 198, 139, false);
                    ACIKLAMA25.Name = "ACIKLAMA25";
                    ACIKLAMA25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA25.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA25.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA25.TextFont.Size = 8;
                    ACIKLAMA25.TextFont.Bold = true;
                    ACIKLAMA25.Value = @"";

                    BIRIM26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 141, 38, 155, false);
                    BIRIM26.Name = "BIRIM26";
                    BIRIM26.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM26.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM26.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM26.TextFont.Size = 8;
                    BIRIM26.TextFont.Bold = true;
                    BIRIM26.Value = @"";

                    ACIKLAMA26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 140, 198, 155, false);
                    ACIKLAMA26.Name = "ACIKLAMA26";
                    ACIKLAMA26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA26.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA26.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA26.TextFont.Size = 8;
                    ACIKLAMA26.TextFont.Bold = true;
                    ACIKLAMA26.Value = @"";

                    BIRIM27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 157, 38, 171, false);
                    BIRIM27.Name = "BIRIM27";
                    BIRIM27.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM27.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM27.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM27.TextFont.Size = 8;
                    BIRIM27.TextFont.Bold = true;
                    BIRIM27.Value = @"";

                    ACIKLAMA27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 157, 198, 171, false);
                    ACIKLAMA27.Name = "ACIKLAMA27";
                    ACIKLAMA27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA27.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA27.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA27.TextFont.Size = 8;
                    ACIKLAMA27.TextFont.Bold = true;
                    ACIKLAMA27.Value = @"";

                    BIRIM28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 173, 38, 187, false);
                    BIRIM28.Name = "BIRIM28";
                    BIRIM28.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM28.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM28.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM28.TextFont.Size = 8;
                    BIRIM28.TextFont.Bold = true;
                    BIRIM28.Value = @"";

                    ACIKLAMA28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 173, 198, 187, false);
                    ACIKLAMA28.Name = "ACIKLAMA28";
                    ACIKLAMA28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA28.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA28.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA28.TextFont.Size = 8;
                    ACIKLAMA28.TextFont.Bold = true;
                    ACIKLAMA28.Value = @"";

                    BIRIM29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 189, 38, 203, false);
                    BIRIM29.Name = "BIRIM29";
                    BIRIM29.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM29.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM29.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM29.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM29.TextFont.Size = 8;
                    BIRIM29.TextFont.Bold = true;
                    BIRIM29.Value = @"";

                    ACIKLAMA29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 189, 198, 203, false);
                    ACIKLAMA29.Name = "ACIKLAMA29";
                    ACIKLAMA29.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA29.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA29.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA29.TextFont.Size = 8;
                    ACIKLAMA29.TextFont.Bold = true;
                    ACIKLAMA29.Value = @"";

                    BIRIM30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 205, 38, 219, false);
                    BIRIM30.Name = "BIRIM30";
                    BIRIM30.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM30.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM30.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM30.TextFont.Size = 8;
                    BIRIM30.TextFont.Bold = true;
                    BIRIM30.Value = @"";

                    ACIKLAMA30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 205, 198, 219, false);
                    ACIKLAMA30.Name = "ACIKLAMA30";
                    ACIKLAMA30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA30.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA30.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA30.TextFont.Size = 8;
                    ACIKLAMA30.TextFont.Bold = true;
                    ACIKLAMA30.Value = @"";

                    BIRIM31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 221, 38, 235, false);
                    BIRIM31.Name = "BIRIM31";
                    BIRIM31.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM31.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM31.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM31.TextFont.Size = 8;
                    BIRIM31.TextFont.Bold = true;
                    BIRIM31.Value = @"";

                    ACIKLAMA31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 221, 198, 235, false);
                    ACIKLAMA31.Name = "ACIKLAMA31";
                    ACIKLAMA31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA31.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA31.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA31.TextFont.Size = 8;
                    ACIKLAMA31.TextFont.Bold = true;
                    ACIKLAMA31.Value = @"";

                    BIRIM32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 236, 38, 251, false);
                    BIRIM32.Name = "BIRIM32";
                    BIRIM32.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM32.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM32.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM32.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM32.TextFont.Size = 8;
                    BIRIM32.TextFont.Bold = true;
                    BIRIM32.Value = @"";

                    ACIKLAMA32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 236, 198, 251, false);
                    ACIKLAMA32.Name = "ACIKLAMA32";
                    ACIKLAMA32.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA32.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA32.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA32.TextFont.Size = 8;
                    ACIKLAMA32.TextFont.Bold = true;
                    ACIKLAMA32.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 12, 7, 252, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 12, 199, 12, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 12, 199, 252, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 28, 199, 28, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 39, 12, 39, 252, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 44, 199, 44, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine182 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 60, 199, 60, false);
                    NewLine182.Name = "NewLine182";
                    NewLine182.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine183 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 76, 199, 76, false);
                    NewLine183.Name = "NewLine183";
                    NewLine183.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine184 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 92, 199, 92, false);
                    NewLine184.Name = "NewLine184";
                    NewLine184.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine185 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 108, 199, 108, false);
                    NewLine185.Name = "NewLine185";
                    NewLine185.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine186 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 124, 199, 124, false);
                    NewLine186.Name = "NewLine186";
                    NewLine186.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine187 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 140, 199, 140, false);
                    NewLine187.Name = "NewLine187";
                    NewLine187.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine188 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 156, 199, 156, false);
                    NewLine188.Name = "NewLine188";
                    NewLine188.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine189 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 172, 199, 172, false);
                    NewLine189.Name = "NewLine189";
                    NewLine189.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine190 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 188, 199, 188, false);
                    NewLine190.Name = "NewLine190";
                    NewLine190.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 204, 199, 204, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine192 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 220, 199, 220, false);
                    NewLine192.Name = "NewLine192";
                    NewLine192.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine193 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 236, 199, 236, false);
                    NewLine193.Name = "NewLine193";
                    NewLine193.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine194 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 252, 199, 252, false);
                    NewLine194.Name = "NewLine194";
                    NewLine194.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BIRIM18.CalcValue = BIRIM18.Value;
                    ACIKLAMA18.CalcValue = ACIKLAMA18.Value;
                    BIRIM19.CalcValue = BIRIM19.Value;
                    ACIKLAMA19.CalcValue = ACIKLAMA19.Value;
                    BIRIM20.CalcValue = BIRIM20.Value;
                    ACIKLAMA20.CalcValue = ACIKLAMA20.Value;
                    BIRIM21.CalcValue = BIRIM21.Value;
                    ACIKLAMA21.CalcValue = ACIKLAMA21.Value;
                    BIRIM22.CalcValue = BIRIM22.Value;
                    ACIKLAMA22.CalcValue = ACIKLAMA22.Value;
                    BIRIM23.CalcValue = BIRIM23.Value;
                    ACIKLAMA23.CalcValue = ACIKLAMA23.Value;
                    BIRIM24.CalcValue = BIRIM24.Value;
                    ACIKLAMA24.CalcValue = ACIKLAMA24.Value;
                    BIRIM25.CalcValue = BIRIM25.Value;
                    ACIKLAMA25.CalcValue = ACIKLAMA25.Value;
                    BIRIM26.CalcValue = BIRIM26.Value;
                    ACIKLAMA26.CalcValue = ACIKLAMA26.Value;
                    BIRIM27.CalcValue = BIRIM27.Value;
                    ACIKLAMA27.CalcValue = ACIKLAMA27.Value;
                    BIRIM28.CalcValue = BIRIM28.Value;
                    ACIKLAMA28.CalcValue = ACIKLAMA28.Value;
                    BIRIM29.CalcValue = BIRIM29.Value;
                    ACIKLAMA29.CalcValue = ACIKLAMA29.Value;
                    BIRIM30.CalcValue = BIRIM30.Value;
                    ACIKLAMA30.CalcValue = ACIKLAMA30.Value;
                    BIRIM31.CalcValue = BIRIM31.Value;
                    ACIKLAMA31.CalcValue = ACIKLAMA31.Value;
                    BIRIM32.CalcValue = BIRIM32.Value;
                    ACIKLAMA32.CalcValue = ACIKLAMA32.Value;
                    return new TTReportObject[] { BIRIM18,ACIKLAMA18,BIRIM19,ACIKLAMA19,BIRIM20,ACIKLAMA20,BIRIM21,ACIKLAMA21,BIRIM22,ACIKLAMA22,BIRIM23,ACIKLAMA23,BIRIM24,ACIKLAMA24,BIRIM25,ACIKLAMA25,BIRIM26,ACIKLAMA26,BIRIM27,ACIKLAMA27,BIRIM28,ACIKLAMA28,BIRIM29,ACIKLAMA29,BIRIM30,ACIKLAMA30,BIRIM31,ACIKLAMA31,BIRIM32,ACIKLAMA32};
                }

                public override void RunScript()
                {
#region ARKASAYFA FOOTER_Script
                    ((HealthCommitteeExaminationSlipReport)ParentReport).counter = 1;
            TTReportField field;
            TTReportField descField;
            
            foreach(ResourceAndProcedure resourceAndProcedure in ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList)
            {
                if(((HealthCommitteeExaminationSlipReport)ParentReport).counter > 17)
                {
                    field = this.FieldsByName("BIRIM" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    descField = this.FieldsByName("ACIKLAMA" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    field.CalcValue = resourceAndProcedure.Resource;
                    descField.CalcValue = resourceAndProcedure.Procedure;
                }
                ((HealthCommitteeExaminationSlipReport)ParentReport).counter++;
            }
            
                
            if (((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList.Count <= 18)
                this.Visible = EvetHayirEnum.ehHayir;
#endregion ARKASAYFA FOOTER_Script
                }
            }

        }

        public ArkasayfaGroup Arkasayfa;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeExaminationSlipReport MyParentReport
            {
                get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField BIRLIKYAZI { get {return Body().BIRLIKYAZI;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField DTYERI { get {return Body().DTYERI;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField SICIL { get {return Body().SICIL;} }
            public TTReportField EMIRTARIHI { get {return Body().EMIRTARIHI;} }
            public TTReportField EMIRNO { get {return Body().EMIRNO;} }
            public TTReportField BASLAMATARIHI { get {return Body().BASLAMATARIHI;} }
            public TTReportField SKSEBEBI { get {return Body().SKSEBEBI;} }
            public TTReportField MUAMELESAYISI { get {return Body().MUAMELESAYISI;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField KILO { get {return Body().KILO;} }
            public TTReportField BIRLIKLABEL { get {return Body().BIRLIKLABEL;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField NewField31 { get {return Body().NewField31;} }
            public TTReportField NewField34 { get {return Body().NewField34;} }
            public TTReportField NewField36 { get {return Body().NewField36;} }
            public TTReportField NewField37 { get {return Body().NewField37;} }
            public TTReportField NewField38 { get {return Body().NewField38;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportField NewField53 { get {return Body().NewField53;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportField BIRIM1 { get {return Body().BIRIM1;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportField BIRIM2 { get {return Body().BIRIM2;} }
            public TTReportField BIRIM3 { get {return Body().BIRIM3;} }
            public TTReportField BIRIM4 { get {return Body().BIRIM4;} }
            public TTReportField BIRIM5 { get {return Body().BIRIM5;} }
            public TTReportField BIRIM6 { get {return Body().BIRIM6;} }
            public TTReportField BIRIM7 { get {return Body().BIRIM7;} }
            public TTReportField BIRIM8 { get {return Body().BIRIM8;} }
            public TTReportField BIRIM9 { get {return Body().BIRIM9;} }
            public TTReportField BIRIM10 { get {return Body().BIRIM10;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine26 { get {return Body().NewLine26;} }
            public TTReportShape NewLine27 { get {return Body().NewLine27;} }
            public TTReportShape NewLine30 { get {return Body().NewLine30;} }
            public TTReportField ACIKLAMA1 { get {return Body().ACIKLAMA1;} }
            public TTReportField ACIKLAMA2 { get {return Body().ACIKLAMA2;} }
            public TTReportField ACIKLAMA3 { get {return Body().ACIKLAMA3;} }
            public TTReportField ACIKLAMA4 { get {return Body().ACIKLAMA4;} }
            public TTReportField ACIKLAMA5 { get {return Body().ACIKLAMA5;} }
            public TTReportField ACIKLAMA6 { get {return Body().ACIKLAMA6;} }
            public TTReportField ACIKLAMA7 { get {return Body().ACIKLAMA7;} }
            public TTReportField ACIKLAMA8 { get {return Body().ACIKLAMA8;} }
            public TTReportField ACIKLAMA9 { get {return Body().ACIKLAMA9;} }
            public TTReportField ACIKLAMA10 { get {return Body().ACIKLAMA10;} }
            public TTReportShape NewLine31 { get {return Body().NewLine31;} }
            public TTReportShape NewLine32 { get {return Body().NewLine32;} }
            public TTReportField PID { get {return Body().PID;} }
            public TTReportField HNO { get {return Body().HNO;} }
            public TTReportField AID { get {return Body().AID;} }
            public TTReportField İslem { get {return Body().İslem;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField SKBASLIK { get {return Body().SKBASLIK;} }
            public TTReportField DOGUMILI { get {return Body().DOGUMILI;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportField XXXXXXLIKSUBESI { get {return Body().XXXXXXLIKSUBESI;} }
            public TTReportField NewField143 { get {return Body().NewField143;} }
            public TTReportShape NewLine172 { get {return Body().NewLine172;} }
            public TTReportShape NewLine1271 { get {return Body().NewLine1271;} }
            public TTReportField BIRIM11 { get {return Body().BIRIM11;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField NewField182 { get {return Body().NewField182;} }
            public TTReportField NASBI { get {return Body().NASBI;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportField NewField1281 { get {return Body().NewField1281;} }
            public TTReportField KUVVET { get {return Body().KUVVET;} }
            public TTReportField ACIKLAMA11 { get {return Body().ACIKLAMA11;} }
            public TTReportShape NewLine113 { get {return Body().NewLine113;} }
            public TTReportField NewField164 { get {return Body().NewField164;} }
            public TTReportShape NewLine1311 { get {return Body().NewLine1311;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine29 { get {return Body().NewLine29;} }
            public TTReportField HEADER1 { get {return Body().HEADER1;} }
            public TTReportShape NewLine1272 { get {return Body().NewLine1272;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommitteeNQL", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HealthCommitteeExaminationSlipReport MyParentReport
                {
                    get { return (HealthCommitteeExaminationSlipReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField BIRLIKYAZI;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField SINIFRUTBE;
                public TTReportField DTYERI;
                public TTReportField MAKAM;
                public TTReportField SICIL;
                public TTReportField EMIRTARIHI;
                public TTReportField EMIRNO;
                public TTReportField BASLAMATARIHI;
                public TTReportField SKSEBEBI;
                public TTReportField MUAMELESAYISI;
                public TTReportField BOLUM;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportField BIRLIKLABEL;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField NewField31;
                public TTReportField NewField34;
                public TTReportField NewField36;
                public TTReportField NewField37;
                public TTReportField NewField38;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportField NewField53;
                public TTReportShape NewLine8;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportField BIRIM1;
                public TTReportShape NewLine18;
                public TTReportField BIRIM2;
                public TTReportField BIRIM3;
                public TTReportField BIRIM4;
                public TTReportField BIRIM5;
                public TTReportField BIRIM6;
                public TTReportField BIRIM7;
                public TTReportField BIRIM8;
                public TTReportField BIRIM9;
                public TTReportField BIRIM10;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine26;
                public TTReportShape NewLine27;
                public TTReportShape NewLine30;
                public TTReportField ACIKLAMA1;
                public TTReportField ACIKLAMA2;
                public TTReportField ACIKLAMA3;
                public TTReportField ACIKLAMA4;
                public TTReportField ACIKLAMA5;
                public TTReportField ACIKLAMA6;
                public TTReportField ACIKLAMA7;
                public TTReportField ACIKLAMA8;
                public TTReportField ACIKLAMA9;
                public TTReportField ACIKLAMA10;
                public TTReportShape NewLine31;
                public TTReportShape NewLine32;
                public TTReportField PID;
                public TTReportField HNO;
                public TTReportField AID;
                public TTReportField İslem;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField DTARIHI;
                public TTReportShape NewLine4;
                public TTReportShape NewLine17;
                public TTReportField NewField163;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField123;
                public TTReportField SKBASLIK;
                public TTReportField DOGUMILI;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportField XXXXXXLIKSUBESI;
                public TTReportField NewField143;
                public TTReportShape NewLine172;
                public TTReportShape NewLine1271;
                public TTReportField BIRIM11;
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportShape NewLine111;
                public TTReportField NewField182;
                public TTReportField NASBI;
                public TTReportShape NewLine1111;
                public TTReportField NewField1281;
                public TTReportField KUVVET;
                public TTReportField ACIKLAMA11;
                public TTReportShape NewLine113;
                public TTReportField NewField164;
                public TTReportShape NewLine1311;
                public TTReportShape NewLine9;
                public TTReportShape NewLine29;
                public TTReportField HEADER1;
                public TTReportShape NewLine1272; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 275;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 199, 25, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"SAĞLIK KURULU MUAYENE FİŞİ";

                    BIRLIKYAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 33, 90, 55, false);
                    BIRLIKYAZI.Name = "BIRLIKYAZI";
                    BIRLIKYAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKYAZI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKYAZI.NoClip = EvetHayirEnum.ehEvet;
                    BIRLIKYAZI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKYAZI.TextFont.Size = 8;
                    BIRLIKYAZI.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 56, 90, 61, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#PNAME#} {#PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 62, 90, 67, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.NoClip = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 74, 90, 79, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.NoClip = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    DTYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 99, 90, 107, false);
                    DTYERI.Name = "DTYERI";
                    DTYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYERI.MultiLine = EvetHayirEnum.ehEvet;
                    DTYERI.NoClip = EvetHayirEnum.ehEvet;
                    DTYERI.WordBreak = EvetHayirEnum.ehEvet;
                    DTYERI.TextFont.Size = 8;
                    DTYERI.Value = @"{%DTARIHI%} / ";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 36, 162, 55, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    SICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 80, 90, 85, false);
                    SICIL.Name = "SICIL";
                    SICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICIL.NoClip = EvetHayirEnum.ehEvet;
                    SICIL.TextFont.Size = 8;
                    SICIL.Value = @"";

                    EMIRTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 56, 162, 61, false);
                    EMIRTARIHI.Name = "EMIRTARIHI";
                    EMIRTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHI.TextFormat = @"Short Date";
                    EMIRTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMIRTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    EMIRTARIHI.TextFont.Size = 8;
                    EMIRTARIHI.Value = @"{#EVRAKTARIHI#}";

                    EMIRNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 62, 162, 73, false);
                    EMIRNO.Name = "EMIRNO";
                    EMIRNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMIRNO.NoClip = EvetHayirEnum.ehEvet;
                    EMIRNO.TextFont.Size = 8;
                    EMIRNO.Value = @"{#EVRAKSAYISI#}";

                    BASLAMATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 92, 140, 97, false);
                    BASLAMATARIHI.Name = "BASLAMATARIHI";
                    BASLAMATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLAMATARIHI.TextFormat = @"Short Date";
                    BASLAMATARIHI.NoClip = EvetHayirEnum.ehEvet;
                    BASLAMATARIHI.TextFont.Size = 8;
                    BASLAMATARIHI.Value = @"";

                    SKSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 104, 162, 113, false);
                    SKSEBEBI.Name = "SKSEBEBI";
                    SKSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKSEBEBI.MultiLine = EvetHayirEnum.ehEvet;
                    SKSEBEBI.WordBreak = EvetHayirEnum.ehEvet;
                    SKSEBEBI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SKSEBEBI.TextFont.Size = 8;
                    SKSEBEBI.Value = @"{#SKSEBEBI#}";

                    MUAMELESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 106, 197, 113, false);
                    MUAMELESAYISI.Name = "MUAMELESAYISI";
                    MUAMELESAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAMELESAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUAMELESAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAMELESAYISI.NoClip = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.TextFont.Name = "Arial Narrow";
                    MUAMELESAYISI.TextFont.Size = 8;
                    MUAMELESAYISI.Value = @"{#MUAMELESAYISI#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 68, 244, 73, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.Visible = EvetHayirEnum.ehHayir;
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.TextFont.Size = 8;
                    BOLUM.Value = @"{#BOLUM#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 108, 54, 113, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BOY.NoClip = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 108, 90, 113, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KILO.NoClip = EvetHayirEnum.ehEvet;
                    KILO.TextFont.Size = 8;
                    KILO.Value = @"{#KILO#}";

                    BIRLIKLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 25, 37, false);
                    BIRLIKLABEL.Name = "BIRLIKLABEL";
                    BIRLIKLABEL.TextFont.Size = 8;
                    BIRLIKLABEL.TextFont.Bold = true;
                    BIRLIKLABEL.Value = @"Birliği : ";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 56, 38, 61, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"Adı Soyadı";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 62, 38, 67, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Size = 8;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"Baba Adı";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 74, 38, 79, false);
                    NewField27.Name = "NewField27";
                    NewField27.TextFont.Size = 8;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"Sınıf, Rütbesi";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 80, 38, 85, false);
                    NewField28.Name = "NewField28";
                    NewField28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField28.TextFont.Size = 8;
                    NewField28.TextFont.Bold = true;
                    NewField28.Value = @"Sicil Numarası";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 99, 38, 107, false);
                    NewField29.Name = "NewField29";
                    NewField29.MultiLine = EvetHayirEnum.ehEvet;
                    NewField29.NoClip = EvetHayirEnum.ehEvet;
                    NewField29.WordBreak = EvetHayirEnum.ehEvet;
                    NewField29.TextFont.Size = 8;
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"Doğum Tarihi ve Yeri";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 108, 38, 113, false);
                    NewField30.Name = "NewField30";
                    NewField30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30.TextFont.Size = 8;
                    NewField30.TextFont.Bold = true;
                    NewField30.Value = @"Boy";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 108, 73, 113, false);
                    NewField31.Name = "NewField31";
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.TextFont.Size = 8;
                    NewField31.TextFont.Bold = true;
                    NewField31.Value = @"Ağırlık";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 32, 132, 36, false);
                    NewField34.Name = "NewField34";
                    NewField34.TextFont.Size = 8;
                    NewField34.TextFont.Bold = true;
                    NewField34.Value = @"Muayeneye Gönderen :";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 56, 125, 61, false);
                    NewField36.Name = "NewField36";
                    NewField36.TextFont.Size = 8;
                    NewField36.TextFont.Bold = true;
                    NewField36.Value = @"Emir Tarihi";

                    NewField37 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 62, 125, 73, false);
                    NewField37.Name = "NewField37";
                    NewField37.MultiLine = EvetHayirEnum.ehEvet;
                    NewField37.WordBreak = EvetHayirEnum.ehEvet;
                    NewField37.TextFont.Size = 8;
                    NewField37.TextFont.Bold = true;
                    NewField37.Value = @"Emri Veren Şube ve Emir Nu.";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 74, 162, 81, false);
                    NewField38.Name = "NewField38";
                    NewField38.MultiLine = EvetHayirEnum.ehEvet;
                    NewField38.NoClip = EvetHayirEnum.ehEvet;
                    NewField38.WordBreak = EvetHayirEnum.ehEvet;
                    NewField38.TextFont.Size = 8;
                    NewField38.TextFont.Bold = true;
                    NewField38.Value = @"Sağlık Kurulunca muayeneye başlandığı tarih";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 32, 199, 32, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 61, 163, 61, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 67, 92, 67, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 79, 92, 79, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 107, 92, 107, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 39, 55, 39, 269, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 100, 162, 104, false);
                    NewField53.Name = "NewField53";
                    NewField53.MultiLine = EvetHayirEnum.ehEvet;
                    NewField53.NoClip = EvetHayirEnum.ehEvet;
                    NewField53.WordBreak = EvetHayirEnum.ehEvet;
                    NewField53.TextFont.Size = 8;
                    NewField53.TextFont.Bold = true;
                    NewField53.Value = @"Ne maksatla muayene edildiği";

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 163, 32, 163, 113, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 55, 126, 73, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 99, 92, 99, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 113, 199, 113, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 32, 92, 113, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 114, 38, 127, false);
                    BIRIM1.Name = "BIRIM1";
                    BIRIM1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM1.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM1.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM1.TextFont.Size = 8;
                    BIRIM1.TextFont.Bold = true;
                    BIRIM1.Value = @"";

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 26, 199, 269, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 129, 38, 141, false);
                    BIRIM2.Name = "BIRIM2";
                    BIRIM2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM2.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM2.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM2.TextFont.Size = 8;
                    BIRIM2.TextFont.Bold = true;
                    BIRIM2.Value = @"";

                    BIRIM3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 143, 38, 156, false);
                    BIRIM3.Name = "BIRIM3";
                    BIRIM3.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM3.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM3.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM3.TextFont.Size = 8;
                    BIRIM3.TextFont.Bold = true;
                    BIRIM3.Value = @"";

                    BIRIM4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 158, 38, 170, false);
                    BIRIM4.Name = "BIRIM4";
                    BIRIM4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM4.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM4.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM4.TextFont.Size = 8;
                    BIRIM4.TextFont.Bold = true;
                    BIRIM4.Value = @"";

                    BIRIM5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 172, 38, 184, false);
                    BIRIM5.Name = "BIRIM5";
                    BIRIM5.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM5.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM5.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM5.TextFont.Size = 8;
                    BIRIM5.TextFont.Bold = true;
                    BIRIM5.Value = @"";

                    BIRIM6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 186, 38, 198, false);
                    BIRIM6.Name = "BIRIM6";
                    BIRIM6.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM6.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM6.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM6.TextFont.Size = 8;
                    BIRIM6.TextFont.Bold = true;
                    BIRIM6.Value = @"";

                    BIRIM7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 200, 38, 212, false);
                    BIRIM7.Name = "BIRIM7";
                    BIRIM7.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM7.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM7.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM7.TextFont.Size = 8;
                    BIRIM7.TextFont.Bold = true;
                    BIRIM7.Value = @"";

                    BIRIM8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 214, 38, 226, false);
                    BIRIM8.Name = "BIRIM8";
                    BIRIM8.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM8.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM8.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM8.TextFont.Size = 8;
                    BIRIM8.TextFont.Bold = true;
                    BIRIM8.Value = @"";

                    BIRIM9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 228, 38, 240, false);
                    BIRIM9.Name = "BIRIM9";
                    BIRIM9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM9.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM9.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM9.TextFont.Size = 8;
                    BIRIM9.TextFont.Bold = true;
                    BIRIM9.Value = @"";

                    BIRIM10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 242, 38, 254, false);
                    BIRIM10.Name = "BIRIM10";
                    BIRIM10.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM10.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM10.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM10.TextFont.Size = 8;
                    BIRIM10.TextFont.Bold = true;
                    BIRIM10.Value = @"";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 128, 199, 128, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 157, 199, 157, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 142, 199, 142, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 185, 199, 185, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 171, 199, 171, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 199, 199, 199, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 213, 199, 213, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine26 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 227, 199, 227, false);
                    NewLine26.Name = "NewLine26";
                    NewLine26.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine27 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 241, 199, 241, false);
                    NewLine27.Name = "NewLine27";
                    NewLine27.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine30 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 26, 7, 269, false);
                    NewLine30.Name = "NewLine30";
                    NewLine30.DrawStyle = DrawStyleConstants.vbSolid;

                    ACIKLAMA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 114, 198, 127, false);
                    ACIKLAMA1.Name = "ACIKLAMA1";
                    ACIKLAMA1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA1.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.TextFont.Size = 8;
                    ACIKLAMA1.TextFont.Bold = true;
                    ACIKLAMA1.Value = @"";

                    ACIKLAMA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 129, 198, 141, false);
                    ACIKLAMA2.Name = "ACIKLAMA2";
                    ACIKLAMA2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA2.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA2.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA2.TextFont.Size = 8;
                    ACIKLAMA2.TextFont.Bold = true;
                    ACIKLAMA2.Value = @"";

                    ACIKLAMA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 143, 198, 156, false);
                    ACIKLAMA3.Name = "ACIKLAMA3";
                    ACIKLAMA3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA3.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA3.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA3.TextFont.Size = 8;
                    ACIKLAMA3.TextFont.Bold = true;
                    ACIKLAMA3.Value = @"";

                    ACIKLAMA4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 158, 198, 170, false);
                    ACIKLAMA4.Name = "ACIKLAMA4";
                    ACIKLAMA4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA4.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA4.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA4.TextFont.Size = 8;
                    ACIKLAMA4.TextFont.Bold = true;
                    ACIKLAMA4.Value = @"";

                    ACIKLAMA5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 172, 198, 184, false);
                    ACIKLAMA5.Name = "ACIKLAMA5";
                    ACIKLAMA5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA5.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA5.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA5.TextFont.Size = 8;
                    ACIKLAMA5.TextFont.Bold = true;
                    ACIKLAMA5.Value = @"";

                    ACIKLAMA6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 186, 198, 198, false);
                    ACIKLAMA6.Name = "ACIKLAMA6";
                    ACIKLAMA6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA6.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA6.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA6.TextFont.Size = 8;
                    ACIKLAMA6.TextFont.Bold = true;
                    ACIKLAMA6.Value = @"";

                    ACIKLAMA7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 200, 198, 212, false);
                    ACIKLAMA7.Name = "ACIKLAMA7";
                    ACIKLAMA7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA7.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA7.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA7.TextFont.Size = 8;
                    ACIKLAMA7.TextFont.Bold = true;
                    ACIKLAMA7.Value = @"";

                    ACIKLAMA8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 214, 198, 226, false);
                    ACIKLAMA8.Name = "ACIKLAMA8";
                    ACIKLAMA8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA8.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA8.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA8.TextFont.Size = 8;
                    ACIKLAMA8.TextFont.Bold = true;
                    ACIKLAMA8.Value = @"";

                    ACIKLAMA9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 228, 198, 240, false);
                    ACIKLAMA9.Name = "ACIKLAMA9";
                    ACIKLAMA9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA9.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA9.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA9.TextFont.Size = 8;
                    ACIKLAMA9.TextFont.Bold = true;
                    ACIKLAMA9.Value = @"";

                    ACIKLAMA10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 242, 198, 254, false);
                    ACIKLAMA10.Name = "ACIKLAMA10";
                    ACIKLAMA10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA10.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA10.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA10.TextFont.Size = 8;
                    ACIKLAMA10.TextFont.Bold = true;
                    ACIKLAMA10.Value = @"";

                    NewLine31 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 55, 92, 55, false);
                    NewLine31.Name = "NewLine31";
                    NewLine31.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine32 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 99, 199, 99, false);
                    NewLine32.Name = "NewLine32";
                    NewLine32.DrawStyle = DrawStyleConstants.vbSolid;

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 28, 252, 32, false);
                    PID.Name = "PID";
                    PID.Visible = EvetHayirEnum.ehHayir;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PID.NoClip = EvetHayirEnum.ehEvet;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Size = 9;
                    PID.Value = @"{#PID#}";

                    HNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 28, 231, 32, false);
                    HNO.Name = "HNO";
                    HNO.Visible = EvetHayirEnum.ehHayir;
                    HNO.TextFont.Name = "Arial Narrow";
                    HNO.TextFont.Size = 9;
                    HNO.TextFont.Bold = true;
                    HNO.Value = @"Hasta Nu";

                    AID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 34, 198, 39, false);
                    AID.Name = "AID";
                    AID.FieldType = ReportFieldTypeEnum.ftVariable;
                    AID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AID.NoClip = EvetHayirEnum.ehEvet;
                    AID.TextFont.Name = "Arial Narrow";
                    AID.TextFont.Size = 9;
                    AID.Value = @"{#ISLEMNO#}";

                    İslem = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 34, 176, 39, false);
                    İslem.Name = "İslem";
                    İslem.TextFont.Name = "Arial Narrow";
                    İslem.TextFont.Size = 9;
                    İslem.TextFont.Bold = true;
                    İslem.Value = @"İşlem Nu";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 46, 244, 51, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 53, 244, 58, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 60, 244, 65, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 73, 92, 73, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 73, 163, 73, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 68, 38, 72, false);
                    NewField163.Name = "NewField163";
                    NewField163.TextFont.Size = 8;
                    NewField163.TextFont.Bold = true;
                    NewField163.Value = @"TC Kimlik Nu";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 68, 90, 72, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 100, 197, 105, false);
                    NewField123.Name = "NewField123";
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Size = 8;
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @"Kaçıncı işlemi";

                    SKBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 39, 244, 44, false);
                    SKBASLIK.Name = "SKBASLIK";
                    SKBASLIK.Visible = EvetHayirEnum.ehHayir;
                    SKBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASLIK.TextFont.Name = "Arial Narrow";
                    SKBASLIK.TextFont.Size = 9;
                    SKBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"","""")";

                    DOGUMILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 77, 244, 82, false);
                    DOGUMILI.Name = "DOGUMILI";
                    DOGUMILI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMILI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMILI.Value = @"{#DOGUMYERI#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 103, 245, 108, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 111, 245, 116, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 95, 245, 100, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#DOGUMYERIULKE#}";

                    XXXXXXLIKSUBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 45, 322, 52, false);
                    XXXXXXLIKSUBESI.Name = "XXXXXXLIKSUBESI";
                    XXXXXXLIKSUBESI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESI.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESI.TextFont.Size = 8;
                    XXXXXXLIKSUBESI.Value = @"";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 41, 322, 45, false);
                    NewField143.Name = "NewField143";
                    NewField143.Visible = EvetHayirEnum.ehHayir;
                    NewField143.TextFont.Size = 8;
                    NewField143.TextFont.Bold = true;
                    NewField143.Value = @"Bağlı Bulunduğu XXXXXXlik Şubesi :";

                    NewLine172 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 255, 199, 255, false);
                    NewLine172.Name = "NewLine172";
                    NewLine172.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1271 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 269, 199, 269, false);
                    NewLine1271.Name = "NewLine1271";
                    NewLine1271.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 256, 38, 268, false);
                    BIRIM11.Name = "BIRIM11";
                    BIRIM11.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRIM11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM11.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM11.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM11.TextFont.Size = 8;
                    BIRIM11.TextFont.Bold = true;
                    BIRIM11.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 42, 198, 96, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftOLE;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 163, 40, 199, 40, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 6, 199, 18, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 86, 92, 86, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 87, 38, 92, false);
                    NewField182.Name = "NewField182";
                    NewField182.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField182.TextFont.Size = 8;
                    NewField182.TextFont.Bold = true;
                    NewField182.Value = @"Nasbı";

                    NASBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 87, 90, 92, false);
                    NASBI.Name = "NASBI";
                    NASBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    NASBI.TextFormat = @"Short Date";
                    NASBI.NoClip = EvetHayirEnum.ehEvet;
                    NASBI.TextFont.Size = 8;
                    NASBI.Value = @"{#NASBITARIHI#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 92, 92, 92, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 38, 98, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1281.TextFont.Size = 8;
                    NewField1281.TextFont.Bold = true;
                    NewField1281.Value = @"Kuvveti";

                    KUVVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 93, 90, 98, false);
                    KUVVET.Name = "KUVVET";
                    KUVVET.FieldType = ReportFieldTypeEnum.ftVariable;
                    KUVVET.NoClip = EvetHayirEnum.ehEvet;
                    KUVVET.TextFont.Size = 8;
                    KUVVET.Value = @"";

                    ACIKLAMA11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 256, 198, 268, false);
                    ACIKLAMA11.Name = "ACIKLAMA11";
                    ACIKLAMA11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA11.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA11.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA11.TextFont.Size = 8;
                    ACIKLAMA11.TextFont.Bold = true;
                    ACIKLAMA11.Value = @"";

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 55, 163, 55, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 36, 107, 41, false);
                    NewField164.Name = "NewField164";
                    NewField164.TextFont.Size = 8;
                    NewField164.TextFont.Bold = true;
                    NewField164.Value = @"Makam : ";

                    NewLine1311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 36, 163, 36, false);
                    NewLine1311.Name = "NewLine1311";
                    NewLine1311.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 75, 107, 75, 113, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine29 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 107, 56, 113, false);
                    NewLine29.Name = "NewLine29";
                    NewLine29.DrawStyle = DrawStyleConstants.vbSolid;

                    HEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 26, 198, 32, false);
                    HEADER1.Name = "HEADER1";
                    HEADER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER1.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER1.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER1.TextFont.Size = 11;
                    HEADER1.TextFont.Bold = true;
                    HEADER1.Value = @"{%SKBASLIK%} XXXXXX Sağlık Kurulu Muayene Fişi";

                    NewLine1272 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 26, 199, 26, false);
                    NewLine1272.Name = "NewLine1272";
                    NewLine1272.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommitteeNQL = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    HEADER.CalcValue = @"SAĞLIK KURULU MUAYENE FİŞİ";
                    BIRLIKYAZI.CalcValue = @"";
                    NAME.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Pname) : "") + @" " + (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.FatherName) : "");
                    SINIFRUTBE.CalcValue = @"";
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dtarihi) : "");
                    DTYERI.CalcValue = MyParentReport.MAIN.DTARIHI.FormattedValue + @" / ";
                    MAKAM.CalcValue = @"";
                    SICIL.CalcValue = @"";
                    EMIRTARIHI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Evraktarihi) : "");
                    EMIRNO.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Evraksayisi) : "");
                    BASLAMATARIHI.CalcValue = @"";
                    SKSEBEBI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Sksebebi) : "");
                    MUAMELESAYISI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Muamelesayisi) : "");
                    BOLUM.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Bolum) : "");
                    BOY.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Boy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Kilo) : "");
                    BIRLIKLABEL.CalcValue = BIRLIKLABEL.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField34.CalcValue = NewField34.Value;
                    NewField36.CalcValue = NewField36.Value;
                    NewField37.CalcValue = NewField37.Value;
                    NewField38.CalcValue = NewField38.Value;
                    NewField53.CalcValue = NewField53.Value;
                    BIRIM1.CalcValue = BIRIM1.Value;
                    BIRIM2.CalcValue = BIRIM2.Value;
                    BIRIM3.CalcValue = BIRIM3.Value;
                    BIRIM4.CalcValue = BIRIM4.Value;
                    BIRIM5.CalcValue = BIRIM5.Value;
                    BIRIM6.CalcValue = BIRIM6.Value;
                    BIRIM7.CalcValue = BIRIM7.Value;
                    BIRIM8.CalcValue = BIRIM8.Value;
                    BIRIM9.CalcValue = BIRIM9.Value;
                    BIRIM10.CalcValue = BIRIM10.Value;
                    ACIKLAMA1.CalcValue = ACIKLAMA1.Value;
                    ACIKLAMA2.CalcValue = ACIKLAMA2.Value;
                    ACIKLAMA3.CalcValue = ACIKLAMA3.Value;
                    ACIKLAMA4.CalcValue = ACIKLAMA4.Value;
                    ACIKLAMA5.CalcValue = ACIKLAMA5.Value;
                    ACIKLAMA6.CalcValue = ACIKLAMA6.Value;
                    ACIKLAMA7.CalcValue = ACIKLAMA7.Value;
                    ACIKLAMA8.CalcValue = ACIKLAMA8.Value;
                    ACIKLAMA9.CalcValue = ACIKLAMA9.Value;
                    ACIKLAMA10.CalcValue = ACIKLAMA10.Value;
                    PID.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Pid) : "");
                    HNO.CalcValue = HNO.Value;
                    AID.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Islemno) : "");
                    İslem.CalcValue = İslem.Value;
                    NewField163.CalcValue = NewField163.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Tcno) : "");
                    NewField123.CalcValue = NewField123.Value;
                    DOGUMILI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeri) : "");
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeriulke) : "");
                    XXXXXXLIKSUBESI.CalcValue = @"";
                    NewField143.CalcValue = NewField143.Value;
                    BIRIM11.CalcValue = BIRIM11.Value;
                    NewField1.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    NewField182.CalcValue = NewField182.Value;
                    NASBI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.NasbiTarihi) : "");
                    NewField1281.CalcValue = NewField1281.Value;
                    KUVVET.CalcValue = @"";
                    ACIKLAMA11.CalcValue = ACIKLAMA11.Value;
                    NewField164.CalcValue = NewField164.Value;
                    SKBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","");
                    HEADER1.CalcValue = MyParentReport.MAIN.SKBASLIK.CalcValue + @" XXXXXX Sağlık Kurulu Muayene Fişi";
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    return new TTReportObject[] { HEADER,BIRLIKYAZI,NAME,FATHERNAME,SINIFRUTBE,DTARIHI,DTYERI,MAKAM,SICIL,EMIRTARIHI,EMIRNO,BASLAMATARIHI,SKSEBEBI,MUAMELESAYISI,BOLUM,BOY,KILO,BIRLIKLABEL,NewField25,NewField26,NewField27,NewField28,NewField29,NewField30,NewField31,NewField34,NewField36,NewField37,NewField38,NewField53,BIRIM1,BIRIM2,BIRIM3,BIRIM4,BIRIM5,BIRIM6,BIRIM7,BIRIM8,BIRIM9,BIRIM10,ACIKLAMA1,ACIKLAMA2,ACIKLAMA3,ACIKLAMA4,ACIKLAMA5,ACIKLAMA6,ACIKLAMA7,ACIKLAMA8,ACIKLAMA9,ACIKLAMA10,PID,HNO,AID,İslem,NewField163,TCKIMLIKNO,NewField123,DOGUMILI,DYERILCE,DYERIL,DYERULKE,XXXXXXLIKSUBESI,NewField143,BIRIM11,NewField1,TCKIMLIKNOBARKOD,NewField182,NASBI,NewField1281,KUVVET,ACIKLAMA11,NewField164,SKBASLIK,HEADER1,SITENAME,SITECITY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeExaminationSlipReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //MilitaryClassDefinitions pMilClass = hc.Episode.MyMilitaryClass();
            //RankDefinitions pRank = hc.Episode.MyRank();
            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
//            RankDefinitions pRank = hc.Episode.Rank;
//            
//            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
//            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
//                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
//            else
//            {
//                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name);
//                if(pMilClass != null)
//                    this.SINIFRUTBE.CalcValue = this.SINIFRUTBE.CalcValue + " ";
//                this.SINIFRUTBE.CalcValue = this.SINIFRUTBE.CalcValue + (pRank == null ? "" : pRank.Name);
//            }
            
//            if(hc.AutomaticallyCreated != true)
//            {
//                if (hc.Episode.MyRelationship() != null)
//                {
//                    if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
//                        this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
//                }
//            }
            
            if(hc.AutomaticallyCreated == true)
                this.BASLAMATARIHI.CalcValue = hc.Episode.OpeningDate.ToString();
            else
            {
                foreach( TTObjectState state in hc.GetStateHistory())
                {
                    if(state.StateDefID == HealthCommittee.States.CommitteeAcceptance)
                    {
                        if (state.BranchDate != null)
                            this.BASLAMATARIHI.CalcValue = state.BranchDate.ToString();
                        break;
                    }
                }
            }
            
            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DTYERI.CalcValue = this.DTYERI.CalcValue + dogumIlce;
                else
                    this.DTYERI.CalcValue = this.DTYERI.CalcValue + dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DTYERI.CalcValue = this.DTYERI.CalcValue + dogumIl;
            else
                this.DTYERI.CalcValue = this.DTYERI.CalcValue + dogumUlke;
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCESLIPREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKIMLIKNO.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKIMLIKNO.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            
            ((HealthCommitteeExaminationSlipReport)ParentReport).counter = 1;
            TTReportField field;
            TTReportField descField;
            
            foreach(ResourceAndProcedure resourceAndProcedure in ((HealthCommitteeExaminationSlipReport)ParentReport).ResourceAndProcedureList)
            {
                if(((HealthCommitteeExaminationSlipReport)ParentReport).counter <= 11)
                {
                    field = this.FieldsByName("BIRIM" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    descField = this.FieldsByName("ACIKLAMA" + (((HealthCommitteeExaminationSlipReport)ParentReport).counter).ToString());
                    field.CalcValue = resourceAndProcedure.Resource;
                    descField.CalcValue = resourceAndProcedure.Procedure;
                }
                ((HealthCommitteeExaminationSlipReport)ParentReport).counter++;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeExaminationSlipReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            Arkasayfa = new ArkasayfaGroup(PARTA,"Arkasayfa");
            MAIN = new MAINGroup(Arkasayfa,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "C7203EFB-0742-4709-9E32-6D3608F9C34F", "No", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEEXAMINATIONSLIPREPORT";
            Caption = "Sağlık Kurulu Muayene Fişi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}

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
    /// Uçucu Muayene Raporu (Arkalı-Önlü-A4)
    /// </summary>
    public partial class HealthCommitteeFlierReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PATIENTINFOGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public PATIENTINFOGroupHeader Header()
            {
                return (PATIENTINFOGroupHeader)_header;
            }

            new public PATIENTINFOGroupFooter Footer()
            {
                return (PATIENTINFOGroupFooter)_footer;
            }

            public TTReportField PATINFO { get {return Header().PATINFO;} }
            public PATIENTINFOGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATIENTINFOGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PATIENTINFOGroupHeader(this);
                _footer = new PATIENTINFOGroupFooter(this);

            }

            public partial class PATIENTINFOGroupHeader : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField PATINFO; 
                public PATIENTINFOGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 195, 13, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATINFO.CalcValue = @"";
                    return new TTReportObject[] { PATINFO};
                }
                public override void RunPreScript()
                {
#region PATIENTINFO HEADER_PreScript
                    if (this.MyParentReport.CurrentPageNumber == 2)
                this.MyParentReport.PATIENTINFO.Header().Visible =EvetHayirEnum.ehHayir;
            else
                this.MyParentReport.PATIENTINFO.Header().Visible =EvetHayirEnum.ehEvet;
#endregion PATIENTINFO HEADER_PreScript
                }

                public override void RunScript()
                {
#region PATIENTINFO HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
             Guid objectID = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
             HealthCommittee healthCommittee = (HealthCommittee)objectContext.GetObject(objectID,typeof(HealthCommittee));
            Episode episode = healthCommittee.Episode;
            string patientInfo = String.Empty;
              
            if(episode.Patient.ForeignUniqueRefNo != null)
                patientInfo += "(*)" + episode.Patient.ForeignUniqueRefNo.ToString()+" ";
            else if(episode.Patient.UniqueRefNo != null)
               patientInfo += episode.Patient.UniqueRefNo.ToString() +" ";          
             if(episode.Patient.Name != null)
                patientInfo += episode.Patient.Name.ToString()+" ";
            if(episode.Patient.Surname != null)
                patientInfo += episode.Patient.Surname.ToString()+" ";
          
            if(episode.Patient.CityOfBirth != null)
                patientInfo += episode.Patient.CityOfBirth.ToString() + " ";
            if(episode.Patient.BirthDate != null)
                patientInfo += "/" + " " + episode.Patient.BirthDate.Value.ToShortDateString() +" ";
            if(healthCommittee.ID !=null)
                patientInfo += healthCommittee.ID.ToString();
            
            this.PATINFO.CalcValue= patientInfo;
#endregion PATIENTINFO HEADER_Script
                }
            }
            public partial class PATIENTINFOGroupFooter : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                 
                public PATIENTINFOGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PATIENTINFOGroup PATIENTINFO;

        public partial class ARKASAYFAGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public ARKASAYFAGroupHeader Header()
            {
                return (ARKASAYFAGroupHeader)_header;
            }

            new public ARKASAYFAGroupFooter Footer()
            {
                return (ARKASAYFAGroupFooter)_footer;
            }

            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField MADDEKARAR { get {return Header().MADDEKARAR;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportShape shape1 { get {return Header().shape1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField BASTABIP { get {return Header().BASTABIP;} }
            public TTReportField SAGLIKDAIREBASKANLIGI { get {return Header().SAGLIKDAIREBASKANLIGI;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportShape shape2 { get {return Header().shape2;} }
            public TTReportField OYBIRLIGI { get {return Header().OYBIRLIGI;} }
            public TTReportShape shape3 { get {return Header().shape3;} }
            public TTReportShape shape4 { get {return Header().shape4;} }
            public TTReportField UNVAN { get {return Header().UNVAN;} }
            public TTReportField ADI { get {return Header().ADI;} }
            public TTReportField SICNO { get {return Header().SICNO;} }
            public TTReportField KARAR { get {return Header().KARAR;} }
            public TTReportField MADDE { get {return Header().MADDE;} }
            public TTReportField SKRAPORALTBASLIK { get {return Header().SKRAPORALTBASLIK;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportField KARAR1 { get {return Header().KARAR1;} }
            public TTReportField SAGLIKDAIREBASKANLIGI1 { get {return Header().SAGLIKDAIREBASKANLIGI1;} }
            public TTReportField SAGLIKDAIREBASKANLIGI2 { get {return Header().SAGLIKDAIREBASKANLIGI2;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField SK_CHAIRMAN { get {return Header().SK_CHAIRMAN;} }
            public TTReportField SK_MEMBER1 { get {return Header().SK_MEMBER1;} }
            public TTReportField SK_MEMBER2 { get {return Header().SK_MEMBER2;} }
            public TTReportField SK_MEMBER3 { get {return Header().SK_MEMBER3;} }
            public TTReportField SK_MEMBER4 { get {return Header().SK_MEMBER4;} }
            public TTReportField SK_MEMBER5 { get {return Header().SK_MEMBER5;} }
            public TTReportField SK_MEMBER6 { get {return Header().SK_MEMBER6;} }
            public TTReportField SK_MEMBER7 { get {return Header().SK_MEMBER7;} }
            public TTReportField SK_MEMBER8 { get {return Header().SK_MEMBER8;} }
            public TTReportField SK_MEMBER9 { get {return Header().SK_MEMBER9;} }
            public TTReportField SK_MEMBER10 { get {return Header().SK_MEMBER10;} }
            public TTReportField SK_MEMBER11 { get {return Header().SK_MEMBER11;} }
            public TTReportField SK_MEMBER12 { get {return Header().SK_MEMBER12;} }
            public TTReportField SK_MEMBER13 { get {return Header().SK_MEMBER13;} }
            public TTReportField SK_MEMBER14 { get {return Header().SK_MEMBER14;} }
            public TTReportField SK_MEMBER15 { get {return Header().SK_MEMBER15;} }
            public TTReportField DECISIONTIME { get {return Header().DECISIONTIME;} }
            public TTReportShape shape131 { get {return Footer().shape131;} }
            public ARKASAYFAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARKASAYFAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARKASAYFAGroupHeader(this);
                _footer = new ARKASAYFAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ARKASAYFAGroupHeader : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField NewField1;
                public TTReportField MADDEKARAR;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape shape1;
                public TTReportField NewField13;
                public TTReportField BASTABIP;
                public TTReportField SAGLIKDAIREBASKANLIGI;
                public TTReportField NewField19;
                public TTReportShape shape2;
                public TTReportField OYBIRLIGI;
                public TTReportShape shape3;
                public TTReportShape shape4;
                public TTReportField UNVAN;
                public TTReportField ADI;
                public TTReportField SICNO;
                public TTReportField KARAR;
                public TTReportField MADDE;
                public TTReportField SKRAPORALTBASLIK;
                public TTReportField DTARIHI;
                public TTReportField KARAR1;
                public TTReportField SAGLIKDAIREBASKANLIGI1;
                public TTReportField SAGLIKDAIREBASKANLIGI2;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField2;
                public TTReportField SK_CHAIRMAN;
                public TTReportField SK_MEMBER1;
                public TTReportField SK_MEMBER2;
                public TTReportField SK_MEMBER3;
                public TTReportField SK_MEMBER4;
                public TTReportField SK_MEMBER5;
                public TTReportField SK_MEMBER6;
                public TTReportField SK_MEMBER7;
                public TTReportField SK_MEMBER8;
                public TTReportField SK_MEMBER9;
                public TTReportField SK_MEMBER10;
                public TTReportField SK_MEMBER11;
                public TTReportField SK_MEMBER12;
                public TTReportField SK_MEMBER13;
                public TTReportField SK_MEMBER14;
                public TTReportField SK_MEMBER15;
                public TTReportField DECISIONTIME; 
                public ARKASAYFAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 106;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 1, 195, 35, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 40, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"Tanı";

                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 36, 195, 79, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.TextFont.Name = "Arial Narrow";
                    MADDEKARAR.TextFont.Size = 8;
                    MADDEKARAR.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 40, 80, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"Karar(*)";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 81, 195, 85, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.Value = @"NOT : Raporun imza yerlerine imzadan önce ve imza üstüne makine ile imza sahibinin rütbe, sicil no, ihtisas, adı ve soyadı yazılacaktır.";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 48, 10, 165, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 158, 194, 163, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.Value = @"(*) Karar hanesine S.Y. Yönetmeliğinin tanıya uygun madde ve fıkra No.ları yazılması zorunludur.";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 164, 195, 206, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.DrawStyle = DrawStyleConstants.vbSolid;
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial Narrow";
                    BASTABIP.Value = @"";

                    SAGLIKDAIREBASKANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 207, 195, 227, false);
                    SAGLIKDAIREBASKANLIGI.Name = "SAGLIKDAIREBASKANLIGI";
                    SAGLIKDAIREBASKANLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 247, 195, 265, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.Value = @"Ek rapor yazılacak kısım :";

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 48, 195, 167, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;

                    OYBIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 6, 236, 10, false);
                    OYBIRLIGI.Name = "OYBIRLIGI";
                    OYBIRLIGI.Visible = EvetHayirEnum.ehHayir;
                    OYBIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OYBIRLIGI.TextFont.Name = "Arial Narrow";
                    OYBIRLIGI.TextFont.Size = 8;
                    OYBIRLIGI.Value = @"";

                    shape3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 80, 195, 80, false);
                    shape3.Name = "shape3";
                    shape3.DrawStyle = DrawStyleConstants.vbSolid;

                    shape4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 17, 195, 49, false);
                    shape4.Name = "shape4";
                    shape4.DrawStyle = DrawStyleConstants.vbSolid;

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 163, 257, 168, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.TextColor = System.Drawing.Color.Red;
                    UNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 168, 294, 173, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.TextColor = System.Drawing.Color.Red;
                    ADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADI.TextFont.Name = "Arial Narrow";
                    ADI.Value = @"";

                    SICNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 163, 294, 168, false);
                    SICNO.Name = "SICNO";
                    SICNO.Visible = EvetHayirEnum.ehHayir;
                    SICNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICNO.TextColor = System.Drawing.Color.Red;
                    SICNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SICNO.TextFont.Name = "Arial Narrow";
                    SICNO.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 24, 240, 29, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 14, 240, 19, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR/";
                    MADDE.Value = @"";

                    SKRAPORALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 30, 243, 35, false);
                    SKRAPORALTBASLIK.Name = "SKRAPORALTBASLIK";
                    SKRAPORALTBASLIK.Visible = EvetHayirEnum.ehHayir;
                    SKRAPORALTBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKRAPORALTBASLIK.TextFormat = @"NOCR /";
                    SKRAPORALTBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORALTBASLIK"","""")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 35, 240, 40, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                    KARAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 41, 240, 46, false);
                    KARAR1.Name = "KARAR1";
                    KARAR1.Visible = EvetHayirEnum.ehHayir;
                    KARAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR1.TextFormat = @"NOCR";
                    KARAR1.Value = @"";

                    SAGLIKDAIREBASKANLIGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 228, 101, 246, false);
                    SAGLIKDAIREBASKANLIGI1.Name = "SAGLIKDAIREBASKANLIGI1";
                    SAGLIKDAIREBASKANLIGI1.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI1.Value = @"";

                    SAGLIKDAIREBASKANLIGI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 228, 194, 246, false);
                    SAGLIKDAIREBASKANLIGI2.Name = "SAGLIKDAIREBASKANLIGI2";
                    SAGLIKDAIREBASKANLIGI2.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI2.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 174, 10, 249, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 174, 195, 250, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 86, 47, 90, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"SAĞLIK KURULU BAŞKANI";

                    SK_CHAIRMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 90, 56, 107, false);
                    SK_CHAIRMAN.Name = "SK_CHAIRMAN";
                    SK_CHAIRMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_CHAIRMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.TextFont.Size = 7;
                    SK_CHAIRMAN.TextFont.Bold = true;
                    SK_CHAIRMAN.Value = @"";

                    SK_MEMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 90, 102, 107, false);
                    SK_MEMBER1.Name = "SK_MEMBER1";
                    SK_MEMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.TextFont.Size = 7;
                    SK_MEMBER1.TextFont.Bold = true;
                    SK_MEMBER1.Value = @"";

                    SK_MEMBER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 90, 148, 107, false);
                    SK_MEMBER2.Name = "SK_MEMBER2";
                    SK_MEMBER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER2.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.TextFont.Size = 7;
                    SK_MEMBER2.TextFont.Bold = true;
                    SK_MEMBER2.Value = @"";

                    SK_MEMBER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 90, 194, 107, false);
                    SK_MEMBER3.Name = "SK_MEMBER3";
                    SK_MEMBER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER3.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.TextFont.Size = 7;
                    SK_MEMBER3.TextFont.Bold = true;
                    SK_MEMBER3.Value = @"";

                    SK_MEMBER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 107, 56, 124, false);
                    SK_MEMBER4.Name = "SK_MEMBER4";
                    SK_MEMBER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER4.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.TextFont.Size = 7;
                    SK_MEMBER4.TextFont.Bold = true;
                    SK_MEMBER4.Value = @"";

                    SK_MEMBER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 107, 102, 124, false);
                    SK_MEMBER5.Name = "SK_MEMBER5";
                    SK_MEMBER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER5.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.TextFont.Size = 7;
                    SK_MEMBER5.TextFont.Bold = true;
                    SK_MEMBER5.Value = @"";

                    SK_MEMBER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 107, 148, 124, false);
                    SK_MEMBER6.Name = "SK_MEMBER6";
                    SK_MEMBER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER6.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.TextFont.Size = 7;
                    SK_MEMBER6.TextFont.Bold = true;
                    SK_MEMBER6.Value = @"";

                    SK_MEMBER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 107, 194, 124, false);
                    SK_MEMBER7.Name = "SK_MEMBER7";
                    SK_MEMBER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER7.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.TextFont.Size = 7;
                    SK_MEMBER7.TextFont.Bold = true;
                    SK_MEMBER7.Value = @"";

                    SK_MEMBER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 124, 56, 141, false);
                    SK_MEMBER8.Name = "SK_MEMBER8";
                    SK_MEMBER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER8.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.TextFont.Size = 7;
                    SK_MEMBER8.TextFont.Bold = true;
                    SK_MEMBER8.Value = @"";

                    SK_MEMBER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 124, 102, 141, false);
                    SK_MEMBER9.Name = "SK_MEMBER9";
                    SK_MEMBER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER9.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.TextFont.Size = 7;
                    SK_MEMBER9.TextFont.Bold = true;
                    SK_MEMBER9.Value = @"";

                    SK_MEMBER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 124, 148, 141, false);
                    SK_MEMBER10.Name = "SK_MEMBER10";
                    SK_MEMBER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER10.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.TextFont.Size = 7;
                    SK_MEMBER10.TextFont.Bold = true;
                    SK_MEMBER10.Value = @"";

                    SK_MEMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 124, 194, 141, false);
                    SK_MEMBER11.Name = "SK_MEMBER11";
                    SK_MEMBER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.TextFont.Size = 7;
                    SK_MEMBER11.TextFont.Bold = true;
                    SK_MEMBER11.Value = @"";

                    SK_MEMBER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 141, 56, 158, false);
                    SK_MEMBER12.Name = "SK_MEMBER12";
                    SK_MEMBER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER12.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.TextFont.Size = 7;
                    SK_MEMBER12.TextFont.Bold = true;
                    SK_MEMBER12.Value = @"";

                    SK_MEMBER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 141, 102, 158, false);
                    SK_MEMBER13.Name = "SK_MEMBER13";
                    SK_MEMBER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER13.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.TextFont.Size = 7;
                    SK_MEMBER13.TextFont.Bold = true;
                    SK_MEMBER13.Value = @"";

                    SK_MEMBER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 141, 148, 158, false);
                    SK_MEMBER14.Name = "SK_MEMBER14";
                    SK_MEMBER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER14.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.TextFont.Size = 7;
                    SK_MEMBER14.TextFont.Bold = true;
                    SK_MEMBER14.Value = @"";

                    SK_MEMBER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 141, 194, 158, false);
                    SK_MEMBER15.Name = "SK_MEMBER15";
                    SK_MEMBER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER15.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.TextFont.Size = 7;
                    SK_MEMBER15.TextFont.Bold = true;
                    SK_MEMBER15.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 49, 240, 54, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    TANI.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    MADDEKARAR.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField13.CalcValue = NewField13.Value;
                    BASTABIP.CalcValue = @"";
                    SAGLIKDAIREBASKANLIGI.CalcValue = SAGLIKDAIREBASKANLIGI.Value;
                    NewField19.CalcValue = NewField19.Value;
                    OYBIRLIGI.CalcValue = @"";
                    UNVAN.CalcValue = @"";
                    ADI.CalcValue = @"";
                    SICNO.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    KARAR1.CalcValue = @"";
                    SAGLIKDAIREBASKANLIGI1.CalcValue = SAGLIKDAIREBASKANLIGI1.Value;
                    SAGLIKDAIREBASKANLIGI2.CalcValue = SAGLIKDAIREBASKANLIGI2.Value;
                    NewField2.CalcValue = NewField2.Value;
                    SK_CHAIRMAN.CalcValue = @"";
                    SK_MEMBER1.CalcValue = @"";
                    SK_MEMBER2.CalcValue = @"";
                    SK_MEMBER3.CalcValue = @"";
                    SK_MEMBER4.CalcValue = @"";
                    SK_MEMBER5.CalcValue = @"";
                    SK_MEMBER6.CalcValue = @"";
                    SK_MEMBER7.CalcValue = @"";
                    SK_MEMBER8.CalcValue = @"";
                    SK_MEMBER9.CalcValue = @"";
                    SK_MEMBER10.CalcValue = @"";
                    SK_MEMBER11.CalcValue = @"";
                    SK_MEMBER12.CalcValue = @"";
                    SK_MEMBER13.CalcValue = @"";
                    SK_MEMBER14.CalcValue = @"";
                    SK_MEMBER15.CalcValue = @"";
                    DECISIONTIME.CalcValue = @"";
                    SKRAPORALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORALTBASLIK","");
                    return new TTReportObject[] { TANI,NewField1,MADDEKARAR,NewField3,NewField4,NewField13,BASTABIP,SAGLIKDAIREBASKANLIGI,NewField19,OYBIRLIGI,UNVAN,ADI,SICNO,KARAR,MADDE,DTARIHI,KARAR1,SAGLIKDAIREBASKANLIGI1,SAGLIKDAIREBASKANLIGI2,NewField2,SK_CHAIRMAN,SK_MEMBER1,SK_MEMBER2,SK_MEMBER3,SK_MEMBER4,SK_MEMBER5,SK_MEMBER6,SK_MEMBER7,SK_MEMBER8,SK_MEMBER9,SK_MEMBER10,SK_MEMBER11,SK_MEMBER12,SK_MEMBER13,SK_MEMBER14,SK_MEMBER15,DECISIONTIME,SKRAPORALTBASLIK};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeFlierReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
//            if (hc.ExplanationsofRejection.Count > 0)
//                this.MADDEKARAR.CalcValue = "KARAR OY ÇOKLUĞU İLE ALINMIŞTIR \n";
            //this.OYBIRLIGI.CalcValue = "KARAR OY ÇOKLUĞU İLE ALINMIŞTIR";
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
                
                this.MADDEKARAR.CalcValue += this.MADDE.CalcValue + "\r\n";
            }
            
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.MADDEKARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.MADDEKARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.MADDEKARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\r\n";
            }
            
            // Şerh ve Şerhi Koyan Tabip
//            if (hc.ExplanationsofRejection.Count > 0)
//            {
//                string rejection = "";
//                foreach(HealthCommittee_ExplanationOfRejectionGrid rejectionGrid in hc.ExplanationsofRejection)
//                {
//                    rejection += "\r\n";
//                    if(rejectionGrid.Doctor != null)
//                    {
//                        if(rejectionGrid.Doctor.Title != null)
//                            rejection += TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(rejectionGrid.Doctor.Title) + " ";
//                        
//                        if(rejectionGrid.Doctor.Rank != null)
//                            rejection += rejectionGrid.Doctor.Rank.ShortName + " ";
//
//                        rejection += rejectionGrid.Doctor.Name;
//                    }
//                    rejection += "   " + TTUtils.Globals.GetRTFText(rejectionGrid.ExplanationOfRejection.ToString());
//                }
//                
//                if (rejection != "")
//                    this.MADDEKARAR.CalcValue += rejection;
//            }
            
            //Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //Baştabip
            string sCrLf = "\r\n";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.ChiefOfMedicine)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID;
                    string sTitle = ""; //(hc.MemberOfHealthCommittee.MasterOfHealthCommittee.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee.MilitaryClass.ShortName);

                    if (member.MemberDoctor.Title.HasValue)
                        sTitle += TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    //string sRank = (hc.MemberOfHealthCommittee.MasterOfHealthCommittee.Rank != null)?hc.MemberOfHealthCommittee.MasterOfHealthCommittee.Rank.ShortName:"";
                    //string sMilClass = (hc.MemberOfHealthCommittee.MasterOfHealthCommittee.MilitaryClass != null)?hc.MemberOfHealthCommittee.MasterOfHealthCommittee.MilitaryClass.ShortName:"";

                    sTitle += " " + (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);
                    string sMasterText = "";

                    sMasterText += "YETKİLİ ÜST MAKAM ONAYLARI:" + sCrLf;
                    sMasterText += "Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği " + this.MADDE.CalcValue + " maddelerine/fıkralarına uygundur." + sCrLf;
                    sMasterText += sCrLf;

                    if (this.SKRAPORALTBASLIK.CalcValue == "")
                        sMasterText = sMasterText + "                                                                                         .......................................        /      / 20" + sCrLf;
                    else
                        sMasterText = sMasterText + "                                                                            " + this.SKRAPORALTBASLIK.CalcValue + "         /      / 20" + sCrLf;

                    sMasterText = sMasterText + "" + sCrLf;
                    sMasterText = sMasterText + "                                                                             Rütbesi, Sicil No. " + sTitle + " (" + sEmpID + ")" + sCrLf;
                    //sMasterText = sMasterText + "                                                                             Rütbesi, Sicil No. " + sMilClass + sRank + " (" + sEmpID + ")" + sCrLf;
                    sMasterText = sMasterText + "                                                                             Adı Soyadı           " + member.MemberDoctor.Name + sCrLf;
                    sMasterText = sMasterText + "                                                                             İmza, mühür" + sCrLf;
                    this.BASTABIP.CalcValue = sMasterText;
                }


                // XXXXXX Sağlık XXXXXX
                string labelText = "XXXXXX Sağlık XXXXXX / Milli Savunma Bakanlığı Sağlık Daire Başkanlığı Onayı" + sCrLf + sCrLf + sCrLf;
                labelText += "                          Rapor İnceleme Ks. A.        /      /20                                        ONAY     /      /20 " + sCrLf + sCrLf;

                this.SAGLIKDAIREBASKANLIGI.CalcValue = labelText;

                labelText = " Rütbesi,Sicil No. " + sCrLf;
                labelText += " Adı Soyadı " + sCrLf;
                labelText += " Görevi " + sCrLf;
                labelText += " İmza, mühür ";

                this.SAGLIKDAIREBASKANLIGI1.CalcValue = labelText;
                this.SAGLIKDAIREBASKANLIGI2.CalcValue = labelText;


                //Signatures

                //Chairman
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string chairmanName = member.MemberDoctor.Name;
                    string chairmanMilClass = member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.ShortName;
                    string chairmanRank = member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName;
                    string chairmanTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    string chairmanRecId = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string chairmanMainSpeciality = "";
                    string chairmanSpecialities = "";
                    for (int s = 0; s < member.MemberDoctor.ResourceSpecialities.Count; s++)
                        if (member.MemberDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
                    {
                        chairmanMainSpeciality += member.MemberDoctor.ResourceSpecialities[s].Speciality.Name;
                        if (!member.MemberDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) chairmanMainSpeciality += " Uzm.";
                    }
                    else
                    {
                        chairmanSpecialities += member.MemberDoctor.ResourceSpecialities[s].Speciality.Name;
                        if (!member.MemberDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) chairmanSpecialities += " Uzm.";
                        chairmanSpecialities += "\r\n";
                    }
                    //if (chairmanSpecialities != "") chairmanSpecialities += " Uzm.";
                    //else if (chairmanMainSpeciality != "") chairmanMainSpeciality += " Uzm.";

                    this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanTitle + chairmanRank + " (" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                    //this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanMilClass + chairmanTitle + chairmanRank + "(" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                }



                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MemberOfHealthCommittee)
                {
                    string memberName = member.MemberDoctor.Name;
                    string memberMilClass = member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.ShortName;
                    string memberRank = member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName;
                    string memberTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    string memberRecId = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string memberMainSpeciality = "";
                    string memberSpecialities = "";
                    for (int s = 0; s < member.MemberDoctor.ResourceSpecialities.Count; s++)
                        if (member.MemberDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
                    {
                        memberMainSpeciality += member.MemberDoctor.ResourceSpecialities[s].Speciality.Name;
                        if (!member.MemberDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
                    }
                    else
                    {
                        memberSpecialities += member.MemberDoctor.ResourceSpecialities[s].Speciality.Name;
                        if (!member.MemberDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberSpecialities += " Uzm.";
                        memberSpecialities += "\r\n";
                    }
                    string sigText = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
                    //string sigText = memberName + "\r\n" + memberMilClass + memberTitle + memberRank + "(" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;

                    //if (memberSpecialities != "") memberSpecialities += " Uzm.";
                    //else if (memberMainSpeciality != "") memberMainSpeciality += " Uzm.";

                    if (this.SK_MEMBER1.CalcValue.Length == 0) this.SK_MEMBER1.CalcValue = sigText;
                    else if (this.SK_MEMBER2.CalcValue.Length == 0) this.SK_MEMBER2.CalcValue = sigText;
                    else if (this.SK_MEMBER3.CalcValue.Length == 0) this.SK_MEMBER3.CalcValue = sigText;
                    else if (this.SK_MEMBER4.CalcValue.Length == 0) this.SK_MEMBER4.CalcValue = sigText;
                    else if (this.SK_MEMBER5.CalcValue.Length == 0) this.SK_MEMBER5.CalcValue = sigText;
                    else if (this.SK_MEMBER6.CalcValue.Length == 0) this.SK_MEMBER6.CalcValue = sigText;
                    else if (this.SK_MEMBER7.CalcValue.Length == 0) this.SK_MEMBER7.CalcValue = sigText;
                    else if (this.SK_MEMBER8.CalcValue.Length == 0) this.SK_MEMBER8.CalcValue = sigText;
                    else if (this.SK_MEMBER9.CalcValue.Length == 0) this.SK_MEMBER9.CalcValue = sigText;
                    else if (this.SK_MEMBER10.CalcValue.Length == 0) this.SK_MEMBER10.CalcValue = sigText;
                    else if (this.SK_MEMBER11.CalcValue.Length == 0) this.SK_MEMBER11.CalcValue = sigText;
                    else if (this.SK_MEMBER12.CalcValue.Length == 0) this.SK_MEMBER12.CalcValue = sigText;
                    else if (this.SK_MEMBER13.CalcValue.Length == 0) this.SK_MEMBER13.CalcValue = sigText;
                    else if (this.SK_MEMBER14.CalcValue.Length == 0) this.SK_MEMBER14.CalcValue = sigText;
                    else if (this.SK_MEMBER15.CalcValue.Length == 0) this.SK_MEMBER15.CalcValue = sigText;
                }
            }
            
            /*
             * old text area signatures changed by ET @ 21.03.2012
            //Members
            if(hc.MemberOfHealthCommittee != null)
            {
                string sMembersText = sCrLf;
                string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId = "", sMemberSpeciality = "";
                
                const int COLUMN_COUNT = 4;
                const int SPACE_COUNT = 31;
                const int SPECIALITY_COUNT = 29;
                int nCounter = 0;
                int nRow = 0;
                bool writeSKChairman = false;
                
                string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                int nRate;
                
                // SK Başkanı Yazılır
                if (hc.MemberOfHealthCommittee.MasterOfHealthCommittee2 != null)
                {
                    sMemberName = hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.Name;
                    sMemberMilClass = hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass.ShortName;
                    sMemberRank = hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.Rank == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.Rank.ShortName;
                    sMemberTitle = !hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.Title.Value);
                    sMemberRecId = hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.EmploymentRecordID == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.EmploymentRecordID;
                    
                    if (hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.GetSpeciality() != null)
                        sMemberSpeciality = hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.GetSpeciality().Name;
                    
                    sNameRow = sNameRow.Insert(nCounter, sMemberName);
                    //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberTitle + " " + sMemberRank);
                    //sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                    sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                    //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
                    if (sMemberSpeciality != "")
                    {
                        sMemberSpeciality += " Uzm.";
                        if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                        {
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
                                sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
                            
                            sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
                            sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
                        }
                        else
                        {
                            sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                        }
                    }
                    else
                    {
                        sTitleRow = sTitleRow.Insert(nCounter, "");
                        sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                    }
                    
                    nCounter += SPACE_COUNT;
                    
                    nRow = nCounter / SPACE_COUNT;
                    nRate = nRow % COLUMN_COUNT;
                    if (nRate == 0)
                    {
                        sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sNameRow + "\r\n";
                        sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sRankRow + "\r\n";
                        sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sTitleRow + "\r\n";
                        sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sSpecialityRow + "\r\n";

                        sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                        sMembersText +=  sCrLf + sCrLf;
                        nCounter = 0;
                    }
                }
                
                foreach(HealthCommitteMemberGrid pMember in hc.MemberOfHealthCommittee.Members)
                {
                    if (pMember.Doctor != null)
                    {
                        sMemberName = pMember.Doctor.Name;
                        sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
                        sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
                        sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
                        sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
                        
                        if (pMember.Doctor.GetSpeciality() != null)
                            sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
                        else
                            sMemberSpeciality = "";
                        
                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberTitle  + " " + sMemberRank);
                        //sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
                        //sSpecialityRow = sSpecialityRow.Insert(nCounter,  sMemberSpeciality + " Uzm.");

                        if (sMemberSpeciality != "")
                        {
                            sMemberSpeciality += " Uzm.";
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                            {
                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
                                
                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
                            }
                            else
                            {
                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                            }
                        }
                        else
                        {
                            sTitleRow = sTitleRow.Insert(nCounter, "");
                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                        }
                        
                        nCounter += SPACE_COUNT;

                        nRow = nCounter / SPACE_COUNT;
                        nRate = nRow % COLUMN_COUNT;
                        if (nRate == 0)
                        {
                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sNameRow + "\r\n";
                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sRankRow + "\r\n";
                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sTitleRow + "\r\n";
                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sSpecialityRow + "\r\n";

                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                            sMembersText +=  sCrLf + sCrLf;
                            nCounter = 0;
                        }
                    }
                }
                     
                
                sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                sMembersText += sNameRow + "\r\n";
                sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                sMembersText += sRankRow + "\r\n";
                sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                sMembersText += sTitleRow + "\r\n";
                sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                sMembersText += sSpecialityRow + "\r\n";
                
                this.MEMBERS.CalcValue = sMembersText;
             * 
                     
                      
                     
            }*/
#endregion ARKASAYFA HEADER_Script
                }
            }
            public partial class ARKASAYFAGroupFooter : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportShape shape131; 
                public ARKASAYFAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 196, 0, false);
                    shape131.Name = "shape131";
                    shape131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public ARKASAYFAGroup ARKASAYFA;

        public partial class ANAGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField MUAYENESEBEBI { get {return Header().MUAYENESEBEBI;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField AD { get {return Header().AD;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField DOGUMTARIHI { get {return Header().DOGUMTARIHI;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField KILO { get {return Header().KILO;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField520 { get {return Header().NewField520;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportShape shape161 { get {return Header().shape161;} }
            public TTReportShape shape1161 { get {return Header().shape1161;} }
            public TTReportShape shape1162 { get {return Header().shape1162;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField DUZENLEYENMERKEZ { get {return Header().DUZENLEYENMERKEZ;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField SOYAD { get {return Header().SOYAD;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1163 { get {return Header().NewField1163;} }
            public TTReportField NewField1164 { get {return Header().NewField1164;} }
            public TTReportField NewField13611 { get {return Header().NewField13611;} }
            public TTReportField NewField14611 { get {return Header().NewField14611;} }
            public TTReportField NewField13612 { get {return Header().NewField13612;} }
            public TTReportField NewField14612 { get {return Header().NewField14612;} }
            public TTReportField NewField13613 { get {return Header().NewField13613;} }
            public TTReportField NewField14613 { get {return Header().NewField14613;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField EMSANSICIL { get {return Header().EMSANSICIL;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField NewField1222 { get {return Header().NewField1222;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField13614 { get {return Header().NewField13614;} }
            public TTReportField NewField14614 { get {return Header().NewField14614;} }
            public TTReportField NewField111631 { get {return Header().NewField111631;} }
            public TTReportField NewField111641 { get {return Header().NewField111641;} }
            public TTReportField NewField121631 { get {return Header().NewField121631;} }
            public TTReportField NewField121641 { get {return Header().NewField121641;} }
            public TTReportShape shape12611 { get {return Header().shape12611;} }
            public TTReportField UCAKTIPI { get {return Header().UCAKTIPI;} }
            public TTReportField SONSKSONUCU { get {return Header().SONSKSONUCU;} }
            public TTReportShape shape111621 { get {return Header().shape111621;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField12221 { get {return Header().NewField12221;} }
            public TTReportField GOREV { get {return Header().GOREV;} }
            public TTReportField UcakLbl11 { get {return Header().UcakLbl11;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField RaporNoLbl11311 { get {return Header().RaporNoLbl11311;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Header().TCKIMLIKNOBARKOD;} }
            public TTReportField NewField1322 { get {return Header().NewField1322;} }
            public TTReportField NewField111642 { get {return Header().NewField111642;} }
            public TTReportField KUVVET { get {return Header().KUVVET;} }
            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                HealthCommittee.GetCurrentHealthCommittee_Class dataSet_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);    
                return new object[] {(dataSet_GetCurrentHealthCommittee==null ? null : dataSet_GetCurrentHealthCommittee.Healthcommitteeobjectid)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField NewField53;
                public TTReportField MUAYENESEBEBI;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField25;
                public TTReportField AD;
                public TTReportField BABAADI;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField DOGUMTARIHI;
                public TTReportField RAPORNO;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportField NewField51;
                public TTReportField NewField520;
                public TTReportField HEADER;
                public TTReportField TCKIMLIKNO;
                public TTReportShape shape161;
                public TTReportShape shape1161;
                public TTReportShape shape1162;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField NewField16;
                public TTReportField NewField12;
                public TTReportField NewField162;
                public TTReportField NewField1162;
                public TTReportField DUZENLEYENMERKEZ;
                public TTReportField NewField122;
                public TTReportField SOYAD;
                public TTReportField NewField123;
                public TTReportField NewField132;
                public TTReportField NewField152;
                public TTReportField NewField1221;
                public TTReportField NewField1163;
                public TTReportField NewField1164;
                public TTReportField NewField13611;
                public TTReportField NewField14611;
                public TTReportField NewField13612;
                public TTReportField NewField14612;
                public TTReportField NewField13613;
                public TTReportField NewField14613;
                public TTReportShape NewLine1111;
                public TTReportField EMSANSICIL;
                public TTReportField NewField124;
                public TTReportField NewField133;
                public TTReportField NewField153;
                public TTReportField NewField1222;
                public TTReportField NewField1321;
                public TTReportField NewField11221;
                public TTReportField NewField13614;
                public TTReportField NewField14614;
                public TTReportField NewField111631;
                public TTReportField NewField111641;
                public TTReportField NewField121631;
                public TTReportField NewField121641;
                public TTReportShape shape12611;
                public TTReportField UCAKTIPI;
                public TTReportField SONSKSONUCU;
                public TTReportShape shape111621;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField NewField12221;
                public TTReportField GOREV;
                public TTReportField UcakLbl11;
                public TTReportField MUAYENETARIHI;
                public TTReportField RaporNoLbl11311;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField NewField1322;
                public TTReportField NewField111642;
                public TTReportField KUVVET; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 106;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 45, 195, 90, false);
                    NewField53.Name = "NewField53";
                    NewField53.FieldType = ReportFieldTypeEnum.ftOLE;
                    NewField53.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.Value = @"";

                    MUAYENESEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 65, 157, 75, false);
                    MUAYENESEBEBI.Name = "MUAYENESEBEBI";
                    MUAYENESEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENESEBEBI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MUAYENESEBEBI.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENESEBEBI.WordBreak = EvetHayirEnum.ehEvet;
                    MUAYENESEBEBI.TextFont.Name = "Arial Narrow";
                    MUAYENESEBEBI.TextFont.Size = 8;
                    MUAYENESEBEBI.Value = @"{#ARKASAYFA.SKSEBEBI#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 32, 195, 37, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#ARKASAYFA.RAPORTARIHI#}";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 44, 33, 49, false);
                    NewField22.Name = "NewField22";
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 8;
                    NewField22.Value = @"ADI";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 55, 33, 60, false);
                    NewField23.Name = "NewField23";
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Size = 8;
                    NewField23.Value = @"BABA ADI";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 61, 33, 66, false);
                    NewField25.Name = "NewField25";
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.Size = 8;
                    NewField25.Value = @"SINIF VE RÜTBE";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 44, 72, 49, false);
                    AD.Name = "AD";
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.MultiLine = EvetHayirEnum.ehEvet;
                    AD.WordBreak = EvetHayirEnum.ehEvet;
                    AD.TextFont.Name = "Arial Narrow";
                    AD.TextFont.Size = 8;
                    AD.Value = @"{#ARKASAYFA.PNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 55, 72, 60, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.MultiLine = EvetHayirEnum.ehEvet;
                    BABAADI.WordBreak = EvetHayirEnum.ehEvet;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#ARKASAYFA.FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 39, 157, 53, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 61, 72, 72, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 79, 72, 84, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 91, 72, 96, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"Short Date";
                    DOGUMTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DOGUMTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DOGUMTARIHI.TextFont.Name = "Arial Narrow";
                    DOGUMTARIHI.TextFont.Size = 8;
                    DOGUMTARIHI.Value = @"{#ARKASAYFA.DTARIHI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 27, 195, 32, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#ARKASAYFA.RAPORNO#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 91, 111, 96, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.MultiLine = EvetHayirEnum.ehEvet;
                    BOY.WordBreak = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#ARKASAYFA.BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 91, 157, 96, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.MultiLine = EvetHayirEnum.ehEvet;
                    KILO.WordBreak = EvetHayirEnum.ehEvet;
                    KILO.TextFont.Name = "Arial Narrow";
                    KILO.TextFont.Size = 8;
                    KILO.Value = @"{#ARKASAYFA.KILO#}";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 97, 48, 106, false);
                    NewField51.Name = "NewField51";
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 9;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve  laboratuvarlar";

                    NewField520 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 100, 171, 105, false);
                    NewField520.Name = "NewField520";
                    NewField520.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField520.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField520.TextFont.Name = "Arial Narrow";
                    NewField520.TextFont.Size = 9;
                    NewField520.TextFont.Bold = true;
                    NewField520.Value = @"BULGULAR";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 196, 25, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCFLIERREPORTCAPTION"","""")";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 39, 72, 44, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#ARKASAYFA.TCNO#}";

                    shape161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 26, 10, 106, false);
                    shape161.Name = "shape161";
                    shape161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 97, 48, 106, false);
                    shape1161.Name = "shape1161";
                    shape1161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 26, 196, 106, false);
                    shape1162.Name = "shape1162";
                    shape1162.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1162.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 26, 196, 26, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 38, 196, 38, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 27, 169, 32, false);
                    NewField16.Name = "NewField16";
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 8;
                    NewField16.Value = @"RAPOR NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 32, 169, 37, false);
                    NewField12.Name = "NewField12";
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 8;
                    NewField12.Value = @"RAPOR TARİHİ";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 27, 40, 32, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.Size = 8;
                    NewField162.Value = @"DÜZENLEYEN MERKEZ";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 27, 42, 32, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1162.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1162.TextFont.Name = "Arial Narrow";
                    NewField1162.TextFont.Size = 8;
                    NewField1162.Value = @":";

                    DUZENLEYENMERKEZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 27, 146, 37, false);
                    DUZENLEYENMERKEZ.Name = "DUZENLEYENMERKEZ";
                    DUZENLEYENMERKEZ.FieldType = ReportFieldTypeEnum.ftExpression;
                    DUZENLEYENMERKEZ.MultiLine = EvetHayirEnum.ehEvet;
                    DUZENLEYENMERKEZ.WordBreak = EvetHayirEnum.ehEvet;
                    DUZENLEYENMERKEZ.TextFont.Name = "Arial Narrow";
                    DUZENLEYENMERKEZ.TextFont.Size = 8;
                    DUZENLEYENMERKEZ.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"","""")";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 49, 33, 54, false);
                    NewField122.Name = "NewField122";
                    NewField122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 8;
                    NewField122.Value = @"SOYADI";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 49, 72, 54, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    SOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    SOYAD.TextFont.Name = "Arial Narrow";
                    SOYAD.TextFont.Size = 8;
                    SOYAD.Value = @"{#ARKASAYFA.PSURNAME#}";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 79, 33, 84, false);
                    NewField123.Name = "NewField123";
                    NewField123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Size = 8;
                    NewField123.Value = @"SİCİL NU.";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 91, 33, 96, false);
                    NewField132.Name = "NewField132";
                    NewField132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.Size = 8;
                    NewField132.Value = @"DOĞUM TARİHİ";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 39, 33, 44, false);
                    NewField152.Name = "NewField152";
                    NewField152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152.WordBreak = EvetHayirEnum.ehEvet;
                    NewField152.TextFont.Name = "Arial Narrow";
                    NewField152.TextFont.Size = 8;
                    NewField152.Value = @"TC.KİMLİK.NU.";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 85, 33, 90, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 8;
                    NewField1221.Value = @"EM.SAN.SİC.NU.";

                    NewField1163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 49, 35, 54, false);
                    NewField1163.Name = "NewField1163";
                    NewField1163.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1163.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1163.TextFont.Name = "Arial Narrow";
                    NewField1163.TextFont.Size = 8;
                    NewField1163.Value = @":";

                    NewField1164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 44, 35, 49, false);
                    NewField1164.Name = "NewField1164";
                    NewField1164.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1164.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1164.TextFont.Name = "Arial Narrow";
                    NewField1164.TextFont.Size = 8;
                    NewField1164.Value = @":";

                    NewField13611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 55, 35, 60, false);
                    NewField13611.Name = "NewField13611";
                    NewField13611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13611.TextFont.Name = "Arial Narrow";
                    NewField13611.TextFont.Size = 8;
                    NewField13611.Value = @":";

                    NewField14611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 61, 35, 66, false);
                    NewField14611.Name = "NewField14611";
                    NewField14611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14611.TextFont.Name = "Arial Narrow";
                    NewField14611.TextFont.Size = 8;
                    NewField14611.Value = @":";

                    NewField13612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 79, 35, 84, false);
                    NewField13612.Name = "NewField13612";
                    NewField13612.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13612.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13612.TextFont.Name = "Arial Narrow";
                    NewField13612.TextFont.Size = 8;
                    NewField13612.Value = @":";

                    NewField14612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 85, 35, 90, false);
                    NewField14612.Name = "NewField14612";
                    NewField14612.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14612.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14612.TextFont.Name = "Arial Narrow";
                    NewField14612.TextFont.Size = 8;
                    NewField14612.Value = @":";

                    NewField13613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 91, 35, 96, false);
                    NewField13613.Name = "NewField13613";
                    NewField13613.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13613.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13613.TextFont.Name = "Arial Narrow";
                    NewField13613.TextFont.Size = 8;
                    NewField13613.Value = @":";

                    NewField14613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 39, 35, 44, false);
                    NewField14613.Name = "NewField14613";
                    NewField14613.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14613.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14613.TextFont.Name = "Arial Narrow";
                    NewField14613.TextFont.Size = 8;
                    NewField14613.Value = @":";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 97, 196, 97, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    EMSANSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 85, 72, 90, false);
                    EMSANSICIL.Name = "EMSANSICIL";
                    EMSANSICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMSANSICIL.MultiLine = EvetHayirEnum.ehEvet;
                    EMSANSICIL.WordBreak = EvetHayirEnum.ehEvet;
                    EMSANSICIL.TextFont.Name = "Arial Narrow";
                    EMSANSICIL.TextFont.Size = 8;
                    EMSANSICIL.Value = @"";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 39, 99, 44, false);
                    NewField124.Name = "NewField124";
                    NewField124.MultiLine = EvetHayirEnum.ehEvet;
                    NewField124.WordBreak = EvetHayirEnum.ehEvet;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Size = 8;
                    NewField124.Value = @"BİRLİĞİ";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 65, 100, 75, false);
                    NewField133.Name = "NewField133";
                    NewField133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.TextFont.Size = 8;
                    NewField133.Value = @"NE MAKSATLA
MUAYENE EDİLDİĞİ";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 75, 99, 85, false);
                    NewField153.Name = "NewField153";
                    NewField153.MultiLine = EvetHayirEnum.ehEvet;
                    NewField153.WordBreak = EvetHayirEnum.ehEvet;
                    NewField153.TextFont.Name = "Arial Narrow";
                    NewField153.TextFont.Size = 8;
                    NewField153.Value = @"SON SAĞLIK İŞLEMİ
VE SONUCU";

                    NewField1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 60, 99, 65, false);
                    NewField1222.Name = "NewField1222";
                    NewField1222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1222.TextFont.Name = "Arial Narrow";
                    NewField1222.TextFont.Size = 8;
                    NewField1222.Value = @"UÇTUĞU UÇAK TİPİ";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 91, 83, 96, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Size = 8;
                    NewField1321.Value = @"BOY";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 91, 123, 96, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 8;
                    NewField11221.Value = @"KİLO";

                    NewField13614 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 39, 101, 44, false);
                    NewField13614.Name = "NewField13614";
                    NewField13614.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13614.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13614.TextFont.Name = "Arial Narrow";
                    NewField13614.TextFont.Size = 8;
                    NewField13614.Value = @":";

                    NewField14614 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 60, 101, 65, false);
                    NewField14614.Name = "NewField14614";
                    NewField14614.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14614.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14614.TextFont.Name = "Arial Narrow";
                    NewField14614.TextFont.Size = 8;
                    NewField14614.Value = @":";

                    NewField111631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 65, 101, 70, false);
                    NewField111631.Name = "NewField111631";
                    NewField111631.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111631.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111631.TextFont.Name = "Arial Narrow";
                    NewField111631.TextFont.Size = 8;
                    NewField111631.Value = @":";

                    NewField111641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 75, 101, 80, false);
                    NewField111641.Name = "NewField111641";
                    NewField111641.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111641.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111641.TextFont.Name = "Arial Narrow";
                    NewField111641.TextFont.Size = 8;
                    NewField111641.Value = @":";

                    NewField121631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 91, 85, 96, false);
                    NewField121631.Name = "NewField121631";
                    NewField121631.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121631.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121631.TextFont.Name = "Arial Narrow";
                    NewField121631.TextFont.Size = 8;
                    NewField121631.Value = @":";

                    NewField121641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 91, 125, 96, false);
                    NewField121641.Name = "NewField121641";
                    NewField121641.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121641.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121641.TextFont.Name = "Arial Narrow";
                    NewField121641.TextFont.Size = 8;
                    NewField121641.Value = @":";

                    shape12611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 38, 73, 97, false);
                    shape12611.Name = "shape12611";
                    shape12611.DrawStyle = DrawStyleConstants.vbSolid;

                    UCAKTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 60, 157, 65, false);
                    UCAKTIPI.Name = "UCAKTIPI";
                    UCAKTIPI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UCAKTIPI.MultiLine = EvetHayirEnum.ehEvet;
                    UCAKTIPI.WordBreak = EvetHayirEnum.ehEvet;
                    UCAKTIPI.ObjectDefName = "AircraftTypeDefinition";
                    UCAKTIPI.DataMember = "NAME";
                    UCAKTIPI.TextFont.Name = "Arial Narrow";
                    UCAKTIPI.TextFont.Size = 8;
                    UCAKTIPI.Value = @"{#ARKASAYFA.UCAKTIPI#}";

                    SONSKSONUCU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 75, 157, 85, false);
                    SONSKSONUCU.Name = "SONSKSONUCU";
                    SONSKSONUCU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONSKSONUCU.MultiLine = EvetHayirEnum.ehEvet;
                    SONSKSONUCU.WordBreak = EvetHayirEnum.ehEvet;
                    SONSKSONUCU.TextFont.Name = "Arial Narrow";
                    SONSKSONUCU.TextFont.Size = 8;
                    SONSKSONUCU.Value = @"";

                    shape111621 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 158, 38, 158, 97, false);
                    shape111621.Name = "shape111621";
                    shape111621.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 27, 171, 32, false);
                    NewField161.Name = "NewField161";
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Name = "Arial Narrow";
                    NewField161.TextFont.Size = 8;
                    NewField161.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 32, 171, 37, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.Value = @":";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 85, 99, 90, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12221.TextFont.Name = "Arial Narrow";
                    NewField12221.TextFont.Size = 8;
                    NewField12221.Value = @"GÖREVİ";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 85, 157, 90, false);
                    GOREV.Name = "GOREV";
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.MultiLine = EvetHayirEnum.ehEvet;
                    GOREV.WordBreak = EvetHayirEnum.ehEvet;
                    GOREV.ObjectDefName = "HCDutyTypeDef";
                    GOREV.DataMember = "NAME";
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 8;
                    GOREV.Value = @"{#ARKASAYFA.GOREV#}";

                    UcakLbl11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 54, 112, 59, false);
                    UcakLbl11.Name = "UcakLbl11";
                    UcakLbl11.TextFont.Name = "Arial Narrow";
                    UcakLbl11.TextFont.Size = 8;
                    UcakLbl11.Value = @"MUAYENE BAŞLANGIÇ TARİHİ :";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 54, 157, 59, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"Short Date";
                    MUAYENETARIHI.TextFont.Name = "Arial Narrow";
                    MUAYENETARIHI.TextFont.Size = 8;
                    MUAYENETARIHI.Value = @"";

                    RaporNoLbl11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 85, 101, 90, false);
                    RaporNoLbl11311.Name = "RaporNoLbl11311";
                    RaporNoLbl11311.TextFont.Name = "Arial Narrow";
                    RaporNoLbl11311.TextFont.Size = 9;
                    RaporNoLbl11311.Value = @":";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 7, 196, 17, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    NewField1322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 73, 33, 78, false);
                    NewField1322.Name = "NewField1322";
                    NewField1322.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1322.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1322.TextFont.Name = "Arial Narrow";
                    NewField1322.TextFont.Size = 8;
                    NewField1322.Value = @"KUVVETİ";

                    NewField111642 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 73, 35, 78, false);
                    NewField111642.Name = "NewField111642";
                    NewField111642.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111642.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111642.TextFont.Name = "Arial Narrow";
                    NewField111642.TextFont.Size = 8;
                    NewField111642.Value = @":";

                    KUVVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 73, 72, 78, false);
                    KUVVET.Name = "KUVVET";
                    KUVVET.FieldType = ReportFieldTypeEnum.ftVariable;
                    KUVVET.MultiLine = EvetHayirEnum.ehEvet;
                    KUVVET.WordBreak = EvetHayirEnum.ehEvet;
                    KUVVET.TextFont.Name = "Arial Narrow";
                    KUVVET.TextFont.Size = 8;
                    KUVVET.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    NewField53.CalcValue = @"";
                    MUAYENESEBEBI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField25.CalcValue = NewField25.Value;
                    AD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    DOGUMTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Boy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kilo) : "");
                    NewField51.CalcValue = NewField51.Value;
                    NewField520.CalcValue = NewField520.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField122.CalcValue = NewField122.Value;
                    SOYAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    NewField123.CalcValue = NewField123.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1163.CalcValue = NewField1163.Value;
                    NewField1164.CalcValue = NewField1164.Value;
                    NewField13611.CalcValue = NewField13611.Value;
                    NewField14611.CalcValue = NewField14611.Value;
                    NewField13612.CalcValue = NewField13612.Value;
                    NewField14612.CalcValue = NewField14612.Value;
                    NewField13613.CalcValue = NewField13613.Value;
                    NewField14613.CalcValue = NewField14613.Value;
                    EMSANSICIL.CalcValue = @"";
                    NewField124.CalcValue = NewField124.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField1222.CalcValue = NewField1222.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField13614.CalcValue = NewField13614.Value;
                    NewField14614.CalcValue = NewField14614.Value;
                    NewField111631.CalcValue = NewField111631.Value;
                    NewField111641.CalcValue = NewField111641.Value;
                    NewField121631.CalcValue = NewField121631.Value;
                    NewField121641.CalcValue = NewField121641.Value;
                    UCAKTIPI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Ucaktipi) : "");
                    UCAKTIPI.PostFieldValueCalculation();
                    SONSKSONUCU.CalcValue = @"";
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    GOREV.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Gorev) : "");
                    GOREV.PostFieldValueCalculation();
                    UcakLbl11.CalcValue = UcakLbl11.Value;
                    MUAYENETARIHI.CalcValue = @"";
                    RaporNoLbl11311.CalcValue = RaporNoLbl11311.Value;
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    NewField1322.CalcValue = NewField1322.Value;
                    NewField111642.CalcValue = NewField111642.Value;
                    KUVVET.CalcValue = @"";
                    HEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCFLIERREPORTCAPTION","");
                    DUZENLEYENMERKEZ.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","");
                    return new TTReportObject[] { NewField53,MUAYENESEBEBI,RAPORTARIHI,NewField22,NewField23,NewField25,AD,BABAADI,BIRLIK,SINIFRUTBE,SICILNO,DOGUMTARIHI,RAPORNO,BOY,KILO,NewField51,NewField520,TCKIMLIKNO,NewField16,NewField12,NewField162,NewField1162,NewField122,SOYAD,NewField123,NewField132,NewField152,NewField1221,NewField1163,NewField1164,NewField13611,NewField14611,NewField13612,NewField14612,NewField13613,NewField14613,EMSANSICIL,NewField124,NewField133,NewField153,NewField1222,NewField1321,NewField11221,NewField13614,NewField14614,NewField111631,NewField111641,NewField121631,NewField121641,UCAKTIPI,SONSKSONUCU,NewField161,NewField1161,NewField12221,GOREV,UcakLbl11,MUAYENETARIHI,RaporNoLbl11311,TCKIMLIKNOBARKOD,NewField1322,NewField111642,KUVVET,HEADER,DUZENLEYENMERKEZ};
                }

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeFlierReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
//            string force = hc.Episode.ForcesCommand != null ? hc.Episode.ForcesCommand.Qref : "";
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
//            RankDefinitions pRank = hc.Episode.Rank;
//            
//            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
//            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
//                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
//            else
//                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//            
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            // Kuvvet
            //this.KUVVET.CalcValue = force;
            
            //Boy-Kilo
            if(hc.ClinicHeight == null)
            {
                if(hc.HCHeight != null)
                    this.BOY.CalcValue = hc.HCHeight.ToString();
            }
            if(hc.ClinicWeight == null)
            {
                if(hc.HCWeight != null)
                    this.KILO.CalcValue = hc.HCWeight.ToString();
            }
            
            foreach( TTObjectState state in hc.GetStateHistory())
            {
                if(state.StateDefID == HealthCommittee.States.CommitteeAcceptance)
                {
                    if (state.BranchDate != null)
                        this.MUAYENETARIHI.CalcValue = state.BranchDate.ToString();
                    break;
                }
            }
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKIMLIKNO.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKIMLIKNO.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ANAGroup ANA;

        public partial class OLCUMGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public OLCUMGroupHeader Header()
            {
                return (OLCUMGroupHeader)_header;
            }

            new public OLCUMGroupFooter Footer()
            {
                return (OLCUMGroupFooter)_footer;
            }

            public TTReportField PATINFO { get {return Header().PATINFO;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape shape16 { get {return Header().shape16;} }
            public TTReportShape shape161 { get {return Header().shape161;} }
            public TTReportShape shape1161 { get {return Header().shape1161;} }
            public TTReportField OLCUMLER { get {return Footer().OLCUMLER;} }
            public TTReportField BOY { get {return Footer().BOY;} }
            public TTReportField KILO { get {return Footer().KILO;} }
            public OLCUMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OLCUMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new OLCUMGroupHeader(this);
                _footer = new OLCUMGroupFooter(this);

            }

            public partial class OLCUMGroupHeader : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField PATINFO;
                public TTReportField DTARIHI;
                public TTReportShape NewLine1;
                public TTReportShape shape16;
                public TTReportShape shape161;
                public TTReportShape shape1161; 
                public OLCUMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 2, 287, 7, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.Visible = EvetHayirEnum.ehHayir;
                    PATINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"{#ARKASAYFA.PNAME#} {#ARKASAYFA.PSURNAME#} ({%DTARIHI%}) {#ARKASAYFA.ISLEMNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 239, 6, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#ARKASAYFA.DTARIHI#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 196, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    shape16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 3, false);
                    shape16.Name = "shape16";
                    shape16.DrawStyle = DrawStyleConstants.vbSolid;
                    shape16.ExtendTo = ExtendToEnum.extPageHeight;

                    shape161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 1, 48, 3, false);
                    shape161.Name = "shape161";
                    shape161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 1, 196, 3, false);
                    shape1161.Name = "shape1161";
                    shape1161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1161.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    PATINFO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "") + @" (" + MyParentReport.OLCUM.DTARIHI.FormattedValue + @") " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    return new TTReportObject[] { DTARIHI,PATINFO};
                }
            }
            public partial class OLCUMGroupFooter : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField OLCUMLER;
                public TTReportField BOY;
                public TTReportField KILO; 
                public OLCUMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    OLCUMLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 3, 195, 8, false);
                    OLCUMLER.Name = "OLCUMLER";
                    OLCUMLER.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUMLER.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUMLER.NoClip = EvetHayirEnum.ehEvet;
                    OLCUMLER.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUMLER.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUMLER.TextFont.Name = "Arial Narrow";
                    OLCUMLER.TextFont.Size = 7;
                    OLCUMLER.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 239, 6, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#ARKASAYFA.HEYETBOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 6, 239, 11, false);
                    KILO.Name = "KILO";
                    KILO.Visible = EvetHayirEnum.ehHayir;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.Value = @"{#ARKASAYFA.HEYETKILO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    OLCUMLER.CalcValue = @"";
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Heyetboy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Heyetkilo) : "");
                    return new TTReportObject[] { OLCUMLER,BOY,KILO};
                }

                public override void RunScript()
                {
#region OLCUM FOOTER_Script
                    if (this.BOY.CalcValue != "" || this.KILO.CalcValue != "")
            {
                string sMeasure = "Sağlık Kurulu Huzurunda Ölçülmüştür:";
                string s1 = "",s2 = "";
                
                if (this.BOY.CalcValue != "") s1="Boy:" + this.BOY.CalcValue + " cm.";
                if (this.KILO.CalcValue != "" ) s2 ="Ağırlık:" + this.KILO.CalcValue + " kg.";

                this.OLCUMLER.CalcValue = sMeasure + "\r\n" + s1 + "\r\n" + s2 + "\r\n";
            }
#endregion OLCUM FOOTER_Script
                }
            }

        }

        public OLCUMGroup OLCUM;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape shape6 { get {return Body().shape6;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportShape shape8 { get {return Body().shape8;} }
            public TTReportShape shape9 { get {return Body().shape9;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField BOLUMRAPORDR { get {return Body().BOLUMRAPORDR;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>("GetHCExaminationByMasterAction", HealthCommitteeExamination.GetHCExaminationByMasterAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape shape6;
                public TTReportField BOLUMRAPOR;
                public TTReportShape shape8;
                public TTReportShape shape9;
                public TTReportField RAPORTARIHI;
                public TTReportField OBJECTID;
                public TTReportField BOLUMRAPORDR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    YENIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 46, 13, false);
                    YENIBOLUM.Name = "YENIBOLUM";
                    YENIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIBOLUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YENIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YENIBOLUM.NoClip = EvetHayirEnum.ehEvet;
                    YENIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YENIBOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YENIBOLUM.TextFont.Name = "Arial Narrow";
                    YENIBOLUM.TextFont.Size = 7;
                    YENIBOLUM.Value = @"{#BOLUM#} ({#RAPORNO#} / {%RAPORTARIHI%}) Raporu";

                    shape6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    shape6.Name = "shape6";
                    shape6.DrawStyle = DrawStyleConstants.vbSolid;
                    shape6.ExtendTo = ExtendToEnum.extPageHeight;

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 195, 7, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 7;
                    BOLUMRAPOR.Value = @"";

                    shape8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 0, 48, 5, false);
                    shape8.Name = "shape8";
                    shape8.DrawStyle = DrawStyleConstants.vbSolid;
                    shape8.ExtendTo = ExtendToEnum.extPageHeight;

                    shape9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 5, false);
                    shape9.Name = "shape9";
                    shape9.DrawStyle = DrawStyleConstants.vbSolid;
                    shape9.ExtendTo = ExtendToEnum.extPageHeight;

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 3, 237, 8, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 3, 307, 8, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    BOLUMRAPORDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 279, 13, false);
                    BOLUMRAPORDR.Name = "BOLUMRAPORDR";
                    BOLUMRAPORDR.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPORDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPORDR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPORDR.TextFont.Size = 7;
                    BOLUMRAPORDR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    RAPORTARIHI.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" (" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @" / " + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @") Raporu";
                    BOLUMRAPOR.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.ObjectID) : "");
                    BOLUMRAPORDR.CalcValue = @"";
                    return new TTReportObject[] { RAPORTARIHI,YENIBOLUM,BOLUMRAPOR,OBJECTID,BOLUMRAPORDR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            HealthCommitteeExamination hcp = (HealthCommitteeExamination)context.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");

            bool unwantedDiagnoseExists = false;
            bool MSAExists = false;
            bool showSection = true;
            
            if (hcp.Report != null)
                showSection = true;
            else
            {
                if (hcp.MatterSliceAnectodes.Count > 0)
                    MSAExists = true;
                
                foreach (DiagnosisGrid dg in hcp.PreDiagnosis)
                {
                    if (dg.DiagnoseCode.Trim() == "Z13.9")
                    {
                        unwantedDiagnoseExists = true;
                        break;
                    }
                }
                
                if (!unwantedDiagnoseExists)
                {
                    foreach (DiagnosisGrid dg in hcp.SecDiagnosis)
                    {
                        if (dg.DiagnoseCode.Trim() == "Z13.9")
                        {
                            unwantedDiagnoseExists = true;
                            break;
                        }
                    }
                }
                
                if (unwantedDiagnoseExists && !MSAExists)
                    showSection = false;
            }
            
            if (showSection == false)
            {
                foreach(BaseAction baseAction in hcp.MasterAction.LinkedActions)
                {
                    if (showSection == false)
                    {
                        if(baseAction is LaboratoryRequest)
                        {
                            LaboratoryRequest lab = baseAction as LaboratoryRequest;
                            
                            foreach(ResourceSpecialityGrid labResourceSpeciality in lab.MasterResource.ResourceSpecialities)
                            {
                                if (hcp.ProcedureSpeciality.ObjectID == labResourceSpeciality.Speciality.ObjectID)
                                {
                                    showSection = true;
                                    break;
                                }
                            }
                        }
                        if(baseAction is Radiology)
                        {
                            Radiology rad = baseAction as Radiology;
                            
                            foreach(ResourceSpecialityGrid radResourceSpeciality in rad.MasterResource.ResourceSpecialities)
                            {
                                if (hcp.ProcedureSpeciality.ObjectID == radResourceSpeciality.Speciality.ObjectID)
                                {
                                    showSection = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            if (showSection)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                
                //Tanı
                if (hcp.PreDiagnosis.Count > 0 || hcp.SecDiagnosis.Count > 0)
                {
                    int nCount = 1;
                    string tani = "";
                    foreach(DiagnosisGrid pGrid in hcp.PreDiagnosis)
                    {
                        if (pGrid.DiagnoseCode.Trim() != "Z13.9")
                        {
                            tani += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                            if (pGrid.FreeDiagnosis != null)
                                tani += " (" + pGrid.FreeDiagnosis + ")";
                            tani += "\r\n";
                            nCount++;
                        }
                    }
                    
                    foreach(DiagnosisGrid pGrid in hcp.SecDiagnosis)
                    {
                        if (pGrid.DiagnoseCode.Trim() != "Z13.9")
                        {
                            tani += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                            if(pGrid.FreeDiagnosis != null)
                                tani += " (" + pGrid.FreeDiagnosis + ")";
                            tani += "\r\n";
                            nCount++;
                        }
                    }
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + tani;
                }
                
                if (hcp.MatterSliceAnectodes.Count > 0)
                {
                    string maddeDilimFikra = "[";
                    foreach(HealthCommitteeExamination_MatterSliceAnectodeGrid msa in hcp.MatterSliceAnectodes)
                    {
                        maddeDilimFikra += msa.Matter + "/" + msa.Slice + "/" + msa.Anectode;
                        maddeDilimFikra += "  ";
                        
                    }
                    maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                    maddeDilimFikra = maddeDilimFikra + "]";
                    
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + maddeDilimFikra + "\r\n";
                }
                
                if (hcp.Report != null)
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + TTObjectClasses.Common.GetTextOfRTFString(hcp.Report.ToString());
                
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue.TrimEnd();
                
                if (hcp.ProcedureDoctor != null)
                {
                    string doctor = "\r\n                      " + hcp.ProcedureDoctor.Name;
                    
                    doctor += ", ";
                    
                    if (hcp.ProcedureDoctor.Title.HasValue)
                        doctor +=  TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcp.ProcedureDoctor.Title.Value);
                    
                    if (hcp.ProcedureDoctor.Rank != null)
                        doctor += hcp.ProcedureDoctor.Rank.ShortName;
                    
                    if (hcp.ProcedureDoctor.EmploymentRecordID != null)
                        doctor += "(" + hcp.ProcedureDoctor.EmploymentRecordID + ")";
                    
                    if (hcp.ProcedureDoctor.GetSpeciality() != null)
                        doctor += ", " + hcp.ProcedureDoctor.GetSpeciality().Name + " Uzmanı";
                    
                    this.BOLUMRAPOR.CalcValue += doctor + " (İMZASI FİŞTEDİR)";
                }
                
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue ;
            }
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeFlierReport MyParentReport
            {
                get { return (HealthCommitteeFlierReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape shape16 { get {return Body().shape16;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportShape shape18 { get {return Body().shape18;} }
            public TTReportShape shape19 { get {return Body().shape19;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class>("GetHCEFOHByMasterAction", HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public HealthCommitteeFlierReport MyParentReport
                {
                    get { return (HealthCommitteeFlierReport)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape shape16;
                public TTReportField BOLUMRAPOR;
                public TTReportShape shape18;
                public TTReportShape shape19;
                public TTReportField OBJECTID;
                public TTReportField REPORTDATE; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    YENIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 46, 13, false);
                    YENIBOLUM.Name = "YENIBOLUM";
                    YENIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIBOLUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YENIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YENIBOLUM.NoClip = EvetHayirEnum.ehEvet;
                    YENIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YENIBOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YENIBOLUM.TextFont.Name = "Arial Narrow";
                    YENIBOLUM.TextFont.Size = 7;
                    YENIBOLUM.Value = @"";

                    shape16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 13, false);
                    shape16.Name = "shape16";
                    shape16.DrawStyle = DrawStyleConstants.vbSolid;
                    shape16.ExtendTo = ExtendToEnum.extPageHeight;

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 195, 13, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 7;
                    BOLUMRAPOR.Value = @"";

                    shape18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 0, 48, 13, false);
                    shape18.Name = "shape18";
                    shape18.DrawStyle = DrawStyleConstants.vbSolid;
                    shape18.ExtendTo = ExtendToEnum.extPageHeight;

                    shape19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 13, false);
                    shape19.Name = "shape19";
                    shape19.DrawStyle = DrawStyleConstants.vbSolid;
                    shape19.ExtendTo = ExtendToEnum.extPageHeight;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 4, 239, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 4, 269, 9, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.Value = @"{#REPORTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class dataset_GetHCEFOHByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class>(0);
                    YENIBOLUM.CalcValue = @"";
                    BOLUMRAPOR.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.ObjectID) : "");
                    REPORTDATE.CalcValue = (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.ReportDate) : "");
                    return new TTReportObject[] { YENIBOLUM,BOLUMRAPOR,OBJECTID,REPORTDATE};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            HealthCommitteeExaminationFromOtherHospitals hcp = (HealthCommitteeExaminationFromOtherHospitals)context.GetObject(new Guid(sObjectID),"HealthCommitteeExaminationFromOtherHospitals");

            bool unwantedDiagnoseExists = false;
            bool MSAExists = false;
            bool showSection = true;
            
            if (hcp.Report != null)
                showSection = true;
            else
            {
                if (hcp.MatterSliceAnectodes.Count > 0)
                    MSAExists = true;
                
                foreach (DiagnosisGrid dg in hcp.PreDiagnosis)
                {
                    if (dg.DiagnoseCode.Trim() == "Z13.9")
                    {
                        unwantedDiagnoseExists = true;
                        break;
                    }
                }
                
                if (!unwantedDiagnoseExists)
                {
                    foreach (DiagnosisGrid dg in hcp.SecDiagnosis)
                    {
                        if (dg.DiagnoseCode.Trim() == "Z13.9")
                        {
                            unwantedDiagnoseExists = true;
                            break;
                        }
                    }
                }
                
                if (unwantedDiagnoseExists && !MSAExists)
                    showSection = false;
            }
            
            /*
            if (showSection == false)
            {
                foreach(BaseAction baseAction in hcp.MasterAction.LinkedActions)
                {
                    if (showSection == false)
                    {
                        if(baseAction is LaboratoryRequest)
                        {
                            LaboratoryRequest lab = baseAction as LaboratoryRequest;
                            
                            foreach(ResourceSpecialityGrid labResourceSpeciality in lab.MasterResource.ResourceSpecialities)
                            {
                                if (hcp.ProcedureSpeciality.ObjectID == labResourceSpeciality.Speciality.ObjectID)
                                {
                                    showSection = true;
                                    break;
                                }
                            }
                        }
                        if(baseAction is Radiology)
                        {
                            Radiology rad = baseAction as Radiology;
                            
                            foreach(ResourceSpecialityGrid radResourceSpeciality in rad.MasterResource.ResourceSpecialities)
                            {
                                if (hcp.ProcedureSpeciality.ObjectID == radResourceSpeciality.Speciality.ObjectID)
                                {
                                    showSection = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
             */
            
            if (showSection)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                
                // XXXXXX, Birim, Rapor No ve Tarihi
                string XXXXXX = string.Empty;
                
                if(hcp.Hospitals != null)
                    XXXXXX += hcp.Hospitals.Name + " ";
                
                if(hcp.ReferableResource != null)
                    XXXXXX += ", " + hcp.ReferableResource.ResourceName;
                else if(hcp.Speciality != null)
                    XXXXXX += ", " + hcp.Speciality.Name;
                
                XXXXXX += " (";
                
                if(!string.IsNullOrEmpty(hcp.ReportNoText))
                    XXXXXX += hcp.ReportNoText;
                
                XXXXXX += " / ";
                
                if(!string.IsNullOrEmpty(this.REPORTDATE.FormattedValue))
                    XXXXXX += this.REPORTDATE.FormattedValue;
                
                XXXXXX += ") Raporu";
                
                this.YENIBOLUM.CalcValue = XXXXXX;
                
                //Tanı
                if (hcp.PreDiagnosis.Count > 0 || hcp.SecDiagnosis.Count > 0)
                {
                    int nCount = 1;
                    string tani = "";
                    foreach(DiagnosisGrid pGrid in hcp.PreDiagnosis)
                    {
                        if (pGrid.DiagnoseCode.Trim() != "Z13.9")
                        {
                            tani += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                            if (pGrid.FreeDiagnosis != null)
                                tani += " (" + pGrid.FreeDiagnosis + ")";
                            tani += "\r\n";
                            nCount++;
                        }
                    }
                    
                    foreach(DiagnosisGrid pGrid in hcp.SecDiagnosis)
                    {
                        if (pGrid.DiagnoseCode.Trim() != "Z13.9")
                        {
                            tani += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                            if(pGrid.FreeDiagnosis != null)
                                tani += " (" + pGrid.FreeDiagnosis + ")";
                            tani += "\r\n";
                            nCount++;
                        }
                    }
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + tani;
                }
                
                if (hcp.MatterSliceAnectodes.Count > 0)
                {
                    string maddeDilimFikra = "[";
                    foreach(HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid msa in hcp.MatterSliceAnectodes)
                    {
                        maddeDilimFikra += msa.Matter + "/" + msa.Slice + "/" + msa.Anectode;
                        maddeDilimFikra += "  ";
                        
                    }
                    maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                    maddeDilimFikra = maddeDilimFikra + "]";
                    
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + maddeDilimFikra + "\r\n";
                }
                
                if (hcp.Report != null)
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + TTObjectClasses.Common.GetTextOfRTFString(hcp.Report.ToString());
                
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue.TrimEnd();
                
                if(!string.IsNullOrEmpty(hcp.DrName))
                {
                    string doctor = "\r\n                      " + hcp.DrName;
                    
                    doctor += ", ";
                    
                    if(!string.IsNullOrEmpty(hcp.DrTitle))
                        doctor += hcp.DrTitle;
                    
                    if(!string.IsNullOrEmpty(hcp.DrEmploymentRecordID))
                        doctor += "(" + hcp.DrEmploymentRecordID + ")";
                    
                    if(hcp.DrSpeciality != null)
                        doctor += ", " + hcp.DrSpeciality.Name + " Uzmanı";
                        
                    this.BOLUMRAPOR.CalcValue += doctor + " (İMZASI FİŞTEDİR)";
                }
                
                this.BOLUMRAPOR.CalcValue += "\r\n";
            }
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeFlierReport()
        {
            PATIENTINFO = new PATIENTINFOGroup(this,"PATIENTINFO");
            ARKASAYFA = new ARKASAYFAGroup(PATIENTINFO,"ARKASAYFA");
            ANA = new ANAGroup(ARKASAYFA,"ANA");
            OLCUM = new OLCUMGroup(ANA,"OLCUM");
            MAIN = new MAINGroup(OLCUM,"MAIN");
            PARTA = new PARTAGroup(OLCUM,"PARTA");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEFLIERREPORT";
            Caption = "Uçucu Muayene Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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
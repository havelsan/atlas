
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
    /// Sağlık Kurulu Raporu (Arkalı-Önlü-A4)
    /// </summary>
    public partial class HealthCommitteeReportBackupET : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class ARKASAYFAGroup : TTReportGroup
        {
            public HealthCommitteeReportBackupET MyParentReport
            {
                get { return (HealthCommitteeReportBackupET)ParentReport; }
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
            public TTReportField PATINFO { get {return Header().PATINFO;} }
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField NewField1;
                public TTReportField MADDEKARAR;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape shape1;
                public TTReportField PATINFO;
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
                    
                    Height = 188;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 17, 195, 51, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 40, 51, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"Tanı";

                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 52, 195, 95, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.TextFont.Name = "Arial Narrow";
                    MADDEKARAR.TextFont.Size = 8;
                    MADDEKARAR.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 51, 40, 96, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"Karar(*)";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 97, 195, 101, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.Value = @"NOT : Raporun imza yerlerine imzadan önce ve imza üstüne makine ile imza sahibinin rütbe, sicil no, ihtisas, adı ve soyadı yazılacaktır.";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 64, 10, 181, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 195, 16, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"{#PNAME#} {#PSURNAME#} ({#DOGUMYERI#} / {%DTARIHI%}) {#ISLEMNO#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 174, 194, 179, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.Value = @"(*) Karar hanesine S.Y. Yönetmeliğinin tanıya uygun madde ve fıkra No.ları yazılması zorunludur.";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 180, 195, 222, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.DrawStyle = DrawStyleConstants.vbSolid;
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial Narrow";
                    BASTABIP.Value = @"";

                    SAGLIKDAIREBASKANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 223, 195, 243, false);
                    SAGLIKDAIREBASKANLIGI.Name = "SAGLIKDAIREBASKANLIGI";
                    SAGLIKDAIREBASKANLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 263, 195, 281, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.Value = @"Ek rapor yazılacak kısım :";

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 64, 195, 183, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;

                    OYBIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 22, 236, 26, false);
                    OYBIRLIGI.Name = "OYBIRLIGI";
                    OYBIRLIGI.Visible = EvetHayirEnum.ehHayir;
                    OYBIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OYBIRLIGI.TextFont.Name = "Arial Narrow";
                    OYBIRLIGI.TextFont.Size = 8;
                    OYBIRLIGI.Value = @"";

                    shape3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 96, 195, 96, false);
                    shape3.Name = "shape3";
                    shape3.DrawStyle = DrawStyleConstants.vbSolid;

                    shape4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 33, 195, 65, false);
                    shape4.Name = "shape4";
                    shape4.DrawStyle = DrawStyleConstants.vbSolid;

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 179, 257, 184, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.TextColor = System.Drawing.Color.Red;
                    UNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 184, 294, 189, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.TextColor = System.Drawing.Color.Red;
                    ADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADI.TextFont.Name = "Arial Narrow";
                    ADI.Value = @"";

                    SICNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 179, 294, 184, false);
                    SICNO.Name = "SICNO";
                    SICNO.Visible = EvetHayirEnum.ehHayir;
                    SICNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICNO.TextColor = System.Drawing.Color.Red;
                    SICNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SICNO.TextFont.Name = "Arial Narrow";
                    SICNO.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 40, 240, 45, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 30, 240, 35, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR/";
                    MADDE.Value = @"";

                    SKRAPORALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 46, 243, 51, false);
                    SKRAPORALTBASLIK.Name = "SKRAPORALTBASLIK";
                    SKRAPORALTBASLIK.Visible = EvetHayirEnum.ehHayir;
                    SKRAPORALTBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKRAPORALTBASLIK.TextFormat = @"NOCR /";
                    SKRAPORALTBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORALTBASLIK"","""")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 51, 240, 56, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                    KARAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 57, 240, 62, false);
                    KARAR1.Name = "KARAR1";
                    KARAR1.Visible = EvetHayirEnum.ehHayir;
                    KARAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR1.TextFormat = @"NOCR";
                    KARAR1.Value = @"";

                    SAGLIKDAIREBASKANLIGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 244, 101, 262, false);
                    SAGLIKDAIREBASKANLIGI1.Name = "SAGLIKDAIREBASKANLIGI1";
                    SAGLIKDAIREBASKANLIGI1.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI1.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI1.Value = @"";

                    SAGLIKDAIREBASKANLIGI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 244, 194, 262, false);
                    SAGLIKDAIREBASKANLIGI2.Name = "SAGLIKDAIREBASKANLIGI2";
                    SAGLIKDAIREBASKANLIGI2.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.NoClip = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKDAIREBASKANLIGI2.TextFont.Name = "Arial Narrow";
                    SAGLIKDAIREBASKANLIGI2.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 190, 10, 265, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 190, 195, 266, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 102, 47, 106, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"SAĞLIK KURULU BAŞKANI";

                    SK_CHAIRMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 106, 52, 122, false);
                    SK_CHAIRMAN.Name = "SK_CHAIRMAN";
                    SK_CHAIRMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_CHAIRMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.TextFont.Name = "Arial Narrow";
                    SK_CHAIRMAN.TextFont.Size = 8;
                    SK_CHAIRMAN.Value = @"";

                    SK_MEMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 106, 97, 122, false);
                    SK_MEMBER1.Name = "SK_MEMBER1";
                    SK_MEMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.TextFont.Name = "Arial Narrow";
                    SK_MEMBER1.TextFont.Size = 8;
                    SK_MEMBER1.Value = @"";

                    SK_MEMBER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 106, 143, 122, false);
                    SK_MEMBER2.Name = "SK_MEMBER2";
                    SK_MEMBER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER2.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.TextFont.Name = "Arial Narrow";
                    SK_MEMBER2.TextFont.Size = 8;
                    SK_MEMBER2.Value = @"";

                    SK_MEMBER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 106, 188, 122, false);
                    SK_MEMBER3.Name = "SK_MEMBER3";
                    SK_MEMBER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER3.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.TextFont.Name = "Arial Narrow";
                    SK_MEMBER3.TextFont.Size = 8;
                    SK_MEMBER3.Value = @"";

                    SK_MEMBER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 123, 52, 139, false);
                    SK_MEMBER4.Name = "SK_MEMBER4";
                    SK_MEMBER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER4.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.TextFont.Name = "Arial Narrow";
                    SK_MEMBER4.TextFont.Size = 8;
                    SK_MEMBER4.Value = @"";

                    SK_MEMBER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 123, 97, 139, false);
                    SK_MEMBER5.Name = "SK_MEMBER5";
                    SK_MEMBER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER5.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.TextFont.Name = "Arial Narrow";
                    SK_MEMBER5.TextFont.Size = 8;
                    SK_MEMBER5.Value = @"";

                    SK_MEMBER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 123, 143, 139, false);
                    SK_MEMBER6.Name = "SK_MEMBER6";
                    SK_MEMBER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER6.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.TextFont.Name = "Arial Narrow";
                    SK_MEMBER6.TextFont.Size = 8;
                    SK_MEMBER6.Value = @"";

                    SK_MEMBER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 123, 188, 139, false);
                    SK_MEMBER7.Name = "SK_MEMBER7";
                    SK_MEMBER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER7.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.TextFont.Name = "Arial Narrow";
                    SK_MEMBER7.TextFont.Size = 8;
                    SK_MEMBER7.Value = @"";

                    SK_MEMBER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 140, 52, 156, false);
                    SK_MEMBER8.Name = "SK_MEMBER8";
                    SK_MEMBER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER8.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.TextFont.Name = "Arial Narrow";
                    SK_MEMBER8.TextFont.Size = 8;
                    SK_MEMBER8.Value = @"";

                    SK_MEMBER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 140, 97, 156, false);
                    SK_MEMBER9.Name = "SK_MEMBER9";
                    SK_MEMBER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER9.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.TextFont.Name = "Arial Narrow";
                    SK_MEMBER9.TextFont.Size = 8;
                    SK_MEMBER9.Value = @"";

                    SK_MEMBER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 140, 143, 156, false);
                    SK_MEMBER10.Name = "SK_MEMBER10";
                    SK_MEMBER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER10.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.TextFont.Name = "Arial Narrow";
                    SK_MEMBER10.TextFont.Size = 8;
                    SK_MEMBER10.Value = @"";

                    SK_MEMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 140, 188, 156, false);
                    SK_MEMBER11.Name = "SK_MEMBER11";
                    SK_MEMBER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.TextFont.Name = "Arial Narrow";
                    SK_MEMBER11.TextFont.Size = 8;
                    SK_MEMBER11.Value = @"";

                    SK_MEMBER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 157, 52, 173, false);
                    SK_MEMBER12.Name = "SK_MEMBER12";
                    SK_MEMBER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER12.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.TextFont.Name = "Arial Narrow";
                    SK_MEMBER12.TextFont.Size = 8;
                    SK_MEMBER12.Value = @"";

                    SK_MEMBER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 157, 97, 173, false);
                    SK_MEMBER13.Name = "SK_MEMBER13";
                    SK_MEMBER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER13.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.TextFont.Name = "Arial Narrow";
                    SK_MEMBER13.TextFont.Size = 8;
                    SK_MEMBER13.Value = @"";

                    SK_MEMBER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 157, 143, 173, false);
                    SK_MEMBER14.Name = "SK_MEMBER14";
                    SK_MEMBER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER14.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.TextFont.Name = "Arial Narrow";
                    SK_MEMBER14.TextFont.Size = 8;
                    SK_MEMBER14.Value = @"";

                    SK_MEMBER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 157, 188, 173, false);
                    SK_MEMBER15.Name = "SK_MEMBER15";
                    SK_MEMBER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER15.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.TextFont.Name = "Arial Narrow";
                    SK_MEMBER15.TextFont.Size = 8;
                    SK_MEMBER15.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 66, 240, 71, false);
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
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    PATINFO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "") + @" (" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "") + @" / " + MyParentReport.ARKASAYFA.DTARIHI.FormattedValue + @") " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
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
                    return new TTReportObject[] { TANI,NewField1,MADDEKARAR,NewField3,NewField4,DTARIHI,PATINFO,NewField13,BASTABIP,SAGLIKDAIREBASKANLIGI,NewField19,OYBIRLIGI,UNVAN,ADI,SICNO,KARAR,MADDE,KARAR1,SAGLIKDAIREBASKANLIGI1,SAGLIKDAIREBASKANLIGI2,NewField2,SK_CHAIRMAN,SK_MEMBER1,SK_MEMBER2,SK_MEMBER3,SK_MEMBER4,SK_MEMBER5,SK_MEMBER6,SK_MEMBER7,SK_MEMBER8,SK_MEMBER9,SK_MEMBER10,SK_MEMBER11,SK_MEMBER12,SK_MEMBER13,SK_MEMBER14,SK_MEMBER15,DECISIONTIME,SKRAPORALTBASLIK};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
//            
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
//            
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
                        chairmanMainSpeciality += member.MemberDoctor.ResourceSpecialities[s];
                    else
                        chairmanSpecialities += member.MemberDoctor.ResourceSpecialities[s] + "\r\n";

                    this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanMilClass + chairmanTitle + chairmanRank + "(" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
                }
                
                public TTReportShape shape131; 
                public ARKASAYFAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
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
            public HealthCommitteeReportBackupET MyParentReport
            {
                get { return (HealthCommitteeReportBackupET)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField FRESOURCE { get {return Header().FRESOURCE;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField MAKSAD { get {return Header().MAKSAD;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField KARANTINANO { get {return Header().KARANTINANO;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField TABURCUTARIHI { get {return Header().TABURCUTARIHI;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField LBLSICIL { get {return Header().LBLSICIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField DTYER { get {return Header().DTYER;} }
            public TTReportField SKBASLIK { get {return Header().SKBASLIK;} }
            public TTReportField EMIRTARIHI { get {return Header().EMIRTARIHI;} }
            public TTReportField NewField40 { get {return Header().NewField40;} }
            public TTReportField EMIRNO { get {return Header().EMIRNO;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField42 { get {return Header().NewField42;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField NewField48 { get {return Header().NewField48;} }
            public TTReportField AGIRLIK { get {return Header().AGIRLIK;} }
            public TTReportField SKNEFESVERME { get {return Header().SKNEFESVERME;} }
            public TTReportField SKNEFESALMA { get {return Header().SKNEFESALMA;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField MUAMELESAYISI { get {return Header().MUAMELESAYISI;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField520 { get {return Header().NewField520;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField ASKSUBE { get {return Header().ASKSUBE;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField KIMLIKNO1 { get {return Header().KIMLIKNO1;} }
            public TTReportField PID { get {return Header().PID;} }
            public TTReportField KIMLIKNO11 { get {return Header().KIMLIKNO11;} }
            public TTReportShape shape161 { get {return Header().shape161;} }
            public TTReportShape shape1161 { get {return Header().shape1161;} }
            public TTReportShape shape1162 { get {return Header().shape1162;} }
            public TTReportField DYERILCE { get {return Header().DYERILCE;} }
            public TTReportField DYERIL { get {return Header().DYERIL;} }
            public TTReportField DYERULKE { get {return Header().DYERULKE;} }
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
                }
                
                public TTReportField FRESOURCE;
                public TTReportField NewField3;
                public TTReportField NewField53;
                public TTReportField NewField21;
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField MAKSAD;
                public TTReportField MAKAM;
                public TTReportField RAPORTARIHI;
                public TTReportField KARANTINANO;
                public TTReportField YATISTARIHI;
                public TTReportField TABURCUTARIHI;
                public TTReportField NewField20;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField25;
                public TTReportField LBLSICIL;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField NewField33;
                public TTReportField ADRES;
                public TTReportField DTYER;
                public TTReportField SKBASLIK;
                public TTReportField EMIRTARIHI;
                public TTReportField NewField40;
                public TTReportField EMIRNO;
                public TTReportField RAPORNO;
                public TTReportField NewField2;
                public TTReportField NewField42;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField BOY;
                public TTReportField NewField48;
                public TTReportField AGIRLIK;
                public TTReportField SKNEFESVERME;
                public TTReportField SKNEFESALMA;
                public TTReportField NewField49;
                public TTReportField NewField24;
                public TTReportField MUAMELESAYISI;
                public TTReportField NewField51;
                public TTReportField NewField520;
                public TTReportField NewField52;
                public TTReportField KIMLIKNO;
                public TTReportField TCNO;
                public TTReportField NewField112;
                public TTReportField DYER;
                public TTReportField NewField1211;
                public TTReportField ASKSUBE;
                public TTReportField ACTIONID;
                public TTReportField KIMLIKNO1;
                public TTReportField PID;
                public TTReportField KIMLIKNO11;
                public TTReportShape shape161;
                public TTReportShape shape1161;
                public TTReportShape shape1162;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 109;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 53, 83, 66, false);
                    FRESOURCE.Name = "FRESOURCE";
                    FRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    FRESOURCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    FRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    FRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    FRESOURCE.TextFont.Name = "Arial Narrow";
                    FRESOURCE.TextFont.Size = 8;
                    FRESOURCE.Value = @"{#ARKASAYFA.FRESOURCE#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 36, 81, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 8;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Muayeneye gönderen makam :";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 16, 196, 66, false);
                    NewField53.Name = "NewField53";
                    NewField53.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField53.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 66, 110, 71, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 8;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"D. Tarihi";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 36, 25, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField0.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 8;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"Muayene Yapan Sağlık Kurulu































































































";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 36, 66, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"XXXXXXde tedavide iken sağlık kuruluna sevk eden servis";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 36, 43, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Karantina Nu";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 36, 86, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Emir Tarihi";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 36, 30, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 8;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"Rapor Numarası";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 91, 110, 101, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 8;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Ne maksatla muayene edildiği";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 36, 48, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 8;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"XXXXXXye Giriş";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 36, 53, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.WordBreak = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 8;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"XXXXXXden Çıkış";

                    MAKSAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 91, 196, 101, false);
                    MAKSAD.Name = "MAKSAD";
                    MAKSAD.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKSAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKSAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAD.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAD.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAD.TextFont.Name = "Arial Narrow";
                    MAKSAD.TextFont.Size = 8;
                    MAKSAD.Value = @"{#ARKASAYFA.SKSEBEBI#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 66, 83, 81, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 30, 83, 38, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#ARKASAYFA.RAPORTARIHI#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 83, 43, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.DrawStyle = DrawStyleConstants.vbSolid;
                    KARANTINANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Name = "Arial Narrow";
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.Value = @"{#ARKASAYFA.KPROKOLNO#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 43, 83, 48, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    YATISTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"Short Date";
                    YATISTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    YATISTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.Size = 8;
                    YATISTARIHI.Value = @"{#ARKASAYFA.HGTARIHI#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 48, 83, 53, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCUTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"Short Date";
                    TABURCUTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.TextFont.Name = "Arial Narrow";
                    TABURCUTARIHI.TextFont.Size = 8;
                    TABURCUTARIHI.Value = @"{#ARKASAYFA.TABURCUTARIHI#}";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 16, 160, 25, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"KÜNYE";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 38, 110, 43, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 8;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Adı Soyadı";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 43, 110, 48, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Size = 8;
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"Baba Adı";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 48, 110, 53, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"Sınıf Rütbe";

                    LBLSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 53, 110, 66, false);
                    LBLSICIL.Name = "LBLSICIL";
                    LBLSICIL.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLSICIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    LBLSICIL.MultiLine = EvetHayirEnum.ehEvet;
                    LBLSICIL.WordBreak = EvetHayirEnum.ehEvet;
                    LBLSICIL.TextFont.Name = "Arial Narrow";
                    LBLSICIL.TextFont.Size = 8;
                    LBLSICIL.TextFont.Bold = true;
                    LBLSICIL.Value = @"Sicil Nu";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 38, 160, 43, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#ARKASAYFA.PNAME#} {#ARKASAYFA.PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 43, 160, 48, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#ARKASAYFA.FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 30, 160, 38, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 48, 160, 53, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 53, 160, 66, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 81, 110, 91, false);
                    NewField33.Name = "NewField33";
                    NewField33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField33.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField33.MultiLine = EvetHayirEnum.ehEvet;
                    NewField33.WordBreak = EvetHayirEnum.ehEvet;
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.TextFont.Size = 8;
                    NewField33.TextFont.Bold = true;
                    NewField33.Value = @"Devamlı Adresi";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 81, 196, 91, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ARKASAYFA.ADRES#}";

                    DTYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 66, 160, 71, false);
                    DTYER.Name = "DTYER";
                    DTYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DTYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYER.TextFormat = @"Short Date";
                    DTYER.MultiLine = EvetHayirEnum.ehEvet;
                    DTYER.WordBreak = EvetHayirEnum.ehEvet;
                    DTYER.TextFont.Name = "Arial Narrow";
                    DTYER.TextFont.Size = 8;
                    DTYER.Value = @"{#ARKASAYFA.DTARIHI#}";

                    SKBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 83, 25, false);
                    SKBASLIK.Name = "SKBASLIK";
                    SKBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SKBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASLIK.TextFont.Name = "Arial Narrow";
                    SKBASLIK.TextFont.Size = 9;
                    SKBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"","""")";

                    EMIRTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 81, 83, 86, false);
                    EMIRTARIHI.Name = "EMIRTARIHI";
                    EMIRTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHI.TextFormat = @"Short Date";
                    EMIRTARIHI.TextFont.Name = "Arial Narrow";
                    EMIRTARIHI.TextFont.Size = 8;
                    EMIRTARIHI.Value = @"{#ARKASAYFA.EVRAKTARIHI#}";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 86, 36, 91, false);
                    NewField40.Name = "NewField40";
                    NewField40.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField40.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 8;
                    NewField40.TextFont.Bold = true;
                    NewField40.Value = @"Emir Şube ve Nu";

                    EMIRNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 86, 83, 91, false);
                    EMIRNO.Name = "EMIRNO";
                    EMIRNO.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRNO.TextFont.Name = "Arial Narrow";
                    EMIRNO.TextFont.Size = 8;
                    EMIRNO.Value = @"{#ARKASAYFA.EVRAKSAYISI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 25, 83, 30, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#ARKASAYFA.RAPORNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 36, 38, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Rapor Tarihi";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 96, 22, 101, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField42.MultiLine = EvetHayirEnum.ehEvet;
                    NewField42.WordBreak = EvetHayirEnum.ehEvet;
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Size = 8;
                    NewField42.TextFont.Bold = true;
                    NewField42.Value = @"Ağırlık";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 96, 66, 101, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.TextFont.Size = 8;
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"Soluk Verme";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 22, 96, false);
                    NewField45.Name = "NewField45";
                    NewField45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField45.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField45.MultiLine = EvetHayirEnum.ehEvet;
                    NewField45.WordBreak = EvetHayirEnum.ehEvet;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 8;
                    NewField45.TextFont.Bold = true;
                    NewField45.Value = @"Boy";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 91, 48, 96, false);
                    BOY.Name = "BOY";
                    BOY.DrawStyle = DrawStyleConstants.vbSolid;
                    BOY.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.MultiLine = EvetHayirEnum.ehEvet;
                    BOY.WordBreak = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#ARKASAYFA.BOY#}";

                    NewField48 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 91, 66, 96, false);
                    NewField48.Name = "NewField48";
                    NewField48.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField48.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField48.MultiLine = EvetHayirEnum.ehEvet;
                    NewField48.WordBreak = EvetHayirEnum.ehEvet;
                    NewField48.TextFont.Name = "Arial Narrow";
                    NewField48.TextFont.Size = 8;
                    NewField48.TextFont.Bold = true;
                    NewField48.Value = @"Soluk Alma";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 96, 48, 101, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    AGIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    AGIRLIK.TextFont.Name = "Arial Narrow";
                    AGIRLIK.TextFont.Size = 8;
                    AGIRLIK.Value = @"{#ARKASAYFA.KILO#}";

                    SKNEFESVERME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 96, 83, 101, false);
                    SKNEFESVERME.Name = "SKNEFESVERME";
                    SKNEFESVERME.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESVERME.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESVERME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESVERME.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.TextFont.Name = "Arial Narrow";
                    SKNEFESVERME.TextFont.Size = 8;
                    SKNEFESVERME.Value = @"";

                    SKNEFESALMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 91, 83, 96, false);
                    SKNEFESALMA.Name = "SKNEFESALMA";
                    SKNEFESALMA.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESALMA.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESALMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESALMA.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.TextFont.Name = "Arial Narrow";
                    SKNEFESALMA.TextFont.Size = 8;
                    SKNEFESALMA.Value = @"";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 66, 196, 81, false);
                    NewField49.Name = "NewField49";
                    NewField49.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField49.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField49.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField49.MultiLine = EvetHayirEnum.ehEvet;
                    NewField49.WordBreak = EvetHayirEnum.ehEvet;
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.TextFont.Size = 8;
                    NewField49.Value = @"Kaçıncı işlemi
(Sağlık fişine göre)";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 30, 110, 38, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 8;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"Birlik";

                    MUAMELESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 76, 194, 80, false);
                    MUAMELESAYISI.Name = "MUAMELESAYISI";
                    MUAMELESAYISI.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAMELESAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAMELESAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUAMELESAYISI.MultiLine = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.WordBreak = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.TextFont.Name = "Arial Narrow";
                    MUAMELESAYISI.TextFont.Size = 8;
                    MUAMELESAYISI.Value = @"{#ARKASAYFA.MUAMELESAYISI#}";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 101, 48, 110, false);
                    NewField51.Name = "NewField51";
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 9;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve  laboratuvarlar";

                    NewField520 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 104, 171, 109, false);
                    NewField520.Name = "NewField520";
                    NewField520.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField520.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField520.TextFont.Name = "Arial Narrow";
                    NewField520.TextFont.Size = 9;
                    NewField520.TextFont.Bold = true;
                    NewField520.Value = @"BULGULAR";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 187, 14, false);
                    NewField52.Name = "NewField52";
                    NewField52.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.TextFont.Size = 14;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"TÜRK SİLAHLI KUVVETLERİ SAĞLIK RAPORU";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 25, 110, 30, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    KIMLIKNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KIMLIKNO.TextFont.Name = "Arial Narrow";
                    KIMLIKNO.TextFont.Size = 8;
                    KIMLIKNO.TextFont.Bold = true;
                    KIMLIKNO.Value = @"T.C. Kimlik Nu";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 25, 160, 30, false);
                    TCNO.Name = "TCNO";
                    TCNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Name = "Arial Narrow";
                    TCNO.TextFont.Size = 8;
                    TCNO.Value = @"{#ARKASAYFA.TCNO#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 71, 110, 76, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 8;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Doğum Yeri";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 71, 160, 76, false);
                    DYER.Name = "DYER";
                    DYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFormat = @"Short Date";
                    DYER.MultiLine = EvetHayirEnum.ehEvet;
                    DYER.WordBreak = EvetHayirEnum.ehEvet;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 8;
                    DYER.Value = @"{#ARKASAYFA.DOGUMYERIILCE#} / {#ARKASAYFA.DOGUMYERI#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 76, 110, 81, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.TextFont.Size = 8;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @"Kayıtlı olduğu As. Ş.";

                    ASKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 76, 160, 81, false);
                    ASKSUBE.Name = "ASKSUBE";
                    ASKSUBE.DrawStyle = DrawStyleConstants.vbSolid;
                    ASKSUBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    ASKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASKSUBE.TextFormat = @"Short Date";
                    ASKSUBE.MultiLine = EvetHayirEnum.ehEvet;
                    ASKSUBE.WordBreak = EvetHayirEnum.ehEvet;
                    ASKSUBE.TextFont.Name = "Arial Narrow";
                    ASKSUBE.TextFont.Size = 8;
                    ASKSUBE.Value = @"";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 16, 195, 21, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACTIONID.ObjectDefName = "HealthCommittee";
                    ACTIONID.DataMember = "ID";
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ARKASAYFA.HEALTHCOMMITTEEOBJECTID#}";

                    KIMLIKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 16, 173, 21, false);
                    KIMLIKNO1.Name = "KIMLIKNO1";
                    KIMLIKNO1.FillStyle = FillStyleConstants.vbFSTransparent;
                    KIMLIKNO1.TextFont.Name = "Arial Narrow";
                    KIMLIKNO1.TextFont.Size = 9;
                    KIMLIKNO1.TextFont.Bold = true;
                    KIMLIKNO1.Value = @"İşlem Nu";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 22, 249, 27, false);
                    PID.Name = "PID";
                    PID.Visible = EvetHayirEnum.ehHayir;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Size = 9;
                    PID.Value = @"{#ARKASAYFA.PID#}";

                    KIMLIKNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 22, 227, 27, false);
                    KIMLIKNO11.Name = "KIMLIKNO11";
                    KIMLIKNO11.Visible = EvetHayirEnum.ehHayir;
                    KIMLIKNO11.TextFont.Name = "Arial Narrow";
                    KIMLIKNO11.TextFont.Size = 9;
                    KIMLIKNO11.TextFont.Bold = true;
                    KIMLIKNO11.Value = @"Hasta Nu";

                    shape161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 101, 10, 110, false);
                    shape161.Name = "shape161";
                    shape161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 101, 48, 110, false);
                    shape1161.Name = "shape1161";
                    shape1161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 101, 196, 110, false);
                    shape1162.Name = "shape1162";
                    shape1162.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1162.ExtendTo = ExtendToEnum.extPageHeight;

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 52, 240, 57, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.TextFormat = @"Short Date";
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#ARKASAYFA.DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 60, 240, 65, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.TextFormat = @"Short Date";
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#ARKASAYFA.DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 44, 240, 49, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.TextFormat = @"Short Date";
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#ARKASAYFA.DOGUMYERIULKE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    FRESOURCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Fresource) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField53.CalcValue = NewField53.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    MAKSAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    MAKAM.CalcValue = @"";
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kprokolno) : "");
                    YATISTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Hgtarihi) : "");
                    TABURCUTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Taburcutarihi) : "");
                    NewField20.CalcValue = NewField20.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField25.CalcValue = NewField25.Value;
                    LBLSICIL.CalcValue = LBLSICIL.Value;
                    NAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    NewField33.CalcValue = NewField33.Value;
                    ADRES.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adres) : "");
                    DTYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    EMIRTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField40.CalcValue = NewField40.Value;
                    EMIRNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "");
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Boy) : "");
                    NewField48.CalcValue = NewField48.Value;
                    AGIRLIK.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kilo) : "");
                    SKNEFESVERME.CalcValue = @"";
                    SKNEFESALMA.CalcValue = @"";
                    NewField49.CalcValue = NewField49.Value;
                    NewField24.CalcValue = NewField24.Value;
                    MUAMELESAYISI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Muamelesayisi) : "");
                    NewField51.CalcValue = NewField51.Value;
                    NewField520.CalcValue = NewField520.Value;
                    NewField52.CalcValue = NewField52.Value;
                    KIMLIKNO.CalcValue = KIMLIKNO.Value;
                    TCNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField112.CalcValue = NewField112.Value;
                    DYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "") + @" / " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    NewField1211.CalcValue = NewField1211.Value;
                    ASKSUBE.CalcValue = @"";
                    ACTIONID.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Healthcommitteeobjectid) : "");
                    ACTIONID.PostFieldValueCalculation();
                    KIMLIKNO1.CalcValue = KIMLIKNO1.Value;
                    PID.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    KIMLIKNO11.CalcValue = KIMLIKNO11.Value;
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriulke) : "");
                    SKBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","");
                    return new TTReportObject[] { FRESOURCE,NewField3,NewField53,NewField21,NewField0,NewField1,NewField4,NewField5,NewField6,NewField7,NewField8,NewField10,MAKSAD,MAKAM,RAPORTARIHI,KARANTINANO,YATISTARIHI,TABURCUTARIHI,NewField20,NewField22,NewField23,NewField25,LBLSICIL,NAME,FATHERNAME,BIRLIK,SINIFRUTBE,SICILNO,NewField33,ADRES,DTYER,EMIRTARIHI,NewField40,EMIRNO,RAPORNO,NewField2,NewField42,NewField44,NewField45,BOY,NewField48,AGIRLIK,SKNEFESVERME,SKNEFESALMA,NewField49,NewField24,MUAMELESAYISI,NewField51,NewField520,NewField52,KIMLIKNO,TCNO,NewField112,DYER,NewField1211,ASKSUBE,ACTIONID,KIMLIKNO1,PID,KIMLIKNO11,DYERILCE,DYERIL,DYERULKE,SKBASLIK};
                }

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //            //MilitaryClassDefinitions pMilClass = hc.Episode.MyMilitaryClass();
            //            //RankDefinitions pRank = hc.Episode.MyRank();
//
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//
            //            if (hc.Episode.MyRelationship() != null)
            //            {
            //                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
            //                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            //            }
            
            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DYER.CalcValue = dogumIlce;
                else
                    this.DYER.CalcValue = dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DYER.CalcValue = dogumIl;
            else
                this.DYER.CalcValue = dogumUlke;
            
            // Karantina No
            if (hc.SubEpisode.InpatientAdmission!= null)
            {
                if (hc.SubEpisode.InpatientAdmission.QuarantineProtocolNo!=null)
                    this.KARANTINANO.CalcValue = hc.Episode.InpatientAdmissions[0].QuarantineProtocolNo.Value.ToString();
            }
            
            //Boy-Kilo
            if(hc.ClinicHeight == null)
            {
                if(hc.HCHeight != null)
                    this.BOY.CalcValue = hc.HCHeight.ToString();
            }
            if(hc.ClinicWeight == null)
            {
                if(hc.HCWeight != null)
                    this.AGIRLIK.CalcValue = hc.HCWeight.ToString();
            }
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
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
            public HealthCommitteeReportBackupET MyParentReport
            {
                get { return (HealthCommitteeReportBackupET)ParentReport; }
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
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
                    
                    Height = 6;
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

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 196, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    shape16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 10, 7, false);
                    shape16.Name = "shape16";
                    shape16.DrawStyle = DrawStyleConstants.vbSolid;
                    shape16.ExtendTo = ExtendToEnum.extPageHeight;

                    shape161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 5, 48, 7, false);
                    shape161.Name = "shape161";
                    shape161.DrawStyle = DrawStyleConstants.vbSolid;
                    shape161.ExtendTo = ExtendToEnum.extPageHeight;

                    shape1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 5, 196, 7, false);
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
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
            public HealthCommitteeReportBackupET MyParentReport
            {
                get { return (HealthCommitteeReportBackupET)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape shape6 { get {return Body().shape6;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField BOLUMRAPOR1 { get {return Body().BOLUMRAPOR1;} }
            public TTReportShape shape8 { get {return Body().shape8;} }
            public TTReportShape shape9 { get {return Body().shape9;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField BOLUMRAPORDR { get {return Body().BOLUMRAPORDR;} }
            public TTReportField BOLUMRAPOR2 { get {return Body().BOLUMRAPOR2;} }
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape shape6;
                public TTReportField BOLUMRAPOR;
                public TTReportField BOLUMRAPOR1;
                public TTReportShape shape8;
                public TTReportShape shape9;
                public TTReportField RAPORTARIHI;
                public TTReportField OBJECTID;
                public TTReportField BOLUMRAPORDR;
                public TTReportField BOLUMRAPOR2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
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
                    YENIBOLUM.Value = @"{#BOLUM#} ({#RAPORNO#} / {%RAPORTARIHI%}) Raporu";

                    shape6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 13, false);
                    shape6.Name = "shape6";
                    shape6.DrawStyle = DrawStyleConstants.vbSolid;
                    shape6.ExtendTo = ExtendToEnum.extPageHeight;

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

                    BOLUMRAPOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 3, 359, 9, false);
                    BOLUMRAPOR1.Name = "BOLUMRAPOR1";
                    BOLUMRAPOR1.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR1.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR1.TextFont.Size = 7;
                    BOLUMRAPOR1.Value = @"                              {#DOKTORADI#}
                              {#DOKTORSINIFI#} {#DOKTORRUTBE#}
                              {#DOKTORUNVAN#}";

                    shape8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 0, 48, 13, false);
                    shape8.Name = "shape8";
                    shape8.DrawStyle = DrawStyleConstants.vbSolid;
                    shape8.ExtendTo = ExtendToEnum.extPageHeight;

                    shape9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 13, false);
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

                    BOLUMRAPOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 364, 3, 412, 9, false);
                    BOLUMRAPOR2.Name = "BOLUMRAPOR2";
                    BOLUMRAPOR2.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR2.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR2.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR2.TextFont.Size = 7;
                    BOLUMRAPOR2.Value = @"                    {#DOKTORADI#}
                    {#DOKTORSINIFI#} {#DOKTORRUTBE#}
                    {#DOKTORUNVAN#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    RAPORTARIHI.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" (" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @" / " + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @") Raporu";
                    BOLUMRAPOR.CalcValue = @"";
                    BOLUMRAPOR1.CalcValue = @"                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    OBJECTID.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.ObjectID) : "");
                    BOLUMRAPORDR.CalcValue = @"";
                    BOLUMRAPOR2.CalcValue = @"                    " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
                    " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
                    " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    return new TTReportObject[] { RAPORTARIHI,YENIBOLUM,BOLUMRAPOR,BOLUMRAPOR1,OBJECTID,BOLUMRAPORDR,BOLUMRAPOR2};
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
                
                //this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + "\r\n\r\n" + this.BOLUMRAPOR2.CalcValue;
                
                if (hcp.ProcedureDoctor != null)
                {
                    string doctor = "                      " + hcp.ProcedureDoctor.Name + "\r\n";
                    
                    //if (hcp.ProcedureDoctor.MilitaryClass != null)
                    //    doctor += hcp.ProcedureDoctor.MilitaryClass.ShortName + " ";
                    
                    doctor += "                      ";
                    
                    if (hcp.ProcedureDoctor.Title.HasValue)
                        doctor +=  TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcp.ProcedureDoctor.Title.Value);
                    
                    if (hcp.ProcedureDoctor.Rank != null)
                        doctor += hcp.ProcedureDoctor.Rank.ShortName;
                    
                    if (hcp.ProcedureDoctor.EmploymentRecordID != null)
                        doctor += "(" + hcp.ProcedureDoctor.EmploymentRecordID + ")";
                    
                    if (hcp.ProcedureDoctor.GetSpeciality() != null)
                        doctor += "\r\n                      " + hcp.ProcedureDoctor.GetSpeciality().Name + " Uzmanı";
                    
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + "\r\n" + doctor;
                }
                
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + "\r\n";
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
            public HealthCommitteeReportBackupET MyParentReport
            {
                get { return (HealthCommitteeReportBackupET)ParentReport; }
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
                public HealthCommitteeReportBackupET MyParentReport
                {
                    get { return (HealthCommitteeReportBackupET)ParentReport; }
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
                    YENIBOLUM.Value = @"{#REFERABLEHOSPITAL#} {#REFERABLERESOURCE#} ({#REPORTNO#} / {%REPORTDATE%}) Raporu";

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
                    REPORTDATE.CalcValue = (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.ReportDate) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.Referablehospital) : "") + @" " + (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.Referableresource) : "") + @" (" + (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.ReportNo) : "") + @" / " + MyParentReport.PARTA.REPORTDATE.FormattedValue + @") Raporu";
                    BOLUMRAPOR.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHCEFOHByMasterAction != null ? Globals.ToStringCore(dataset_GetHCEFOHByMasterAction.ObjectID) : "");
                    return new TTReportObject[] { REPORTDATE,YENIBOLUM,BOLUMRAPOR,OBJECTID};
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
                
                /*
                if (hcp.ProcedureDoctor != null)
                {
                    string doctor = "                      " + hcp.ProcedureDoctor.Name + "\r\n";
                    
                    //if (hcp.ProcedureDoctor.MilitaryClass != null)
                    //    doctor += hcp.ProcedureDoctor.MilitaryClass.ShortName + " ";
                    
                    doctor += "                      ";
                    
                    if (hcp.ProcedureDoctor.Title.HasValue)
                        doctor +=  TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcp.ProcedureDoctor.Title.Value);
                    
                    if (hcp.ProcedureDoctor.Rank != null)
                        doctor += hcp.ProcedureDoctor.Rank.ShortName;
                    
                    if (hcp.ProcedureDoctor.EmploymentRecordID != null)
                        doctor += "(" + hcp.ProcedureDoctor.EmploymentRecordID + ")";
                    
                    if (hcp.ProcedureDoctor.GetSpeciality() != null)
                        doctor += "\r\n                      " + hcp.ProcedureDoctor.GetSpeciality().Name + " Uzmanı";
                    
                    this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + "\r\n" + doctor;
                }
                */
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + "\r\n";
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

        public HealthCommitteeReportBackupET()
        {
            ARKASAYFA = new ARKASAYFAGroup(this,"ARKASAYFA");
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
            Name = "HEALTHCOMMITTEEREPORTBACKUPET";
            Caption = "Sağlık Kurulu Raporu Yedeği";
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
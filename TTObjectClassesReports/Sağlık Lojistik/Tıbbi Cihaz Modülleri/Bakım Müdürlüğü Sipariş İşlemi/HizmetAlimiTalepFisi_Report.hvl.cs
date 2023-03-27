
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
    /// Hizmet Alımı Talep Fişi
    /// </summary>
    public partial class HizmetAlimiTalepFisi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HizmetAlimiTalepFisi MyParentReport
            {
                get { return (HizmetAlimiTalepFisi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField REPORTNAME1 { get {return Body().REPORTNAME1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField REGISTERNO { get {return Body().REGISTERNO;} }
            public TTReportField RESPONSIBLESECTION { get {return Body().RESPONSIBLESECTION;} }
            public TTReportField SENDINGDATE { get {return Body().SENDINGDATE;} }
            public TTReportField DEMANDDATE { get {return Body().DEMANDDATE;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField MARKANDMODEL { get {return Body().MARKANDMODEL;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportRTF DESCRIPTIONRTF { get {return Body().DESCRIPTIONRTF;} }
            public TTReportRTF DETAILRTF { get {return Body().DETAILRTF;} }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField NewField111411 { get {return Body().NewField111411;} }
            public TTReportField NewField111421 { get {return Body().NewField111421;} }
            public TTReportField NewField1124111 { get {return Body().NewField1124111;} }
            public TTReportField NewField111431 { get {return Body().NewField111431;} }
            public TTReportField NewField111441 { get {return Body().NewField111441;} }
            public TTReportField TECHNICIAN { get {return Body().TECHNICIAN;} }
            public TTReportField SECTIONCHIEF { get {return Body().SECTIONCHIEF;} }
            public TTReportField REPAIRCHIEF { get {return Body().REPAIRCHIEF;} }
            public TTReportField MAINTENANCEORDER { get {return Body().MAINTENANCEORDER;} }
            public TTReportField ACCOUNTANT { get {return Body().ACCOUNTANT;} }
            public TTReportField PLANCOORDINATION { get {return Body().PLANCOORDINATION;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField NewField1132 { get {return Body().NewField1132;} }
            public TTReportField SENDINGDATE1 { get {return Body().SENDINGDATE1;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HizmetAlimiTalepFisi MyParentReport
                {
                    get { return (HizmetAlimiTalepFisi)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField1;
                public TTReportField REPORTNAME1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField ORDERNO;
                public TTReportField REGISTERNO;
                public TTReportField RESPONSIBLESECTION;
                public TTReportField SENDINGDATE;
                public TTReportField DEMANDDATE;
                public TTReportField MATERIALNAME;
                public TTReportField SERIALNO;
                public TTReportField MARKANDMODEL;
                public TTReportField MILITARYUNIT;
                public TTReportRTF DESCRIPTIONRTF;
                public TTReportRTF DETAILRTF;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField111421;
                public TTReportField NewField1124111;
                public TTReportField NewField111431;
                public TTReportField NewField111441;
                public TTReportField TECHNICIAN;
                public TTReportField SECTIONCHIEF;
                public TTReportField REPAIRCHIEF;
                public TTReportField MAINTENANCEORDER;
                public TTReportField ACCOUNTANT;
                public TTReportField PLANCOORDINATION;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine14;
                public TTReportShape NewLine13;
                public TTReportField NewField1132;
                public TTReportField SENDINGDATE1;
                public TTReportShape NewLine111;
                public TTReportShape NewLine2;
                public TTReportShape NewLine15;
                public TTReportShape NewLine131;
                public TTReportShape NewLine3;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 122, 285, 127, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" 2. PİYASADA YAPTIRILMASI TALEP EDİLEN İŞİN ÖZETİ :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 77, 285, 82, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" 1. TESPİT EDİLEN ARIZA :";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 285, 21, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"HİZMET ALIMI TALEP FİŞİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 23, 77, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" SİPARİŞ NU.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 32, 77, 41, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @" SAYMANLIK KAYIT NU.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 59, 77, 68, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @" ONARIMDAN SORUMLU KISIM";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 41, 77, 50, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @" PLAN KOORDİNASYON KISMI
 TESLİM TARİHİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 68, 77, 77, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @" HİZMET ALIMI TALEP TARİHİ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 23, 212, 32, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @" AİT OLDUĞU ANA MALZEME";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 32, 212, 41, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @" ANA MALZ. SERİ NU. (VARSA)";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 41, 212, 59, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @" MARKA VE MODELİ";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 59, 212, 77, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @" BİRLİĞİ";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 23, 150, 32, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"";

                    REGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 32, 150, 41, false);
                    REGISTERNO.Name = "REGISTERNO";
                    REGISTERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTERNO.TextFont.Name = "Arial";
                    REGISTERNO.TextFont.CharSet = 162;
                    REGISTERNO.Value = @"";

                    RESPONSIBLESECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 59, 150, 68, false);
                    RESPONSIBLESECTION.Name = "RESPONSIBLESECTION";
                    RESPONSIBLESECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLESECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLESECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLESECTION.TextFont.Name = "Arial";
                    RESPONSIBLESECTION.TextFont.CharSet = 162;
                    RESPONSIBLESECTION.Value = @"";

                    SENDINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 41, 150, 50, false);
                    SENDINGDATE.Name = "SENDINGDATE";
                    SENDINGDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDINGDATE.TextFormat = @"dd/MM/yyyy";
                    SENDINGDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDINGDATE.TextFont.Name = "Arial";
                    SENDINGDATE.TextFont.CharSet = 162;
                    SENDINGDATE.Value = @"";

                    DEMANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 68, 150, 77, false);
                    DEMANDDATE.Name = "DEMANDDATE";
                    DEMANDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DEMANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDDATE.TextFormat = @"dd/MM/yyyy";
                    DEMANDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEMANDDATE.TextFont.Name = "Arial";
                    DEMANDDATE.TextFont.CharSet = 162;
                    DEMANDDATE.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 23, 285, 32, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 32, 285, 41, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @"";

                    MARKANDMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 41, 285, 59, false);
                    MARKANDMODEL.Name = "MARKANDMODEL";
                    MARKANDMODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKANDMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKANDMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKANDMODEL.MultiLine = EvetHayirEnum.ehEvet;
                    MARKANDMODEL.WordBreak = EvetHayirEnum.ehEvet;
                    MARKANDMODEL.TextFont.Name = "Arial";
                    MARKANDMODEL.TextFont.CharSet = 162;
                    MARKANDMODEL.Value = @"";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 59, 285, 77, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"";

                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 16, 82, 284, 122, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.CanExpand = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.CanShrink = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.CanSplit = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.Value = @"";

                    DETAILRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 16, 127, 284, 167, false);
                    DETAILRTF.Name = "DETAILRTF";
                    DETAILRTF.CanExpand = EvetHayirEnum.ehHayir;
                    DETAILRTF.CanShrink = EvetHayirEnum.ehHayir;
                    DETAILRTF.CanSplit = EvetHayirEnum.ehHayir;
                    DETAILRTF.Value = @"";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 167, 60, 176, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"MUAYENE EDEN
TEKNİSYEN";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 167, 105, 176, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"KISIM AMİRİ";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 167, 150, 176, false);
                    NewField111421.Name = "NewField111421";
                    NewField111421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111421.TextFont.Name = "Arial";
                    NewField111421.TextFont.Bold = true;
                    NewField111421.TextFont.CharSet = 162;
                    NewField111421.Value = @"BÖLÜM AMİRİ";

                    NewField1124111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 167, 195, 176, false);
                    NewField1124111.Name = "NewField1124111";
                    NewField1124111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1124111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1124111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1124111.TextFont.Name = "Arial";
                    NewField1124111.TextFont.Bold = true;
                    NewField1124111.TextFont.CharSet = 162;
                    NewField1124111.Value = @"TEKNİK MÜDÜR";

                    NewField111431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 167, 240, 176, false);
                    NewField111431.Name = "NewField111431";
                    NewField111431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111431.TextFont.Name = "Arial";
                    NewField111431.TextFont.Bold = true;
                    NewField111431.TextFont.CharSet = 162;
                    NewField111431.Value = @"SAYMAN";

                    NewField111441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 167, 285, 176, false);
                    NewField111441.Name = "NewField111441";
                    NewField111441.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111441.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111441.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111441.TextFont.Name = "Arial";
                    NewField111441.TextFont.Bold = true;
                    NewField111441.TextFont.CharSet = 162;
                    NewField111441.Value = @"ATÖLYE İKMAL KS.A.";

                    TECHNICIAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 190, 60, 200, false);
                    TECHNICIAN.Name = "TECHNICIAN";
                    TECHNICIAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TECHNICIAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TECHNICIAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TECHNICIAN.MultiLine = EvetHayirEnum.ehEvet;
                    TECHNICIAN.TextFont.Name = "Arial";
                    TECHNICIAN.TextFont.CharSet = 162;
                    TECHNICIAN.Value = @"";

                    SECTIONCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 190, 105, 200, false);
                    SECTIONCHIEF.Name = "SECTIONCHIEF";
                    SECTIONCHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTIONCHIEF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECTIONCHIEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECTIONCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    SECTIONCHIEF.TextFont.Name = "Arial";
                    SECTIONCHIEF.TextFont.CharSet = 162;
                    SECTIONCHIEF.Value = @"";

                    REPAIRCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 190, 150, 200, false);
                    REPAIRCHIEF.Name = "REPAIRCHIEF";
                    REPAIRCHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRCHIEF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPAIRCHIEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIRCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    REPAIRCHIEF.TextFont.Name = "Arial";
                    REPAIRCHIEF.TextFont.CharSet = 162;
                    REPAIRCHIEF.Value = @"";

                    MAINTENANCEORDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 190, 195, 200, false);
                    MAINTENANCEORDER.Name = "MAINTENANCEORDER";
                    MAINTENANCEORDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINTENANCEORDER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAINTENANCEORDER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINTENANCEORDER.MultiLine = EvetHayirEnum.ehEvet;
                    MAINTENANCEORDER.TextFont.Name = "Arial";
                    MAINTENANCEORDER.TextFont.CharSet = 162;
                    MAINTENANCEORDER.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 190, 240, 200, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.Name = "Arial";
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"";

                    PLANCOORDINATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 190, 285, 200, false);
                    PLANCOORDINATION.Name = "PLANCOORDINATION";
                    PLANCOORDINATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    PLANCOORDINATION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PLANCOORDINATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PLANCOORDINATION.MultiLine = EvetHayirEnum.ehEvet;
                    PLANCOORDINATION.TextFont.Name = "Arial";
                    PLANCOORDINATION.TextFont.CharSet = 162;
                    PLANCOORDINATION.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 23, 285, 23, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 77, 285, 77, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 122, 285, 122, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 176, 285, 176, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 2;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 167, 285, 167, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 50, 77, 59, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.Bold = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @" PLAN KOORDİNASYON KISMI
 İKMAL KAYIT KÜTÜK NU.";

                    SENDINGDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 50, 150, 59, false);
                    SENDINGDATE1.Name = "SENDINGDATE1";
                    SENDINGDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDINGDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDINGDATE1.TextFont.Name = "Arial";
                    SENDINGDATE1.TextFont.CharSet = 162;
                    SENDINGDATE1.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 68, 150, 68, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 23, 15, 200, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 285, 23, 285, 200, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.DrawWidth = 2;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 200, 285, 200, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131.DrawWidth = 2;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 167, 60, 200, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.DrawWidth = 2;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, 167, 105, 200, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.DrawWidth = 2;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 150, 167, 150, 200, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.DrawWidth = 2;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 167, 195, 200, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.DrawWidth = 2;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 240, 167, 240, 200, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.DrawWidth = 2;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 150, 23, 150, 77, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    NewField1.CalcValue = NewField1.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    ORDERNO.CalcValue = @"";
                    REGISTERNO.CalcValue = @"";
                    RESPONSIBLESECTION.CalcValue = @"";
                    SENDINGDATE.CalcValue = SENDINGDATE.Value;
                    DEMANDDATE.CalcValue = @"";
                    MATERIALNAME.CalcValue = @"";
                    SERIALNO.CalcValue = @"";
                    MARKANDMODEL.CalcValue = @"";
                    MILITARYUNIT.CalcValue = @"";
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    DETAILRTF.CalcValue = DETAILRTF.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    NewField1124111.CalcValue = NewField1124111.Value;
                    NewField111431.CalcValue = NewField111431.Value;
                    NewField111441.CalcValue = NewField111441.Value;
                    TECHNICIAN.CalcValue = @"";
                    SECTIONCHIEF.CalcValue = @"";
                    REPAIRCHIEF.CalcValue = @"";
                    MAINTENANCEORDER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    PLANCOORDINATION.CalcValue = @"";
                    NewField1132.CalcValue = NewField1132.Value;
                    SENDINGDATE1.CalcValue = SENDINGDATE1.Value;
                    return new TTReportObject[] { NewField12,NewField1,REPORTNAME1,NewField11,NewField111,NewField121,NewField131,NewField141,NewField151,NewField1111,NewField1121,NewField1131,ORDERNO,REGISTERNO,RESPONSIBLESECTION,SENDINGDATE,DEMANDDATE,MATERIALNAME,SERIALNO,MARKANDMODEL,MILITARYUNIT,DESCRIPTIONRTF,DETAILRTF,NewField11411,NewField111411,NewField111421,NewField1124111,NewField111431,NewField111441,TECHNICIAN,SECTIONCHIEF,REPAIRCHIEF,MAINTENANCEORDER,ACCOUNTANT,PLANCOORDINATION,NewField1132,SENDINGDATE1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((HizmetAlimiTalepFisi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            ORDERNO.CalcValue =  " " + mo.RequestNo + " - " + mo.OrderNO;
            RESPONSIBLESECTION.CalcValue = " " + mo.WorkShop.Name;
            MATERIALNAME.CalcValue = " " + mo.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
            
            if(mo.Description != null)
                DESCRIPTIONRTF.Value = mo.Description;
            if(mo.DetailDescription != null)
                DETAILRTF.Value = mo.DetailDescription;
            
            if(mo.FixedAssetMaterialDefinition.SerialNumber != "")
                SERIALNO.CalcValue = " " + mo.FixedAssetMaterialDefinition.SerialNumber;
            else
                SERIALNO.CalcValue = " ---";
            
            MARKANDMODEL.CalcValue = " " + mo.FixedAssetMaterialDefinition.Mark + " / " + mo.FixedAssetMaterialDefinition.Model;
            //if(mo.Demand != null)
            DEMANDDATE.CalcValue = " " + DateTime.Now.ToString();
            MILITARYUNIT.CalcValue = " " + mo.SenderAccountancy.Name + "\n " + mo.SenderAccountancy.Address;
            
            foreach(CMRActionSignDetail signDetail in mo.ServiceProcurementSignDetails)
            {
                if(signDetail.SignUserType == SignUserTypeEnum.Teknisyen)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    TECHNICIAN.CalcValue = userSing ;
                }
                
                if(signDetail.SignUserType == SignUserTypeEnum.KısımAmiri)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    SECTIONCHIEF.CalcValue = userSing ;
                }
                
                if(signDetail.SignUserType == SignUserTypeEnum.BölümAmiri)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    REPAIRCHIEF.CalcValue = userSing ;
                }
                
                if(signDetail.SignUserType == SignUserTypeEnum.TeknikMudur)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    MAINTENANCEORDER.CalcValue = userSing ;
                }
                
                if(signDetail.SignUserType == SignUserTypeEnum.MalSaymani)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    ACCOUNTANT.CalcValue = userSing ;
                }
                
                if(signDetail.SignUserType == SignUserTypeEnum.AtolyeIkmalKisimAmiri)
                {
                    string userSing = string.Empty;
                    if(signDetail.SignUser!= null)
                    {
                        userSing = signDetail.SignUser.Name ;
                        if(signDetail.SignUser.Rank != null)
                            userSing = userSing + "\n" + signDetail.SignUser.Rank.Name;
                    }
                    PLANCOORDINATION.CalcValue = userSing ;
                }
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

        public HizmetAlimiTalepFisi()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HIZMETALIMITALEPFISI";
            Caption = "Hizmet Alımı Talep Fişi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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
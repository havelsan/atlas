
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
    /// Günübirlik K-Çizelgesi
    /// </summary>
    public partial class KScheduleDailyReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAMEHEADER { get {return Header().HOSPITALNAMEHEADER;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField DESTINATIONSTORE { get {return Header().DESTINATIONSTORE;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField STARTDATE1 { get {return Header().STARTDATE1;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1132 { get {return Footer().NewField1132;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public TTReportField NewField11312 { get {return Footer().NewField11312;} }
            public TTReportField NewField111311 { get {return Footer().NewField111311;} }
            public TTReportField NewField111321 { get {return Footer().NewField111321;} }
            public TTReportField NewField111331 { get {return Footer().NewField111331;} }
            public TTReportField NewField1133111 { get {return Footer().NewField1133111;} }
            public TTReportField NewField1133121 { get {return Footer().NewField1133121;} }
            public TTReportField REQUEST1 { get {return Footer().REQUEST1;} }
            public TTReportField REQUESTDATE1 { get {return Footer().REQUESTDATE1;} }
            public TTReportField REQUESTNO1 { get {return Footer().REQUESTNO1;} }
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
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField HOSPITALNAMEHEADER;
                public TTReportField NewField1131;
                public TTReportField DESTINATIONSTORE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField STARTDATE1;
                public TTReportField NewField11311; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAMEHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 199, 29, false);
                    HOSPITALNAMEHEADER.Name = "HOSPITALNAMEHEADER";
                    HOSPITALNAMEHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAMEHEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.TextFont.Name = "Arial";
                    HOSPITALNAMEHEADER.TextFont.Size = 12;
                    HOSPITALNAMEHEADER.TextFont.Bold = true;
                    HOSPITALNAMEHEADER.TextFont.CharSet = 162;
                    HOSPITALNAMEHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 31, 199, 37, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 11;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"GÜNÜBİRLİK İLAÇ TEVHİD ÇİZELGESİ";

                    DESTINATIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 44, 199, 49, false);
                    DESTINATIONSTORE.Name = "DESTINATIONSTORE";
                    DESTINATIONSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTORE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESTINATIONSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESTINATIONSTORE.TextFont.Name = "Arial";
                    DESTINATIONSTORE.TextFont.CharSet = 162;
                    DESTINATIONSTORE.Value = @"";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 50, 109, 55, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 50, 199, 55, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"";

                    STARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 50, 111, 55, false);
                    STARTDATE1.Name = "STARTDATE1";
                    STARTDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE1.TextFont.Name = "Arial";
                    STARTDATE1.TextFont.CharSet = 162;
                    STARTDATE1.Value = @"-";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 37, 199, 43, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 11;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"K-ÇİZELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1131.CalcValue = NewField1131.Value;
                    DESTINATIONSTORE.CalcValue = @"";
                    STARTDATE.CalcValue = @"";
                    ENDDATE.CalcValue = @"";
                    STARTDATE1.CalcValue = STARTDATE1.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    HOSPITALNAMEHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1131,DESTINATIONSTORE,STARTDATE,ENDDATE,STARTDATE1,NewField11311,HOSPITALNAMEHEADER};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = ((KScheduleDailyReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            KScheduleDaily kScheduleDaily = (KScheduleDaily)ctx.GetObject(new Guid(objectID), typeof(KScheduleDaily));
            
            if (kScheduleDaily != null)
            {
                DESTINATIONSTORE.CalcValue = kScheduleDaily.DestinationStore.Name;
                
                if ( kScheduleDaily.StartDate.HasValue )
                    STARTDATE.CalcValue = kScheduleDaily.StartDate.Value.ToString("dd.MM.yyyy");
                
                if ( kScheduleDaily.EndDate.HasValue )
                    ENDDATE.CalcValue = kScheduleDaily.EndDate.Value.ToString("dd.MM.yyyy");
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField PAGENUMBER;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField1132;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportField NewField11312;
                public TTReportField NewField111311;
                public TTReportField NewField111321;
                public TTReportField NewField111331;
                public TTReportField NewField1133111;
                public TTReportField NewField1133121;
                public TTReportField REQUEST1;
                public TTReportField REQUESTDATE1;
                public TTReportField REQUESTNO1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 85;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 14, 230, 19, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.Visible = EvetHayirEnum.ehHayir;
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa : {@pagenumber@}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 26, 200, 56, false);
                    NewField111.Name = "NewField111";
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"  1. Bu çizelge kopyalı iki nüsha olarak tanzim edilir.
  2. Tabibin hasta tabelalarına, yazdığı ilaçlar karantina numaralarına göre bu çizelgeye servis hemşiresi tarafından servis şefi nezaretinde yazılır ve eczaneye gönderilir.
  3. Eczanede toplu olarak hazırlanan bu çizelge muhteviyatları servis hemşireleri tarafından imza mukabili tam ve sağlam olarak alınır.
  4. K-Çizelgesi hazırlanmadan eczaneden hiç bir suretle ilaç verilmez.
  5. K-Çizelgesi ile birlikte hasta tabelaları da eczaneye getirilecektir.                  ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 21, 49, 26, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"AÇIKLAMALAR :";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 60, 10, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Servis Sorumlu
Hemşire";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 200, 10, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"Servis Şefi";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 61, 60, 70, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"TESLİM ALAN
Sorumlu Hemşire";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 61, 200, 70, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"TESLİM EDEN
Eczane Şefi";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 65, 60, 65, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 65, 200, 65, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 61, 93, 66, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11312.TextFont.Name = "Arial";
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"İstek Yapan";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 66, 93, 71, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111311.TextFont.Name = "Arial";
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"İstek Tarihi";

                    NewField111321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 71, 93, 76, false);
                    NewField111321.Name = "NewField111321";
                    NewField111321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111321.TextFont.Name = "Arial";
                    NewField111321.TextFont.CharSet = 162;
                    NewField111321.Value = @"İstek Nu.";

                    NewField111331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 61, 94, 66, false);
                    NewField111331.Name = "NewField111331";
                    NewField111331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111331.TextFont.Name = "Arial";
                    NewField111331.TextFont.CharSet = 162;
                    NewField111331.Value = @":";

                    NewField1133111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 66, 94, 71, false);
                    NewField1133111.Name = "NewField1133111";
                    NewField1133111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1133111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1133111.TextFont.Name = "Arial";
                    NewField1133111.TextFont.CharSet = 162;
                    NewField1133111.Value = @":";

                    NewField1133121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 71, 94, 76, false);
                    NewField1133121.Name = "NewField1133121";
                    NewField1133121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1133121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1133121.TextFont.Name = "Arial";
                    NewField1133121.TextFont.CharSet = 162;
                    NewField1133121.Value = @":";

                    REQUEST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 61, 146, 66, false);
                    REQUEST1.Name = "REQUEST1";
                    REQUEST1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUEST1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUEST1.TextFont.Name = "Arial";
                    REQUEST1.TextFont.CharSet = 162;
                    REQUEST1.Value = @"";

                    REQUESTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 66, 146, 71, false);
                    REQUESTDATE1.Name = "REQUESTDATE1";
                    REQUESTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE1.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE1.TextFont.Name = "Arial";
                    REQUESTDATE1.TextFont.CharSet = 162;
                    REQUESTDATE1.Value = @"";

                    REQUESTNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 71, 146, 76, false);
                    REQUESTNO1.Name = "REQUESTNO1";
                    REQUESTNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO1.TextFont.Name = "Arial";
                    REQUESTNO1.TextFont.CharSet = 162;
                    REQUESTNO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"Sayfa : " + ParentReport.CurrentPageNumber.ToString();
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField111321.CalcValue = NewField111321.Value;
                    NewField111331.CalcValue = NewField111331.Value;
                    NewField1133111.CalcValue = NewField1133111.Value;
                    NewField1133121.CalcValue = NewField1133121.Value;
                    REQUEST1.CalcValue = @"";
                    REQUESTDATE1.CalcValue = @"";
                    REQUESTNO1.CalcValue = @"";
                    return new TTReportObject[] { PAGENUMBER,NewField111,NewField121,NewField131,NewField1132,NewField1141,NewField11411,NewField11312,NewField111311,NewField111321,NewField111331,NewField1133111,NewField1133121,REQUEST1,REQUESTDATE1,REQUESTNO1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string objectID = ((KScheduleDailyReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            KScheduleDaily kScheduleDaily = (KScheduleDaily)ctx.GetObject(new Guid(objectID), typeof(KScheduleDaily));
            ResUser user;
            if (kScheduleDaily != null)
            {
                user = (ResUser)kScheduleDaily.GetState("New", true).User.UserObject;
                if (user != null)
                    REQUEST1.CalcValue = user.Name.ToString();
                
                if ( kScheduleDaily.TransactionDate.HasValue )
                    REQUESTDATE1.CalcValue = kScheduleDaily.TransactionDate.Value.ToString("dd.MM.yyyy");
                
                if ( kScheduleDaily.StockActionID.Value.HasValue )
                    REQUESTNO1.CalcValue = kScheduleDaily.StockActionID.Value.Value.ToString();
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCHEADERGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public PARTCHEADERGroupHeader Header()
            {
                return (PARTCHEADERGroupHeader)_header;
            }

            new public PARTCHEADERGroupFooter Footer()
            {
                return (PARTCHEADERGroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public PARTCHEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCHEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCHEADERGroupHeader(this);
                _footer = new PARTCHEADERGroupFooter(this);

            }

            public partial class PARTCHEADERGroupHeader : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField111;
                public TTReportField NewField11111;
                public TTReportField NewField1121;
                public TTReportShape NewLine11;
                public TTReportField NewField1111; 
                public PARTCHEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 7, 69, 12, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Hasta Adı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 31, 12, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"S. Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 7, 183, 12, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Malzeme";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 7, 200, 12, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Adedi ";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 12, 200, 12, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 199, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İSTENEN İLAÇLAR (HASTA BAZINDA)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { NewField111111,NewField111,NewField11111,NewField1121,NewField1111};
                }
            }
            public partial class PARTCHEADERGroupFooter : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                 
                public PARTCHEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCHEADERGroup PARTCHEADER;

        public partial class PARTCGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField ORDERNO1 { get {return Body().ORDERNO1;} }
            public TTReportField MATERIALNAME1 { get {return Body().MATERIALNAME1;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public TTReportField PATIENTNAME1 { get {return Body().PATIENTNAME1;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<KScheduleDaily.GetKScheduleDailyReportQuery_Class>("GetKScheduleDailyReportQuery", KScheduleDaily.GetKScheduleDailyReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField ORDERNO1;
                public TTReportField MATERIALNAME1;
                public TTReportField AMOUNT1;
                public TTReportField PATIENTNAME1; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 31, 6, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO1.TextFont.Name = "Arial";
                    ORDERNO1.TextFont.CharSet = 162;
                    ORDERNO1.Value = @"{@counter@}";

                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 1, 183, 6, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME1.TextFont.Name = "Arial";
                    MATERIALNAME1.TextFont.CharSet = 162;
                    MATERIALNAME1.Value = @" {#MATERIAL#}";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 1, 200, 6, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"{#AMOUNT#} ";

                    PATIENTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 69, 6, false);
                    PATIENTNAME1.Name = "PATIENTNAME1";
                    PATIENTNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTNAME1.TextFont.Name = "Arial";
                    PATIENTNAME1.TextFont.CharSet = 162;
                    PATIENTNAME1.Value = @"{#PATIENTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KScheduleDaily.GetKScheduleDailyReportQuery_Class dataset_GetKScheduleDailyReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KScheduleDaily.GetKScheduleDailyReportQuery_Class>(0);
                    ORDERNO1.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME1.CalcValue = @" " + (dataset_GetKScheduleDailyReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDailyReportQuery.Material) : "");
                    AMOUNT1.CalcValue = (dataset_GetKScheduleDailyReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDailyReportQuery.Amount) : "") + @" ";
                    PATIENTNAME1.CalcValue = (dataset_GetKScheduleDailyReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDailyReportQuery.PatientName) : "");
                    return new TTReportObject[] { ORDERNO1,MATERIALNAME1,AMOUNT1,PATIENTNAME1};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDHEADERGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public PARTDHEADERGroupHeader Header()
            {
                return (PARTDHEADERGroupHeader)_header;
            }

            new public PARTDHEADERGroupFooter Footer()
            {
                return (PARTDHEADERGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public PARTDHEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDHEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDHEADERGroupHeader(this);
                _footer = new PARTDHEADERGroupFooter(this);

            }

            public partial class PARTDHEADERGroupHeader : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField111111;
                public TTReportField NewField11211;
                public TTReportShape NewLine111;
                public TTReportField NewField11111; 
                public PARTDHEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 31, 11, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"S. Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 6, 184, 11, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Malzeme";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 6, 201, 11, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Adedi ";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 11, 201, 11, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 199, 5, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İSTENEN İLAÇLAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    return new TTReportObject[] { NewField1111,NewField111111,NewField11211,NewField11111};
                }
            }
            public partial class PARTDHEADERGroupFooter : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                 
                public PARTDHEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDHEADERGroup PARTDHEADER;

        public partial class PARTDGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField ORDERNO11 { get {return Body().ORDERNO11;} }
            public TTReportField MATERIALNAME11 { get {return Body().MATERIALNAME11;} }
            public TTReportField AMOUNT11 { get {return Body().AMOUNT11;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class>("GetKScheduleDailyDrugReportQuery", KScheduleDaily.GetKScheduleDailyDrugReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                
                public TTReportField ORDERNO11;
                public TTReportField MATERIALNAME11;
                public TTReportField AMOUNT11; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ORDERNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 31, 6, false);
                    ORDERNO11.Name = "ORDERNO11";
                    ORDERNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO11.TextFont.Name = "Arial";
                    ORDERNO11.TextFont.CharSet = 162;
                    ORDERNO11.Value = @"{@counter@}";

                    MATERIALNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 184, 6, false);
                    MATERIALNAME11.Name = "MATERIALNAME11";
                    MATERIALNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME11.TextFont.Name = "Arial";
                    MATERIALNAME11.TextFont.CharSet = 162;
                    MATERIALNAME11.Value = @" {#MATERIAL#}";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 201, 6, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT11.TextFont.Name = "Arial";
                    AMOUNT11.TextFont.CharSet = 162;
                    AMOUNT11.Value = @"{#AMOUNT#} ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class dataset_GetKScheduleDailyDrugReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class>(0);
                    ORDERNO11.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME11.CalcValue = @" " + (dataset_GetKScheduleDailyDrugReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDailyDrugReportQuery.Material) : "");
                    AMOUNT11.CalcValue = (dataset_GetKScheduleDailyDrugReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDailyDrugReportQuery.Amount) : "") + @" ";
                    return new TTReportObject[] { ORDERNO11,MATERIALNAME11,AMOUNT11};
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleDailyReport MyParentReport
            {
                get { return (KScheduleDailyReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public KScheduleDailyReport MyParentReport
                {
                    get { return (KScheduleDailyReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KScheduleDailyReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTCHEADER = new PARTCHEADERGroup(PARTA,"PARTCHEADER");
            PARTC = new PARTCGroup(PARTCHEADER,"PARTC");
            PARTDHEADER = new PARTDHEADERGroup(PARTA,"PARTDHEADER");
            PARTD = new PARTDGroup(PARTDHEADER,"PARTD");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "K- Çizelgesi", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KSCHEDULEDAILYREPORT";
            Caption = "Günübirlik K-Çizelgesi";
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
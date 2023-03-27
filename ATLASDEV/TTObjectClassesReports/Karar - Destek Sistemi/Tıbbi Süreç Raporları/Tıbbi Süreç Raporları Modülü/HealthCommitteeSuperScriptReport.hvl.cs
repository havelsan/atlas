
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
    /// Sağlık Kurulu Üstyazı
    /// </summary>
    public partial class HealthCommitteeSuperScriptReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PART1Group : TTReportGroup
        {
            public HealthCommitteeSuperScriptReport MyParentReport
            {
                get { return (HealthCommitteeSuperScriptReport)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField192 { get {return Header().NewField192;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField1192 { get {return Header().NewField1192;} }
            public TTReportField NewField1193 { get {return Header().NewField1193;} }
            public TTReportField NewField1194 { get {return Header().NewField1194;} }
            public TTReportField NewField1195 { get {return Header().NewField1195;} }
            public TTReportField NewField1196 { get {return Header().NewField1196;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField SINIFRUT { get {return Header().SINIFRUT;} }
            public TTReportField TITLE { get {return Header().TITLE;} }
            public TTReportField NewField181 { get {return Footer().NewField181;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField1241 { get {return Footer().NewField1241;} }
            public TTReportField NewField1341 { get {return Footer().NewField1341;} }
            public TTReportField NewField1441 { get {return Footer().NewField1441;} }
            public TTReportField NewField1541 { get {return Footer().NewField1541;} }
            public TTReportField NewField1641 { get {return Footer().NewField1641;} }
            public TTReportField NewField1741 { get {return Footer().NewField1741;} }
            public TTReportField NewField1841 { get {return Footer().NewField1841;} }
            public TTReportField NewField1941 { get {return Footer().NewField1941;} }
            public TTReportField NewField1051 { get {return Footer().NewField1051;} }
            public TTReportField NewField11501 { get {return Footer().NewField11501;} }
            public TTReportField NewField12501 { get {return Footer().NewField12501;} }
            public TTReportField NewField110511 { get {return Footer().NewField110511;} }
            public TTReportField NewField13501 { get {return Footer().NewField13501;} }
            public TTReportField NewField120511 { get {return Footer().NewField120511;} }
            public TTReportField NewField110521 { get {return Footer().NewField110521;} }
            public TTReportField NewField1115011 { get {return Footer().NewField1115011;} }
            public TTReportField NewField1125011 { get {return Footer().NewField1125011;} }
            public TTReportField NewField11105111 { get {return Footer().NewField11105111;} }
            public TTReportField NewField14501 { get {return Footer().NewField14501;} }
            public TTReportField NewField130511 { get {return Footer().NewField130511;} }
            public TTReportField NewField120521 { get {return Footer().NewField120521;} }
            public TTReportField NewField1215011 { get {return Footer().NewField1215011;} }
            public TTReportField NewField110531 { get {return Footer().NewField110531;} }
            public TTReportField NewField1115021 { get {return Footer().NewField1115021;} }
            public TTReportField NewField1225011 { get {return Footer().NewField1225011;} }
            public TTReportField NewField12105111 { get {return Footer().NewField12105111;} }
            public TTReportField NewField11105211 { get {return Footer().NewField11105211;} }
            public TTReportField NewField111150111 { get {return Footer().NewField111150111;} }
            public TTReportField NewField110541 { get {return Footer().NewField110541;} }
            public TTReportField NewField1115031 { get {return Footer().NewField1115031;} }
            public TTReportField NewField1125021 { get {return Footer().NewField1125021;} }
            public TTReportField NewField11105121 { get {return Footer().NewField11105121;} }
            public TTReportField NewField1135011 { get {return Footer().NewField1135011;} }
            public TTReportField NewField11205111 { get {return Footer().NewField11205111;} }
            public TTReportField NewField11105221 { get {return Footer().NewField11105221;} }
            public TTReportField NewField111150121 { get {return Footer().NewField111150121;} }
            public TTReportField NewField111250111 { get {return Footer().NewField111250111;} }
            public TTReportField NewField1111051111 { get {return Footer().NewField1111051111;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public HealthCommitteeSuperScriptReport MyParentReport
                {
                    get { return (HealthCommitteeSuperScriptReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField191;
                public TTReportField NewField192;
                public TTReportField NewField1291;
                public TTReportField NewField1191;
                public TTReportField NewField1192;
                public TTReportField NewField1193;
                public TTReportField NewField1194;
                public TTReportField NewField1195;
                public TTReportField NewField1196;
                public TTReportField NewField1;
                public TTReportField ADSOYAD;
                public TTReportField SINIFRUT;
                public TTReportField TITLE; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 176;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 4, 204, 27, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 5, 35, 11, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Underline = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"HİZMETE ÖZEL";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 27, 30, 33, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"SAĞ.KRL.";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 33, 30, 39, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Size = 11;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"KONU";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 33, 32, 39, false);
                    NewField192.Name = "NewField192";
                    NewField192.TextFont.Size = 11;
                    NewField192.TextFont.CharSet = 162;
                    NewField192.Value = @":";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 27, 32, 33, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Size = 11;
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @":";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 27, 83, 33, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Size = 11;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"9029.242.07/1661-9829";

                    NewField1192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 33, 92, 48, false);
                    NewField1192.Name = "NewField1192";
                    NewField1192.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1192.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1192.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1192.TextFont.Size = 11;
                    NewField1192.TextFont.CharSet = 162;
                    NewField1192.Value = @"Arşive Gönderilen 2001 Yılı Raporları ve 1997 Yılı Rapor Defterleri";

                    NewField1193 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 68, 139, 74, false);
                    NewField1193.Name = "NewField1193";
                    NewField1193.TextFont.Size = 11;
                    NewField1193.TextFont.CharSet = 162;
                    NewField1193.Value = @"MSB ARŞİV MÜDÜRLÜĞÜNE";

                    NewField1194 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 75, 140, 81, false);
                    NewField1194.Name = "NewField1194";
                    NewField1194.TextFont.Size = 11;
                    NewField1194.TextFont.Underline = true;
                    NewField1194.TextFont.CharSet = 162;
                    NewField1194.Value = @"LODUMLU/XXXXXX";

                    NewField1195 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 103, 65, 109, false);
                    NewField1195.Name = "NewField1195";
                    NewField1195.TextFont.Size = 11;
                    NewField1195.TextFont.CharSet = 162;
                    NewField1195.Value = @"İLGİ: XXXXXX Arşiv Yönergesi (MY-71-1)";

                    NewField1196 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 113, 199, 142, false);
                    NewField1196.Name = "NewField1196";
                    NewField1196.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1196.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1196.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1196.TextFont.Size = 11;
                    NewField1196.TextFont.CharSet = 162;
                    NewField1196.Value = @"İlgi yönerge gereği Sağlık Kurulu arşivinde 2001 yılına ait raporlar ve 1997 yılına ait rapor defterlerinin aşağıda sayı ve miktarları belirtilmiş ve kolilenerek saklanmak üzere görevli personel ile gönderilmiştir.
             Gereğini rica ederim.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 29, 199, 34, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFormat = @"Short Date";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.Value = @"{@printdate@}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 152, 200, 156, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    SINIFRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 156, 200, 160, false);
                    SINIFRUT.Name = "SINIFRUT";
                    SINIFRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUT.TextFont.Size = 9;
                    SINIFRUT.TextFont.CharSet = 162;
                    SINIFRUT.Value = @"";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 160, 200, 164, false);
                    TITLE.Name = "TITLE";
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.TextFont.Size = 9;
                    TITLE.TextFont.CharSet = 162;
                    TITLE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1192.CalcValue = NewField1192.Value;
                    NewField1193.CalcValue = NewField1193.Value;
                    NewField1194.CalcValue = NewField1194.Value;
                    NewField1195.CalcValue = NewField1195.Value;
                    NewField1196.CalcValue = NewField1196.Value;
                    NewField1.CalcValue = DateTime.Now.ToShortDateString();
                    ADSOYAD.CalcValue = @"";
                    SINIFRUT.CalcValue = @"";
                    TITLE.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField18,NewField19,NewField191,NewField192,NewField1291,NewField1191,NewField1192,NewField1193,NewField1194,NewField1195,NewField1196,NewField1,ADSOYAD,SINIFRUT,TITLE,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    string sHeadID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
            TTObjectContext context = new TTObjectContext(true);
            ResUser head = (ResUser)context.GetObject(new Guid(sHeadID), "ResUser");
            
            this.ADSOYAD.CalcValue = head.Name;
            string sClassRank = head.MilitaryClass != null ? head.MilitaryClass.Name : "";
            sClassRank += " " + head.Rank != null ? head.Rank.Name : "";
            this.SINIFRUT.CalcValue = sClassRank;
            this.TITLE.CalcValue = head.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(head.Title.Value) : "";
#endregion PART1 HEADER_Script
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public HealthCommitteeSuperScriptReport MyParentReport
                {
                    get { return (HealthCommitteeSuperScriptReport)ParentReport; }
                }
                
                public TTReportField NewField181;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1241;
                public TTReportField NewField1341;
                public TTReportField NewField1441;
                public TTReportField NewField1541;
                public TTReportField NewField1641;
                public TTReportField NewField1741;
                public TTReportField NewField1841;
                public TTReportField NewField1941;
                public TTReportField NewField1051;
                public TTReportField NewField11501;
                public TTReportField NewField12501;
                public TTReportField NewField110511;
                public TTReportField NewField13501;
                public TTReportField NewField120511;
                public TTReportField NewField110521;
                public TTReportField NewField1115011;
                public TTReportField NewField1125011;
                public TTReportField NewField11105111;
                public TTReportField NewField14501;
                public TTReportField NewField130511;
                public TTReportField NewField120521;
                public TTReportField NewField1215011;
                public TTReportField NewField110531;
                public TTReportField NewField1115021;
                public TTReportField NewField1225011;
                public TTReportField NewField12105111;
                public TTReportField NewField11105211;
                public TTReportField NewField111150111;
                public TTReportField NewField110541;
                public TTReportField NewField1115031;
                public TTReportField NewField1125021;
                public TTReportField NewField11105121;
                public TTReportField NewField1135011;
                public TTReportField NewField11205111;
                public TTReportField NewField11105221;
                public TTReportField NewField111150121;
                public TTReportField NewField111250111;
                public TTReportField NewField1111051111; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 92;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 83, 36, 89, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Size = 11;
                    NewField181.TextFont.Underline = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"HİZMETE ÖZEL";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 3, 96, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"2001 YILI RAPORLARI";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 3, 120, 16, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"DOSYA SAYISI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 3, 144, 16, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.Value = @"RAPOR SAYISI";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 3, 168, 16, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.Value = @"1997 YILI RAPOR DEFTERLERİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 16, 96, 22, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.Value = @"ER";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 22, 96, 28, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.Value = @"SVL.ME.AİLELERİ VE SVL.ME.AD.";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 28, 96, 34, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.Value = @"ASK.ÖĞ. VE ASK. ÖĞ. AD.";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 34, 96, 40, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.Value = @"KHO SINIFLANDIRMA ";

                    NewField1441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 96, 46, false);
                    NewField1441.Name = "NewField1441";
                    NewField1441.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1441.Value = @"JN.OK.K.LIĞI JN.ASTSB.AD.";

                    NewField1541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 46, 96, 52, false);
                    NewField1541.Name = "NewField1541";
                    NewField1541.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1541.Value = @"JN.OK.K.LIĞI UZM.ÇVŞ.AD.";

                    NewField1641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 52, 96, 58, false);
                    NewField1641.Name = "NewField1641";
                    NewField1641.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1641.Value = @"PERİYODİK";

                    NewField1741 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 58, 96, 64, false);
                    NewField1741.Name = "NewField1741";
                    NewField1741.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1741.Value = @"ÜÇ UZM.TBP. EMEKLİ";

                    NewField1841 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 64, 96, 70, false);
                    NewField1841.Name = "NewField1841";
                    NewField1841.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1841.Value = @"KHO PARAŞÜT";

                    NewField1941 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 70, 96, 76, false);
                    NewField1941.Name = "NewField1941";
                    NewField1941.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1941.Value = @"TOPLAM";

                    NewField1051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 16, 120, 22, false);
                    NewField1051.Name = "NewField1051";
                    NewField1051.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1051.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1051.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1051.Value = @"0";

                    NewField11501 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 22, 120, 28, false);
                    NewField11501.Name = "NewField11501";
                    NewField11501.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11501.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11501.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11501.Value = @"0";

                    NewField12501 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 28, 120, 34, false);
                    NewField12501.Name = "NewField12501";
                    NewField12501.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12501.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12501.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12501.Value = @"0";

                    NewField110511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 34, 120, 40, false);
                    NewField110511.Name = "NewField110511";
                    NewField110511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110511.Value = @"0";

                    NewField13501 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 40, 120, 46, false);
                    NewField13501.Name = "NewField13501";
                    NewField13501.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13501.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13501.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13501.Value = @"0";

                    NewField120511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 46, 120, 52, false);
                    NewField120511.Name = "NewField120511";
                    NewField120511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField120511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField120511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField120511.Value = @"0";

                    NewField110521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 52, 120, 58, false);
                    NewField110521.Name = "NewField110521";
                    NewField110521.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110521.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110521.Value = @"0";

                    NewField1115011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 58, 120, 64, false);
                    NewField1115011.Name = "NewField1115011";
                    NewField1115011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1115011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1115011.Value = @"0";

                    NewField1125011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 64, 120, 70, false);
                    NewField1125011.Name = "NewField1125011";
                    NewField1125011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1125011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1125011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1125011.Value = @"0";

                    NewField11105111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 70, 120, 76, false);
                    NewField11105111.Name = "NewField11105111";
                    NewField11105111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11105111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11105111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11105111.Value = @"0";

                    NewField14501 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 16, 144, 22, false);
                    NewField14501.Name = "NewField14501";
                    NewField14501.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14501.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14501.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14501.Value = @"0";

                    NewField130511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 22, 144, 28, false);
                    NewField130511.Name = "NewField130511";
                    NewField130511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField130511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField130511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField130511.Value = @"0";

                    NewField120521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 28, 144, 34, false);
                    NewField120521.Name = "NewField120521";
                    NewField120521.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField120521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField120521.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField120521.Value = @"0";

                    NewField1215011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 34, 144, 40, false);
                    NewField1215011.Name = "NewField1215011";
                    NewField1215011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1215011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1215011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1215011.Value = @"0";

                    NewField110531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 40, 144, 46, false);
                    NewField110531.Name = "NewField110531";
                    NewField110531.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110531.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110531.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110531.Value = @"0";

                    NewField1115021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 46, 144, 52, false);
                    NewField1115021.Name = "NewField1115021";
                    NewField1115021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1115021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1115021.Value = @"0";

                    NewField1225011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 52, 144, 58, false);
                    NewField1225011.Name = "NewField1225011";
                    NewField1225011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1225011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1225011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1225011.Value = @"0";

                    NewField12105111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 58, 144, 64, false);
                    NewField12105111.Name = "NewField12105111";
                    NewField12105111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12105111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12105111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12105111.Value = @"0";

                    NewField11105211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 64, 144, 70, false);
                    NewField11105211.Name = "NewField11105211";
                    NewField11105211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11105211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11105211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11105211.Value = @"0";

                    NewField111150111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 70, 144, 76, false);
                    NewField111150111.Name = "NewField111150111";
                    NewField111150111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111150111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111150111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111150111.Value = @"0";

                    NewField110541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 16, 168, 22, false);
                    NewField110541.Name = "NewField110541";
                    NewField110541.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110541.Value = @"0";

                    NewField1115031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 22, 168, 28, false);
                    NewField1115031.Name = "NewField1115031";
                    NewField1115031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1115031.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1115031.Value = @"0";

                    NewField1125021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 28, 168, 34, false);
                    NewField1125021.Name = "NewField1125021";
                    NewField1125021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1125021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1125021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1125021.Value = @"0";

                    NewField11105121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 34, 168, 40, false);
                    NewField11105121.Name = "NewField11105121";
                    NewField11105121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11105121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11105121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11105121.Value = @"0";

                    NewField1135011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 40, 168, 46, false);
                    NewField1135011.Name = "NewField1135011";
                    NewField1135011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1135011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1135011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1135011.Value = @"0";

                    NewField11205111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 46, 168, 52, false);
                    NewField11205111.Name = "NewField11205111";
                    NewField11205111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11205111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11205111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11205111.Value = @"0";

                    NewField11105221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 52, 168, 58, false);
                    NewField11105221.Name = "NewField11105221";
                    NewField11105221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11105221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11105221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11105221.Value = @"0";

                    NewField111150121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 58, 168, 64, false);
                    NewField111150121.Name = "NewField111150121";
                    NewField111150121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111150121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111150121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111150121.Value = @"0";

                    NewField111250111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 64, 168, 70, false);
                    NewField111250111.Name = "NewField111250111";
                    NewField111250111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111250111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111250111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111250111.Value = @"0";

                    NewField1111051111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 70, 168, 76, false);
                    NewField1111051111.Name = "NewField1111051111";
                    NewField1111051111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111051111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111051111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111051111.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField181.CalcValue = NewField181.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField1441.CalcValue = NewField1441.Value;
                    NewField1541.CalcValue = NewField1541.Value;
                    NewField1641.CalcValue = NewField1641.Value;
                    NewField1741.CalcValue = NewField1741.Value;
                    NewField1841.CalcValue = NewField1841.Value;
                    NewField1941.CalcValue = NewField1941.Value;
                    NewField1051.CalcValue = NewField1051.Value;
                    NewField11501.CalcValue = NewField11501.Value;
                    NewField12501.CalcValue = NewField12501.Value;
                    NewField110511.CalcValue = NewField110511.Value;
                    NewField13501.CalcValue = NewField13501.Value;
                    NewField120511.CalcValue = NewField120511.Value;
                    NewField110521.CalcValue = NewField110521.Value;
                    NewField1115011.CalcValue = NewField1115011.Value;
                    NewField1125011.CalcValue = NewField1125011.Value;
                    NewField11105111.CalcValue = NewField11105111.Value;
                    NewField14501.CalcValue = NewField14501.Value;
                    NewField130511.CalcValue = NewField130511.Value;
                    NewField120521.CalcValue = NewField120521.Value;
                    NewField1215011.CalcValue = NewField1215011.Value;
                    NewField110531.CalcValue = NewField110531.Value;
                    NewField1115021.CalcValue = NewField1115021.Value;
                    NewField1225011.CalcValue = NewField1225011.Value;
                    NewField12105111.CalcValue = NewField12105111.Value;
                    NewField11105211.CalcValue = NewField11105211.Value;
                    NewField111150111.CalcValue = NewField111150111.Value;
                    NewField110541.CalcValue = NewField110541.Value;
                    NewField1115031.CalcValue = NewField1115031.Value;
                    NewField1125021.CalcValue = NewField1125021.Value;
                    NewField11105121.CalcValue = NewField11105121.Value;
                    NewField1135011.CalcValue = NewField1135011.Value;
                    NewField11205111.CalcValue = NewField11205111.Value;
                    NewField11105221.CalcValue = NewField11105221.Value;
                    NewField111150121.CalcValue = NewField111150121.Value;
                    NewField111250111.CalcValue = NewField111250111.Value;
                    NewField1111051111.CalcValue = NewField1111051111.Value;
                    return new TTReportObject[] { NewField181,NewField11,NewField111,NewField121,NewField131,NewField141,NewField1141,NewField1241,NewField1341,NewField1441,NewField1541,NewField1641,NewField1741,NewField1841,NewField1941,NewField1051,NewField11501,NewField12501,NewField110511,NewField13501,NewField120511,NewField110521,NewField1115011,NewField1125011,NewField11105111,NewField14501,NewField130511,NewField120521,NewField1215011,NewField110531,NewField1115021,NewField1225011,NewField12105111,NewField11105211,NewField111150111,NewField110541,NewField1115031,NewField1125021,NewField11105121,NewField1135011,NewField11205111,NewField11105221,NewField111150121,NewField111250111,NewField1111051111};
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeSuperScriptReport MyParentReport
            {
                get { return (HealthCommitteeSuperScriptReport)ParentReport; }
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
                public HealthCommitteeSuperScriptReport MyParentReport
                {
                    get { return (HealthCommitteeSuperScriptReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
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

        public HealthCommitteeSuperScriptReport()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "HEALTHCOMMITTEESUPERSCRIPTREPORT";
            Caption = "Sağlık Kurulu Üstyazı";
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
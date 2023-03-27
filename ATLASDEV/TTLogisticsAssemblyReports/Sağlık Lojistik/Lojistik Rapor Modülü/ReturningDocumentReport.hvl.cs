
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
    /// İade Belgesi Raporu
    /// </summary>
    public partial class ReturningDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ReturningDocumentReport MyParentReport
            {
                get { return (ReturningDocumentReport)ParentReport; }
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
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1222 { get {return Header().NewField1222;} }
            public TTReportField NewField1113 { get {return Header().NewField1113;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField MALSAYMANI { get {return Footer().MALSAYMANI;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
            public TTReportField DEPOSORUMLUSU { get {return Footer().DEPOSORUMLUSU;} }
            public TTReportField DEPOSORUMLUSUTARIH { get {return Footer().DEPOSORUMLUSUTARIH;} }
            public TTReportField MALSAYMANITARIH { get {return Footer().MALSAYMANITARIH;} }
            public TTReportField BELGENO { get {return Footer().BELGENO;} }
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
                public ReturningDocumentReport MyParentReport
                {
                    get { return (ReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField HOSPITALNAMEHEADER;
                public TTReportField NewField1112;
                public TTReportField NewField1222;
                public TTReportField NewField1113; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAMEHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 4, 198, 27, false);
                    HOSPITALNAMEHEADER.Name = "HOSPITALNAMEHEADER";
                    HOSPITALNAMEHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEHEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.TextFont.Size = 11;
                    HOSPITALNAMEHEADER.TextFont.Bold = true;
                    HOSPITALNAMEHEADER.TextFont.CharSet = 162;
                    HOSPITALNAMEHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 27, 140, 34, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"(Teslim ve tesellüm işlerinde)";

                    NewField1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 27, 198, 34, false);
                    NewField1222.Name = "NewField1222";
                    NewField1222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222.TextFont.CharSet = 162;
                    NewField1222.Value = @"................sayfanın................sayfası";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 26, 52, 34, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Size = 14;
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"İade Belgesi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1222.CalcValue = NewField1222.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    HOSPITALNAMEHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1112,NewField1222,NewField1113,HOSPITALNAMEHEADER};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ReturningDocumentReport MyParentReport
                {
                    get { return (ReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField MALSAYMANI;
                public TTReportField MALSORUMLUSU;
                public TTReportField DEPOSORUMLUSU;
                public TTReportField DEPOSORUMLUSUTARIH;
                public TTReportField MALSAYMANITARIH;
                public TTReportField BELGENO; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 72;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 66, 96, 72, false);
                    NewField10.Name = "NewField10";
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Size = 8;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"L-101-5 (447)";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 198, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" İstek Yetkisi :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 107, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" Malın Durumunun İzahı :
 NAY	- Normal aşınma ve yıpranmadan dolayı gayrifaal
 TIR	- Gayrifaal, tahkikat raporu açılacak
 K.Ö.B	- Gayrifaal, kendiliğinden ödeme beyanı
 F	- Faal
 Fazla	- Kadro miktarından fazla";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 198, 35, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @" Bu belge üzerinde gösterilen malların durum sürununda işaret edilen şartlar
 gereğince iadesi gerekmektedir.
 Mal Sorumlusu : Adı, Soyadı, Rütbe, Sicil No.





Yukarıdaki miktarlar alınmıştır.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 35, 107, 66, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @" Alınan miktar sütununda gösterilenler alınmıştır.
 Depocu : Adı, Soyadı, Rütbe, Sicil No.




 Tarih :";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 35, 198, 59, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @" Alınan miktar sütununda gösterilen miktarların iadesi uygundur.
 Mal Saymanı : Adı, Soyadı, Rütbe, Sicil No.



 Tarih :";

                    MALSAYMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 42, 192, 54, false);
                    MALSAYMANI.Name = "MALSAYMANI";
                    MALSAYMANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    MALSAYMANI.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI.WordBreak = EvetHayirEnum.ehEvet;
                    MALSAYMANI.TextFont.Size = 8;
                    MALSAYMANI.TextFont.CharSet = 162;
                    MALSAYMANI.Value = @"";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 19, 192, 32, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.FillStyle = FillStyleConstants.vbFSTransparent;
                    MALSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.TextFont.Size = 8;
                    MALSORUMLUSU.TextFont.CharSet = 162;
                    MALSORUMLUSU.Value = @"";

                    DEPOSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 43, 94, 58, false);
                    DEPOSORUMLUSU.Name = "DEPOSORUMLUSU";
                    DEPOSORUMLUSU.FillStyle = FillStyleConstants.vbFSTransparent;
                    DEPOSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    DEPOSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    DEPOSORUMLUSU.TextFont.Size = 8;
                    DEPOSORUMLUSU.TextFont.CharSet = 162;
                    DEPOSORUMLUSU.Value = @"";

                    DEPOSORUMLUSUTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 59, 47, 63, false);
                    DEPOSORUMLUSUTARIH.Name = "DEPOSORUMLUSUTARIH";
                    DEPOSORUMLUSUTARIH.TextFormat = @"dd/MM/yyyy";
                    DEPOSORUMLUSUTARIH.TextFont.Size = 8;
                    DEPOSORUMLUSUTARIH.TextFont.CharSet = 162;
                    DEPOSORUMLUSUTARIH.Value = @"";

                    MALSAYMANITARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 55, 141, 59, false);
                    MALSAYMANITARIH.Name = "MALSAYMANITARIH";
                    MALSAYMANITARIH.TextFormat = @"dd/MM/yyyy";
                    MALSAYMANITARIH.TextFont.Size = 8;
                    MALSAYMANITARIH.TextFont.CharSet = 162;
                    MALSAYMANITARIH.Value = @"";

                    BELGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 59, 198, 66, false);
                    BELGENO.Name = "BELGENO";
                    BELGENO.DrawStyle = DrawStyleConstants.vbSolid;
                    BELGENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BELGENO.TextFont.Size = 8;
                    BELGENO.TextFont.CharSet = 162;
                    BELGENO.Value = @" Belge No. :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    MALSAYMANI.CalcValue = MALSAYMANI.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    DEPOSORUMLUSU.CalcValue = DEPOSORUMLUSU.Value;
                    DEPOSORUMLUSUTARIH.CalcValue = DEPOSORUMLUSUTARIH.Value;
                    MALSAYMANITARIH.CalcValue = MALSAYMANITARIH.Value;
                    BELGENO.CalcValue = BELGENO.Value;
                    return new TTReportObject[] { NewField10,NewField11,NewField12,NewField13,NewField14,NewField15,MALSAYMANI,MALSORUMLUSU,DEPOSORUMLUSU,DEPOSORUMLUSUTARIH,MALSAYMANITARIH,BELGENO};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(StockAction));
                if(stockAction is ReturningDocument)
                {
                    ReturningDocument returningDocument = (ReturningDocument)stockAction;
                    foreach (StockActionSignDetail stockActionSignDetail in returningDocument.StockActionSignDetails)
                    {
                        string signDesc = string.Empty;
                        signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                        if(stockActionSignDetail.SignUser.MilitaryClass != null)
                            signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                        if(stockActionSignDetail.SignUser.Rank != null)
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName + "\r\n";
                        signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                        switch (stockActionSignDetail.SignUserType)
                        {
                            case SignUserTypeEnum.MalSorumlusu:
                                this.MALSORUMLUSU.Value = signDesc;
                                break;
                            case SignUserTypeEnum.DepoSorumlusu:
                                this.DEPOSORUMLUSU.Value = signDesc;
                                break;
                            case SignUserTypeEnum.MalSaymani:
                                this.MALSAYMANI.Value = signDesc;
                                break;
                            default:
                                break;
                        }
                    }

                    this.MALSAYMANITARIH.Value = "Tarih : " + returningDocument.TransactionDate.Value.ToShortDateString();
                    this.DEPOSORUMLUSUTARIH.Value = "Tarih : " + returningDocument.TransactionDate.Value.ToShortDateString();
                    this.BELGENO.Value = " Belge No. : " + returningDocument.RegistrationNumber + " - " + returningDocument.SequenceNumber;
                }
                
                if(stockAction is VoucherReturnDocument)
                {
                    VoucherReturnDocument returningDocument = (VoucherReturnDocument)stockAction;
                    foreach (StockActionSignDetail stockActionSignDetail in returningDocument.StockActionSignDetails)
                    {
                        string signDesc = string.Empty;
                        signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                        if(stockActionSignDetail.SignUser.MilitaryClass != null)
                            signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                        if(stockActionSignDetail.SignUser.Rank != null)
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName + "\r\n";
                        signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                        switch (stockActionSignDetail.SignUserType)
                        {
                            case SignUserTypeEnum.MalSorumlusu:
                                this.MALSORUMLUSU.Value = signDesc;
                                break;
                            case SignUserTypeEnum.DepoSorumlusu:
                                this.DEPOSORUMLUSU.Value = signDesc;
                                break;
                            case SignUserTypeEnum.MalSaymani:
                                this.MALSAYMANI.Value = signDesc;
                                break;
                            default:
                                break;
                        }
                    }

                    this.MALSAYMANITARIH.Value = "Tarih : " + returningDocument.TransactionDate.Value.ToShortDateString();
                    this.DEPOSORUMLUSUTARIH.Value = "Tarih : " + returningDocument.TransactionDate.Value.ToShortDateString();
                    this.BELGENO.Value = " Belge No. : " + returningDocument.RegistrationNumber + " - " + returningDocument.SequenceNumber;
                }
            }
#endregion PARTA FOOTER_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ReturningDocumentReport MyParentReport
            {
                get { return (ReturningDocumentReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField STORE { get {return Header().STORE;} }
            public TTReportField DESTINATIONSTORE { get {return Header().DESTINATIONSTORE;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField NewField1912 { get {return Header().NewField1912;} }
            public TTReportField NewField1922 { get {return Header().NewField1922;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField1962 { get {return Header().NewField1962;} }
            public TTReportField NewField1972 { get {return Header().NewField1972;} }
            public TTReportField NewField1982 { get {return Header().NewField1982;} }
            public TTReportField NewField1392 { get {return Header().NewField1392;} }
            public TTReportField NewField1992 { get {return Header().NewField1992;} }
            public TTReportField NewField1903 { get {return Header().NewField1903;} }
            public TTReportField NewField1413 { get {return Header().NewField1413;} }
            public TTReportField STOCKACTIONID { get {return Header().STOCKACTIONID;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1923 { get {return Header().NewField1923;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField1772 { get {return Header().NewField1772;} }
            public TTReportField NewField1993 { get {return Header().NewField1993;} }
            public TTReportField NewField1904 { get {return Header().NewField1904;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField ITEMCOUNT { get {return Footer().ITEMCOUNT;} }
            public TTReportField ITEM { get {return Footer().ITEM;} }
            public TTReportField ITEMTEXT { get {return Footer().ITEMTEXT;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public ReturningDocumentReport MyParentReport
                {
                    get { return (ReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField171;
                public TTReportField NewField14;
                public TTReportField STORE;
                public TTReportField DESTINATIONSTORE;
                public TTReportField NewField102;
                public TTReportField NewField1912;
                public TTReportField NewField1922;
                public TTReportField NewField132;
                public TTReportField NewField152;
                public TTReportField NewField1962;
                public TTReportField NewField1972;
                public TTReportField NewField1982;
                public TTReportField NewField1392;
                public TTReportField NewField1992;
                public TTReportField NewField1903;
                public TTReportField NewField1413;
                public TTReportField STOCKACTIONID;
                public TTReportField NewField112;
                public TTReportField NewField1923;
                public TTReportField NewField162;
                public TTReportField NewField1772;
                public TTReportField NewField1993;
                public TTReportField NewField1904;
                public TTReportField NewField123;
                public TTReportField NewField133;
                public TTReportField NewField143;
                public TTReportField NewField153; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 41;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 16, 107, 32, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @" Alacak Mal Saymanı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 107, 16, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @" Gönderen Mal Sorumlusu";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 107, 16, false);
                    STORE.Name = "STORE";
                    STORE.FillStyle = FillStyleConstants.vbFSTransparent;
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORE.MultiLine = EvetHayirEnum.ehEvet;
                    STORE.WordBreak = EvetHayirEnum.ehEvet;
                    STORE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STORE.ObjectDefName = "StockAction";
                    STORE.DataMember = "STORE.NAME";
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @"{@TTOBJECTID@}";

                    DESTINATIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 107, 32, false);
                    DESTINATIONSTORE.Name = "DESTINATIONSTORE";
                    DESTINATIONSTORE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESTINATIONSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESTINATIONSTORE.MultiLine = EvetHayirEnum.ehEvet;
                    DESTINATIONSTORE.WordBreak = EvetHayirEnum.ehEvet;
                    DESTINATIONSTORE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESTINATIONSTORE.ObjectDefName = "StockAction";
                    DESTINATIONSTORE.DataMember = "DESTINATIONSTORE.NAME";
                    DESTINATIONSTORE.TextFont.CharSet = 162;
                    DESTINATIONSTORE.Value = @"{@TTOBJECTID@}";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 140, 8, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.TextFont.Size = 8;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @" İade Belge No.";

                    NewField1912 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 140, 16, false);
                    NewField1912.Name = "NewField1912";
                    NewField1912.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1912.TextFont.Size = 8;
                    NewField1912.TextFont.CharSet = 162;
                    NewField1912.Value = @"";

                    NewField1922 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 198, 8, false);
                    NewField1922.Name = "NewField1922";
                    NewField1922.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1922.TextFont.Size = 8;
                    NewField1922.TextFont.CharSet = 162;
                    NewField1922.Value = @" Malın Teknik Sınıfı :";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 198, 16, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.TextFont.Size = 8;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @" Malın Sınıfı :";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 16, 198, 24, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.TextFont.Size = 8;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @" Verile Emri No. :";

                    NewField1962 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 24, 198, 32, false);
                    NewField1962.Name = "NewField1962";
                    NewField1962.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1962.TextFont.Size = 8;
                    NewField1962.TextFont.CharSet = 162;
                    NewField1962.Value = @" İş Emri No. :";

                    NewField1972 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 16, 118, 24, false);
                    NewField1972.Name = "NewField1972";
                    NewField1972.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1972.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1972.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1972.TextFont.Size = 8;
                    NewField1972.TextFont.CharSet = 162;
                    NewField1972.Value = @"İlk";

                    NewField1982 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 16, 129, 24, false);
                    NewField1982.Name = "NewField1982";
                    NewField1982.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1982.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1982.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1982.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1982.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1982.TextFont.Size = 8;
                    NewField1982.TextFont.CharSet = 162;
                    NewField1982.Value = @"Yerine Koyma";

                    NewField1392 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 16, 140, 24, false);
                    NewField1392.Name = "NewField1392";
                    NewField1392.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1392.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1392.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1392.TextFont.Size = 8;
                    NewField1392.TextFont.CharSet = 162;
                    NewField1392.Value = @"Senet";

                    NewField1992 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 24, 118, 32, false);
                    NewField1992.Name = "NewField1992";
                    NewField1992.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1992.TextFont.CharSet = 162;
                    NewField1992.Value = @"";

                    NewField1903 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 24, 129, 32, false);
                    NewField1903.Name = "NewField1903";
                    NewField1903.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1903.TextFont.CharSet = 162;
                    NewField1903.Value = @"";

                    NewField1413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 24, 140, 32, false);
                    NewField1413.Name = "NewField1413";
                    NewField1413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1413.TextFont.CharSet = 162;
                    NewField1413.Value = @"";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 24, 190, 29, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.FillStyle = FillStyleConstants.vbFSTransparent;
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.ObjectDefName = "StockAction";
                    STOCKACTIONID.DataMember = "STOCKACTIONID";
                    STOCKACTIONID.TextFont.CharSet = 162;
                    STOCKACTIONID.Value = @"{@TTOBJECTID@}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 22, 41, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Size = 8;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Sıra
No";

                    NewField1923 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 32, 118, 41, false);
                    NewField1923.Name = "NewField1923";
                    NewField1923.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1923.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1923.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1923.TextFont.Size = 8;
                    NewField1923.TextFont.CharSet = 162;
                    NewField1923.Value = @"Stok No    Parça No    Malın İsmi";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 32, 188, 36, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Size = 8;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"Fiyatı Tutarı";

                    NewField1772 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 32, 129, 41, false);
                    NewField1772.Name = "NewField1772";
                    NewField1772.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1772.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1772.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1772.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1772.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1772.TextFont.Size = 8;
                    NewField1772.TextFont.CharSet = 162;
                    NewField1772.Value = @"Malın Durumu";

                    NewField1993 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 36, 181, 41, false);
                    NewField1993.Name = "NewField1993";
                    NewField1993.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1993.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1993.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1993.TextFont.Size = 8;
                    NewField1993.TextFont.CharSet = 162;
                    NewField1993.Value = @"TL";

                    NewField1904 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 36, 188, 41, false);
                    NewField1904.Name = "NewField1904";
                    NewField1904.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1904.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1904.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1904.TextFont.Size = 8;
                    NewField1904.TextFont.CharSet = 162;
                    NewField1904.Value = @"Kr";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 32, 140, 41, false);
                    NewField123.Name = "NewField123";
                    NewField123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123.TextFont.Size = 8;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Tevzi Vahidi";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 32, 150, 41, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField133.TextFont.Size = 8;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"İade Miktarı";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 32, 160, 41, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField143.TextFont.Size = 8;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Alınan
Miktar";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 32, 198, 41, false);
                    NewField153.Name = "NewField153";
                    NewField153.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField153.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField153.TextFont.Size = 8;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"İşlem";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField171.CalcValue = NewField171.Value;
                    NewField14.CalcValue = NewField14.Value;
                    STORE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    STORE.PostFieldValueCalculation();
                    DESTINATIONSTORE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESTINATIONSTORE.PostFieldValueCalculation();
                    NewField102.CalcValue = NewField102.Value;
                    NewField1912.CalcValue = NewField1912.Value;
                    NewField1922.CalcValue = NewField1922.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField1962.CalcValue = NewField1962.Value;
                    NewField1972.CalcValue = NewField1972.Value;
                    NewField1982.CalcValue = NewField1982.Value;
                    NewField1392.CalcValue = NewField1392.Value;
                    NewField1992.CalcValue = NewField1992.Value;
                    NewField1903.CalcValue = NewField1903.Value;
                    NewField1413.CalcValue = NewField1413.Value;
                    STOCKACTIONID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    STOCKACTIONID.PostFieldValueCalculation();
                    NewField112.CalcValue = NewField112.Value;
                    NewField1923.CalcValue = NewField1923.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField1772.CalcValue = NewField1772.Value;
                    NewField1993.CalcValue = NewField1993.Value;
                    NewField1904.CalcValue = NewField1904.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField153.CalcValue = NewField153.Value;
                    return new TTReportObject[] { NewField171,NewField14,STORE,DESTINATIONSTORE,NewField102,NewField1912,NewField1922,NewField132,NewField152,NewField1962,NewField1972,NewField1982,NewField1392,NewField1992,NewField1903,NewField1413,STOCKACTIONID,NewField112,NewField1923,NewField162,NewField1772,NewField1993,NewField1904,NewField123,NewField133,NewField143,NewField153};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ReturningDocumentReport MyParentReport
                {
                    get { return (ReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField ITEMCOUNT;
                public TTReportField ITEM;
                public TTReportField ITEMTEXT;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    RepeatCount = 0;
                    
                    ITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 198, 6, false);
                    ITEMCOUNT.Name = "ITEMCOUNT";
                    ITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMCOUNT.TextFont.CharSet = 162;
                    ITEMCOUNT.Value = @"//////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız {%ITEM%} ({%ITEMTEXT%}) kalemdir. //////////////////////////////////////////////////////////////////////////////////////////////////////";

                    ITEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 236, 7, false);
                    ITEM.Name = "ITEM";
                    ITEM.Visible = EvetHayirEnum.ehHayir;
                    ITEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEM.Value = @"{@subgroupcount@}";

                    ITEMTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 7, 236, 12, false);
                    ITEMTEXT.Name = "ITEMTEXT";
                    ITEMTEXT.Visible = EvetHayirEnum.ehHayir;
                    ITEMTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMTEXT.TextFormat = @"NUMBERTEXT";
                    ITEMTEXT.Value = @"{%ITEM%}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 6, 196, 19, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ObjectDefName = "StockAction";
                    DESCRIPTION.DataMember = "DESCRIPTION";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{@TTOBJECTID@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 0, 198, 25, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 0, 13, 25, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ITEM.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    ITEMTEXT.CalcValue = MyParentReport.PARTB.ITEM.CalcValue;
                    ITEMCOUNT.CalcValue = @"//////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız " + MyParentReport.PARTB.ITEM.CalcValue + @" (" + MyParentReport.PARTB.ITEMTEXT.FormattedValue + @") kalemdir. //////////////////////////////////////////////////////////////////////////////////////////////////////";
                    DESCRIPTION.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESCRIPTION.PostFieldValueCalculation();
                    return new TTReportObject[] { ITEM,ITEMTEXT,ITEMCOUNT,DESCRIPTION};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ReturningDocumentReport MyParentReport
            {
                get { return (ReturningDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField STOCKLEVELTYPE { get {return Body().STOCKLEVELTYPE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField REQUIREAMOUNT { get {return Body().REQUIREAMOUNT;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReturningDocumentReport MyParentReport
                {
                    get { return (ReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField AMOUNT;
                public TTReportField STOCKLEVELTYPE;
                public TTReportField UNITPRICE;
                public TTReportField ORDERNO;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField REQUIREAMOUNT;
                public TTReportField NewField102;
                public TTReportField MATERIALDESCRIPTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 236, 5, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 160, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    STOCKLEVELTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 129, 5, false);
                    STOCKLEVELTYPE.Name = "STOCKLEVELTYPE";
                    STOCKLEVELTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKLEVELTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKLEVELTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOCKLEVELTYPE.TextFont.CharSet = 162;
                    STOCKLEVELTYPE.Value = @"{#STOCKLEVELTYPE#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 188, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 22, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 140, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    REQUIREAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 150, 5, false);
                    REQUIREAMOUNT.Name = "REQUIREAMOUNT";
                    REQUIREAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUIREAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUIREAMOUNT.TextFormat = @"#,##0";
                    REQUIREAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REQUIREAMOUNT.TextFont.CharSet = 162;
                    REQUIREAMOUNT.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 198, 5, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 118, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.CharSet = 162;
                    MATERIALDESCRIPTION.Value = @"{#NATOSTOCKNO#}  {#MATERIALNAME#} ({#STOCKCARDCLASSCODE#} - {#CARDORDERNO#})";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    STOCKLEVELTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockleveltype) : "");
                    UNITPRICE.CalcValue = UNITPRICE.Value;
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    REQUIREAMOUNT.CalcValue = @"";
                    NewField102.CalcValue = NewField102.Value;
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "") + @"  " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "") + @" (" + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockcardclasscode) : "") + @" - " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.CardOrderNO) : "") + @")";
                    return new TTReportObject[] { STOCKACTIONDETAILOBJECTID,AMOUNT,STOCKLEVELTYPE,UNITPRICE,ORDERNO,DISTRIBUTIONTYPE,REQUIREAMOUNT,NewField102,MATERIALDESCRIPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
            if (stockAction is ReturningDocument)
            {
                ReturningDocumentMaterial returningMaterial = (ReturningDocumentMaterial)MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(ReturningDocumentMaterial));
                REQUIREAMOUNT.CalcValue = returningMaterial.RequireAmount.ToString();
                UNITPRICE.CalcValue = (Convert.ToDouble(returningMaterial.TotalPrice) / Convert.ToDouble(AMOUNT.CalcValue)).ToString();
            }
            else if(stockAction is VoucherReturnDocument)
            {
                VoucherReturnDocumentMaterial returningMaterial = (VoucherReturnDocumentMaterial)MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(VoucherReturnDocumentMaterial));
                REQUIREAMOUNT.CalcValue = returningMaterial.RequireAmount.ToString();
                UNITPRICE.CalcValue = (Convert.ToDouble(returningMaterial.TotalPrice) / Convert.ToDouble(AMOUNT.CalcValue)).ToString();
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

        public ReturningDocumentReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Dağıtım Belgesi", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RETURNINGDOCUMENTREPORT";
            Caption = "İade Belgesi Raporu";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabanciDxManagement.ServiceReference1;
using System.ServiceModel;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using ClosedXML.Excel;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using SabanciDxManagement.Model;
using SabanciDxManagement.Helper;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Sinks.File;
using Serilog.Sinks.RollingFile;
using Serilog.Configuration;

namespace SabanciDxManagement
{
    class Program
    {

        static TimeSpan Timeout = new TimeSpan(0, 10, 0);
        static string Password = ConfigurationManager.AppSettings["pass"];
        static string destDir = "";
        static string destFileName = "";
        static string connectionString => ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        static string sql = "INSERT INTO [dbo].[EmployeeDx]([Caskerh],[Ccalgrb],[Ccikisn],[Ccikist],[Cdogtar],[Cfnksyn],[Cgirist],[Chukkod],[Ciliadi],[Cilkgir],[Cisyeri],[Ckadadt],[Ckangrb],[Ckunvan],[Cmedhal],[Cogrsev],[Corgadt],[Corgkod],[Cperbad],[Cpercin],[Cpersad],[Cpozkod],[Csakkod2],[Csicili],[Cyakren],[IsMailAdresi],[MasrafYeriAdi],[MasrafYeriKodu],[OzelMailAdresi],[TcKimlikNo],[UnvanAciklamasi],[UnvanKodu],[YoneticiPozisyonAdi],[YoneticiPozisyonKodu],[calisanGrupKodu],[DateCreated],[IsActive]) VALUES(@Caskerh, @Ccalgrb, @Ccikisn, @Ccikist, @Cdogtar, @Cfnksyn, @Cgirist, @Chukkod, @Ciliadi, @Cilkgir, @Cisyeri, @Ckadadt, @Ckangrb, @Ckunvan, @Cmedhal, @Cogrsev, @Corgadt, @Corgkod, @Cperbad, @Cpercin, @Cpersad, @Cpozkod, @Csakkod2, @Csicili, @Cyakren, @IsMailAdresi, @MasrafYeriAdi, @MasrafYeriKodu, @OzelMailAdresi, @TcKimlikNo, @UnvanAciklamasi,@UnvanKodu, @YoneticiPozisyonAdi, @YoneticiPozisyonKodu,@calisanGrupKodu,@DateCreated, @IsActive)";
        static string selectSql = "SELECT [ID],[Caskerh],[Ccalgrb],[Ccikisn],[Ccikist],[Cdogtar],[Cfnksyn],[Cgirist],[Chukkod],[Ciliadi],[Cilkgir],[Cisyeri],[Ckadadt],[Ckangrb],[Ckunvan],[Cmedhal],[Cogrsev],[Corgadt],[Corgkod],[Cperbad],[Cpercin],[Cpersad] ,[Cpozkod],[Csakkod2],[Csicili],[Cyakren],[IsMailAdresi],[MasrafYeriAdi],[MasrafYeriKodu],[OzelMailAdresi],[TcKimlikNo],[UnvanAciklamasi],[UnvanKodu],[YoneticiPozisyonAdi],[YoneticiPozisyonKodu],[DateCreated],[DateModified],[IsActive] FROM [EmployeeDx]";
        static string truncateSql = "truncate table EmployeeDx";
        static ILogger<Program> logProvider;



        static void Main(string[] args)
        {
            ConfigureLog();
            
            Stopwatch stopwatch = new Stopwatch();
            KWebServiceDincer2Client kWebServiceDincer = new KWebServiceDincer2Client();
            ConfigureEndPoint(kWebServiceDincer);
            try
            {
                stopwatch.Start();
                logProvider.LogInformation($"Personel Info Getting From Service");
                var sonucBean = GetPersonelInfo(kWebServiceDincer);
                stopwatch.Stop();
                logProvider.LogInformation($"Personel Info Getting Service Finished:{stopwatch.ElapsedMilliseconds.ToString()} milisecods");

                if (sonucBean.resultMessage == "Başarılı")
                {
                    stopwatch.Start();
                    AddRecordsToDb(sonucBean.personelBeans);
                    stopwatch.Stop();
                    logProvider.LogInformation($"Add To Database  Finished:{stopwatch.ElapsedMilliseconds.ToString()} milisecods");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sbException = new StringBuilder();
                do
                {
                    sbException.Append(ex.Message);
                    ex = ex.InnerException;
                } while (ex.InnerException != null);
                logProvider.LogError($"Getting Personel An Exception Occured {sbException.ToString()}");
            }

        }

        static SonucBean GetPersonelInfo(KWebServiceDincer2Client kWebServiceDincer)
        {
            var result = kWebServiceDincer.getPersonelBilgileri(Password);
            return result;
        }

        static void ConfigureEndPoint(KWebServiceDincer2Client kWebServiceDincer)
        {
            BasicHttpBinding httpBinding = kWebServiceDincer.Endpoint.Binding as BasicHttpBinding;
            httpBinding.MaxReceivedMessageSize = int.MaxValue;
            httpBinding.SendTimeout = Timeout;
            httpBinding.OpenTimeout = Timeout;
            httpBinding.ReceiveTimeout = Timeout;
            httpBinding.CloseTimeout = Timeout;
        }

        private static IEnumerable<Personel> GetAllPersonelsFromDb()
        {
            List<Personel> _list = new List<Personel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open(); 

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = selectSql;
                        using (SqlDataReader d = cmd.ExecuteReader())
                        {
                            if (d.HasRows)
                            {
                                while (d.Read())
                                {
                                    _list.Add(new Personel
                                    {
                                        Caskerh = (d["Caskerh"] is DBNull) ? "" : d["Caskerh"].ToString(),
                                        Ccalgrb = (d["Ccalgrb"] is DBNull) ? "" : d["Ccalgrb"].ToString(),
                                        Ccikisn = (d["Ccikisn"] is DBNull) ? "" : d["Ccikisn"].ToString(),
                                        Ccikist = (d["Ccikist"] is DBNull) ? "" : d["Ccikist"].ToString(),
                                        Cdogtar = (d["Cdogtar"] is DBNull) ? "" : d["Cdogtar"].ToString(),
                                        Cfnksyn = (d["Cfnksyn"] is DBNull) ? "" : d["Cfnksyn"].ToString(),
                                        Cgirist = (d["Cgirist"] is DBNull) ? "" : d["Cgirist"].ToString(),
                                        Chukkod = (d["Chukkod"] is DBNull) ? "" : d["Chukkod"].ToString(),
                                        Ciliadi = (d["Ciliadi"] is DBNull) ? "" : d["Ciliadi"].ToString(),
                                        Cilkgir = (d["Cilkgir"] is DBNull) ? "" : d["Cilkgir"].ToString(),
                                        Cisyeri = (d["Cisyeri"] is DBNull) ? "" : d["Cisyeri"].ToString(),
                                        Ckadadt = (d["Ckadadt"] is DBNull) ? "" : d["Ckadadt"].ToString(),
                                        Ckangrb = (d["Ckangrb"] is DBNull) ? "" : d["Ckangrb"].ToString(),
                                        Ckunvan = (d["Ckunvan"] is DBNull) ? "" : d["Ckunvan"].ToString(),
                                        Cmedhal = (d["Cmedhal"] is DBNull) ? "" : d["Cmedhal"].ToString(),
                                        Cogrsev = (d["Cogrsev"] is DBNull) ? "" : d["Cogrsev"].ToString(),
                                        Corgadt = (d["Corgadt"] is DBNull) ? "" : d["Corgadt"].ToString(),
                                        Corgkod = (d["Corgkod"] is DBNull) ? "" : d["Corgkod"].ToString(),
                                        Cperbad = (d["Cperbad"] is DBNull) ? "" : d["Cperbad"].ToString(),
                                        Cpercin = (d["Cpercin"] is DBNull) ? "" : d["Cpercin"].ToString(),
                                        Cpozkod = (d["Cpozkod"] is DBNull) ? "" : d["Cpozkod"].ToString(),
                                        Csakkod2 = (d["Csakkod2"] is DBNull) ? "" : d["Csakkod2"].ToString(),
                                        Csicili = (d["Csicili"] is DBNull) ? "" : d["Csicili"].ToString(),
                                        Cyakren = (d["Cyakren"] is DBNull) ? "" : d["Cyakren"].ToString(),
                                        IsMailAdresi = (d["IsMailAdresi"] is DBNull) ? "" : d["IsMailAdresi"].ToString(),
                                        MasrafYeriAdi = (d["MasrafYeriAdi"] is DBNull) ? "" : d["MasrafYeriAdi"].ToString(),
                                        OzelMailAdresi = (d["OzelMailAdresi"] is DBNull) ? "" : d["OzelMailAdresi"].ToString(),
                                        MasrafYeriKodu = (d["MasrafYeriKodu"] is DBNull) ? "" : d["MasrafYeriKodu"].ToString(),
                                        TcKimlikNo = (d["TcKimlikNo"] is DBNull) ? "" : d["TcKimlikNo"].ToString(),
                                        UnvanAciklamasi = (d["UnvanAciklamasi"] is DBNull) ? "" : d["UnvanAciklamasi"].ToString(),
                                        UnvanKodu = (d["UnvanKodu"] is DBNull) ? "" : d["UnvanKodu"].ToString(),
                                        Cpersad = (d["Cpersad"] is DBNull) ? "" : d["Cpersad"].ToString(),
                                        YoneticiPozisyonAdi = (d["YoneticiPozisyonAdi"] is DBNull) ? "" : d["YoneticiPozisyonAdi"].ToString(),
                                        YoneticiPozisyonKodu = (d["YoneticiPozisyonKodu"] is DBNull) ? "" : d["YoneticiPozisyonKodu"].ToString()
                                    });
                                } 
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                /*log exception*/
            }
            finally
            {

            }
            return _list;
        }


        private static void AddRecordsToDb(PersonelValue[] personelValues)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                //Silme İşlemi yapıyor transaction da
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = connection;
                cmdDelete.Transaction = transaction;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = truncateSql;
                cmdDelete.ExecuteNonQuery();

                foreach (var personel in personelValues)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 30;
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    if (!string.IsNullOrEmpty(personel.caskerh))
                        cmd.Parameters.Add("@Caskerh", SqlDbType.NVarChar).Value = personel.caskerh;
                    else
                        cmd.Parameters.Add("@Caskerh", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ccalgrb))
                        cmd.Parameters.Add("@Ccalgrb", SqlDbType.NVarChar).Value = personel.ccalgrb;
                    else
                        cmd.Parameters.Add("@Ccalgrb", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ccikisn))
                        cmd.Parameters.Add("@Ccikisn", SqlDbType.NVarChar).Value = personel.ccikisn;
                    else
                        cmd.Parameters.Add("@Ccikisn", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ccikist))
                        cmd.Parameters.Add("@Ccikist", SqlDbType.NVarChar).Value = personel.ccikist;
                    else
                        cmd.Parameters.Add("@Ccikist", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cdogtar))
                        cmd.Parameters.Add("@Cdogtar", SqlDbType.NVarChar).Value = personel.cdogtar;
                    else
                        cmd.Parameters.Add("@Cdogtar", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.cfnksyn))
                        cmd.Parameters.Add("@Cfnksyn", SqlDbType.NVarChar).Value = personel.cfnksyn;
                    else
                        cmd.Parameters.Add("@Cfnksyn", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cgirist))
                        cmd.Parameters.Add("@Cgirist", SqlDbType.NVarChar).Value = personel.cgirist;
                    else
                        cmd.Parameters.Add("@Cgirist", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.chukkod))
                        cmd.Parameters.Add("@Chukkod", SqlDbType.NVarChar).Value = personel.chukkod;
                    else
                        cmd.Parameters.Add("@Chukkod", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ciliadi))
                        cmd.Parameters.Add("@Ciliadi", SqlDbType.NVarChar).Value = personel.ciliadi;
                    else
                        cmd.Parameters.Add("@Ciliadi", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cilkgir))
                        cmd.Parameters.Add("@Cilkgir", SqlDbType.NVarChar).Value = personel.cilkgir;
                    else
                        cmd.Parameters.Add("@Cilkgir", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cisyeri))
                        cmd.Parameters.Add("@Cisyeri", SqlDbType.NVarChar).Value = personel.cisyeri;
                    else
                        cmd.Parameters.Add("@Cisyeri", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ckadadt))
                        cmd.Parameters.Add("@Ckadadt", SqlDbType.NVarChar).Value = personel.ckadadt;
                    else
                        cmd.Parameters.Add("@Ckadadt", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ckangrb))
                        cmd.Parameters.Add("@Ckangrb", SqlDbType.NVarChar).Value = personel.ckangrb;
                    else
                        cmd.Parameters.Add("@Ckangrb", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ckunvan))
                        cmd.Parameters.Add("@Ckunvan", SqlDbType.NVarChar).Value = personel.ckunvan;
                    else
                        cmd.Parameters.Add("@Ckunvan", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cmedhal))
                        cmd.Parameters.Add("@Cmedhal", SqlDbType.NVarChar).Value = personel.cmedhal;
                    else
                        cmd.Parameters.Add("@Cmedhal", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.cogrsev))
                        cmd.Parameters.Add("@Cogrsev", SqlDbType.NVarChar).Value = personel.cogrsev;
                    else
                        cmd.Parameters.Add("@Cogrsev", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.corgadt))
                        cmd.Parameters.Add("@Corgadt", SqlDbType.NVarChar).Value = personel.corgadt;
                    else
                        cmd.Parameters.Add("@Corgadt", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.corgkod))
                        cmd.Parameters.Add("@Corgkod", SqlDbType.NVarChar).Value = personel.corgkod;
                    else
                        cmd.Parameters.Add("@Corgkod", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cperbad))
                        cmd.Parameters.Add("@Cperbad", SqlDbType.NVarChar).Value = personel.cperbad;
                    else
                        cmd.Parameters.Add("@Cperbad", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cpercin))
                        cmd.Parameters.Add("@Cpercin", SqlDbType.NVarChar).Value = personel.cpercin;
                    else
                        cmd.Parameters.Add("@Cpercin", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cpersad))
                        cmd.Parameters.Add("@Cpersad", SqlDbType.NVarChar).Value = personel.cpersad;
                    else
                        cmd.Parameters.Add("@Cpersad", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cpozkod))
                        cmd.Parameters.Add("@Cpozkod", SqlDbType.NVarChar).Value = personel.cpozkod;
                    else
                        cmd.Parameters.Add("@Cpozkod", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.csakkod2))
                        cmd.Parameters.Add("@Csakkod2", SqlDbType.NVarChar).Value = personel.csakkod2;
                    else
                        cmd.Parameters.Add("@Csakkod2", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.csicili))
                        cmd.Parameters.Add("@Csicili", SqlDbType.NVarChar).Value = personel.csicili;
                    else
                        cmd.Parameters.Add("@Csicili", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.cyakren))
                        cmd.Parameters.Add("@Cyakren", SqlDbType.NVarChar).Value = personel.cyakren;
                    else
                        cmd.Parameters.Add("@Cyakren", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.ismailadresi))
                        cmd.Parameters.Add("@IsMailAdresi", SqlDbType.NVarChar).Value = personel.ismailadresi;
                    else
                        cmd.Parameters.Add("@IsMailAdresi", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.masrafyeriadi))
                        cmd.Parameters.Add("@MasrafYeriAdi", SqlDbType.NVarChar).Value = personel.masrafyeriadi;
                    else
                        cmd.Parameters.Add("@MasrafYeriAdi", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.masrafyerikodu))
                        cmd.Parameters.Add("@MasrafYeriKodu", SqlDbType.NVarChar).Value = personel.masrafyerikodu;
                    else
                        cmd.Parameters.Add("@MasrafYeriKodu", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.ozelmailadresi))
                        cmd.Parameters.Add("@OzelMailAdresi", SqlDbType.NVarChar).Value = personel.ozelmailadresi;
                    else
                        cmd.Parameters.Add("@OzelMailAdresi", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.tckimlikno))
                        cmd.Parameters.Add("@TcKimlikNo", SqlDbType.NVarChar).Value = personel.tckimlikno;
                    else
                        cmd.Parameters.Add("@TcKimlikNo", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.unvanaciklamasi))
                        cmd.Parameters.Add("@UnvanAciklamasi", SqlDbType.NVarChar).Value = personel.unvanaciklamasi;
                    else
                        cmd.Parameters.Add("@UnvanAciklamasi", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (!string.IsNullOrEmpty(personel.unvankodu))
                        cmd.Parameters.Add("@UnvanKodu", SqlDbType.NVarChar).Value = personel.unvankodu;
                    else
                        cmd.Parameters.Add("@UnvanKodu", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.yoneticipozisyonadi))
                        cmd.Parameters.Add("@YoneticiPozisyonAdi", SqlDbType.NVarChar).Value = personel.yoneticipozisyonadi;
                    else
                        cmd.Parameters.Add("@YoneticiPozisyonAdi", SqlDbType.NVarChar).Value = DBNull.Value;
                    if (!string.IsNullOrEmpty(personel.yoneticipozisyonkodu))
                        cmd.Parameters.Add("@YoneticiPozisyonKodu", SqlDbType.NVarChar).Value = personel.yoneticipozisyonkodu;
                    else
                        cmd.Parameters.Add("@YoneticiPozisyonKodu", SqlDbType.NVarChar).Value = DBNull.Value;
                    
                    if (!string.IsNullOrEmpty(personel.calisanGrupKodu))
                        cmd.Parameters.Add("@calisanGrupKodu", SqlDbType.NVarChar).Value = personel.calisanGrupKodu;
                    else
                        cmd.Parameters.Add("@calisanGrupKodu", SqlDbType.NVarChar).Value = DBNull.Value;
                  

                    cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
                    cmd.ExecuteNonQuery();
                };


                try { transaction.Commit(); }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    StringBuilder sbException = new StringBuilder();
                    while (ex.InnerException != null)
                    {
                        sbException.Append(ex.InnerException);
                        ex = ex.InnerException;
                    }
                    logProvider.LogError($"Adding Data To Db An Exception Occured {sbException.ToString()}");
                }
            }
        }

        private static bool DeleteRecordsFromDb()
        {
            bool isValid = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = truncateSql;
                        cmd.ExecuteNonQuery();
                    }
                  isValid=true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }


        private static void ExportDataSetToExcel(DataSet ds)
        {
            try
            {
                string tempFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "") + "\\ExcelFiles\\DataFileTemplate.xlsx";

                destDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "") + "\\ExcelFiles\\";
                destFileName = "Comparement_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xlsx";

                File.Copy(Path.Combine(destDir, "DataFileTemplate.xlsx"), Path.Combine(destDir, destFileName), true);

                using (XLWorkbook xlWorkbook = new XLWorkbook())
                {
                    xlWorkbook.Worksheets.Add(ds.Tables[0]);
                    xlWorkbook.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xlWorkbook.Style.Font.Bold = true;
                    xlWorkbook.SaveAs(destDir + destFileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public static void SendMail()
        {
            try
            {
                using (var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["host"].ToString())) // outlook.office365.com, smtp-mail.outlook.com, smtp.office365.com
                {
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"].ToString(), ConfigurationManager.AppSettings["password"].ToString()); //new NetworkCredential("bildiri@dincerlojistik.com", "Dl2019!!"),
                    smtpClient.EnableSsl = true;

                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress(ConfigurationManager.AppSettings["from"].ToString())
                    };

                    string[] separator = new string[1] { ";" };

                    string to = ConfigurationManager.AppSettings["to"].ToString();
                    foreach (string addresses in to.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                        message.To.Add(addresses);

                    string cc = ConfigurationManager.AppSettings["cc"].ToString();
                    foreach (string addresses in cc.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                        message.CC.Add(addresses);

                    string bcc = ConfigurationManager.AppSettings["bcc"].ToString();
                    foreach (string addresses in bcc.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                        message.Bcc.Add(addresses);

                    message.IsBodyHtml = true;
                    message.Body = "<p> Merhaba,</p>" +
                                    "<p> </p>" +
                                    "<p> Karşılaştırma dokümanı ektedir.</p>" +
                                    "<p> </p>" +
                                    "<p> Bilginize.</p>";
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = ConfigurationManager.AppSettings["subject"].ToString();
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    Attachment attachment = new Attachment(destDir + destFileName);
                    message.Attachments.Add(attachment);

                    smtpClient.Send(message);

                    message.Dispose(); // File.Delete komutu sonrası "the process cannot access the file ..."  hatasını önlemek için.

                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry("StockComparementSender : Successfully finished and mail sent", EventLogEntryType.Information, 101, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("StockComparementSender : " + ex.Message, EventLogEntryType.Information, 101, 1);
                }
            }
            finally
            {
                if (File.Exists(destDir + destFileName))
                {
                    try
                    {
                        File.Delete(destDir + destFileName);
                    }
                    catch (IOException e)
                    {
                    }
                }
            }
        }

        private static void ConfigureLog()
        {
            var loggerFactory = new LoggerFactory();
            var loggerConfig = new LoggerConfiguration()
                
                .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            loggerFactory.AddSerilog(loggerConfig);
            // create logger and put it to work.
            logProvider = loggerFactory.CreateLogger<Program>();
            //logProvider.LogDebug("debugging");
        }
    }
}

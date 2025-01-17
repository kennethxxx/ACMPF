﻿using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Data;
//using Newtonsoft.Json;
using PrivateWorker.FileUploadService;
using PrivateWorker.OntologyService;
//using Program.VMTServiceReference;
using PrivateWorker.TimeService;
using PrivateWorker.VMTServiceForCuttingTool;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace PrivateWorker
{
    public class WorkerRole
    {
        BasicHttpBinding binding = new BasicHttpBinding();
        Receive_ModulePortTypeChannel channelOntology;
        //int lockStep = -1;
        bool lockWork = false;
        MySqlCommand cmd;
        MySqlConnection con;
        MySqlDataReader reader;

        readonly EndpointAddress nckuEpAddress = new EndpointAddress("http://140.116.86.172/ServiceBroker/Service1.svc?wsdl");
        readonly EndpointAddress chevalierEpAddress = new EndpointAddress("http://114.33.127.121/ServiceBroker/Service1.svc?wsdl");


        #region MultiplayerArchitecture

        public void MultiplayerArchitecture()
        {
            String Table_In = "table_in";
            String Table_Out = "table_out";
            con = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString);
            while (true)
            {             
                con.Open();
                bool isMatchData = false;
                do
                {
                    try
                    {
                        TableDataClass query = new TableDataClass();
                        if (lockWork == false)
                        {
                            TableDataClass tempquery = new TableDataClass();
                            String Query = "SELECT * FROM " + Table_In;
                            cmd = new MySqlCommand(Query, con);
                            reader = cmd.ExecuteReader(CommandBehavior.SingleRow);                         
                            if (reader.HasRows) //抓取talbe_in的值並將各欄位的值傳入tempquery
                            {
                                reader.Read();
                                tempquery.UserID = reader["UserID"].ToString();
                                tempquery.FunctionCodeIndicator = reader["FunctionCodeIndicator"].ToString();
                                tempquery.FunctionData = reader["FunctionData"].ToString();
                                tempquery.CurrentJob = reader["CurrentJob"].ToString();
                                tempquery.LastJob = reader["LastJob"].ToString();
                                tempquery.WorkerRoleID = reader["WorkerRoleID"].ToString();
                            }
                            reader.Close();
                            if (tempquery.FunctionCodeIndicator == null || tempquery.FunctionCodeIndicator == ""){
                                continue;                                   
                            }                          
                            Console.WriteLine(tempquery.FunctionCodeIndicator+" ("+tempquery.CurrentJob+"/"+tempquery.LastJob+")- Retrieve finish!");
                            query = tempquery;
                            if (!tempquery.Equals(null))
                            {
                                String Delete = "DELETE FROM " + Table_In + " where UserID='" + query.UserID + "' && CurrentJob='" + query.CurrentJob + "'&& LastJob='" + query.LastJob + "';";
                                MySqlCommand Delcmd = new MySqlCommand(Delete, con);
                                Delcmd.ExecuteNonQuery();
                                Delcmd.Dispose();
                                Console.WriteLine("Delete finish!");

                                System.Diagnostics.Debug.WriteLine("WokerRole1----------------------------");

                                if (query.UserID != null && query.FunctionCodeIndicator != null)
                                {
                                    lockWork = true;
                                }
                            }
                        }

                        if (!query.Equals(null) && query != null && lockWork == true)
                        {
                            string method = query.FunctionCodeIndicator;
                            string data = query.FunctionData;
                            string returnData = "";

                            if (!(query).Equals(null) && query != null)
                            {

                                //LogController.LogFile(query.UserID);
                                bool result = RegistrationServiceTable(query);
                                System.Diagnostics.Debug.WriteLine("result:" + result);
                                if (result == true)
                                {
                                    Console.WriteLine("Calculating...");
                                    returnData = OntologyServiceFunction(method, data);
                                    if (returnData == null || returnData == "")
                                    {
                                        Console.WriteLine("Calculation fail!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Calculation success!");
                                    }
                                }
                                else{}
                            }

                            if (!returnData.Equals("") && returnData != "")
                            {
                                query.FunctionData = returnData;
                                query.WorkerRoleID = "boyiliTest4";
                                string Insert = "INSERT INTO " + Table_Out + "(UserID,FunctionCodeIndicator,FunctionData,CurrentJob,LastJob,WorkerRoleID) values(@UserID,@FunctionCodeIndicator,@FunctionData,@CurrentJob,@LastJob,@WorkerRoleID);";
                                MySqlCommand InsertCmd = con.CreateCommand();
                                InsertCmd.CommandText = Insert;
                                InsertCmd.Parameters.AddWithValue("@UserID", query.UserID);
                                InsertCmd.Parameters.AddWithValue("@FunctionCodeIndicator", query.FunctionCodeIndicator);
                                InsertCmd.Parameters.AddWithValue("@FunctionData", query.FunctionData);
                                InsertCmd.Parameters.AddWithValue("@CurrentJob", query.CurrentJob);
                                InsertCmd.Parameters.AddWithValue("@LastJob", query.LastJob);
                                InsertCmd.Parameters.AddWithValue("@WorkerRoleID", query.WorkerRoleID);
                                InsertCmd.ExecuteNonQuery();
                                InsertCmd.Dispose();
                                Console.WriteLine("Return finish!");
                                //LogController.LogFile(query.UserID + " - Data Add Table Out");
                                lockWork = false;
                                isMatchData = true;
                            }
                        }
                    }
                    catch (TargetInvocationException e)
                    {
                        //Console.WriteLine("Unexpected exception: " + e.Message);
                        System.Diagnostics.Debug.WriteLine("WokerRole1" + e.Message);
                        //LogController.LogFile("WR" + e.Message);
                    }
                    catch (MySqlException e){                       
                    }
                    catch (Exception e){
                        //Console.WriteLine("Unexpected exception: " + e.Message);
                        //System.Diagnostics.Debug.WriteLine("WokerRole1" + e.Message);
                        //LogController.LogFile("WR" + e.Message);
                    }
                } 
                while (isMatchData == false);
                Thread.Sleep(1000);
                con.Close();
            }           
        }

        #region RegistrationServiceTable
        private bool RegistrationServiceTable(TableDataClass query)
        {
            bool returnbool = true;
            try
            {
                //string roleCommunicationServiceUri = "http://" + RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TomcatWeb80"].IPEndpoint + "/AMC_Ontology/services/Receive_Module?wsdl";
                //DBConnect dbconnect = new DBConnect("amc_refresh");
                //returnbool = dbconnect.registration_service_table_Select(query, roleCommunicationServiceUri);
                return returnbool;
            }
            catch (System.Exception e)
            {
                //LogController.LogFile("RegistrationServiceTable" + e.Message);
            }
            return returnbool;
        }
        #endregion

        public string GetTime()
        {
            string time = "";
            try
            {
                DataTimePortTypeChannel timeService = ChannelFactory<DataTimePortTypeChannel>.CreateChannel(binding, new EndpointAddress("http://140.116.86.249:8080/DataTime/services/DataTime?wsdl"));
                timeService.Open();
                TimeDisplayRequest timeDisplayRequest = new TimeDisplayRequest();
                TimeDisplayResponse timeDisplayResponse = timeService.TimeDisplay(timeDisplayRequest);
                time = timeDisplayResponse.@return;
                timeService.Close();
                return time;
            }
            catch (System.Exception e)
            {
                //LogController.LogFile("GetTime" + e.Message);
            }
            return time;
        }

        #region Ontology Service Distribution
        public string OntologyServiceFunction(string method, string data)
        {
            string returnString = "";
            try
            {
                Uri roleCommunicationServiceUri = new Uri("http://localhost:8080/AMCOntologyForCuttingTool/services/Receive_Module?wsdl");
                //Uri roleCommunicationServiceUri = new Uri(string.Format("http://{0}/AMC_Ontology/services/Receive_Module?wsdl", RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TomcatWeb80"].IPEndpoint));
                channelOntology = ChannelFactory<Receive_ModulePortTypeChannel>.CreateChannel(binding, new EndpointAddress(roleCommunicationServiceUri));
                channelOntology.Open();

                switch (method)
                {
                    case "CallOntologyDataBase":
                        returnString = CallLoadOntologyDB();
                        break;
                    case "CallOntologyRuleDataBase":
                        returnString = CallOntologyRuleDataBase(data);
                        break;
                    case "InferenceForCuttingTool":
                        returnString = InferenceForCuttingTool(data);
                        break;
                    case "CallVMTService":
                        returnString = VMTServcie(data);
                        break;

                    default:
                        return "沒有此函數!";
                }
                channelOntology.Close();

                return returnString;
            }
            catch (System.Exception e)
            {}
            return returnString;
        }

        #endregion

        #region  Step1. 讀取所有的Ontology資料庫
        private string CallLoadOntologyDB()
        {
            ShowAllOntologyRequest showAllOntologyRequest = new OntologyService.ShowAllOntologyRequest();
            ShowAllOntologyResponse showAllOntologyResponse = channelOntology.ShowAllOntology(showAllOntologyRequest);

            string showAllOntologyData = showAllOntologyResponse.@return;

            Trace.WriteLine("CallLoadOntologyDB", "Information");

            return showAllOntologyData;
        }
        #endregion

        #region  Step2. CallOntologyRuleDataBase
        private string CallOntologyRuleDataBase(string data)
        {

            ShowDataBaseTableRequest showDataBaseTableRequest = new ShowDataBaseTableRequest();
            showDataBaseTableRequest.DataBase = data;
            ShowDataBaseTableResponse showDataBaseTableResponse = channelOntology.ShowDataBaseTable(showDataBaseTableRequest);

            string showDataBaseTable = showDataBaseTableResponse.@return;


            Trace.WriteLine("CallOntologyRuleDataBase", "Information");

            return showDataBaseTable;
        }
        #endregion

        #region  Step3. InferenceForCuttingTool
        private string InferenceForCuttingTool(string data)
        {
            InferenceForCuttingToolRequest inferenceForCuttingToolRequest = new InferenceForCuttingToolRequest();
            channelOntology.OperationTimeout = TimeSpan.FromMinutes(5);

            inferenceForCuttingToolRequest.ontologyFile = "CuttingToolOntology";
            inferenceForCuttingToolRequest.inferData = data;
            InferenceForCuttingToolResponse inferenceForCuttingToolResponse = channelOntology.InferenceForCuttingTool(inferenceForCuttingToolRequest);


            string inferenceForCuttingTool = inferenceForCuttingToolResponse.@return;


            Trace.WriteLine("InferenceForCuttingTool", "Information");

            return inferenceForCuttingTool;
        }
        #endregion

        #region  Step4. VMTServcie
        private string VMTServcie(string data)
        {

            Uri roleCommunicationVMTServiceUri = new Uri("http://localhost:8080/VEServiceForCuttingTool/services/VMTService?wsdl");
            VMTServicePortTypeChannel channelVMTService = ChannelFactory<VMTServiceForCuttingTool.VMTServicePortTypeChannel>.CreateChannel(binding, new EndpointAddress(roleCommunicationVMTServiceUri));
            channelVMTService.Open();
            channelVMTService.OperationTimeout = TimeSpan.FromMinutes(5);

            VMTServiceForCuttingToolRequest vmtServiceForCuttingToolRequest = new VMTServiceForCuttingToolRequest();
            vmtServiceForCuttingToolRequest.NCFilePathList = data;

            VMTServiceForCuttingToolResponse vmtServiceForCuttingToolResponse = channelVMTService.VMTServiceForCuttingTool(vmtServiceForCuttingToolRequest);


            string vmtServiceForCuttingTool = vmtServiceForCuttingToolResponse.@return;

            Trace.WriteLine("VMTServcie", "Information");
            channelVMTService.Close();
            return vmtServiceForCuttingTool;
        }
        #endregion      

        #region  上傳CL檔與NC檔
        private string UploadFile1(string fileName, Stream strm, string filename)
        {
            byte[] buffer = new byte[strm.Length];
            strm.Read(buffer, 0, (int)strm.Length);
            strm.Dispose();
            strm.Close();

            UploadFile file = new UploadFile();
            file.FileName = fileName;
            file.File = buffer;
            string newfilename = filename;
            if (newfilename != "")
            {
                IService1Channel channelFileUpload = ChannelFactory<IService1Channel>.CreateChannel(binding, new EndpointAddress("http://140.116.86.249/FileUploadService/Service1.svc?wsdl"));
                channelFileUpload.SaveFile2(file, "CNC");

                return "上傳成功!";
            }
            else
            {
                return "上傳失敗!";
            }
        }
        #endregion

        #endregion

    }
}

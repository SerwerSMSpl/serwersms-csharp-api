/*
 * Created by SharpDevelop.
 * User: Przemek
 * Date: 15.01.2016
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using serwersms.lib;

namespace serwersms
{
	
	public class SerwerSMS
	{
		
		private const string api_url 		= "http://s1api2.serwersms.pl/";
		private const string system	 			= "client_csharp";
		private string username 			= null;
		private string password 			= null;
		public string format	 			= "json";
		
		
		public Messages messages 			= null;
		public Files files 					= null;
		public Blacklist blacklist 			= null;
		public Errors error 				= null;
		public Phones phones 				= null;
		public Stats stats 					= null;
		public Account account 				= null;
		public Contacts contacts 			= null;
		public Groups groups 				= null;
		public Payments payments 			= null;
		public Senders senders	 			= null;
		public Premium premium	 			= null;
		public Templates templates	 		= null;
		public Subaccounts subaccounts	 	= null;
			
		
		public SerwerSMS( String username, String password ){
		
			if( string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ){
				throw new Exception("Brak danych");
			}
			
			
			this.username 	= 	username;
			this.password 	= 	password;
			
			this.messages 	= 	new Messages(this);
			this.files 		= 	new Files(this);
			this.blacklist  = 	new Blacklist(this);
			this.error 		= 	new Errors(this);
			this.phones 	= 	new Phones(this);
			this.stats 		= 	new Stats(this);
			this.account 	= 	new Account(this);
			this.contacts 	= 	new Contacts(this);
			this.groups		= 	new Groups(this);
			this.payments	= 	new Payments(this);
			this.senders	= 	new Senders(this);
			this.premium	= 	new Premium(this);
			this.templates	= 	new Templates(this);
			this.subaccounts= 	new Subaccounts(this);
					
		}
		
		public Object call( String url, Dictionary<String, String> data )
        {

			data["username"] = this.username;
			data["password"] = this.password;
			data["system"]   = system;
			string json = JsonConvert.SerializeObject(data);
		
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_url+url+"."+format);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8"; 
            request.Accept = "application/json; charset=utf-8";
            
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            requestWriter.Write(json);
            requestWriter.Close();

            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            
            if( this.format == "xml" ){
            	
                XmlDocument xmlDoc = new XmlDocument();
    			xmlDoc.LoadXml(responseReader.ReadToEnd());
                
    			return xmlDoc;
    			
            }else{
            
            	return responseReader.ReadToEnd();
            	
            }      
		
        }
		public Stream callStream( String url, Dictionary<String, String> data )
        {

			data["username"] = this.username;
			data["password"] = this.password;
			data["system"] 	 = system;
			string json = JsonConvert.SerializeObject(data);
			
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_url+url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8"; 
            request.Accept = "application/json; charset=utf-8";
            
            
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            requestWriter.Write(json);
            requestWriter.Close();

            WebResponse webResponse = request.GetResponse();
           
            Stream webStream = webResponse.GetResponseStream();
            
            return webStream;
            
        }
		
	}
}
# SerwerSMS - C Sharp
Klient C Sharp do komunikacji zdalnej z API v2 SerwerSMS.pl

Zalecane jest, aby komunikacja przez HTTPS API odbywała się z loginów utworzonych specjalnie do połączenia przez API. Konto użytkownika API można utworzyć w Panelu Klienta → Ustawienia interfejsów → HTTPS XML API → Użytkownicy.

Przykładowe wywołanie
```c#
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using Newtonsoft.Json;
        using serwersms;
        using System.Web;
        using System.IO;
        using System.Xml;
        
        namespace example
        {
        	class example
        	{
        		public static void Main(string[] args)
        		{
        		    try{
        		    
            			var serwerssms = new SerwerSMS("username","password");
            			var data = new Dictionary<string, string>();
            			data.Add("test" , "0" );
            			serwerssms.format = "json";
            			var response  = serwerssms.senders.index(data).ToString();
            			/*
            			    serwerssms.format = "xml";
            			    XmlDocument response  = serwerssms.senders.index(data);
            			    XmlNodeList elemlist = response.GetElementsByTagName("message");
			                string result = elemlist[0].InnerXml; 
			                Console.WriteLine(result);
            			*/
            			Console.WriteLine(response);
            			
        			} catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
        			Console.ReadKey(true);
        		}
        	}
        }
```
Wysyłka SMS
```c#

        try{
        		    
			var serwerssms = new SerwerSMS("username","password");
			var data = new Dictionary<string, string>();
            
            // SMS FULL
            
            String phone = "500600700";
            String text = "text";
            String sender = "INFORMACJA";
            data.Add("details" , "1" );
			var response  = serwerssms.messages.sendSms(phone,text,sender,data).ToString();
			Console.WriteLine(response);
			
			// SMS ECO
			
			String phone = "500600700";
            String text = "text";
            String sender = null;
			var response  = serwerssms.messages.sendSms(phone,text,sender,data).ToString();
			Console.WriteLine(response);
			
			// VOICE from text
			
			String phone = "500600700";
            data.Add("text" , text );
            var response  = serwerssms.messages.sendVoice(phone, data).ToString();
			Console.WriteLine(response);
			
			// MMS
			
			String phone = "500600700";
            data.Add("title" , "text" );
            data.Add("file_id" , "1f9e980e87" );
            var response  = serwerssms.messages.sendMms(phone, data).ToString();
			Console.WriteLine(response);
			
	} catch (Exception e) {
        Console.WriteLine(e.Message);
    };
```        
Wysyłka spersonalizowanych SMS
```c#

    try{
        		    
			var serwerssms = new SerwerSMS("username","password");
			var data = new Dictionary<string, string>();
           
            String sender = "INFORMACJA";
            
            var item = new Dictionary<string, string>();
			item.Add("phone", "500600700");
			item.Add("text", "test");
			
			var item1 = new Dictionary<string, string>();
			
			item1.Add("phone", "500600700");
			item1.Add("text", "test2");
			
			List<Dictionary<string,string>> messages = new List <Dictionary<string, string>>();
			messages.Add(item);
			messages.Add(item1);
            
			var response  = serwerssms.messages.sendPersonalized(messages,sender,data).ToString();
			Console.WriteLine(response);
			
	} catch (Exception e) {
        Console.WriteLine(e.Message);
    };
```
Pobieranie raportów doręczeń
```c#

    try{
        		    
			var serwerssms = new SerwerSMS("username","password");
			var data = new Dictionary<string, string>();
            data.Add("test" , "1" );
            data.Add("id","c7d505d346,4fbf1cd942");
			var response  = serwerssms.messages.reports(data).ToString();
			Console.WriteLine(response);
			
	} catch (Exception e) {
        Console.WriteLine(e.Message);
    };
```
Pobieranie wiadomości przychodzących
```c#

    try{
        		    
			var serwerssms = new SerwerSMS("username","password");
			var data = new Dictionary<string, string>();
            data.Add("test" , "1" );
            String type = "eco";
			var response  = serwerssms.messages.recived(type, data).ToString();
			Console.WriteLine(response);
			
	} catch (Exception e) {
        Console.WriteLine(e.Message);
    };
```
## Wymagania

C# ver. 6.0

## Dokumentacja
http://dev.serwersms.pl

Konsola

http://apiconsole.serwersms.pl/

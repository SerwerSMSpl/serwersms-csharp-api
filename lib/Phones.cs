/*
 * Created by SharpDevelop.
 * User: Przemek
 * Date: 18.01.2016
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using serwersms;

namespace serwersms.lib
{
	
	public class Phones
	{
		private SerwerSMS obj = null;
		
		public Phones( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Checking phone in to HLR
		 * 
		 * @param String phone
		 * @param String id Query ID returned if the processing takes longer than 60 seconds
		 * @return array
		 *      @option String "phone"
		 *      @option String "status"
		 *      @option int "imsi"
		 *      @option String "network"
		 *      @option bool "ported"
		 *      @option String "network_ported"
		 */
		public Object check( String phone, String id = null ) {
	        	
			var data = new Dictionary<String, String>();
			
			data.Add("phone", phone);
			data.Add("id", id);
			
	        return this.obj.call("phones/check",data);
	    
	    }
		/**
		 * Validating phone number
		 * 
		 * @param String phone
		 * @return array
		 *      @option bool "correct"
		 */
		public Object test( String phone ) {
	        	
			var data = new Dictionary<String, String>();
			
			data.Add("phone", phone);
			
	        return this.obj.call("phones/test",data);
	    
	    }
	}
	
}

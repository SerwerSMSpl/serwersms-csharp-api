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
	
	public class Senders
	{
		private SerwerSMS obj = null;
		
		public Senders( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Creating new Sender name
		 * 
		 * @param string name
		 * @return array
		 *      @option Boolean "success"
		 */
		public Object add( String name ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("name",name);
			
	        return this.obj.call("senders/add",data);
	    
	    }
		/**
		 * Senders list
		 * 
		 * @param array params
		 *      @option Boolean "predefined"
	     *      @option string "sort" Values: name
	     *      @option string "order" Values: asc|desc
		 * @return array
		 *      @option array "items"
		 *          @option string "name"
		 *          @option string "agreement" delivered|required|not_required
		 *          @option string "status" pending_authorization|authorized|rejected|deactivated
		 */
		public Object index( Dictionary<String, String> data = null ) {
	        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				data = arr;
				
			}
			
	        return this.obj.call("senders/index",data);
	    
	    }
	}
	
}

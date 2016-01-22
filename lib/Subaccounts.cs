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
	
	public class Subaccounts
	{
		private SerwerSMS obj = null;
		
		public Subaccounts( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Creating new subaccount
		 * 
		 * @param string $subaccount_username
		 * @param string $subaccount_password
		 * @param int $subaccount_id Subaccount ID, which is template of powers
		 * @param array $params
		 *      @option string "name"
		 *      @option string "phone"
		 *      @option string "email"
		 * @return type
		 */
		public Object add( String subaccount_username , String subaccount_password, String subaccount_id, Dictionary<String, String> data = null ) {
	        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("subaccount_username",subaccount_username);
				arr.Add("subaccount_password",subaccount_password);
				arr.Add("subaccount_id",subaccount_id);
				data = arr;
				
			}else{
				
				data.Add("subaccount_username",subaccount_username);
				data.Add("subaccount_password",subaccount_password);
				data.Add("subaccount_id",subaccount_id);
				
			}
			
	        return this.obj.call("subaccounts/add",data);
	    
	    }
		/**
		 * List of subaccounts
		 * 
		 * @return array
		 *      @option array "items"
		 *          @option int "id"
		 *          @option string "username"
		 */
		public Object index() {
        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("subaccounts/index",data);
	    
	    }
		/**
		 * View details of subaccount
		 * 
		 * @param int $id
		 * @return array
		 *      @option int "id"
		 *      @option string "username"
		 *      @option string "name"
		 *      @option string "phone"
		 *      @option string "email"
		 */
		public Object view( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("subaccounts/view",data);
	    
	    }
		
		/**
		 * Setting the limit on subaccount
		 * 
		 * @param int $id
		 * @param string $type Message type: eco|full|voice|mms|hlr
		 * @param int $val
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object limit( String id, String type, String val ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			data.Add("type",type);
			data.Add("value",val);
			
	        return this.obj.call("subaccounts/limit",data);
	    
	    }
		
		
		/**
		 * Deleting a subaccount
		 * 
		 * @param int $id
		 * @return array
		 *      @option bool "success"
		 */
		public Object delete( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("subaccounts/delete",data);
	    
	    }
		
	}
	
}

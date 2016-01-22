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
	
	public class Blacklist
	{
		private SerwerSMS obj = null;
		
		public Blacklist( SerwerSMS obj )
		{
			this.obj = obj;
		}
		/**
		 * Add phone to the blacklist
		 * 
		 * @param String phone
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object add( String phone ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("phone",phone);
	
	        return this.obj.call("blacklist/add",data);
	    
	    }
		/**
		 * List of blacklist phones
		 * 
		 * @param String phone
		 * @param array params
		 *      @option int "page" The number of the displayed page
		 *      @option int "limit" Limit items are displayed on the single page
		 * @return array
		 *      @option array "paging"
		 *          @option int "page" The number of current page
		 *          @option int "count" The number of all pages
		 *      @option array "items"
		 *          @option String "phone"
		 *          @option String "added" Date of adding phone
		 */
		public Object index( String phone = null, Dictionary<String, String> data = null ) {
	        	
			if( data == null ){
					
				var arr = new Dictionary<String, String>();
				arr.Add("phone",phone);
				data = arr;
				
			}else{
				
				data.Add("phone",phone);
				
			}
			
	        return this.obj.call("blacklist/index",data);
	    
	    }
		/**
		 * Checking if phone is blacklisted
		 * 
		 * @param String phone
		 * @return array
		 *      @option bool "exists"
		 */
		public Object check( String phone ) {
	        			
			var data = new Dictionary<String, String>();
			data.Add("phone",phone);
				
	        return this.obj.call("blacklist/check",data);
	    
	    }
		/**
		 * Deleting phone from the blacklist
		 * 
		 * @param String phone
		 * @return array
		 *      @option bool "success"
		 */
		public Object delete( String phone ) {
	        			
			var data = new Dictionary<String, String>();
			data.Add("phone",phone);
				
	        return this.obj.call("blacklist/delete",data);
	    
	    }
	}
	
}

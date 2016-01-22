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
	
	public class Account
	{
		private SerwerSMS obj = null;
		
		public Account( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Register new account
		 * 
		 * @param array $params
		 *      @option string "phone"
		 *      @option string "email"
		 *      @option string "first_name"
		 *      @option string "last_name"
		 *      @option string "company"
		 * @return array
		 *      @option bool "success"
		 */
		public Object add( Dictionary<String, String> data) {
	        	
	        return this.obj.call("account/add",data);
	    
	    }
		/**
		 * Return limits SMS
		 * 
		 * @return array
		 *      @option array "items"
		 *          @option string "type" Type of message
		 *          @option string "chars_limit" The maximum length of message
		 *          @option string "value" Limit messages
		 * 
		 */
		public Object limits() {
	        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("account/limits",data);
	    
	    }
		/**
		 * Return contact details
		 * 
		 * @return array
		 *      @option string "telephone"
		 *      @option string "email"
		 *      @option string "form"
		 *      @option string "faq"
		 *      @option array "quardian_account"
		 *          @option string "name"
		 *          @option string "email"
		 *          @option string "telephone"
		 *          @option string "photo"
		 */
		public Object help() {
	        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("account/help",data);
	    
	    }
		/**
		 * Return messages from the administrator
		 * 
		 * @return array
		 *      @option bool "new" Marking unread message
		 *      @option string "message" 
		 */
		public Object messages() {
	        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("account/messages",data);
	    
	    }
	}
	
}

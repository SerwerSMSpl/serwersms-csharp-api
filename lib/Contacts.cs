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
using Newtonsoft.Json;

namespace serwersms.lib
{
	
	public class Contacts
	{
		private SerwerSMS obj = null;
		
		public Contacts( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Add new contact
		 * 
		 * @param String group_id
		 * @param string phone
		 * @param array params
		 *      @option string "email"
		 *      @option string "first_name"
		 *      @option string "last_name"
		 *      @option string "company"
		 *      @option string "tax_id"
		 *      @option string "address"
		 *      @option string "city"
		 *      @option string "description"
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object add( String group_id, String phone,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("phone",phone);
				arr.Add("group_id",group_id);
				data = arr;
				
			}else{
				
				data.Add("phone",phone);
				data.Add("group_id",group_id);
				
			}
	        return this.obj.call("contacts/add",data);
	    
	    }
		/**
		 * List of contacts
		 * 
		 * @param string group_id
		 * @param string search
		 * @param array params
		 *      @option int "page" The number of the displayed page
		 *      @option int "limit" Limit items are displayed on the single page
	     *      @option string "sort" Values: first_name|last_name|phone|company|tax_id|email|address|city|description
	     *      @option string "order" Values: asc|desc
		 * @return array
		 *      @option array "paging"
		 *          @option int "page" The number of current page
		 *          @option int "count" The number of all pages
		 *      @options array "items"
		 *          @option int "id"
		 *          @option string "phone"
		 *          @option string "email"
		 *          @option string "company"
		 *          @option string "first_name"
		 *          @option string "last_name"
		 *          @option string "tax_id"
		 *          @option string "address"
		 *          @option string "city"
		 *          @option string "description"
		 *          @option bool "blacklist"
		 *          @option int "group_id"
		 *          @option string "group_name"
		 */
		public Object index( String group_id = null, String search = null,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("group_id",group_id);
				arr.Add("search",search);
				data = arr;
				
			}else{
				
				data.Add("group_id",group_id);
				data.Add("search",search);
				
			}
	        return this.obj.call("contacts/index",data);
	    
	    }
		/**
		 * View single contact
		 * 
		 * @param string id
		 * @return array
		 *      @option integer "id"
		 *      @option string "phone"
		 *      @option string "email"
		 *      @option string "company"
		 *      @option string "first_name"
		 *      @option string "last_name"
		 *      @option string "tax_id"
		 *      @option string "address"
		 *      @option string "city"
		 *      @option string "description"
		 *      @option bool "blacklist"
		 */
		public Object view( String id) {
        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);

	        return this.obj.call("contacts/view",data);
	    
	    }
		/**
		 * Editing a contact
		 * 
		 * @param int id
		 * @param int|array group_id
		 * @param string phone
		 * @param array params
		 *      @option string "email"
		 *      @option string "first_name"
		 *      @option string "last_name"
		 *      @option string "company"
		 *      @option string "tax_id"
		 *      @option string "address"
		 *      @option string "city"
		 *      @option string "description"
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object edit( String id, String group_id, String phone ,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("group_id",group_id);
				arr.Add("phone",phone);
				arr.Add("id",id);
				data = arr;
				
			}else{
				
				data.Add("group_id",group_id);
				data.Add("phone",phone);
				data.Add("id",id);
				
			}
	        return this.obj.call("contacts/edit",data);
	    
	    }
		/**
		 * Deleting a phone from contacts
		 * 
		 * @param string id
		 * @return array
		 *      @option bool "success"
		 */
		public Object delete( String id) {
        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);

	        return this.obj.call("contacts/delete",data);
	    
	    }
		/**
		 * Import contact list
		 * 
		 * @param string group_name
		 * @param array contact[]
		 *      @option string "phone"
		 *      @option string "email"
		 *      @option string "first_name"
		 *      @option string "last_name"
		 *      @option string "company"
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 *      @option int "correct" Number of contacts imported correctly
		 *      @option int "failed" Number of errors
		 */
		public Object import( String name, List<Dictionary<String, String>> contact) {
        	
			var data = new Dictionary<String, String>();
			data.Add("group_name",name);
			
			string json = JsonConvert.SerializeObject(contact);
			data.Add("contact",json);
			
	        return this.obj.call("contacts/import",data);
	    
	    }
	}
	
}

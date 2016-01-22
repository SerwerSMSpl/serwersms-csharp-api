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
	
	public class Groups
	{
		private SerwerSMS obj = null;
		
		public Groups( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Add new group
		 * 
		 * @param string name
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object add( String name ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("name",name);
			
	        return this.obj.call("groups/add",data);
	    
	    }
		/**
		 * List of group
		 * 
		 * @param string search Group name
		 * @param array params
		 *      @option int "page" The number of the displayed page
		 *      @option int "limit" Limit items are displayed on the single page
	     *      @option string "sort" Values: name
	     *      @option string "order" Values: asc|desc
		 * @return array
		 *      @option array "paging"
		 *          @option int "page" The number of current page
		 *          @option int "count" The number of all pages
		 *      @option array "items"
		 *          @option int "id"
		 *          @option string "name"
		 *          @option int "count" Number of contacts in the group
		 */
		public Object index( String search, Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("search",search);
				data = arr;
				
			}else{
				
				data.Add("search",search);
				
			}
	        return this.obj.call("groups/index",data);
	    
	    }
		/**
		 * View single group
		 * 
		 * @param int id
		 * @return array
		 *      @option int "id"
		 *      @option string "name"
		 *      @option int "count" Number of contacts in the group
		 */
		public Object view( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("groups/view",data);
	    
	    }
		/**
		 * Editing a group
		 * 
		 * @param int id
		 * @param string name
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object edit( String id, String name ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			data.Add("name",name);
			
	        return this.obj.call("groups/edit",data);
	    
	    }
		/**
		 * Deleting a group
		 * 
		 * @param int id
		 * @return array
		 *      @option bool "success"
		 */
		public Object delete( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("groups/delete",data);
	    
	    }
		/**
		 * Viewing a groups containing phone
		 * 
		 * @param string phone
		 * @return array
		 *      @option int "id"
		 *      @option int "group_id"
		 *      @option string "group_name"
		 */
		public Object check( String phone ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("phone",phone);
			
	        return this.obj.call("groups/check",data);
	    
	    }
	}
	
}

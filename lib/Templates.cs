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
	
	public class Templates
	{
		private SerwerSMS obj = null;
		
		public Templates( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Adding new template
		 * 
		 * @param string name
		 * @param string text
		 * @return array
		 *      @option array
		 *          @option bool "success"
		 *          @option int "id"
		 */
		public Object add( String name, String text ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("name",name);
			data.Add("text",text);
			
	        return this.obj.call("templates/add",data);
	    
	    }
		/**
		 * List of templates
		 * @param array params
	     *      @option string "sort" Values: name
	     *      @option string "order" Values: asc|desc
		 * @return array
		 *      @option array "items"
		 *          @option int "id"
		 *          @option string "name"
		 *          @option string "text"
		 */
		public Object index( Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				data = arr;
				
			}
	        return this.obj.call("templates/index",data);
	    
	    }
		/**
		 * Editing a template
		 * 
		 * @param int id
		 * @param string name
		 * @param string text
		 * @return array
		 *      @option bool "success"
		 *      @option int "id"
		 */
		public Object edit( String id, String name, String text ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			data.Add("name",name);
			data.Add("text",text);
			
	        return this.obj.call("templates/edit",data);
	    
	    }
		
		/**
		 * Deleting a template
		 * 
		 * @param int id
		 * @return array
		 *      @option bool "success"
		 */
		public Object delete( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("templates/delete",data);
	    
	    }
		
	}
	
}

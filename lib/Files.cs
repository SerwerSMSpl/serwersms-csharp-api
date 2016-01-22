/*
 * Created by SharpDevelop.
 * User: Przemek
 * Date: 18.01.2016
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using serwersms;

namespace serwersms.lib
{

	public class Files
	{
		private SerwerSMS obj = null;
		
		public Files(SerwerSMS obj){
		
			this.obj = obj;
		}
		
		/**
		 * Add new file
		 * 
		 * @param String type - mms|voice
		 * @param array params
		 *      @option String "url" URL address to file
		 * @return array
		 *      @option Boolean "success"
		 *      @option String "id"
		 */
		public Object add( String type, Dictionary<String, String> data = null ) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("type",type);
				data = arr;
				
			}else{
				
				data.Add("type",type);

			}
	        return this.obj.call("files/add",data);
	        
	    }
		/**
		 * List of files
		 * 
		 * @param String type - mms|voice
		 * @return array
		 *      @option array "items"
		 *          @option String "id"
		 *          @option String "name"
		 *          @option int "size"
		 *          @option String "type" - mms|voice
		 *          @option String "date"
		 */
		public Object index( String type ) {
        	
			var data = new Dictionary<String, String>();
			data.Add("type",type);
			
	        return this.obj.call("files/index",data);
	    
	    }
		/**
		 * View file
		 * 
		 * @param String id
		 * @param String type - mms|voice
		 * @return array
		 *      @option String "id"
		 *      @option String "name"
		 *      @option int "size"
		 *      @option String "type" - mms|voice
		 *      @option String "date"
		 */
		public Object view( String id, String type ) {
        	
			var data = new Dictionary<String, String>();
			data.Add("type",type);
			data.Add("id",id);
	        return this.obj.call("files/view",data);
	    
	    }
		/**
		 * Deleting a file
		 * 
		 * @param String $id
		 * @param String $type - mms|voice
		 * @return array
		 *      @option Boolean "success"
		 */
		public Object delete( String id, String type ) {
        	
			var data = new Dictionary<String, String>();
			data.Add("type",type);
			data.Add("id",id);
	        return this.obj.call("files/delete",data);
	    
	    }
	}
}

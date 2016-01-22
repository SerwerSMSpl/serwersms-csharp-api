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
	
	public class Premium
	{
		private SerwerSMS obj = null;
		
		public Premium( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * List of received SMS Premium
		 * 
		 * @return array
		 *      @option array "items"
		 *          @option int "id"
		 *          @option string "to_number" Premium number
		 *          @option string "from_number" Sender phone number
		 *          @option string "date"
		 *          @option int "limit" Limitation the number of responses
		 *          @option string "text" Message
		 */
		public Object index() {
	        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("premium/index",data);
	    
	    }
		/**
		 * Sending replies for received SMS Premium
		 * 
		 * @param string $phone
		 * @param string $text Message
		 * @param string $gate Premium number
		 * @param int $id ID received SMS Premium
		 * @return array
		 *      @option bool "success"
		 */
		public Object send( String phone, String text, String gate, String id ) {
        	
			var data = new Dictionary<String, String>();
			data.Add("phone",phone);
			data.Add("text",text);
			data.Add("gate",gate);
			data.Add("id",id);
			
	        return this.obj.call("premium/send",data);
	    
	    }
		/**
		 * View quiz results
		 * 
		 * @param int $id
		 * @return array
		 *      @option int "id"
		 *      @option string "name"
		 *      @option array "items"
		 *          @option int "id"
		 *          @option int "count" Number of response
		 */
		public Object quiz( String id ) {
	        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);
			
	        return this.obj.call("quiz/view",data);
	    
	    }
		
	}
	
}

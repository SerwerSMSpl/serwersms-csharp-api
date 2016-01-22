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
	
	public class Stats
	{
		private SerwerSMS obj = null;
		
		public Stats( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * Statistics an sending
		 * 
		 * @param array params
		 *      @option String "type" eco|full|voice|mms
		 *      @option String "begin" Start date
		 *      @option String "end" End date
		 * @return array
		 *      @option array "items"
		 *          @option int "id"
		 *          @option String "name"
		 *          @option int "delivered"
		 *          @option int "pending"
		 *          @option int "undelivered"
		 *          @option int "unsent"
		 *          @option String "begin"
		 *          @option String "end"
		 *          @option String "text"
		 *          @option String "type" eco|full|voice|mms
		 */
		public Object index( Dictionary<String, String> data = null ) {
	        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				data = arr;
			
			}
	        return this.obj.call("stats/index",data);
	    
	    }
		
	}
	
}
